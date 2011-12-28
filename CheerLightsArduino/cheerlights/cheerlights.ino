String colorString = "";
String red = "";
String green = "";
String blue = "";
int RED_PIN = 9;
int GREEN_PIN = 10;
int BLUE_PIN = 11;

void setup(){
  Serial.begin(9600);
  waitConnection();
}

void loop()
{
  if (Serial.available()) {
    getColor();
    defineColorValues();
    debugMessage();
    analogWrite(RED_PIN, red);
    analogWrite(GREEN_PIN, green);
    analogWrite(BLUE_PIN, blue);
    colorString = "";
  }else {
    waitWithAMessage("Waiting color");
  }
}

int toInt(String value) {
  int n;
  char carray[3];
  value.toCharArray(carray, sizeof(carray));
  n = atoi(carray);
  return n;
}

void debugMessage() {
  Serial.println("color received: " + colorString);
  String result = "red:";
  result += red;
  result += "green:";
  result += green;
  result += "blue:";
  result += blue;
  Serial.println(result);
}

void waitConnection() {
  waitWithAMessage("Waiting connection");
}

void getColor() {
  while (Serial.available()) {
    char c = Serial.read();
    colorString += c;
  }
}

void defineColorValues() {
  int firstSeparator = colorString.indexOf(',');
  int lastSeparator = colorString.lastIndexOf(',');
  red = colorString.substring(0, firstSeparator);
  green = colorString.substring(firstSeparator + 1, lastSeparator);
  blue = colorString.substring(lastSeparator + 1);
}

void waitWithAMessage(String message) {
  while (Serial.available() <= 0) {
    Serial.println(message);
    delay(1000);
  }
}
