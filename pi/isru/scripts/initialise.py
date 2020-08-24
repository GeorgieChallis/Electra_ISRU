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
    HOST ="192.168.43.50"
    PORT = 9000
    s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    print ('Socket created')

    s.bind((HOST, PORT))

    s.listen(5)
    print ('Socket awaiting messages')
    (conn, addr) = s.accept()
    print ('Connected')

    # awaiting for message
    while True:
        data = conn.recv(1024)
        print ('Following received: ' + data.decode('utf-8'))
        reply = ''
        data.decode('utf-8')
        # process your message
        if data == 'Test':
            reply = 'Test Succesful!'
        elif data == 'command01':
            reply = 'Executing Command'
        elif data == 'Terminate':
            conn.send('Terminating')
            break
        else:
            reply = 'Unknown command'

        # Sending reply
        conn.send(reply.encode('utf-8'))
    conn.close()

arduino_thread = threading.Thread(target=init_arduino)
#socket_thread = threading.Thread(target=init_socket)

arduino_thread.start()
#socket_thread.start()

# do everything else we need to do to initialise

# wait until these have finished before we are 'ready'
arduino_thread.join()
socket_thread.join()

# mission GO
