using System;
using System.IO;

namespace program_2
{
    class Program
    { 
        static int LevenshteinDistance(string firstWord, string secondWord)
        {
            var n = firstWord.Length + 1;
            var m = secondWord.Length + 1;
            var matrixD = new int[n, m];

            const int deletionCost = 1;
            const int insertionCost = 1;

            for (var i = 0; i < n; i++)
            {
                matrixD[i, 0] = i;
            }

            for (var j = 0; j < m; j++)
            {
                matrixD[0, j] = j;
            }

            for (var i = 1; i < n; i++)
            {
                for (var j = 1; j < m; j++)
                {
                    var substitutionCost = firstWord[i - 1] == secondWord[j - 1] ? 0 : 1;

                    matrixD[i, j] = Math.Min(matrixD[i - 1, j] + deletionCost, matrixD[i, j - 1] + insertionCost);
                    matrixD[i, j] = Math.Min(matrixD[i, j], matrixD[i - 1, j - 1] + substitutionCost);
                }
            }
            return matrixD[n - 1, m - 1];
        }

        static void Main(string[] args)
        {
            string read_name;
            string[] array_name;
            int i;
            int j;
            int result;
            string yes_or_no;

             
            array_name = new string[5163]; 
            Console.WriteLine("Enter name:");
            read_name = Console.ReadLine();
            if (read_name == "")
            {
                Console.WriteLine("Your name was not found.");
                Environment.Exit(-1);
            }
            foreach(var simvol in read_name)
            {
                if (!char.IsLetter(simvol))
                {
                    Console.WriteLine("Your name was not found.");
                    Environment.Exit(-1);
                }
            }
            StreamReader file = new StreamReader("array_name.txt");
            i = 0;
            while (!file.EndOfStream)
            {
                array_name[i] = file.ReadLine();
                i++;
            }
            file.Close();
            i = 0;
            while(i < array_name.Length)
            {
                if (array_name[i] == read_name)
                {
                    Console.WriteLine("Hello, {1}", array_name[i]);
                    Environment.Exit(0);
                }
                result = LevenshteinDistance(read_name, array_name[i]);
                if (result < 3)
                {
                    Console.WriteLine($"Did you mean: {array_name[i]}? Y/N");
                    yes_or_no = Console.ReadLine();
                    if (yes_or_no == "Y")
                    {
                        Console.WriteLine($"Hello, {array_name[i]}");
                        Environment.Exit(0);
                    }
                }
                i++;
            }
            Console.WriteLine("Your name was not found.");
            Environment.Exit(-1);
        }
    }
}
