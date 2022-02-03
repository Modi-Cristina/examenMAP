using System;
using System.IO;
using System.Collections.Generic;

namespace ex13
{
     /*
    (D)Modi
     Ex13
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = GetNumbers();
            int count = 0;

            for(int i = 999; i>= 100; i--)
            {
                if(!numbers.Contains(i))
                {
                    Console.Write($"{i} ");
                    count++;
                }
                if (count == 2)
                    break;
            }

            Console.WriteLine();

            if(count == 1)
                Console.WriteLine("There is only one number with 3 digits that was not found in the array");
            else if(count == 0)
                Console.WriteLine("All the numbers with 3 digits are present in the array");

        }

        public static List<int> GetNumbers()
        {
            FileStream fs = new FileStream("./../../../../input.in", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            List<int> list = new List<int>();

            while (!sr.EndOfStream)
                list.Add(int.Parse(sr.ReadLine().Trim()));

            sr.Close();
            fs.Close();

            return list;
        }
    }
}
