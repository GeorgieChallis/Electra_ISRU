# electra_ISRU
The F.O.R.G.E. is an In-Situ Resource Utilisation unit intended to deploy a [G.I.M.L.I. rover](https://github.com/GeorgieChallis/electra_Rover) from a lander, accept unfiltered ice deposits and process them into hydrogen and oxygen for use in further missions. 

## System Overview
Primary ISRU control via Raspberry Pi 4. Receives commands and sends simple command number (#0 - 32) to an Arduino to integrate with analogue sensors.

### Arduino
`/arduino/Arduino_Overview/Arduino_Overview.ino` - `Setup` function initialises comms by echoing "hello!" over Serial port. Once connection has been established, wait for a command number and execute in `loop`. 

Single interrupt function connected to a push button acts a an emergency stop to halt dangerous functions like melting and electrolysis until manually re-started.

<img src="https://github.com/GeorgieChallis/electra_ISRU/blob/dev-gc/arduino/Flow.jpg" width="320">

### Pi



