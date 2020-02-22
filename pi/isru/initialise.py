import serial
import time
import threading
import socket
import sys

# Initialise Arduino Comms
arduino_ok = False
data = ""

def init_arduino():
    global arduino_ok
    global data
    my_serial = serial.Serial('/dev/ttyACM0', timeout=1)
    my_serial.baudrate = 115200

    time.sleep(1)

    prev_data = ""

    # Send hello! to initiate connection (try 5 times)
    i = 0
    while i < 5:
        if not arduino_ok:
            msg = 'hello!'
            my_serial.write(msg.encode('utf-8'))
        i += 1
        time.sleep(0.5)

    # Read back from Serial to look for the !
    while my_serial.inWaiting():
        x = my_serial.read().decode("utf-8") # decode needed for Python3
        if x != '!':
            data += x
        else:
            print(data)
            data = ""
            arduino_ok = True

# Init ISRU as server - listen to port 8000
def init_socket():
    my_ssocket = socket.socket()
    port = 8000
    my_ssocket.bind(('', port)) #pass ip address into empty string when we've confirmed rover/gs
    my_ssocket.listen(3) 

    while True: 
        client, address = my_ssocket.accept()
        client.send('hi!')
        client.close() 

arduino_thread = threading.Thread(target=init_arduino)
socket_thread = threading.Thread(target=init_socket)

arduino_thread.start()
socket_thread.start()

# do everything else we need to do to initialise

# wait until these have finished before we are 'ready'
arduino_thread.join()
socket_thread.join()

# mission GO
