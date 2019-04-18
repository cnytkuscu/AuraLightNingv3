

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

int led0Pin = 12;
int led1Pin = 11;
int led2Pin = 10;
int led3Pin = 9;
int led4Pin = 8;
int led5Pin = 7;
int led6Pin = 6;
int led7Pin = 5;
int led8Pin = 4;
int led9Pin = 3;

boolean isConnected = false;

void setup() {
  Serial.begin(9600);
  pinMode(led0Pin, OUTPUT);
  pinMode(led1Pin, OUTPUT);
  pinMode(led2Pin, OUTPUT);
  pinMode(led3Pin, OUTPUT);
  pinMode(led4Pin, OUTPUT);
  pinMode(led5Pin, OUTPUT);
  pinMode(led6Pin, OUTPUT);
  pinMode(led7Pin, OUTPUT);
  pinMode(led8Pin, OUTPUT);
  pinMode(led9Pin, OUTPUT);


}

void loop() {

  if (stringComplete)
  {   
    stringComplete = false;
    getCommand();
  
    if (commandString.equals("LED0"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
      } else
      {
        turnLedOff(led0Pin);
        turnLedOff(led1Pin);
        turnLedOff(led2Pin);
        turnLedOff(led3Pin);
        turnLedOff(led4Pin);
        turnLedOff(led5Pin);
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }

    else if (commandString.equals("LED1"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
      } else
      {
        turnLedOff(led1Pin);
        turnLedOff(led2Pin);
        turnLedOff(led3Pin);
        turnLedOff(led4Pin);
        turnLedOff(led5Pin);
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED2"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      { turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
      } else
      {
        turnLedOff(led2Pin);
        turnLedOff(led3Pin);
        turnLedOff(led4Pin);
        turnLedOff(led5Pin);
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED3"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
      } else
      {
        turnLedOff(led3Pin);
        turnLedOff(led4Pin);
        turnLedOff(led5Pin);
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED4"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
        turnLedOn(led4Pin);
      } else
      {
        turnLedOff(led4Pin);
        turnLedOff(led5Pin);
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED5"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
        turnLedOn(led4Pin);
        turnLedOn(led5Pin);
      } else
      {
        turnLedOff(led5Pin);
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED6"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
        turnLedOn(led4Pin);
        turnLedOn(led5Pin);
        turnLedOn(led6Pin);
      } else
      {
        turnLedOff(led6Pin);
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED7"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
        turnLedOn(led4Pin);
        turnLedOn(led5Pin);
        turnLedOn(led6Pin);
        turnLedOn(led7Pin);
      } else
      {
        turnLedOff(led7Pin);
        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED8"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
        turnLedOn(led4Pin);
        turnLedOn(led5Pin);
        turnLedOn(led6Pin);
        turnLedOn(led7Pin);
        turnLedOn(led8Pin);
      } else
      {

        turnLedOff(led8Pin);
        turnLedOff(led9Pin);
      }
    }
    else if (commandString.equals("LED9"))
    {
      boolean LedState = getLedState();
      if (LedState == true)
      {
        turnLedOn(led0Pin);
        turnLedOn(led1Pin);
        turnLedOn(led2Pin);
        turnLedOn(led3Pin);
        turnLedOn(led4Pin);
        turnLedOn(led5Pin);
        turnLedOn(led6Pin);
        turnLedOn(led7Pin);
        turnLedOn(led8Pin);
        turnLedOn(led9Pin);
      } else
      {
        turnLedOff(led9Pin);
      }
    }
    inputString = "";
    
  }

}

boolean getLedState()
{
  boolean state = false;
  if(inputString.substring(5,7).equals("ON"))
  {
    state = true;
  }else
  {
    state = false;
  }
  return state;
}

void getCommand()
{
  if(inputString.length()>0)
  {
     commandString = inputString.substring(1,5);
  }
}

void turnLedOn(int pin)
{
  digitalWrite(pin,HIGH);
}

void turnLedOff(int pin)
{
  digitalWrite(pin,LOW);
}




void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}
