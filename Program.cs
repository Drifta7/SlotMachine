using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            int PLAYER_MONEY = 500;
            int playerBet;
            int WINNING_BET = 10;

            const int BONUS = 50;
            const int BONUS_2 = 75;

            char PlayerSelection = 'y';

            int[,] Grid2D = new int[3, 3]; // 3x3 grid created 
            int gridChecks(int[,] array, int x1, int y1, int x2, int y2, int x3, int y3)
            {
                if (array[x1, y1] == array[x2, y2] && array[x2, y2] == array[x3, y3])
                {

                    return 1;
                }


                else
                {
                    return 0; //
                }
            }


            Console.WriteLine($" You have ${PLAYER_MONEY}!");
            Console.Write(" Place your Bet ");

            playerBet = Console.Read(); // take players input
            PLAYER_MONEY -= playerBet; //here player bet substract from PlayerMONEY

            Console.WriteLine($"Balance is now: {PLAYER_MONEY}"); // amount after the player has bet

            const int LOW = 0; // const low number 
            const int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random(); // this is the random seed 

            while (!quit)
            {

                for (int rows = 0; rows < Grid2D.GetLength(0); rows++)
                {
                    for (int cols = 0; cols < Grid2D.GetLength(1); cols++)
                    {
                        int randNumInArray = range.Next(LOW, HIGH); // variable to store the random number 
                        Console.Write((Grid2D[rows, cols] = randNumInArray) + " ");    // adding ranNumInArray value into elements
                    }
                    Console.WriteLine(); // this makes sure that everthing get printed on the next line.
                }

                /////// horizontal checks///////
                if (Grid2D[0, 0] == Grid2D[0, 1] && Grid2D[0, 1] == Grid2D[0, 2]) // 1st row (winning match)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET);
                    Console.Write($"You've Won{WINNING_BET}");

                }

                if (Grid2D[1, 0] == Grid2D[1, 1] && Grid2D[1, 1] == Grid2D[1, 2]) // 2nd row
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET);
                    Console.Write($"You've Won{WINNING_BET}");
                }


                if (Grid2D[2, 0] == Grid2D[2, 1] && Grid2D[2, 1] == Grid2D[2, 2]) // 3rd row
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET);
                    Console.Write($"You've Won{WINNING_BET}");
                }


                //////////vertical checks ///////////////////


                if (Grid2D[0, 0] == Grid2D[1, 0] && Grid2D[1, 0] == Grid2D[2, 0]) // 1st col
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS);
                    Console.Write($"You've Won: {WINNING_BET}");
                }


                if (Grid2D[0, 1] == Grid2D[1, 1] && Grid2D[1, 1] == Grid2D[2, 1]) // 2nd col
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS);
                    Console.Write($"You've Won: {WINNING_BET}"); ;
                }


                if (Grid2D[2, 0] == Grid2D[1, 2] && Grid2D[1, 2] == Grid2D[2, 2]) // 3rd col
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS);
                    Console.Write($"You've Won{WINNING_BET}");
                }


                ///// Diagonal check (left to bottom right) ////

                if (Grid2D[0, 0] == Grid2D[1, 1] && Grid2D[1, 1] == Grid2D[2, 2])
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS_2);
                    Console.Write($"You've Won{WINNING_BET} +{BONUS_2}");
                }

                ///Diagonal (top right to bottom left) /////

                if (Grid2D[0, 2] == Grid2D[1, 1] && Grid2D[1, 1] == Grid2D[2, 0])
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS_2);
                    Console.Write($"You've Won{WINNING_BET} + {BONUS_2}");
                }

                ///negative check////
                ///



                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear(); // reset the Grid.

                Console.WriteLine($"Balance is now: {PLAYER_MONEY}");
                Console.Write("Would you like to bet again?");

                PlayerSelection = (Convert.ToChar(Console.ReadLine()));


                Console.WriteLine("place you bets.");
                playerBet = Console.Read();

                if (PlayerSelection == 'y' || PlayerSelection == 'Y')
                {
                    PLAYER_MONEY -= playerBet;
                    Console.WriteLine($"You Now have {PLAYER_MONEY}");

                }

                if (PlayerSelection == 'n' || PlayerSelection == 'N' || PLAYER_MONEY <= 0)
                {
                    quit = true;
                    Console.WriteLine("Game Over");

                }
            }
        }
    }
}

