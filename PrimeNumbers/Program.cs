using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrimeNumbers
{

    class Program
    {
        static void Main(string[] args)
        {
            WritePrimeNumbers();
        }

        private static void WritePrimeNumbers()
        {
            List<Int64> primeList = new List<Int64>();
            Int64 primeCount = 500000;
            Boolean primeMatchFound = false;
            StringBuilder sbText = new StringBuilder();
            DateTime startTime = DateTime.Now;
            DateTime endTime;
            TimeSpan totalTime;

            if (primeCount >= 1)
            {
                primeList.Add(2);
                sbText.Append("2,");
            }

            for (Int64 i = 3; i <= primeCount; i += 2)
            {
                //primeMatchFound = CheckWithLinq(primeList, primeMatchFound, i);
                primeMatchFound = CheckWithForLoop(primeList, primeMatchFound, i);

                if (primeMatchFound == false)
                {
                    primeList.Add(i);
                    sbText.Append(String.Format("{0},", i.ToString()));
                }
            }

            if (sbText.Length > 0)
            { sbText.Length--; }

            Console.WriteLine(sbText);
            Console.WriteLine();

            endTime = DateTime.Now;
            totalTime = endTime.Subtract(startTime);
            Console.WriteLine(String.Format("{0}:{1}:{2}.{3}",
                totalTime.Hours, totalTime.Minutes, totalTime.Seconds, totalTime.Milliseconds));
            Console.ReadLine();
        }

        private static bool CheckWithForLoop(List<Int64> primeList, Boolean primeMatchFound, Int64 i)
        {
            primeMatchFound = false;

            foreach (Int64 prime in primeList)
            {
                if (i % prime == 0)
                {
                    primeMatchFound = true;
                    break;
                }
            }
            return primeMatchFound;
        }

        private static bool CheckWithLinq(List<Int64> primeList, Boolean primeMatchFound, Int64 i)
        {
            primeMatchFound =
                (from Int64 num in primeList
                 where i % num == 0
                 select true
                 ).Any();
            return primeMatchFound;
        }
    }

}
