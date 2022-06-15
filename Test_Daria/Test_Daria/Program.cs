using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Test_Daria
{

    class Program
    {
        static string file = @"/Users/andriikurdiumov/Projects/Tests/Test_Daria/Test_Daria/da.txt";
        static int count = 0;
        static int countArray = 0;
        static string[] readEveryLine = new string[351];
        static int[] alreadyHave;
        static string userAnswer;
        static int correctCount = 0;
        static int countCheck = 1;

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] questions = new int[70];

            for(int i = 0; i<70; i++)
            {
                questions[i] =+ count;
                count += 5;
            }

            count = 0;

           for(int k = 0; k < 50; k++)
            {
                Generate(questions);
            }
        }
        static void Generate(int[] questions)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rand = new Random();
            readEveryLine = File.ReadAllLines(file, Encoding.UTF8);
            countArray = questions[rand.Next(0, questions.Length)];
            a: Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(readEveryLine[countArray]);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine(readEveryLine[countArray + 1]);
            Console.WriteLine();
            Console.WriteLine(readEveryLine[countArray + 2]);
            Console.WriteLine();
            Console.WriteLine(readEveryLine[countArray + 3]);
            Console.WriteLine();
            userAnswer = Console.ReadLine();
            if (userAnswer == "А" || userAnswer == "В" || userAnswer == "Б")
            {
                if (userAnswer == readEveryLine[countArray + 4])
                {
                    correctCount += 1;
                }
                questions = questions.Where(val => val != countArray - 1).ToArray();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(correctCount + "/" + countCheck++);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Напиши А,Б или В :)");
                goto a;
            }
        }
    }
}
