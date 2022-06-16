using System;
using System.IO;
using System.Text;
using System.Linq;

namespace Test_Daria
{

    class Program
    {
        static string fileDa = @"/Users/andriikurdiumov/Projects/Tests/Test_Daria/Test_Daria/da.txt";
        static string fileNet = @"/Users/andriikurdiumov/Projects/Tests/Test_Daria/Test_Daria/net.txt";
        static int count = 0;
        static int countArray = 0;
        static string[] readEveryLineDa = new string[1051];
        static string[] readEveryLineNet = new string[1081];
      //  static int[] alreadyHave;
        static string userAnswer;
        static int correctCount = 0;
        static int countCheck = 1;
        static int questionType = 0;
        static int anotherCount = 1;
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] questionsDa = new int[210];
            int[] questionsNet = new int[181];

            for(int i = 0; i<70; i++)
            {
                questionsDa[i] =+ count;
                count += 5;
            }
            count = 0;
            for (int l = 0; l < 81; l++)
            {
                questionsNet[l] =+ count;
                count += 6;
            }
            count = 0;
 
                for (int k = 0; k < 51; k++)
                {
                    Generate(questionsDa, questionsNet);
                if (k == 50)
                {
                    Console.Write(correctCount + "/" + countCheck++);
                    Console.Write("Умничка солнце!!");
                }
 
                }
        }
        static void Generate(int[] questionsDa, int[] questionsNet)
        {
            //Console.OutputEncoding = System.Text.Encoding.UTF8;
            questionType = rand.Next(1, 3);
            if(questionType == 1)
            {
                GenerateDa(questionsDa);
            }
            else
            {
                GenerateNet(questionsNet);
            }
        }
        static void GenerateDa(int[] questionsDa)
        {
            countArray = 0;
            userAnswer = null;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            readEveryLineDa = File.ReadAllLines(fileDa, Encoding.UTF8);
            countArray = questionsDa[rand.Next(0, questionsDa.Length)];
            a: Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(readEveryLineDa[countArray]);
            Console.ResetColor();
            Console.WriteLine();
            for(int q = 1; q <= 3; q++)
            {
                Console.WriteLine(readEveryLineDa[countArray + anotherCount]);
                Console.WriteLine();
                anotherCount++;
            }
            anotherCount = 1;
            userAnswer = Console.ReadLine();
            if (userAnswer == "А" || userAnswer == "В" || userAnswer == "Б")
            {
                if (userAnswer == readEveryLineDa[countArray + 4])
                {
                    correctCount += 1;
                }
                questionsDa = questionsDa.Where(val => val != countArray - 1).ToArray();
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
        static void GenerateNet(int[] questionsNet)
        {
            countArray = 0;
            userAnswer = null;
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            readEveryLineNet = File.ReadAllLines(fileNet, Encoding.UTF8);
            countArray = questionsNet[rand.Next(0, questionsNet.Length)];
            b: Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(readEveryLineNet[countArray]);
            Console.ResetColor();
            Console.WriteLine();
            for (int q = 1; q <= 4; q++)
            {
                Console.WriteLine(readEveryLineNet[countArray + anotherCount]);
                Console.WriteLine();
                anotherCount++;
            }
            anotherCount = 1;
            userAnswer = Console.ReadLine();
            if (userAnswer == "А" || userAnswer == "В" || userAnswer == "Б" || userAnswer == "Г")
            {
                if (userAnswer == readEveryLineNet[countArray + 5])
                {
                    correctCount += 1;
                }
                questionsNet = questionsNet.Where(val => val != countArray - 1).ToArray();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(correctCount + "/" + countCheck++);
                Console.ResetColor();
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Напиши А,Б,В или Г:)");
                goto b;
            }
        }
    }
}
