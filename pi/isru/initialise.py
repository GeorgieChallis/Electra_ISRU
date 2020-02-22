import serial
import time

connectionOK = False

mySerial = serial.Serial('/dev/ttyACM0', timeout = 1)
mySerial.baudrate = 115200

time.sleep(1)

data = ""
prevData = ""

i = 0

#Send hello to initiate connection (try 5 times)
while i < 5:
    msg =  'hello!'
    #print(msg.encode('utf-8'))
    mySerial.write(msg.encode('utf-8'))
    i +=  1

while mySerial.inWaiting():
    x = mySerial.read().decode("utf-8") # decode needed for Python3
    if x != '!':
        data += x
    else:
        print(data)


mySerial.close()