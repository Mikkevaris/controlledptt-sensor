# One MLX90614 Sensor

This sketch and C# communication program are dedicated to reading temperature in Celcius from one MLX90614 or similar infrared temperature sensor. The temperature is read 5 times each 0.2 second, averaged and sent to serial port, which subsequently read and displayed by C# program.

# Requirements

- Arduino or similar board
- One MLX90614 or similar sensor (we used ...)
- Two resistors (xx kOhm)
- One capacitor (xx uF)
- Arduino Studio
- .NET version
- Visual Studio Code or Visual Studio 2019 (this maybe not needed if we compile C# programs beforehand)

# Board Wiring

Image for board wiring

# Compilation

To compile the sketch, I2Cmaster library is needed, which can be found in...