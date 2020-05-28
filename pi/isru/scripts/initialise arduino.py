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

    # Send hello! to initiate connection (try 5 times)
    i = 0
    while i < 5 and not arduino_ok:
        msg = 'hello!'
        my_serial.write(msg.encode('utf-8'))
        while my_serial.inWaiting():
            # Read back from Serial to look for the !
            x = my_serial.read().decode("utf-8") # decode needed for Python3
            if x != '!':
                data += x
            else:
                print(data)
                data = ""
                arduino_ok = True
        i += 1
        time.sleep(0.2)

arduino_thread = threading.Thread(target=init_arduino)

arduino_thread.start()

# do everything else we need to do to initialise

# wait until these have finished before we are 'ready'
arduino_thread.join()

time.sleep(0.5)

if arduino_ok:
    print("Connection to arduino established :)");


else:
    print("Unable to connect to arduino :(")

# mission GO
