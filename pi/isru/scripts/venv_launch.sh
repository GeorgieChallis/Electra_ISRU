#!/bin/bash

#Launch virtual environment with Python3/OpenCV 4
source virtualenvwrapper.sh
workon gimli

python3 initialise_arduino.py
