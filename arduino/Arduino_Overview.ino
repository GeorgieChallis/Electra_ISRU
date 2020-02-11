//Basic program flow for ISRU control (Arduino)

// Updated: 10/02/2020, 16:11, GC


// Changes: 
//
//
//

//-------------------------------------------------------------

//CHECK PIN CAPABILITES
//Pin allocations 
//Digital
#define RED 6
#define ORANGE 7
#define GREEN 8

#define MAGNET 9
#define HEATER 10
#define ELECTRO 11

#define CAM_SERVO 12

//Analogue
#define H2 0
#define FLOW 1
#define REACT_TEMP 2
#define MELT_TEMP 3

#define BATT_CURRENT 4
#define BATT_VOLTAGE 5
#define BUS_VOLTAGE 6
#define ELECTRO_CURRENT 7
#define SOLAR_CURRENT 8


//Global Variables
int numChars = 64;
char receivedChars[64];
bool newData = false;
char command;

static bool magnetOn = true;
static bool heaterOn= false;
static bool electroOn = false;

enum missionStates { 
  idle, 
  initialising, 
  exploring, 
  excavating, 
  returning, 
  melting, 
  electrolysis, 
  error
 };

enum missionStates currentState;

// Temperature probes
double reactionTemp;
double heaterTemp;

// Voltage/ current monitoring
double batteryCurrent;
double batteryVoltage;
double busVoltage;
double solarCurrent;
double electroCurrent;

// Gas monitoring
double hydrogenPPM;
double gasFlow;

//camera servo
double servoRotation;

//Set up is called once on start-up
void setup(){
  currentState = initialising;
  
  //Initialise Digital Pins
  pinMode(RED, OUTPUT);
  pinMode(ORANGE, OUTPUT);
  pinMode(GREEN, OUTPUT);
  
  pinMode(MAGNET, OUTPUT);
  pinMode(HEATER, OUTPUT);
  pinMode(ELECTRO, OUTPUT);
  
  pinMode(CAM_SERVO, OUTPUT);

  
  
  //Red LED ON indicates power is present
  digitalWrite(RED, HIGH);
  
  //Attempt communication with Pin
  //Serial.begin(115200); //Start Serial comms
  
  //If comms is good
    // Switch LED ON
    
  //If comms is not good
    // If this is attempt 1 or 2
      // Try to connect again
    //Return an error to the user, blink LED
      
    
    

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
  
  if (currentState > 3) {
      getMeltingTemp();  //Needed for melting, electrolysis
  }
  else if (currentState > 4){
    getReactionTemp(); //Needed for electrolysis
    getHydrogenPPM(); //Needed for electrolysis
    getGasFlow(); //Needed for electrolysis
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

//int moveCamServo{
  //Move the servo for the planet-cam 
  //if move executed okay...
  //return 0;
  //if it didn't work:
    //return -1;
//}
  



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

double getHydrogenPPM(){
//Read the ppm of Hydrogen produced at the ISRU output

  return 0.0;
}

double getGasFlow(){
//Read the flow (cm/s?) of the gas sensor at the ISRU output

  return 0.0;
}

  
  
  
