import sys
import queue
import logging
import threading

from Writer import Writer
from Listener import Listener


class ISRUAdapter():

    def __init__(self):
        self.recievedQueue = queue.Queue()
        self.broadcastQueue = queue.Queue()
        self.logger = self.create_logger()

        self.listener = self.start_listener()
        self.writer = self.start_writer()

        self.start_router()


    def create_logger(self):
        '''
        Creates and configures a logger object instance
        for writing formatted log messages to the
        standard output stream.
        '''
        # Create logger object instance
        logger = logging.getLogger('ISRU.adapter')
        logger.setLevel(logging.INFO)
        
        # Configure logger output for standard output stream
        handler = logging.StreamHandler(sys.stdout)
        handler.setLevel(logging.INFO)
        formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')
        handler.setFormatter(formatter)
        logger.addHandler(handler)

        return logger


    def start_listener(self):
        '''
        Creates a new thread listening for an upstream 
        connection from the ground station.
        '''
        listenerThread = Listener(self.recievedQueue)
        listenerThread.setName('ISRU Listener')
        listenerThread.start()

        return listenerThread


    def start_writer(self):
        '''
        Creates a new thread responsible for creating a 
        downstream connection to the ground station.
        '''
        writerThread = Writer('127.0.0.1', 9000, self.broadcastQueue)
        writerThread.setName('ISRU Writer')
        writerThread.start()

        return writerThread


    def send_transmission(self, transmission):
        '''
        Appends the provided transmission to the broadcast queue, this should 
        reflect the following JSON format for a transmission:
        {
            id: <transmission ID>,
            payload: {
                <transmission payload contents>
                ...
            }
        }
        :param transmission: Transmission object to broadcast to ground station
        '''
        isValid = self.validate_transmission(transmission)
        if isValid: self.broadcastQueue.put(transmission)
        else: raise Exception("Transmission failed validation, check format is correct.")


    def validate_transmission(self, transmission):
        '''
        Checks a given transmssion conforms to the defined transmission format.
        :param transmission: the transmission instance to validate
        :returns True for valid format.
        '''
        if (
            type(transmission) is not dict or
            'id' not in transmission.keys() or 
            'payload' not in transmission.keys()
            ):
            return False
        
        return True


    def start_router(self):
        '''
        Starts run-loop which checks for new transmissions recieved from 
        the ground station, routes transmissions to the relevant 
        destination.
        '''
        try:
            while True:
                if not self.recievedQueue.empty():
                    transmission = self.recievedQueue.get()
                    # TODO: apply routing rules for transmission

        except KeyboardInterrupt:
            self.logger.info("Recieved close signal, shutting down adapter...")

        except Exception as ex:
            self.logger.error("An unexpected error occured during execution: {0}".format(str(ex)))
            traceback.print_exc()

        finally:
            # Stop listener thread
            self.listener.stop()
            self.listener.join()
            # Stop writer thread
            self.writer.stop()
            self.writer.join()


if __name__ == "__main__":
    adapter = ISRUAdapter()