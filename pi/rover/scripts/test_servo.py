import redboard
import time

while True:
    redboard.servo22(0)
    time.sleep(1)

    redboard.servo22(90)
    time.sleep(1)

    redboard.servo22(0)
    time.sleep(1)

    redboard.servo22(-90)
    time.sleep(1)




