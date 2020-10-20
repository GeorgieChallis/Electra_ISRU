import redboard

stop = False

def __init__(self):
    redboard.M1(0)
    redboard.M2(0)

def move_forward():
    """Move the rover forwards at full speed"""
    while stop != True: #don't forget to implement a stop!
        redboard.M1(-100)
        redboard.M2(100)

def move_backwards():
    """Move the rover in reverse at full speed"""
    while stop != True:
        redboard.M1(100)
        redboard.M2(-100)
        
def move_left():
    while stop != True:
        redboard.M1(-100)
        redboard.M2(-100)

def move_right():
    while stop != True:
        redboard.M1(100)
        redboard.M2(100)

def stop_moving():
    if not stop:
        stop = True
        redboard.M1(0)
        redboard.M2(0)

def rotate_servo(pin, angle): 
    """Rotate servo to a set angle (or actuator to a set extension)"""
    if pin == 20 and angle >= -90 and angle <= 90 : #if actuator, limit between +-45
        redboard.servo20(angle)
    #... 

def servo_off(pin):
    if pin == 20:
        redboard.servo20_off()
    #...






    

