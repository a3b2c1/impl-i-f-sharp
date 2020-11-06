using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FuncProgArt
{
    class imp_and_dec
    {
        void declarative()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            List<int> oddNumbers = numbers.Where(x => x % 2 == 1).ToList();
        }

        void imperative()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
            List<int> oddNumbers = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                int number = numbers[i];

                if (number % 2 == 1)
                {
                    oddNumbers.Add(number);
                }
            }
        }
    }
}
