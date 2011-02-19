﻿using System;
using System.Collections.Generic;

namespace KataFizzBuzz.MSpec
{
    public class FizzBuzz
    {
        public string Translate(int number)
        {
            if (number % 15 == 0)
                return "FizzBuzz";

            if (number % 5 == 0)
                return "Buzz";

            if (number % 3 == 0)
                return "Fizz";

            return number.ToString();
        }

        public List<TranslationEntry> TranslateRange(int fromNumber, int toNumber)
        {
            throw new NotImplementedException();
        }
    }
}