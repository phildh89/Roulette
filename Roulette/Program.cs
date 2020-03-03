using System;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();

            BetType();

            //TODO: Bin bet     35:1

            //TODO: Even or Odd     1:1

            //TODO: Red or black    1:1

            //TODO: Lows (1-18) or Highs (19-36) 1:1

            //TODO: Dozens (1-12, 13-24, 25-36) 2:1

            //TODO: Columns 1,2,3   2:1

            //TODO: Street bet (1,2,3)  11:1

            //TODO: 6 numbers- double row (1-6) or (22-27)  5:1

            //TODO: split at the edge of two nums 1/2, 11/14    17:1

            //TODO: Corners. Intersections of four numbers (1,2,4,5)    8:1
        }


        public static int money;
        public static int betAmount;
        public static int winnings;
        public static int[] numbers = { 00, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
                        11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
                        21, 22, 23, 24, 25, 26, 27, 28, 29, 30,
                        31, 32, 33, 34, 35, 36 };
        public static int[] blackNum = {2, 4, 6, 8, 10, 11, 13, 15, 17, 20, 
                            22, 24, 26, 28, 29, 31, 33, 35};
        public static int[] redNum = {1, 3, 5, 7, 9, 12, 14, 16, 18, 19, 21,
                        23, 25, 27, 30, 32, 34, 36};

        public static void Welcome()
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("\t~ Welcome to Roulette ~\n");
            Console.WriteLine("You will start off with $500. GOOD LUCK!");
            Console.WriteLine("\tPress Enter to start");
            Console.WriteLine("==========================================");
            money = 500;
            Console.ReadKey();
            Console.Clear();
        }                   //Welcome Screen
        public static void IsWinner(bool input)
        {
            if(input == false)
            {
                money -= betAmount;
                Console.WriteLine("\t\nNo luck this time. Press enter to bet again.");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                money += winnings;
                Console.WriteLine($"\t\nCongrats you're a winner! You have won {winnings}!! Press enter to bet again.");
                Console.ReadLine();
                Console.Clear();
            }

            if (money == 0)
            {
                Console.WriteLine("Game over! Better luck next time.");
            }
            else
            {
                BetType();
            }
        }       //Calculates money (winning and losing). Ends game if 0 money
        public static void BetType()
        {
            Console.WriteLine($"Your Balance: \t${money}\n");

            Console.WriteLine("\tType of bet: \t\t_Payout_");
            Console.WriteLine("\t1. Bin bet\t\t35:1");
            Console.WriteLine("\t2. Even or Odd\t\t1:1");
            Console.WriteLine("\t3. Red or Black\t\t1:1");
            Console.WriteLine("\t4. Lows or Highs\t1:1");
            Console.WriteLine("\t5. Dozens\t\t2:1");
            Console.WriteLine("\t6. Columns\t\t2:1");
            Console.WriteLine("\t7. Street\t\t11:1");
            Console.WriteLine("\t8. Six #s\t\t5:1");
            Console.WriteLine("\t9. Split\t\t17:1");
            Console.WriteLine("\t0. Corners\t\t8:1");

            Console.Write("\n\tEnter a number to select bet type: ");   //Enter bet type
            string inputBetType = Console.ReadLine();
            int betType;
            while (!Int32.TryParse(inputBetType, out betType) || betType < 0 || betType > 9)
            {
                Console.Write("\tInvalid entry. Try again: ");
                inputBetType = Console.ReadLine();
            }

            Console.Write("\tHow much would you like to bet?: ");     //Enter bet amoount
            string inputBetAmount = Console.ReadLine();
            while (!Int32.TryParse(inputBetAmount, out betAmount) || betAmount <= 0 || betAmount > money)
            {
                Console.Write("\tInvalid entry. Try again: ");
                inputBetAmount = Console.ReadLine();
            }

            Console.Clear();
            Console.WriteLine($"Balance: ${money}");
            Console.WriteLine($"Bet Amount: ${betAmount}\n");


            if (betType == 1)   //TODO: Call bet type methods for each if statement OOORRRR enums/array of each bettype
            {
                BinBet();
            }
            else if (betType == 2)
            {
                //Even or odd
            }
            else if (betType == 3)
            {
                //red or black
            }
            else if (betType == 4)
            {
                // low or high
            }
            else if (betType == 5)
            {
                //dozen
            }
            else if (betType == 6)
            {
                //column
            }
            else if (betType == 7)
            {
                //street
            }
            else if (betType == 8)
            {
                //six
            }
            else if (betType == 9)
            {
                //split
            }
            else if (betType == 0)
            {
                //corners
            }


        }
        public static void BinBet()
        {
            int betNum;
            Console.Write("\tBin Bet! Choose a number to bet on (00-36): ");    //TODO: 00 does not work. Try string?
            string inputBetNum = Console.ReadLine();
            while (!Int32.TryParse(inputBetNum, out betNum) || betNum > 36 || betNum < 0)
            {
                Console.Write("\tInvalid entry. Try again: ");
                inputBetNum = Console.ReadLine();
            }
            
            Random random = new Random();
            int randomIndex = random.Next(0, 1);
            Console.WriteLine($"\tThe winning number is.. {numbers[randomIndex]}!");

            if (betNum == numbers[randomIndex])
            {
                winnings = betAmount * 35;
                IsWinner(true);
            }
            else
            {
                IsWinner(false);
            }
        }
    }
}
