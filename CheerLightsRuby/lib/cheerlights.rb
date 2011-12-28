require 'net/http'

class Cheerlights

	def Welcome
		puts "C H E E R L I G H T S"
		puts "====================="
		puts ""
	end

	def GetColor
		puts "Requesting color..."
		Net::HTTP.get URI.parse('http://api.thingspeak.com/channels/1417/field/1/last.txt')
	end

	def Convert(color_string)
		#
		#	List of colors from http://www.cheerlights.com/control-cheerlights
		#
		case color_string
			when "red" then "255,0,0"
			when "green" then "0,255,0"
			when "blue" then "0,0,255"
			when "cyan" then "0,255,255"
			when "white" then "255,255,255"
			when "warmwhite" then "253,245,230"
			when "purple" then "128,0,128"
			when "magenta" then "255,0,255"
			when "yellow" then "255,255,0"
			when "orange" then "255,165,0"
			else "0,0,0"
		end
	end

	def Wait(seconds)
		cr = "\r"
		clear = "\e[K"
		reset = cr + clear
		seconds.downto(0) {|i|
			print "#{reset}"
			print "Waiting #{i}s"
			sleep 1
		}
	end

end