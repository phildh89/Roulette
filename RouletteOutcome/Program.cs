using System;
using System.Collections.Generic;

namespace RouletteOutcome
{
    class Program
    {
        public static string[] numbers = 
        { 
            "00","0","1","2","3","4","5","6","7","8","9","10",
            "11","12","13","14","15","16","17","18","19","20",
            "21","22","23","24","25","26","27","28","29","30",
            "31","32","33","34","35","36" 
        };
        public static int[] blackNum =
        {
            2, 4, 6, 8, 10, 11, 13, 15, 17, 20,
            22, 24, 26, 28, 29, 31, 33, 35
        };

        static void Main(string[] args)
        {
            string reroll = "";
            do
            {
                StartUp();
                Console.Write("\n\n\tEnter 'y' to reroll:");
                reroll = Console.ReadLine().ToLower();
                Console.Clear();
            } while (reroll == "y");


        }
        public static void StartUp()
        {
            string winningString = RandomNum();
            Console.WriteLine($"\tThe winning number is {winningString}!");
            Console.WriteLine("\n\tWinning bets are as follows:");
            Console.WriteLine($"\t\tBin bet: {winningString}");
            if (winningString == "0" || winningString == "00")
            {
                Console.WriteLine("\t\tSplit bet: 0/00");
            }
            else
            {
                int winningInt = Convert.ToInt32(winningString);

                Console.WriteLine($"\t\tEven or Odd: {EvenOrOdd(winningInt)}");
                Console.WriteLine($"\t\tRed or Black: {RedOrBlack(winningInt)}");
                Console.WriteLine($"\t\tLows or Highs: {LowOrHigh(winningInt)}");
                Console.WriteLine($"\t\tDozens: {DozenBet(winningInt)}");
                Console.WriteLine($"\t\tColumns: {ColumnBet(winningInt)}");
                Console.WriteLine($"\t\tStreet: {StreetBet(winningInt)}");
                Console.WriteLine($"\t\tDouble Row: {DoubleRow(winningInt)}");
                Console.WriteLine($"\t\tSplit Bet: {SplitBet(winningInt)}");
                Console.WriteLine($"\t\tCorner Bet: {CornerBet(winningInt)}");
            }
        }
        public static string RandomNum()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, numbers.Length);

            return numbers[randomIndex];
        }
        public static string EvenOrOdd(int input)
        {
            if (input % 2 == 1)
            {
                return "Odd";
            }
            return "Even";
        }
        public static string RedOrBlack(int input)
        {
            for (int i = 0; i < blackNum.Length; i++)
            {
                if (blackNum[i] == input)
                {
                    return "Black";
                }
            }
            return "Red";
        }
        public static string LowOrHigh(int input)
        {
            if (input < 19)
            {
                return "Low (1-18)";
            }
             
                return "High (19-36)";   
        }
        public static string DozenBet(int input)
        {
            if (input < 13)
            {
                return "1st Dozen (1-12)";
            }
            else if (input > 24)
            {
                return "3rd Dozen (25-36)";
            }
            return "2nd Dozen (13-24)";

        }
        public static string ColumnBet(int input)
        {
            if (input % 3 == 1)
            {
                return "1st Column";
            }
            else if (input % 3 == 2)
            {
                return "2nd Column";
            }
            return "3rd Column";

        }
        public static string StreetBet(int input)
        {
            if (input % 3 == 0)
            {
                return $"{input - 2}, {input - 1}, {input}";
            }
            else if ((input + 1) % 3 == 0)
            {
                return $"{input - 1}, {input}, {input + 1}";
            }
            return $"{input}, {input + 1}, {input + 2}";

        }
        public static string DoubleRow(int input)
        {
            string result = "(";
            int firstSet;    
            int secondSet;

            if (input % 3 == 0)     //column 3
            {
                firstSet = input - 5;
                secondSet = input - 2;
            }
            else                    //column 1 and 2
            {
                firstSet = input - ((input % 3) + 2);
                secondSet = input - ((input % 3) -1);
            }

            if (input <= 3)                       //These two will return only 1 bet option
            {
                return "(1, 2, 3, 4, 5, 6)";
            }
            else if (input >= 34)
            {
                return "(31, 32, 33, 34, 35, 36)";
            }

            for (int i = 0; i < 6; i++)             //Adds to resultString for the first set of numbers
            {
                if (i == 5)
                {
                    result += $"{firstSet}) and (";
                    break;
                }
                result += $"{firstSet}, ";
                firstSet++;
            }

            for (int i = 0; i < 6; i++)             //Adds to resultString for the second set of numbers
            {
                if (i == 5)
                {
                    result += $"{secondSet})";
                    break;
                }
                result += $"{secondSet}, ";
                secondSet++;
            }
            return result;
        }
        public static string SplitBet(int input)
        {
            int[][] columnArr = new int[][]
            {
                new int[] { -3, -1, 3 },    //mod 0 (column 3)
                new int[] { -3, 1, 3 },     //mod 1 (column 1)
                new int[] { -3, -1, 1, 3 }  //mod 2 (column 2)
            };
            int columnNum = input % 3;
            string result = "";

            for (int i = 0; i < columnArr[columnNum].Length; i++)       //length of arr will depend on the column
            {
                if (input + columnArr[columnNum][i] > 36 || input + columnArr[columnNum][i] < 1)
                {
                    continue;
                }
                result += $"{input}/{input + columnArr[columnNum][i]}   ";
            }

            return result;
        }
        public static string CornerBet(int input)
        {
            int[][,] columnArr = new int[3][,]              //int[column][corner,num]
            {
                new int[,] { {-1, 0, 2, 3}, {-4, -3, -1, 0} },                                    //mod 0 (column 3)
                new int[,] { {-3,-2, 0, 1}, {0, 1, 3, 4} },                                       //mod 1 (column 1)
                new int[,] { { -3, -2, 0, 1}, {0, 1, 3, 4}, { -1, 0, 2, 3}, { -4, -3, -1, 0} }    //mod 2 (column 2)
            };
            int columnNum = input % 3;
            bool finishedArr = false;
            string result = "";

            for (int i = 0; i < columnArr[columnNum].GetLength(0); i++)
            {
                string temp = "";
                for (int k = 0; k < 4; k++)
                {
                    int nextNum = input + columnArr[columnNum][i, k];
                    if (nextNum > 36 || nextNum < 1)
                    {
                        temp = "";
                        break;
                    }
                    else if (k == 2)
                    {
                        finishedArr = true;
                    }
                    if (k == 3)
                    {
                        temp += $"{input + columnArr[columnNum][i, k]}";
                        break;
                    }
                    temp += $"{input + columnArr[columnNum][i, k]}/";
                }
                if (finishedArr == true)
                {
                    result += $"{temp}   ";
                }
            }

            return result;
        }
    }
}
