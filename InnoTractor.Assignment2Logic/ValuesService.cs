using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnoTractor.Assignment2Logic
{

    public class ValuesService
    {

        private string?[] _values;
        
        public ValuesService(string?[] values)
        {
            _values = values;
        }

        /// <summary>
        /// get the sum of the predetermined values array.
        /// </summary>
        /// <returns></returns>
        public decimal GetSumOfValues()
        {
            int result = 0;
            foreach (var value in _values)
            {
                if(value != null)
                {
                    result += checkValue(value);
                }
            }
            return result;
        }

        /// <summary>
        /// small method created to convert floating point values stored in string to a representative of it in an int value
        /// </summary>
        /// <returns></returns>
        private int checkValue(string valueString)
        {
            int result = 0;
            //check if string can simply be parsed to a integer, if so return it
            if (int.TryParse(valueString, out result))
                return result;
            else
            {
                // remove any decimal markers from the string representation
                string cleanedValue = removeDecimalMarkers(valueString);
                //check if string contains no exponent denotation, if so try and parse it to an integer
                if(!cleanedValue.Contains("e"))
                    if(int.TryParse(cleanedValue, out result))
                        return result;

                //calculate the integer representation of an exponent denotation
                result = calculateExponent(cleanedValue);
 
            }

            return result;
        }

        private int calculateExponent(string exponentString)
        {
            var indexOfExpMarker = exponentString.IndexOf('e');
            var separatedValues = exponentString.Split('e');
            if (int.TryParse(separatedValues[indexOfExpMarker],out int power))
            {
                string multiplierString = $"1{new string('0', power)}";
                return int.Parse(separatedValues[0]) * int.Parse(multiplierString);
            }
            else
            {
                throw new Exception($"the exponent value is not valid, illegal characters exist in the value. the exponent string is: {separatedValues[indexOfExpMarker]}");
            }
        }

        private string removeDecimalMarkers(string value)
        {
            return value.Replace(".", "");
        }


    }
}
