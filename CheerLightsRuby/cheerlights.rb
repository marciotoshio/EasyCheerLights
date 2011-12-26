require 'serialport'

delay = 20000
@port_name = '/dev/ttyUSB0'
@boud_rate = 9600

def StartSerial
	s = SerialPort.new @port_name, @boud_rate
end

serial = StartSerial();
serial.write "1"
sleep 2
serial.write "0"
sleep 2
serial.write "1"
sleep 2
serial.write "0"