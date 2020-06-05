
/****************************************************************************** 
Arduino or similar board to read temperature from one MLX90614 or similar
infrared temperature sensor. Reads the temperature in Celcius and 
send the data via serial port each second. To see output in
Arduino studio, open serial monitor and seth the baud rate to 9600.

Based on:
Infrared Thermometer MLX90614
by Jaime Patarroyo

Hardware Hookup (if you're not using the eval board):
MLX90614 ------------- Arduino or compatible board
  VDD ------------------ 3.3V
  VSS ------------------ GND
  SDA ------------------ SDA (A4 on older boards)
  SCL ------------------ SCL (A5 on older boards)

Development environment specifics:
Arduino 1.6.9
SparkFun IR Thermometer Evaluation Board - MLX90614
******************************************************************************/

//#include <i2cmaster.h>
#include <i2c_t3.h> //Enhanced I2C library for Teensy 3.x & LC devices (Works only with Teensy LC and 3.x boards).


// Address for I2C communication for sensor
// If address was changed, it can be checked using sketch
// in Utils folder of repository

int sensor_address = 0x50<<1;   // Shift the address 1 bit right, the 
                                // I2C master library only needs the 7 most 
                                // significant bits for the address.
int obj_temp_address = 0x07;    // address to read object temperature from sensor
int amb_temp_address = 0x06;    // address to read ambient temperature from sensor

float obj_temp = 0;             // Sensor measures temperature from the object
float amb_temp = 0;             // and on its shell
int counter = 0;                // to average measurements

void setup() 
{
  Serial.begin(9600);                       // Initialize Serial to log output
  //i2c_init();                               // Initialise the I2C bus.'
  Wire.begin();
  PORTC = (1 << PORTC4) | (1 << PORTC5);    // Enable pullups.
}

void loop() 
{
  // read the temperatures from sensor
  obj_temp += temperature(sensor_address, obj_temp_address);
  amb_temp += temperature(sensor_address, amb_temp_address);
  counter++;
  

  if(counter == 5)
  {
    obj_temp = obj_temp / 5;
    amb_temp = amb_temp / 5;
    Serial.println("Object: " + String(obj_temp, 2) + " Ambient: " + String(amb_temp, 2));
    obj_temp = 0;
    amb_temp = 0;
    counter = 0;
  }
  delay(200);
}

float temperature(int address, int obj_amb_addr) {
  // perform the actual temperature read using
  // I2C library
  int device = address;
  int data_low = 0;
  int data_high = 0;
  int pec = 0;

  // Write
  //i2c_start_wait(device + I2C_WRITE);
  //i2c_write(obj_amb_addr); // this is address for object temperature
  Wire.beginTransmission(device);
  Wire.write(obj_amb_addr); // Or Wire.send(obj_amb_addr)?
  Wire.endTransmission(I2C_NOSTOP);
  
  // Read
  //i2c_rep_start(device + I2C_READ);
  //data_low = i2c_readAck();       // Read 1 byte and then send ack.
  //data_high = i2c_readAck();      // Read 1 byte and then send ack.
  //pec = i2c_readNak();
  //i2c_stop();
  Wire.requestFrom(device,2);
  data_low = Wire.read();
  data_high = Wire.read();
  pec = Wire.read();
  Wire.endTransmission();

  // This converts high and low bytes together and processes temperature, 
  // MSB is a error bit and is ignored for temps.
  double tempFactor = 0.02;       // 0.02 degrees per LSB (measurement 
                                  // resolution of the MLX90614).
  double tempData = 0x0000;       // Zero out the data
  int frac;                       // Data past the decimal point

  // This masks off the error bit of the high byte, then moves it left 
  // 8 bits and adds the low byte.
  tempData = (double)(((data_high & 0x007F) << 8) + data_low);
  tempData = (tempData * tempFactor) - 0.01;
  float celcius = tempData - 273.15;
  
  // Returns temperature un Celcius.
  return celcius;
}
