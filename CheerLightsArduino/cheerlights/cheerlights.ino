String colorString = "";
String red = "";
String green = "";
String blue = "";

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
    colorString = "";
  }else {
    waitWithAMessage("Waiting color");
  }
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
