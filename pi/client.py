import socket
HOST = "192.168.43.50"
PORT = 9000
s = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
s.connect((HOST,PORT))

while True:
    command = input ("enter command: ")
    s.send(str(command).encode('utf-8'))
s.close()
exit()