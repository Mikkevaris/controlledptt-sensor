# To be continued..

# One MLX90614 Sensor

This sketch and C# communication program are dedicated to reading temperature in Celcius from one MLX90614 or similar infrared temperature sensor. Sensor detects thermal radiation and measures temperatures without making contact with any objects. The temperature is read 5 times each 0.2 second, averaged and sent to serial port, which subsequently read and displayed by C# program.

# Requirements

- Arduino or similar board (we used Teensy 3.6)
- One MLX90614 or similar sensor (we used MLX90614 Infrared Thermometer)
- Two resistors (4,7 kOhm)
- One capacitor (100 nF)
- One silicon diode (dropout voltage ~0.7V)
- USB wire
- Arduino Studio
- .NET version
- Visual Studio Code or Visual Studio 2019 (this maybe not needed if we compile C# programs beforehand)

# Board Wiring

- Connect the Anode of a Silicon Diode to 3V Pin of Teensy. The Diode will drop ~0.7V, so the Cathode will be at ~2.7V. These 2.7V will be the supply voltage “VDD” for the sensor.
- Plug in the USB and measure the supply voltage with a multimeter. It should be somewhere between 2.5V and 2.75V, else it will fry your sensor.
- Disconnect USB.
- Connect Teensy Pin 18 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 19 to 2.7V with a 4.7kOhm Resistor (Pullup)
- Connect Teensy Pin 18 to I2C Data (SDA) Pin of Sensor
- Connect Teensy Pin 19 to I2C clock (SCL) Pin of Sensor
- Connect GND and 2.7V with a 100nF ceramic Capacitor.
- Connect the VSS Pin of the Sensor to GND.
- Connect the VDD Pin of the Sensor to 2.7V

 See below for a Fritzing diagram with a Teensy 3.1 – a circuit analogous to our Teensy 3.6 setup. 
 
<img src="https://github.com/Mikkevaris/controlledptt-sensor/blob/master/one-mlx-sensor/OneMlx.png" height="350" width="600">

# Compilation

To compile the Arduino sketch, [Adafruit's MLX60914 library](https://github.com/adafruit/Adafruit-MLX90614-Library) is needed, which is already included one-mlx-sensor folder with the sketch. Library provides sensor's functionality and methods for use in sketch. Sketch also utilizes Arduino's standard library [Wire](https://www.arduino.cc/en/Reference/Wire).

# Scanning and changing the address of sensor

Sensor's default address is 0x5A. If address has been changed it can be checked using i2c_scanner sketch in utils folder.

If it is needed to change the sensor's address, use i2c_change_address sketch in utils folder. 
