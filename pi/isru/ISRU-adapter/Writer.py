import sys
import ssl
import time
import json
import queue
import select
import socket
import logging
import traceback
import threading


class Writer(threading.Thread):

    def __init__(self, host, port, broadcastQueue):
        super(Writer, self).__init__()
        self.stopThread = False

        self.host = host
        self.port = port
        self.broadcastQueue = broadcastQueue
        self.logger = self.create_logger()

        self.connection_alive = False
        self.connection = None


    def create_logger(self):
        '''
        Creates and configures a logger object instance
        for writing formatted log messages to the
        standard output stream.
        '''
        # Create logger object instance
        logger = logging.getLogger('ISRU.adapter.writer')
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
        Creates a secure connection to the ground station
        using SSL with the accepted certificates.
        '''
        # Create socket for connection
        connectionSocket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
        connectionSocket.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

        # Transforms generic socket into SSL compatible socket,
        # loads certificates recognised by server enabling connection
        sslSocket = ssl.wrap_socket(connectionSocket, 
            ssl_version=ssl.PROTOCOL_TLSv1_2,
            cert_reqs=ssl.CERT_REQUIRED,
            ca_certs="./certs/authority/ca.crt", 
            certfile="./certs/ISRU/electra.ISRU.crt", 
            keyfile="./certs/ISRU/electra.ISRU.key"
        )

        # Connect to server using argument address port pair
        sslSocket.setblocking(1);
        
        # Attempts to establish connection with sever,
        # if connection fails, tries again in 5 seconds
        while not self.connection_alive:
            try:
                self.logger.info("Attempting to connect to {0}:{1}...".format(self.host, self.port))
                sslSocket.connect((self.host, self.port))
                self.logger.info("Connection established with {0}:{1}.".format(self.host, self.port))
                self.connection_alive = True
                self.connection = sslSocket

            except ConnectionRefusedError:
                self.logger.error(
                    "Failed to establish connetion with {0}:{1}, will try again in 5 seconds..."
                    .format(self.host, self.port)
                )
                time.sleep(5);
    

    def send_transmissions(self):
        '''
        Checks the broadcast queue for new messages to transmit
        to the server, attempts to send any messages queued.
        '''
        while not self.broadcastQueue.empty():
            transmission = self.broadcastQueue.get()
            retryCount = 0

            # Tries to send the transmission three times before failing
            while retryCount < 3:
                try:
                    self.logger.info("Sending transmission: " + transmission['id'])

                    # Convert JSON to string
                    transmissionStr = json.dumps(transmission)
                    # Convert string to bytes, append \n ternination character
                    transmissionBytes = str.encode(transmissionStr + '\n')
                    # Send transmission to server
                    self.connection.sendall(transmissionBytes)  
                    
                    # Check for response, timeout set to 5 seconds
                    self.connection.setblocking(0)
                    ready = select.select([self.connection], [], [], 5)
                    if ready[0]:
                        response = self.connection.read(2048)
                        if response != str.encode('recieved\n'):
                            raise Exception('Unexpected response back from server: {0}'.format(response))

                    self.connection.setblocking(1)
                    break

                except Exception as ex:
                    retryCount += 1
                    self.logger.warning(
                        "Issue sending transmission {0}: {1}... attempt {2}"
                        .format(transmission['id'], str(ex), str(retryCount+1))
                    )
                    
            if retryCount >= 3:
                self.logger.error("Failed to send transmission, maximum attempts exceeded.")


    def run(self):
        '''
        Starts the event loop for the ISRUWriter.
        Each iteration of the loop checks the 
        broadcast queue for new transmissions to 
        send to the ground station.
        '''
        try:
            # Create socket connection
            self.create_connection()

            # Run loop
            while(self.connection_alive):
                self.send_transmissions()

        except Exception as ex:
            self.logger.error("An unexpected error occured during execution: {0}".format(str(ex)))
            traceback.print_exc()

        except KeyboardInterrupt:
            self.logger.info("Recieved close signal, closing down...")

        finally:
            if self.connection is not None:
                self.connection.close()


    def stop(self):
        '''
        Causes the thread to complete execution and stop.
        '''
        self.stopThread = True


# Test harness
if __name__ == "__main__":
    broadcastQueue = queue.Queue()
    writerThread = Writer('127.0.0.1', 9000, broadcastQueue)
    writerThread.setName('ISRU Writer')
    writerThread.start()

    time.sleep(1)

    broadcastQueue.put({
        'id': 'test_message',
        'payload': {
            'message': 'testing the writer'
        }
    })
    