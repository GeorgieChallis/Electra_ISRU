// This enumerator lists the commands to control the Arduino functions. 
// To call a function, the command number is sent via Serial, terminated with a ';'

enum Command
{
    ERROR = 0,
    STATUS = 1,
    ALL_DATA = 2,
    SW_MAGNET = 3,
    SW_HEATER = 4,
    SW_ELECTRO = 5,
    SW_RED = 6,
    SW_YELLOW = 7,
    SW_GREEN = 8,
    RD_MAGNET = 9,
    RD_HEATER = 10,
    RD_ELECTRO = 11,
    RD_TEMP_1 = 12,
    RD_TEMP_2 = 13,
    RD_LIGHT = 21,
    RD_RED = 28,
    RD_YELLOW = 29,
    RD_GREEN = 30,
    ESTOP = 22
    //Other commands not yet implemented in hardware
}