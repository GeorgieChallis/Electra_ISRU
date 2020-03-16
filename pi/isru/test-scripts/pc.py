import socket

HOST = "192.168.43.50"
PORT = 9000
s = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
s.connect((HOST,PORT))

while True:
	command = input("Enter Command: ")
	s.send(str(command).encode('utf-8'))
	reply = s.recv(1024).decode('utf-8')
	if reply == 'Terminating':
		break
	print (reply)
s.close()
exit()
