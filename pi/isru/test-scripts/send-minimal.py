from socket import (socket, AF_INET, SOCK_DGRAM, SOL_SOCKET, SO_REUSEADDR)
import socket
from time import sleep


my_IP_address="192.168.1.70"			
destination_IP_address="192.168.1.71"	
port_number=9000

#Open up network socket
Net_sock=socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
Net_sock.setsockopt(SOL_SOCKET, SO_REUSEADDR, 1)		#Allow reuse of addresses
Net_sock.setblocking(0)									#non blocking mode
Net_sock.bind((my_IP_address, port_number))				#bind for listening

while True:

	message="hi!"
	Net_sock.sendto(message, (destination_IP_address, port_number))

	sleep(1)	#sleep every 1 second.
	
	try:
		frame_received, addr=Net_sock.recvfrom(256)
	except socket.error:
		pass
	else:
		requestor_IP=str(addr)
		requestor_IP=requestor_IP[2:17].partition("'")[0]
		print("\nReceived message: <%s> over network from %s" %(frame_received, requestor_IP))
