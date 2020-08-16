# electra_ISRU
The F.O.R.G.E. (Future-mission Oxygen Resource Generation Equipment) is an In-Situ Resource Utilisation unit intended to deploy a [G.I.M.L.I. (Gathering Instrument for Martian and Lunar Ice) rover](https://github.com/GeorgieChallis/electra_Rover) from a lander, accept unfiltered ice deposits and process them into oxygen for use in further planetary missions. 

## System Overview
Primary ISRU control is achieved via Raspberry Pi 4. This receives commands over WiFi and either sends simple command number (#0 - 32) to an Arduino for analogue sensor/actuator instrumentation or act as relay to pass messages to the exploring rover.

### Arduino
[Install Instructions](https://github.com/GeorgieChallis/electra_ISRU/blob/master/arduino/README.md)

`Arduino_Overview.ino`: `Setup` initialises comms by echoing "hello!" over Serial port. Once connection has been established, wait for a command number and execute in `loop`. Interrupt function connected to a push button acts a an emergency stop to halt dangerous functions like melting and electrolysis until manually re-started.

### Raspberry Pi
[Install Instructions](https://github.com/GeorgieChallis/electra_ISRU/blob/master/pi/README.md)


