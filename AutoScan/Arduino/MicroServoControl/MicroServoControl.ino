#include <Servo.h>

#define RESET_COMMAND "RESET"
#define AUTO_COMMAND "AUTO"
#define A_ANGLE_COMMAND "AANGLE"
#define AANGLE_LENGTH 6
#define SPLIT_CHAR ';'
#define RECEIVE_STAGE 0   // 接收命令阶段
#define EXECUTE_STAGE 1   // 执行命令阶段
#define OBSERVE_STAGE 2   // 观察阶段

#define ORIGIN_POS 0
#define MAX_CHARS 49

Servo myservo;  // create servo object to control a servo
// a maximum of eight servo objects can be created

int pos = 0;    // variable to store the servo position
int posstep = 1;

int servopin = 9;
int currentStage;
char buffer[MAX_CHARS + 1];
int charIndex = 0;

void setup()
{
  Serial.begin(9600);
  Serial.flush();

  currentStage = RECEIVE_STAGE;

  myservo.attach(servopin);  // attaches the servo on pin 9 to the servo object
  myservo.write(ORIGIN_POS);// 舵机复位


  Serial.println("Ready");

}

void loop()
{
  //Serial.print("loop:currentStage=");
  //Serial.println(currentStage);
  
  switch (currentStage)
  {
    case RECEIVE_STAGE:
      ReceiveCommand();
      break;

    case EXECUTE_STAGE:
      currentStage = RECEIVE_STAGE;
      if (strcmp(buffer, RESET_COMMAND) == 0)
      {
        ResetDJ();
      }
      else if (strcmp(buffer, AUTO_COMMAND) == 0)
      {
        AutoTurn();
        currentStage = OBSERVE_STAGE;
      }
      else if (strncmp(buffer, A_ANGLE_COMMAND, AANGLE_LENGTH) == 0)
      {
        char* pInt = &buffer[AANGLE_LENGTH + 1];
        AAngle(atoi(pInt));
      }
      break;

    case OBSERVE_STAGE:
      if (Serial.available() > 0)
      {
        currentStage = RECEIVE_STAGE;
      }
      else
      {
        AutoTurn();
      }

      break;
  }
}

void ReceiveCommand()
{
  if (Serial.available() > 0)
  {
    char ch = Serial.read();

    //Serial.print("received char is ");
    //Serial.println(ch);

    if ((charIndex < MAX_CHARS) && (ch != SPLIT_CHAR))
    {
      buffer[charIndex++] = ch;
    }
    else
    {
      buffer[charIndex] = 0;
      charIndex = 0;
      currentStage = EXECUTE_STAGE;

      Serial.print("received command is ");
      Serial.println(buffer);

    }
  }
}
void ResetDJ()
{
  myservo.write(ORIGIN_POS);
}

void AAngle(int angle)
{
  myservo.write(angle);
}

void AutoTurn()
{
  pos += posstep;
  myservo.write(pos);              // tell servo to go to position in variable 'pos'
  delay(15);                       // waits 15ms for the servo to reach the position

  if (pos == 0)
  {
    posstep = 1;
  }
  else if (pos == 180)
  {
    posstep = -1;
  }

  //Serial.print("AutoTrun:pos=");
  //Serial.println(pos);
}
