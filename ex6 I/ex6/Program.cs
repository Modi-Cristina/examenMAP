using System;
using System.IO;
using System.Collections.Generic;

namespace ex6
{
    internal class Program
    {
        /*
         (I)Modi
            6.   a)Sa se afiseze matricea de adiacenta a unui graf.
                 b) sa se faca parcurgerea lui prin algoritmul BFS si sa se afiseze aceasta.
                 c) sa se faca parcurgerea lui prin algoritmul DFS si sa se afiseze acesta.
                 d) Sa se verifice daca graful este bipartit.
         */

        static void Main(string[] args)
        {
            int[,] matrix = BuildMatrix("./../../../../input.in");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("BFS:");
            BFSCrossing(matrix, 0);
            Console.WriteLine();

            Console.WriteLine("DFS:");
            bool[] visited = new bool[matrix.GetLength(0)];
            DFS(matrix, visited, 0);
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine($"Bipartit: {BipartitGraph(matrix)}");
        }

        static int[,] BuildMatrix(string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            List<string> data = new List<string>();
            
            while (!sr.EndOfStream)
                data.Add(sr.ReadLine());

            sr.Close();
            fs.Close();

            int length = data.Count;


            int[,] matrix = new int[length, length];
            for (int i = 0; i < length; i++)
                for (int j = 0; j < length; j++)
                    matrix[i, j] = int.Parse((data[i])[j].ToString());

            return matrix;
        }

        static void BFSCrossing(int[,] matrix, int start = 0)
        {
            int length = matrix.GetLength(0);

            Queue<int> queue = new Queue<int>();

            queue.Enqueue(start);

            bool[] visited = new bool[length];
            visited[start] = true;

            while (queue.Count != 0)
            {
                int nodCurent = queue.Dequeue();
                Console.Write(nodCurent + " ");
                for (int i = 0; i < length; i++)
                {
                    if (matrix[nodCurent, i] != 0 && visited[i] == false)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }

            Console.WriteLine();
        }

        public static void DFS(int[,] matrix, bool[] visited, int start)
        {
            visited[start] = true;
            int v = matrix.GetLength(0);

            Console.Write(start + " ");
            
            for (int i = 0; i < v; i++)
            {
                if (i == start)
                    continue;
                if (!visited[i] && matrix[start, i] == 1)
                {
                    DFS(matrix, visited, i);
                }
            }
        }

        static bool BipartitGraph(int[,] matrix)
        {
            int start = 0;
            int n = matrix.GetLength(0);

            Queue<int> q = new Queue<int>();

            q.Enqueue(start);

            int[] visited = new int[n];
            visited[start] = 1;
            
            while (q.Count != 0)
            {
                int nodCurent = q.Dequeue();

                for (int i = 0; i < n; i++)
                {
                    if (matrix[nodCurent, i] != 0)
                    {
                        if (visited[i] == 0)
                        {
                            q.Enqueue(i);
                            if (visited[nodCurent] == 1)
                                visited[i] = 2;
                            else
                                visited[i] = 1;
                        }
                        else
                            if (visited[nodCurent] == visited[i])
                                return false;
                    }

                }
            }

            return true;
        }
    }
}
