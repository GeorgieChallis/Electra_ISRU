import socket

HOST ="192.168.43.50"
PORT = 12222
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
