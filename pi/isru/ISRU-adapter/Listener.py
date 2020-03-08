import sys
import ssl
import time
import json
import queue
import socket
import logging
import threading


class Listener(threading.Thread):

    def __init__(self, recievedQueue, port=9001):
        super(Listener, self).__init__()
        self.stopThread = False

        self.host = '127.0.0.1'
        self.port = port
        self.recievedQueue = recievedQueue
        self.logger = self.create_logger()

        self.server = None
        self.connection = None
        self.listening = None


    def create_logger(self):
        '''
        Creates and configures a logger object instance
        for writing formatted log messages to the
        standard output stream.
        '''
        # Create logger object instance
        logger = logging.getLogger('ISRU.adapter.listener')
        logger.setLevel(logging.INFO)
        
        # Configure logger output for standard output stream
        handler = logging.StreamHandler(sys.stdout)
        handler.setLevel(logging.INFO)
        formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
        handler.setFormatter(formatter)
        logger.addHandler(handler)

        return logger


    def create_connection(self):
        '''
        Create a socket server which enables
        an upstream connection from the
        Ground Station to the ISRU.
        '''
        # Create socket for connection
        serverSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        serverSocket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)
        serverSocket.bind( (self.host, self.port) )

        # Expected number of connections is one (the ground station), 
        # therefore limit the number of connections to prevent
        # alternate clients connecting. 
        serverSocket.listen(1)

        self.server = serverSocket


    def accept_connections(self):
        '''
        Listens for incomming connections to establish
        uplink from the client. Wraps the socket with
        SSL/TLS properties and authenticates the connections
        certificate against trusted sources.
        '''
        while(self.connection is None):
            connectionSocket = None
            try:
                # Listen for connections and accept. Blocks until connection.
                connectionSocket, fromaddr = self.server.accept()

                # Transforms generic socket into SSL compatible socket,
                # sets trusted certificates to authenticate connection
                sslSocket = ssl.wrap_socket(
                    connectionSocket, 
                    server_side=True,
                    ssl_version=ssl.PROTOCOL_TLSv1_2,
                    cert_reqs=ssl.CERT_REQUIRED,
                    ca_certs="./certs/authority/ca.crt", 
                    certfile="./certs/ISRU/electra.ISRU.crt", 
                    keyfile="./certs/ISRU/electra.ISRU.key"
                )

                # Get connecting clients certificate
                cert = sslSocket.getpeercert()        

                # Validate against trusted sources
                if not cert not in cert['subject'][3]: 
                    raise Exception("Invalid Certificate: the connections certificate is not trusted.")

                self.connection = sslSocket
                self.logger.info("Accepted connection from: {0}".format(sslSocket.getpeername()))

            except ssl.SSLError as sslEx:
                self.logger.error("Failed to accept incomming connection: an SSL error occured: {0}".format(str(sslEx)))
                if connectionSocket is not None: connectionSocket.close()
                self.connection = None

            except Exception as ex:
                self.logger.error("Unhandled exception occured: {0}".format(str(ex)))


    def read_from_connection(self):
        '''
        Listens for incomming messages from the connected
        client, upon recieval, appends the message to the
        recieved queue for further usage outside the 
        server.
        '''
        transmission = self.connection.read(4096).decode("utf-8")
        self.recievedQueue.put(json.loads(transmission))
        self.connection.sendall(str.encode('recieved\n'))


    def run(self):
        # Create the socket with the server role
        self.create_connection()
        self.listening = True
        self.logger.info("Listening for connections on {0}:{1}...".format(self.host, self.port))

        while self.listening and not self.stopThread:
            # Listen for incomming connections 
            self.accept_connections()

            # Listen for incomming requests/responses
            self.read_from_connection()

        self.connection.close()
        self.server.close()

    
    def stop(self):
        '''
        Causes the thread to complete execution and stop.
        '''
        self.stopThread = True


# Test harness
if __name__ == "__main__":
    recievedQueue = queue.Queue()
    listenerThread = Listener(recievedQueue)
    listenerThread.setName('ISRU Listener')
    listenerThread.start()

    time.sleep(1)

    while(True):
        if not recievedQueue.empty():
            print(json.dumps(recievedQueue.get()))
    