# electra_ISRU
Repository for configuration and code related to control of the In-Situ Resource Utilisation hardware (Raspberry Pi)

## Architecture
ISRU is controlled primarily with RPi 4. Receives commands and sends simple instruction label (#0 - 32) to an Arduino.

### Pi
* Camera streaming (OpenCV)
* Communications adapter
* ...

### Arduino
* Single Sketch - initialise comms by echoing "hello!" then runs on loops to populate a command string over Serial.
