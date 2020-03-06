import queue
import logging
import threading


class ISRUAdapter():

    def __init__(self):
        self.recievedQueue = queue.Queue()
        self.broadcastQueue = queue.Queue()

        self.start_listener()
        self.start_writer()


    def start_listener(self):
        pass


    def start_writer(self):
        pass