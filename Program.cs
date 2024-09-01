using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            bool numbersHasWon = false;

            int PLAYER_MONEY = 500;
            int playerBet;
            int WINNING_BET = 10;

            const int BONUS = 50;
            const int BONUS_2 = 75;

            char PlayerSelection = 'y';

            int[,] Grid2D = new int[3, 3]; // 3x3 grid 

            int gridChecks(int[,] Gridspace, int x1, int y1, int x2, int y2, int x3, int y3) // method or function for checking the grid
            {
                if (Gridspace[x1, y1] == Gridspace[x2, y2] && Gridspace[x2, y2] == Gridspace[x3, y3])
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

                int firstRowCheck = gridChecks(Grid2D, 0, 0, 0, 1, 0, 2);

                if (firstRowCheck == 1) // checks the first row for matching numbers 
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET);
                    Console.Write($"You've Won {WINNING_BET}");
                    numbersHasWon = true;
                }

                int secondRowCheck = gridChecks(Grid2D, 1, 0, 1, 1, 1, 2);// checks for the secondRow for matching numbers 

                if (secondRowCheck == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET);
                    Console.Write($"You've Won {WINNING_BET}");
                    numbersHasWon = true;
                }

                int thirdRowCheck = gridChecks(Grid2D, 2, 0, 2, 1, 2, 2); // checks for the thirdRow for matching numbers 

                if (thirdRowCheck == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET);
                    Console.Write($"You've Won {WINNING_BET}");
                    numbersHasWon = true;
                }


                //////////vertical checks ///////////////////


                int firstColsCheck = gridChecks(Grid2D, 0, 0, 0, 1, 0, 2); // first column

                if (firstColsCheck == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS);
                    Console.Write($"You've Won: {WINNING_BET}");
                    numbersHasWon = true;
                }


                int secondColsCheck = gridChecks(Grid2D, 1, 0, 1, 1, 1, 2); // second column

                if (secondColsCheck == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS);
                    Console.Write($"You've Won: {WINNING_BET}");
                    numbersHasWon = true;
                }



                int thirdColsCheck = gridChecks(Grid2D, 2, 0, 2, 1, 2, 2); // third column

                if (thirdColsCheck == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS);
                    Console.Write($"You've Won: {WINNING_BET}");
                    numbersHasWon = true;
                }

                int topLeftDiagnol = gridChecks(Grid2D, 0, 0, 1, 1, 2, 2);// top left diagnol check

                if (topLeftDiagnol == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS_2);
                    Console.Write($" You've Won: {WINNING_BET}");
                    numbersHasWon = true;
                }

                int topRightDiagnol = gridChecks(Grid2D, 0, 2, 1, 1, 2, 0);
                if (topRightDiagnol == 1)
                {
                    PLAYER_MONEY += (playerBet + WINNING_BET + BONUS_2);
                    Console.Write($" You've Won: {WINNING_BET}");
                    numbersHasWon = true;
                }

                if (numbersHasWon == false)
                {
                    Console.WriteLine("no winnning numbers");
                }


                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear(); // reset the Grid.

                Console.WriteLine($"Balance is now: {PLAYER_MONEY}");
                Console.Write("Would you like to bet again?");

                PlayerSelection = (Convert.ToChar(Console.ReadLine()));// gets user input for selection 


                if (PlayerSelection == 'y' || PlayerSelection == 'Y')
                {
                    Console.WriteLine("place you bets.");
                    playerBet = Console.Read();
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

