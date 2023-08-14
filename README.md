# ArduinoCS - Arduino Communication

ArduinoCS is a lightweight example code that facilitates seamless communication between an Arduino board and a C# application via a serial connection. This library empowers you to control digital and analog pins on your Arduino board using C# code.

## Features

- **DigitalWrite:** Set the logic level (HIGH or LOW) of a digital pin on the Arduino board.
- **AnalogWrite:** Set an analog value (PWM) on a specific pin.
- **SendMessage:** Send custom messages to the Arduino.

## Getting Started

To use the ArduinoCS code, follow these steps:

1. Clone or download the repository: [ArduinoCS](https://github.com/unreliablecode/ArduinoCS)
2. Include the ArduinoCS Extension Code in your C# project.
3. Connect your Arduino board to your computer via a USB cable.
4. Open the Arduino IDE and upload the Arduino code provided in the `ArduinoSide` folder to your Arduino board.
5. In your C# code, create an instance of the `SerialPort` class and establish a serial connection to the Arduino board.

### Example Usage

```csharp
using ArduinoCS;
using System.IO.Ports;

class Program
{
    static void Main(string[] args)
    {
        using (SerialPort serialPort = new SerialPort("COM3", 9600))
        {
            serialPort.Open();

            // DigitalWrite example
            serialPort.DigitalWrite(13, 1); // Set digital pin 13 to HIGH

            // AnalogWrite example
            serialPort.AnalogWrite(9, 127); // Set analog pin 9 to PWM value 127

            // Send a custom message
            serialPort.SendMessage("Hello, Arduino!");

            // Remember to close the serial port when done
            serialPort.Close();
        }
    }
}
```
Arduino Code
The provided Arduino code in the ArduinoSide folder handles communication from the C# application.

```cpp
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
        // Continue processing the received data here
    }
}
```
Contributing
Contributions to ArduinoCS are welcome! If you encounter any issues or have suggestions for improvements, feel free to create a pull request or submit an issue on the GitHub repository.

License
ArduinoCS is licensed under the MIT License.

Disclaimer: This library is provided as-is and may not cover all use cases. Please review and modify the code to suit your specific needs.
