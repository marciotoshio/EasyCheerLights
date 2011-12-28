require 'serialport'

class Serial
	def StartSerial(port_name, boud_rate)
		@serial = SerialPort.new port_name, boud_rate
	end
	
	def Write(color_rgb)
		@serial.write color_rgb
	end
end