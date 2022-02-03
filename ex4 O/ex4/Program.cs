using System;
using System.IO;

namespace ex4
{
    /*
     (O)Modi
      4. Se citeşte un număr natural nenul n. Să se afişeze, în ordine invers lexicografică,
      permutările mulţimii {1,2,..,n}. Fişierul de intrare permutari1.in conţine pe prima linie
      numărul n. Fişierul de ieşire permutari1.out va conţine pe fiecare linie elementele
      unei permutări, separate prin câte un spaţiu.
     */

    internal class Program
    {
        static int[] array;
        static int number;

        static void Main(string[] args)
        {
            FileStream fsIn = new FileStream("./../../../../permutari.in", FileMode.Open);
            StreamReader sr = new StreamReader(fsIn);

            number = int.Parse(sr.ReadLine().Trim());
            array = new int[number];

            sr.Close();
            fsIn.Close();

            FileStream fsOut = new FileStream("./../../../../permutari.out", FileMode.Create);
            StreamWriter sw = new StreamWriter(fsOut);

            Backtrack(0, sw);

            sw.Close();
            fsOut.Close();
        }

        public static bool Verify(int pos)
        {
            for (int i = 0; i < pos; i++)
                if (array[i] == array[pos])
                    return false;

            return true;
        }

        public static void Backtrack(int position, StreamWriter sw)
        {
            for (int i = number; i > 0; i--)
            {
                array[position] = i;
                if (Verify(position))
                {
                    if (position == number - 1)
                    {
                        for (int j = 0; j < number; j++)
                            sw.Write(array[j]  + " ");
                        sw.WriteLine();
                    }
                    else
                        Backtrack(position + 1, sw);
                }
            }
        }
    }
}
