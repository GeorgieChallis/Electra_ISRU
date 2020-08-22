# 17/08/2020: Confirmed serial comms OK, sending command OK, receiving data OK
#             Next step: read out data from multiple command calls

"""Pi->Arduino Commands Test"""

import serial
import time
import sys

# Initialise Arduino Comms
port_name = '/dev/ttyACM0'
baud_rate = 115200
try:
    my_serial = serial.Serial(port_name, timeout=1)
except:
    print('Serial connection failed. Is it plugged in?');

arduino_ok = False
data = ''

def main():    
    ready = init_arduino()
    if ready:
        print('Serial port connection established.')
        #Send command
        request =  1
        while(True):
            send_command(request)
            request += 1
            time.sleep(2)
    else:
        print('Error - Serial connection failed.')


    my_serial.close()

def init_arduino():
    global arduino_ok
    global data
    my_serial.baudrate = baud_rate

    time.sleep(1)

    # Send ! to initiate connection (try 5 times)
    i = 0
    while i < 5:
        if not arduino_ok:
            msg = '!'
            my_serial.write(msg.encode('utf-8'))
        i += 1
        time.sleep(0.5)

    # Read back from Serial to look for the !
    while my_serial.inWaiting():
        incoming = my_serial.read().decode('utf-8') # decode needed for Python3
        if incoming != '!':
            data += incoming
        else:
            data += incoming
            print(data)
            data = ''
            arduino_ok = True

    return arduino_ok

def send_command(command):
    outgoing = str(command) + ';'
    my_serial.write(outgoing.encode('utf-8'))
    receive_data()

def receive_data():
    newCommand = False
    global data

    data = ''
        
    while my_serial.inWaiting():
        endCommand = False

        while not endCommand:
            incoming = my_serial.read()# decode needed for Python3
            if incoming.decode('utf-8')  == '{':
                commandID = my_serial.read().decode('utf-8')
                separator = my_serial.read().decode('utf-8')
                if separator != ':': return
                newCommand = True

            elif incoming.decode('utf-8')  == '}':
                newCommand = False
                endCommand = True
                print(data)

            elif newCommand == True:
                data += incoming.decode('utf-8') 

                

if __name__ == "__main__":
    main()