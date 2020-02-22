import serial
import time
import threading

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

    i = 0

    # Send hello! to initiate connection (try 5 times)
    while i < 5:
        if not arduino_ok:
            msg = 'hello!'
            my_serial.write(msg.encode('utf-8'))
        i += 1

    # Read back from Serial to look for the !
    while my_serial.inWaiting():
        x = my_serial.read().decode("utf-8") # decode needed for Python3
        if x != '!':
            data += x
        else:
            print(data)
            data = ""
            arduino_ok = True

arduino_thread = threading.Thread(target=init_arduino)

arduino_thread.start()

# do everything else we need to do to initialise


arduino_thread.join()
