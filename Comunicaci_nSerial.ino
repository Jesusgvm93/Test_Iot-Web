
#include <HCSR04.h>

const int LedPin=2;
const int triggerPin = 19;
const int echoPin = 18;
int data;


void setup() {
Serial.begin(9600);
HCSR04.begin(triggerPin, echoPin);
pinMode(LedPin,OUTPUT);
digitalWrite(LedPin,LOW);

}

void loop() {

  temp();
   
  if (Serial.available())
  {
  data=Serial.read();
    if(data == 'A')
    {
      
      digitalWrite(LedPin,HIGH);     
    }
    else
    {
      digitalWrite(LedPin,LOW);
    }
    delay(50);
  }
 
}

void temp (){
  double* distances = HCSR04.measureDistanceCm();
  Serial.print(distances[0]);
  Serial.println();
  delay(100);  
}
