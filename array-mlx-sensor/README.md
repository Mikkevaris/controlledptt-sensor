# Array MLX90621 sensor

This sketch and C# communication program are dedicated to reading temperatures simultaneously from 64 different pixels in Celcius with one MLX90621 16x4 IR thermal array or similar sensor. Sensor detects thermal radiation and measures temperatures without making contact with any objects. The temperature is read from all the pixels every second and send to serial port, which subsequently read and visualized by C# program. User can choose from which pixels the average temperature is calculated in C# program. This sensor needs Teensy or similar board. It is not compatible with Arduino due to larger memory requirements needed to store and send temperature data.


# Requirements

- Teensy or similar board (we used Teensy 3.6)
- MLX90621 IR thermal array or similar sensor
- Two resistors (4,7 kOhm)
- One capacitor (100 nF)
- One silicion diode (dropout voltage  ~0.7V)
- USB wire
- Arduino studio
- .Net version
- Visual Studio Code or Visual Studio 2019

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
 
<img src="https://github.com/Mikkevaris/controlledptt-sensor/blob/master/array-mlx-sensor/Array_bb.png" height="350" width="600">

# Compilation

To compile the Arduino sketch, [nox771's i2c_t3 enhanced Teensy 3 Wire library](https://github.com/nox771/i2c_t3) is needed. This library allows a Teensy 3.x or Arduino compatible USB development board to communicate with the MLX90621 over I2C/TWI. Library can also be found in this repository's library folder.

The sketch also utilizes MaxBot's MLX90621 [Arduino library](https://forum.arduino.cc/index.php?topic=126244.0) patched with KMoto's [minor change](https://forum.arduino.cc/index.php?topic=126244.msg2307588#msg2307588) in defaultConfig_H, which is already included in readTemperatures file with the sketch. This library provides sensor's functionality and methods for use in sketch.
