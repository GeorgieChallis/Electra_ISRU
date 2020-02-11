//Basic program flow for ISRU control (Arduino)

// Updated: 10/02/2020, 16:11, GC


// To Do:
// 1. CHECK PIN CAPABILITES!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!*****
// 2. Write all the functions.....
//
//




//-------------------------------------------------------------


//Pin allocations 
RED = 5;
ORANGE = 6;
GREEN = 7;

MAGNET = 8;
HEATER = 9;
ELECTRO = 10;

CAM_SERVO = 15;

H2 = 11;
FLOW = 12;
BATT_CURRENT = 13;
BATT_VOLTAGE = 14;
BUS_VOLTAGE = 16;
ELECTRO_CURRENT = 17;
SOLAR_CURRENT = 18;

//Motor speeds for PWM (Cam Servo Only on ISRU)
// CHECK THESE THROUGH TESTING!!!!!!!!!!!!!!!!!!!!!!
OFF = 0;
LOW = 50;
HALF = 127;
HIGH = 200;
MAX = 255;


//Global Variables
const byte numChars = 64; //Start with a string buffer with 64 empty chars
char incomingString[numChars]; 
boolean newData = false;
char command;

static boolean magnetOn = true;
static boolean heaterOn= false;
static bool electroOn = false;

enum missionStatus { idle, initialising, exploring, excavating, returning, melting, electrolysis, error};
missionStatus status = missionStatus.idle;

// Temperature probes
double reactionTemp;
double heaterTemp;

// Voltage/ current monitoring
double batteryCurrent;
double batteryVoltage;
double busVoltage;

double electroCurrent;
double solarCurrent;

// Gas monitoring
double hydrogenPPM;
double gasFlow;

//camera servo
double servoRotation;

//Set up is called once on start-up
void Setup(){
	
	status = missionStatus.initialising;
	
	//Initialise Pins
	pinMode(RED, OUTPUT);
	pinMode(ORANGE, OUTPUT);
	pinMode(GREEN, OUTPUT);
	
	pinMode(MAGNET, OUTPUT);
	pinMode(HEATER, OUTPUT);
	pinMode(ELECTRO, OUTPUT);
	
	pinMode(CAM_SERVO, OUTPUT);
	
	pinMode(H2, INPUT);
	pinMode(FLOW, INPUT);
	
	
	//Red LED ON indicates power is present
	digitalWrite(RED, HIGH);
	
	//Attempt communication with Pin
	int baudRate = 115200;
	Serial.begin(baudRate); //Start Serial comms
		
	//If comms is good
		// Switch LED ON
		
	//If comms is not good
		// If this is attempt 1 or 2
			// Try to connect again
		//Return an error to the user, blink LED
			
		
	// Get initial values from all sensors
	

}

//Loop operates continuously when the program runs
void loop(){
	UpdateValues();
	//Receive Data
	command = recvCommands();
	//Act on Request
	sendReply(command);
	//Send full packet of info based on state
	sendAllData();
}

void UpdateValues(){
	//Get ALL currently required values from sensors being used
	
	getBatteryCurrent(); //Always Needed
	getBatteryVoltage(); //Always Needed
	getBusVoltage(); //Always Needed
	
	if (status > 3) {
			getMeltingTemp();  //Needed for melting, electrolysis
	}
	else if (status > 4){
		getReactionTemp(); //Needed for electrolysis
		getHydrogenPPM(); //Needed for electrolysis
		getGasFlow(); //Needed for electrolysis
		getElectroCurrent();
		getSolarCurrent();		
	}

}
	
	


void startComms(){
	char incomingChar = '0';
	
	while (Serial.available() > 0 && newData = false){
		incomingChar = Serial.read();
		//use Fabio's code
	
	}

}

int recvCommands(){
	//Get the command number from the data sent
	//Char to int
	
	return 0;
}

void sendReply(char command){
	//Send back acknowledge of command number and data, if necessary
}

void sendAllData(){
	//Full data packet contains relevant data acquired for each 
}

// CIRCUIT CONTROL - OUTPUTS ------------------------------------------------------


int setMagnet(boolean state){
//Switch the Magnet circuit OFF or ON (0 or 1)

	//If trying to switch the magnet OFF
	if(state == false){
		if(magnetOn == true){
			digitalWrite(MAGNET, LOW);
			magnetOn = false;
			return 0;
		}
		else {
			return -1;
		}
	}
	
	//If trying to switch the magnet ON
	if (state == true){
		if(magnetOn == false){
			digitalWrite(MAGNET, HIGH);
			magnetOn = true;
			return 0;
		}
		else {
			return -1;
		}
	}
}


int setHeater(boolean state){
//Switch the Heater circuit ON or OFF (1 or 0)

	//If trying to switch the heater ON
	if (state == true) {	
		if (heaterOn == false) {
			digitalWrite(HEATER, HIGH);
			heaterOn = true;
			return 0;
		}
		else { 	
			return -1; //Heater is already ON so has not changed - error
		}
	}
	
	//If trying to switch the heater OFF
	else if (state == false){
		if(heaterOn == true){
			digitalWrite(HEATER, LOW);
			heaterOn = false;
			return 0;
		}
		else{
			return -1;
		}
	}
}

int setElectrolysis(boolean state){
//Switch the Electrolysis circuit ON or OFF (1 or 0)

	//If trying to switch the  ON
	if (state == true) {	
		if (electroOn == false) {
			digitalWrite(ELECTRO, HIGH);
			electroOn = true;
			return 0;
		}
		else { 	
			return -1; //Electrolysis is already ON so has not changed - error
		}
	}
	
	//If trying to switch the heater OFF
	else if (state == false){
		if(electroOn == true){
			digitalWrite(ELECTRO, LOW);
			electroOn = false;
			return 0;
		}
		else{
			return -1;
		}
	}
}

int moveCamServo(){
	//Move the servo for the planet-cam 
	analogWrite(CAM_SERVO, HALF); //Start moving at half speed
	delay(250); // Wait for 250ms to move
	analogWrite(CAM_SERVO, OFF); //Stop moving
	
	//if move executed okay...
	return 0;
	//if it didn't work:
		//return -1;
}
	

// SENSOR DATA - INPUTS ---------------------------------------------------
	
double getReactionTemp(){
// Read the temperature value of the reaction temperature probe
	
	return 0.0;
 
}

double getMeltingTemp(){
// Read the temperature value of the filter temperature probe

	return 0.0;
}

double getBatteryCurrent(){
// Read the current from the ammeter on the ISRU battery

	return 0.0;
}

double getBatteryVoltage(){
// Read the voltage from the ISRU battery

	return 0.0;
}

double getBusVoltage(){
// Read the regulated bus voltage

	return 0.0;
}

double getElectroCurrent(){
// Read the current value across the electrolysis circuitry	

	return 0.0;
}

double getSolarCurrent(){
// Read the current value across the solar panels

	return 0.0;
}

double getHydrogenPPM(){
//Read the ppm of Hydrogen produced at the ISRU output

	return 0.0;
}

double getGasFlow(){
//Read the flow (cm/s?) of the gas sensor at the ISRU output

	return 0.0;
}

	
	
	







