import sys
import ssl
import time
import queue
import socket
import threading


class Writer(threading.Thread):

    def __init__(self, host, port, broadcastQueue):
        self.host = host
        self.port = port
        self.socket = None
        self.broadcastQueue = broadcastQueue
        self.connection_alive = False


    def create_connection(self):
        '''
        Creates a secure connection to the ground station
        using SSL with the accepted certificates.
        '''
        try:
            # Create socket for connection
            s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
            s.setsockopt(socket.SOL_SOCKET, socket.SO_REUSEADDR, 1)

            # Transforms generic socket into SSL compatible socket,
            # loads certificates recognised by server enabling connection
            sslSocket = ssl.wrap_socket(s, 
                ssl_version=ssl.PROTOCOL_TLSv1_2,
                cert_reqs=ssl.CERT_REQUIRED,
                ca_certs="./certs/authority/ca.crt", 
                certfile="./certs/ISRU/electra.ISRU.crt", 
                keyfile="./certs/ISRU/electra.ISRU.key"
            )

            # Connect to server using argument address port pair
            sslSocket.setblocking(1);
            sslSocket.connect((self.host, self.port))

            self.connection_alive = True
            self.socket = sslSocket

        except ConnectionRefusedError:
            print("Failed to establish upstream connetion, connection refused".format(host,port))
            if sslSocket is not None:
                sslSocket.close()
                sys.exit()
    

    def run(self):
        '''
        Starts the event loop for the ISRUWriter.
        Each iteration of the loop checks the 
        broadcast queue for new transmissions to 
        send to the ground station.
        '''
        # Create socket connection
        self.create_connection()

        # Run loop
        while(self.connection_alive):
            
            retryCount = 0
            while not self.broadcastQueue.empty():
                transmission = self.broadcastQueue.queue[0]
    
                # TODO: transmission validation

                try:
                    print("sending transmission: " + transmission)
                    self.socket.send(str.encode(transmission + '\n'))
                    self.broadcastQueue.get()
                    retryCount = 0

                except ConnectionResetError:
                    print("Failed to send message to {0}:{1}, retrying...".format(host, port))
                    retryCount += 1
        
        ssl_socket.close()


# Test harness
if __name__ == "__main__":
    broadcastQueue = queue.Queue()
    client = Writer('127.0.0.1', 9001, broadcastQueue)
    broadcastQueue.put("Testing broadcast ability")
    client.run()