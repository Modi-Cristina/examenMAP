using System;
using System.IO;

namespace ex5
{
    /*     
     M(Modi)     
        5. Scrieţi un program C# care citeşte de la tastatură un număr natural n (n∈[2,102]) și 
           un șir de n numere naturale din intervalul [0,104] și construiește în memorie un 
           tablou bidimensional cu n linii şi n coloane, numerotate începând de la 0, astfel 
           încât parcurgând orice coloană numerotată cu un număr par, de jos în sus, sau orice 
           coloană numerotată cu un număr impar, de sus în jos, se obține șirul citit, ca în 
           exemplu. Programul afișează pe ecran tabloul obținut, fiecare linie a tabloului pe 
           câte o linie a ecranului, elementele de pe aceeași linie fiind separate prin câte un 
           spațiu. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream fsOut = new FileStream("./../../../../output.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fsOut);

            int[] a = ReadData();
            int[,] mx = new int[a.Length, a.Length];


            for (int j = 0; j < mx.GetLength(1); j++)
                for (int i = 0; i < mx.GetLength(0); i++)
                    if (j % 2 == 0) mx[i, j] = a[a.Length - i - 1];
                    else mx[i, j] = a[i];

            for (int i = 0; i < mx.GetLength(0); i++)
            {
                for (int j = 0; j < mx.GetLength(1); j++)
                    sw.Write($"{mx[i, j]} ");
                sw.WriteLine();
            }

            sw.Close();
            fsOut.Close();
        }

        public static int[] ReadData()
        {
            FileStream fsIn = new FileStream("./../../../../input.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fsIn);

            int n = int.Parse(sr.ReadLine());
            int[] a = new int[n];

            string line = sr.ReadLine();
            string[] elements = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < elements.Length; i++)
                a[i] = int.Parse(elements[i]);

            sr.Close();
            fsIn.Close();
            return a;
        }
    }
}
