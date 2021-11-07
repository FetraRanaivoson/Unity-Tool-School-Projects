using System;
using System.Diagnostics;

namespace Recursion
{
    class Program
    {
        static void Main(string[] args)
        {
            const int numberOfResult = 3;
            int numberOfTeams= 2;
            Console.WriteLine(GetNumberOfCombination(numberOfResult, numberOfTeams));
        }
        
        public static void RecursionAvecStop(int nb, int value)
        {
            if (nb >= 0)
            {
                for (int i = 0; i < value; i++)
                {
                    Console.Write(i);
                }
                Console.WriteLine("");
                RecursionAvecStop(nb - 1, value);
            }
        }


        private static double GetNumberOfPermutation(double population, double samples)
        {
            if (samples > population)
                throw new Exception("Sample count must be lesser than the population count");
            double numerator = GetFactorial(population);
            double denominator = GetFactorial(population - samples);
            return numerator / denominator;
        }
        private static double GetNumberOfCombination(double population, double samples)
        {
            if (samples > population)
                throw new Exception("Sample count must be lesser than the population count");
            double numerator = GetFactorial(population);
            double denominator = GetFactorial(samples) * GetFactorial(population - samples);
            return numerator / denominator;
        }

        private static double GetFactorial(double number)
        {
            if (number == 0)
                return 1;
            return number * GetFactorial(number - 1);
        }
        
        
        
    }
}
