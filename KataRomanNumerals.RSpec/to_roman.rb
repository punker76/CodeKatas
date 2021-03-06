class Fixnum
  def to_roman 
    romans = { 
      1 => "I", 4 => "IV", 5 => "V", 9 => "IX", 
      10 => "X", 40 => "XL", 50 => "L", 90 => "XC",
      100 => "C", 400 => "CL", 500 => "L", 900 => "CM",
      1000 => "M"
    }
    
    roman = ""
    value = self

    romans.keys.sort.reverse.each do |dec|
      while value >= dec
        roman << romans[dec]
        value -= dec
      end
    end

    roman
  end
end
