/****************************************************************************** 
Teensy or similar board to read temperature from one MLX90614 or similar
infrared temperature sensor. Reads the temperature in Celcius and 
send the data via serial port each second. To see output in
Arduino studio, open serial monitor and seth the baud rate to 9600.

credit to.. https://github.com/adafruit/Adafruit-MLX90614-Library 
Written by Limor Fried/Ladyada

Hardware Hookup (if you're not using the eval board):
MLX90614 ------------- Teensy 3.x or compatible board
  VDD ------------------ 3.3V
  VSS ------------------ GND
  SDA ------------------ PIN 18
  SCL ------------------ PIN 19

Development environment specifics:
Arduino 1.8.12
SparkFun IR Thermometer Evaluation Board - MLX90614
******************************************************************************/

#include <Adafruit_MLX90614.h> // If address was changed, it can be checked using sketch
                               // in Utils folder of repository. Change the correct address
                               // manually in Adafruit_MLX90614.h file.
#include <Wire.h>
Adafruit_MLX90614 mlx = Adafruit_MLX90614();

float obj_temp = 0;             // Sensor measures temperature from the object
float amb_temp = 0;             // and on its shell
int counter = 0;                // to average measurements

void setup() 
{
  Serial.begin(9600);

  mlx.begin(); //Initialise the I2C bus.
}
void loop() 
{
  // read the temperatures from sensor
  obj_temp += mlx.readObjectTempC();
  amb_temp += mlx.readAmbientTempC();
  counter++;

  if(counter == 5)
  {
    obj_temp = obj_temp / 5;
    amb_temp = amb_temp / 5;
    Serial.println("Object: " + String(obj_temp, 2) + " Ambient: " + String(amb_temp, 2));
    obj_temp = 0;
    amb_temp = 0;
    counter = 0;
    Serial.println();
  }
  delay(200);
}
