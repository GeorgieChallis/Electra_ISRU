### Operating System
G.I.ML.I. runs on Raspbian Buster (32-Bit) Lite v4.19: [Download Raspberry Pi OS](https://www.raspberrypi.org/downloads/raspbian/)

### 1. Initial Setup
Follow the standard procedure for [headless Pi setup](https://desertbot.io/blog/headless-raspberry-pi-4-ssh-wifi-setup), ensuring that you:
* Enable SSH by adding the `ssh` file to the boot partition of the card
* Add wireless network SSID and passkey information to `wpa_supplicant.conf`
* (_Optional_) Set a static IP address on your subnet
* (_Recommended_)Expand the filesystem using `$ raspi-config`
* (_Recommended_) Change the hostname and password

### 2. Install Dependencies
First up, run update and upgrade:
```
$ sudo apt-get update && sudo apt-get upgrade -y
```
#### OpenCV
Then, install the necessary pre-requisties for OpenCV (to use the camera for object tracking).
*Note:* If you want to use virtual environments, read [over here](https://www.pyimagesearch.com/2018/09/19/pip-install-opencv/) first!
```
$ sudo apt-get install libhdf5-dev libhdf5-serial-dev libhdf5-100
$ sudo apt-get install libqtgui4 libqtwebkit4 libqt4-test python3-pyqt5
$ sudo apt-get install libatlas-base-dev
$ sudo apt-get install libjasper-dev
```
Install pip (if not already):
```
$ wget https://bootstrap.pypa.io/get-pip.py
$ sudo python3 get-pip.py
```
Then V4.1.0.25 of OpenCV (remove `-headless` if you are using Pi with Desktop and want a GUI:
```
$ sudo pip install opencv-contrib-python-headless==4.1.0.25
```
