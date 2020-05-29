#Arduino Usage

## Build Instructions
The arduino setup is simple - open the sketch `Arduino_Overview.ino` in the [Arduino IDE](https://www.arduino.cc/en/main/software), connect your device up via USB and hit the Upload arrow (remember to select the correct port first).
We used the Arduino Mega 2560 to maximise the number of pins, but other models should work fine too.

## Operation 
* `Setup` function initialises comms by echoing "hello!" over Serial port. 
* Once connection has been established, wait for a command number and execute in `loop`. 
* Additional `eStop_ISR` interrupt function connected to a push button acts a an emergency stop to halt dangerous functions (like melting and electrolysis) until manually re-started.

<p align="center">
  <img src="https://github.com/GeorgieChallis/electra_ISRU/blob/dev-gc/arduino/Flow.jpg" width="420"/>
</p>
