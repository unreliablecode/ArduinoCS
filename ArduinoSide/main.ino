#include <ArduinoJson.h>

struct ArduinoMessage {
    int GPIO;
    int LOGIC;
    float Value;
    int isDigitalWrite;
    char Message_[50];
};

void setup() {
    Serial.begin(9600);
}

void loop() {
    if (Serial.available() > 0) {
        String jsonStr = Serial.readStringUntil('\n');
        DynamicJsonDocument jsonDoc(256);
        deserializeJson(jsonDoc, jsonStr);

        int gpio = jsonDoc["GPIO"];
        int logic = jsonDoc["LOGIC"];
        float value = jsonDoc["Value"];
        int isDigital = jsonDoc["isDigitalWrite"];
        if (isDigital == 1)
        {
            DigitalWrite(gpio, logic);
        }
        else if (isDigitalWrite == 0)
        {
            AnalogWrite(gpio, value);
        }
    }
}
