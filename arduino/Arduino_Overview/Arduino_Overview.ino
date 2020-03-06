//Basic program flow for ISRU control (Arduino)

// Updated: 25/02/2020, 19:39, GC

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
//#define H2 0
//#define FLOW 1 
#define REACT_TEMP 2
#define MELT_TEMP 3

#define BATT_CURRENT 4
#define BATT_VOLTAGE 5
#define BUS_VOLTAGE 6
#define ELECTRO_CURRENT 7
#define SOLAR_CURRENT 8


//Global Variables -----------------------------

//Comms
//Use these if only using simple command numbers
char incomingChar = '0';
String incomingString;
String completeString;

bool newCommand = false;
char command;

// Return message: XX,XX,[][][][]...;
struct returnMessage{
  uint8_t commandRecvd;
  uint8_t  numValsReturned;
  //byte data[];
};

static struct returnMessage myMessageOut;
//outgoing
uint8_t numVals;


//Circuit control
static bool magnetOn = true;
static bool heaterOn= false;
static bool electroOn = false;

// Temperature probes
float reactionTemp;
float coeffA1 = 2.1085081e-03; //Steinhart-Hart A,B,C Coefficients (thermistor)
float coeffB1 = 0.7979204e-04;
float coeffC1 = 6.5350763e-07; 
int reactionVIn; // Voltage in from thermistor changes
float reactionR; //thermistor resistance
int R1; //Voltage divider resistor value - reaction

double heaterTemp;
double coeffA2; //Steinhart-Hart A,B,C Coefficients (thermistor)
double coeffB2;
double coeffC2; 
int R2; //Voltage divider resistor value - heaters

// Voltage/ current monitoring
double batteryCurrent;
double batteryVoltage;
double busVoltage;
double solarCurrent;
double electroCurrent;

// Gas monitoring
//double hydrogenPPM;
//double gasFlow;

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
    //-----Get the most recent sensor values
    UpdateValues();

    
    //----------Receive Data
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

    //--------Process request
    if(newCommand){
        processCommands(command);
        newCommand = false;
        digitalWrite(ORANGE, LOW);
    }
    
/*    if (command != 1 && command != 2){
    //--------Send full packet of info
    sendAllData();
    }*/
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
}
  
  
void processCommands(int command){
  //Get the command number from the data sent
  switch(command){
    case'0':
       // Whoops, you messed up... flash the orange LED!
       flashLED(ORANGE);
       break;

    case 1:
       // Get comms status of the board
       // Send Command number and TRUE (2 bytes)
       sendReply(command);
       break;

     case 2:
       // Get all data available
       sendReply(command);
      // sendAllData(); //***
       break;

     case 3:
       // Switch magnet
       switchFunction(MAGNET);
       magnetOn = !magnetOn;
       sendReply(command);
       break;

     case 4:
      // Switch heater
      switchFunction(HEATER);
      heaterOn = !heaterOn;
      sendReply(command);
      break;

      case 5:
      // Switch Electrolysis
      switchFunction(ELECTRO);
      electroOn = !electroOn;
      sendReply(command);
      break;

      case 6:
      // Switch Red LED
      switchFunction(RED);
      sendReply(command);
      break;

      case 7:
      //Switch Orange LED
      switchFunction(ORANGE);
      sendReply(command);
      break;

      case 8:
      //Switch Green LED
      switchFunction(GREEN);
      sendReply(command);
      break;

      case 9:
      //Get Magnet status
      //***
      sendReply(command);
      break;

      case 10:
      //Get heater status
      //**
      sendReply(command);
      break;

      case 11:
      //Get electrolysis status
      //**
      sendReply(command);
      break;

      case 12:
      //Get reaction temperature
      getReactionTemp();
      sendReply(command);
      break;

      case 13:
      //Get melting temperature
      getMeltingTemp();
      sendReply(command);
      break;

      case 14:
      //Get battery current
      //**
      sendReply(command);
      break;

      case 15:
      //Get battery voltage
      //**
      sendReply(command);
      break;

      case 16:
      //Get bus voltage
      //**
      sendReply(command);
      break;

      case 17:
      //Get electrolysis current
      //**
      sendReply(command);
      break;

      case 18:
      //Get solar panel current
      //**
      sendReply(command);
      break;

      case 19:
      //Get hydrogen ppm - TBC
      //**
      sendReply(command);
      break;

      case 20:
      //Get gas flow - TBC
      //**
      sendReply(command);
      break;
    
      default:
        //Unexpected command number -> error
        flashLED(ORANGE);
        break;
    }

}

void sendReply(int command){
  //Send back acknowledge of command number and data, if necessary
  myMessageOut.commandRecvd = command;
  myMessageOut.numValsReturned = 0;
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
  

// SENSOR DATA - INPUTS ---------------------------------------------------
  
double getReactionTemp(){
// Read the temperature value of the reaction temperature probe
  //need to convert change in resistance/voltage to temperature
  R1 = 10000; // Other resistor value set to 10kohm
  reactionVIn = analogRead(REACT_TEMP);
  reactionR = R1*(1023.0 / (float)reactionVIn - 1.0);
  float logrR = log(reactionR);
  reactionTemp = 1.0 / (coeffA1 + coeffB1*logrR + coeffC1*logrR*logrR*logrR);  // Steinhart and Hart
  reactionTemp = reactionTemp - 273.15; //Kelvin to Celsius
  return reactionTemp;
 
}

double getMeltingTemp(){
// Read the temperature value of the filter temperature probe
    //Voltage divider used as above
    R2 = 10000; //Rough estimate for 10kohm resistor value
    
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


//No longer used ---------------------
double getHydrogenPPM(){ return 0.0;}
double getGasFlow(){ return 0.0;}

  
  
  
