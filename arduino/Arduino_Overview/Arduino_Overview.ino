//Basic program flow for ISRU control (Arduino)

// Updated: 11/02/2020, 19:39, GC

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

//Comms
//Use these if only using simple command numbers
char incomingChar = '0';
String incomingString;
String completeString;

//removed - 11/2/20

bool newCommand = false;
char command;


//outgoing
uint8_t numVals;


//Circuit control
static bool magnetOn = true;
static bool heaterOn= false;
static bool electroOn = false;

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
//  currentState = initialising;
  
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
  
  //Attempt communication with Pi
  Serial.begin(115200); //Start Serial comms (baud rate)
  Serial.read(); // to clear buffer
  
  Serial.print("hello!");

  incomingChar = Serial.read();
  
  while(incomingChar != '!'){
      Serial.print("hello!");
      digitalWrite(ORANGE, HIGH);
      delay(250);
      digitalWrite(ORANGE,LOW);
      incomingChar = Serial.read();
      delay(250);
  }

  
  //Gets to here once hello! is received
  digitalWrite(RED, LOW);
  digitalWrite(GREEN, HIGH); 

}

//Loop operates continuously when the program runs
void loop(){
    //Get the most recent sensor values
    UpdateValues();

    
    //Receive Data
    while(Serial.available() && !newCommand){
       incomingChar = Serial.read();
       if (incomingChar == ';'){
         completeString = incomingString;
         if(command = completeString.toInt()){
          newCommand = true; 
          digitalWrite(ORANGE, HIGH);
         }
         incomingString = "";
        }
       
       else {
        if (isDigit(incomingChar)){
          incomingString += incomingChar;
         }
       }
    }
    Serial.println(incomingString);

    //Process request
    if(newCommand){
        processCommands(command);
        newCommand = false;
        digitalWrite(ORANGE, LOW);
    }
    
    if (command != 1 && command != 2){
    //Send full packet of info
    sendAllData();
    }
}





void UpdateValues(){
  //Get ALL currently required values from sensors being used, regardless of state
  
  getBatteryCurrent(); //Always Needed
  getBatteryVoltage(); //Always Needed
  getBusVoltage(); //Always needed
  getSolarCurrent(); //Always needed?
  getElectroCurrent(); //Always needed? Maybe not though..?
  getMeltingTemp();  //Needed for melting, electrolysis
  getReactionTemp(); //Needed for electrolysis
  getHydrogenPPM(); //Needed for electrolysis
  getGasFlow(); //Needed for electrolysis
}
  
  




void processCommands(int command){
  //Get the command number from the data sent
  switch(command){
    case'0':
       // Whoops, you done messed up... flash the orange LED!
       flashLED(ORANGE);
       break;

    case 1:
       // Get status of the board
       // ***
       // Send Command number and TRUE (2 bytes)
       break;

     case 2:
       // Get all data available
       sendAllData(); //***
       break;

     case 3:
       // Switch magnet
       switchFunction(MAGNET);
       magnetOn = !magnetOn;
       break;

     case 4:
      // Switch heater
      switchFunction(HEATER);
      heaterOn = !heaterOn;
      break;

      case 5:
      // Switch Electrolysis
      switchFunction(ELECTRO);
      electroOn = !electroOn;
      break;

      case 6:
      // Switch Red LED
      switchFunction(RED);
      break;

      case 7:
      //Switch Orange LED
      switchFunction(ORANGE);
      break;

      case 8:
      //Switch Green LED
      switchFunction(GREEN);
      break;

      case 9:
      //Get Magnet status
      //***
      break;

      case 10:
      //Get heater status
      //**
      break;

      case 11:
      //Get electrolysis status
      //**
      break;

      case 12:
      //Get reaction temperature
      //**
      break;

      case 13:
      //Get melting temperature
      //**
      break;

      case 14:
      //Get battery current
      //**
      break;

      case 15:
      //Get battery voltage
      //**
      break;

      case 16:
      //Get bus voltage
      //**
      break;

      case 17:
      //Get electrolysis current
      //**
      break;

      case 18:
      //Get solar panel current
      //**
      break;

      case 19:
      //Get hydrogen ppm
      //**
      break;

      case 20:
      //Get gas flow
      //**
      break;
    
      default:
        //WHOOPS AGAIN
        flashLED(ORANGE);
        break;
    }

}

void sendReply(char command){
  //Send back acknowledge of command number and data, if necessary
}

void sendAllData(){
  //Full data packet contains relevant data acquired for each 
}

// CIRCUIT CONTROL - OUTPUTS ------------------------------------------------------


void flashLED(int pin){
  digitalWrite(pin, HIGH);
  delay(500);
  digitalWrite(pin, LOW);
  delay(500);
  digitalWrite(pin, HIGH);
  delay(500);
  digitalWrite(pin, LOW);
  delay(500);
}

void switchFunction(int pin){
//Invert digital pin state - switch OFF if ON, vice versa
  digitalWrite(pin, !digitalRead(pin));
}


/*int setElectrolysis(boolean state){
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
}*/

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

double getBusVoltage(){
 // Read value from bus voltmeter

   return 0.0;
}

double getSolarCurrent(){
 // Read current value from solar panel ammeter  

  return 0.0;
}

double getElectroCurrent(){
 // Get current value across electrodes 
 
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

  
  
  
