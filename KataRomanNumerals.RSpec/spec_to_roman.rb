require 'to_roman'

describe "to_roman" do
  describe "when number is 1" do
    it "should return I" do
      1.to_roman.should == "I"
    end
  end

  describe "when number is 2" do
    it "should return II" do
      2.to_roman.should == "II"
    end
  end

  describe "when number is 4" do
    it "should return IV" do
      4.to_roman.should == "IV"
    end
  end

  describe "when number is 5" do
    it "should return V" do
      5.to_roman.should == "V"
    end
  end

  describe "when number is 9" do
    it "should return IX" do
      9.to_roman.should == "IX"
    end
  end

  describe "when number is 10" do
    it "should return X" do
      10.to_roman.should == "X"
    end
  end

  describe "when number is 40" do
    it "should return XL" do
      40.to_roman.should == "XL"
    end
  end

  describe "when number is 50" do
    it "should return L" do
      50.to_roman.should == "L"
    end
  end

  describe "when number is 100" do
    it "should return C" do
      100.to_roman.should == "C"
    end
  end

  describe "when number is 90" do
    it "should return XC" do
      90.to_roman.should == "XC"
    end
  end

  describe "when number is 500" do
    it "should return L" do
      500.to_roman.should == "L"
    end
  end

  describe "when number is 400" do
    it "should return CL" do
      400.to_roman.should == "CL"
    end
  end

  describe "when number is 1000" do
    it "should return M" do
      1000.to_roman.should == "M"
    end
  end

  describe "when number is 900" do
    it "should return CM" do
      900.to_roman.should == "CM"
    end
  end

  describe "when number is 1999" do
    it "should return MCMXCIX" do
      1999.to_roman.should == "MCMXCIX"
    end
  end
end
