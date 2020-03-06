using System;

namespace RouletteOutcome
{
    class Program
    {
        public static string[] numbers = { "00","0","1","2","3","4","5","6","7","8","9","10",
                                            "11","12","13","14","15","16","17","18","19","20",
                                            "21","22","23","24","25","26","27","28","29","30",
                                            "31","32","33","34","35","36" };
        public static int[] blackNum = {2, 4, 6, 8, 10, 11, 13, 15, 17, 20,
                                        22, 24, 26, 28, 29, 31, 33, 35};

        static void Main(string[] args)
        {

            string winningNum = RandomNum();
            Console.WriteLine($"\tThe winning number is {winningNum}!");
            Console.WriteLine("\n\tWinning bets are as follows:");
            Console.WriteLine($"\t\tBin bet: {winningNum}");
            if (winningNum == "0" || winningNum == "00")
            {
                Console.WriteLine("\t\tSplit bet: 0/00");
            }
            else
            {
                Console.WriteLine($"\t\tEven or Odd: {EvenOrOdd(winningNum)}");
                Console.WriteLine($"\t\tRed or Black: {RedOrBlack(winningNum)}");
                Console.WriteLine($"\t\tLows or Highs: {LowOrHigh(winningNum)}");
                Console.WriteLine($"\t\tDozens: {DozenBet(winningNum)}");
                Console.WriteLine($"\t\tColumns: {ColumnBet(winningNum)}");
                Console.WriteLine($"\t\tStreet: {StreetBet(winningNum)}");
                Console.WriteLine($"\t\tDouble Row: {DoubleRow(winningNum)}");
                Console.WriteLine($"\t\tSplit Bet: {SplitBet(winningNum)}");
                //Console.WriteLine($"\t\tCorners
            }
        }
        public static string RandomNum()
        {
            Random random = new Random();
            int randomIndex = random.Next(0, numbers.Length);

            return numbers[randomIndex];
        }
        public static string EvenOrOdd(string input)
        {
            int inputNum = Convert.ToInt32(input);

            if (inputNum % 2 == 1)
            {
                return "Odd";
            }
            return "Even";
        }
        public static string RedOrBlack(string input)
        {
            int inputNum = Convert.ToInt32(input);

            for (int i = 0; i < blackNum.Length; i++)
            {
                if (blackNum[i] == inputNum)
                {
                    return "Black";
                }
            }
            return "Red";
        }
        public static string LowOrHigh(string input)
        {
            int inputNum = Convert.ToInt32(input);

            if (inputNum < 19)
            {
                return "Low (1-18)";
            }
             
                return "High (19-36)";   
        }
        public static string DozenBet(string input)
        {
            int inputNum = Convert.ToInt32(input);

            if (inputNum < 13)
            {
                return "1st Dozen (1-12)";
            }
            else if (inputNum > 24)
            {
                return "3rd Dozen (25-36)";
            }
            return "2nd Dozen (13-24)";

        }
        public static string ColumnBet(string input)
        {
            int inputNum = Convert.ToInt32(input);
            if (inputNum % 3 == 1)
            {
                return "1st Column";
            }
            else if (inputNum % 3 == 2)
            {
                return "2nd Column";
            }
            return "3rd Column";

        }
        public static string StreetBet(string input)
        {
            int inputNum = Convert.ToInt32(input);
            if (inputNum % 3 == 0)
            {
                return $"{inputNum - 2}, {inputNum - 1}, {inputNum}";
            }
            else if ((inputNum + 1) % 3 == 0)
            {
                return $"{inputNum - 1}, {inputNum}, {inputNum +1}";
            }
            return $"{inputNum}, {inputNum + 1}, {inputNum + 2}";

        }
        public static string DoubleRow(string input)
        {
            int inputNum = Convert.ToInt32(input);
            string resultString = "(";
            int firstSet;    
            int secondSet;

            if (inputNum % 3 == 0)
            {
                firstSet = inputNum - 5;
                secondSet = inputNum - 2;
            }
            else
            {
                firstSet = inputNum - ((inputNum % 3) + 2);
                secondSet = inputNum - ((inputNum % 3) -1);
            }

            if (inputNum <=3)                       //These two will return only 1 bet option
            {
                return "(1, 2, 3, 4, 5, 6)";
            }
            else if (inputNum >= 34)
            {
                return "(31, 32, 33, 34, 35, 36)";
            }

            for (int i = 0; i < 6; i++)             //Adds to resultString for the first set of numbers
            {
                if (i == 5)
                {
                    resultString += $"{firstSet}) and (";
                    break;
                }
                resultString += $"{firstSet}, ";
                firstSet++;
            }

            for (int i = 0; i < 6; i++)             //Adds to resultString for the second set of numbers
            {
                if (i == 5)
                {
                    resultString += $"{secondSet})";
                    break;
                }
                resultString += $"{secondSet}, ";
                secondSet++;
            }
            return resultString;
        }
        public static string SplitBet(string input)
        {

        }
    }
}
