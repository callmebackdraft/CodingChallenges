using System;
using System.Collections.Generic;
using System.Linq;
namespace InnoTractor.Assignment1Logic
{
    public static class FizzBuzzService
    {
        /// <summary>
        /// Gets an <see cref="IEnumerable{string}"/> of string values representing basic FizzBuzz Logic
        /// </summary>
        /// <param name="depth">the amount of iterations to go trough, default is 30</param>
        /// <returns></returns>
        public static IEnumerable<FizzBuzzOutput> Get(int depth = 30)
        {
            List<FizzBuzzOutput> result = new();
            for (int i = 0; i <= depth; i++)
            {
                if (i % 15 == 0)
                    result.Add(new(i, "FizzBuzz"));
                else if (i % 3 == 0)
                    result.Add(new(i, "Fizz"));
                else if (i % 5 == 0)
                    result.Add(new(i, "Buzz"));
                else
                    result.Add(new(i, $"{i}"));
            }
            return result;
        }
    }
}
