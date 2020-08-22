import serial
import time
import threading
import socket
import sys

# Initialise Arduino Comms
arduino_ok = False
data = ""
my_serial = serial.Serial('/dev/ttyACM0', timeout=1)

def main():
    global my_serial
    arduino_thread = threading.Thread(target=init_arduino)
    arduino_thread.start()

    # do everything else we need to do to initialise...
    # wait until these have finished before we are 'ready'
    arduino_thread.join()

    time.sleep(0.5)

    if not arduino_ok:
        print("Unable to connect to arduino :(")

    else:
        print("Connection to arduino established :)");
        while True:
            command = input("Please enter a command number:")
            command += ";"
            print(command)
            my_serial.write(command.encode('utf-8'))

    # mission GO

def init_arduino():
    global arduino_ok
    global data
    global my_serial
    
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

if __name__ == "__main__":
    main()
