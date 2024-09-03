using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            bool numbersHasMactched = false;

            int PLAYER_MONEY = 500;
            int playerBet;
            int WINNING_BET = 10;

            const int BONUS = 50;
            const int BONUS_2 = 75;

            char PlayerSelection = 'y';


            int[,] Grid2D = new int[3, 3]; // 3x3 grid 

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
                // The 2 for loops creates the array grid for the slots game
                for (int rows = 0; rows < Grid2D.GetLength(0); rows++) // loops through the rows 
                {
                    for (int cols = 0; cols < Grid2D.GetLength(1); cols++) // loops through the columns
                    {
                        int randNumInArray = range.Next(LOW, HIGH); // variable to store the random number also so that "random" 'resets' after each loop 
                        Console.Write((Grid2D[rows, cols] = randNumInArray) + " ");    // adding ranNumInArray value into elements
                    }
                    Console.WriteLine(); // this makes sure that everthing get printed on the next line.
                }


                // the  loops rows checks through the grid
                for (int rows = 0; rows < Grid2D.GetLength(0); rows++) // this loops through the rows
                {
                    int checkEqualNumbers = Grid2D[rows, 0]; // starts with the first element 
                    bool allMatch = true; // bools set
                    for (int cols = 0; cols < Grid2D.GetLength(1); cols++)// this loops through cols
                    {
                        if (Grid2D[rows, cols] != checkEqualNumbers) //checks if numbers are not the same
                        {
                            allMatch = false;
                            break; // breaks out of the loop if it finds a match
                        }
                    }

                    if (allMatch) // if all number in a row match is true
                    {
                        numbersHasMactched = true;
                        break;
                    }
                }
                // loops cols checks through the grid
                for (int cols = 0; cols < Grid2D.GetLength(0); cols++) // this loops through the rows
                {
                    int checkEqualNumbers = Grid2D[0, cols]; // this will check the first element of the columns
                    bool allMatch = true; // bool set
                    for (int rows = 0; rows < Grid2D.GetLength(1); rows++) // this loops through rows
                    {
                        if (Grid2D[rows, cols] != checkEqualNumbers) // checks if the numbers are not the same
                        {
                            allMatch = false;
                            break;
                        }
                    }

                    if (allMatch) //  if all number in a cols match is true
                    {
                        numbersHasMactched = true;
                        break;
                    }
                }

                if (numbersHasMactched) // declares if you've won or there are no matching numbers and 
                {
                    Console.WriteLine("You've have Won");
                }

                else
                {
                    Console.WriteLine("the are no matching numbers ");
                }

                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear(); // reset the Grid.

                Console.WriteLine($"Balance is now: {PLAYER_MONEY}");
                Console.Write("Would you like to bet again?");

                PlayerSelection = (Convert.ToChar(Console.ReadLine()));// gets user input for selection 

                if (PlayerSelection == 'y' || PlayerSelection == 'Y') // still an issue with this , It doesn't wait for the user input
                {
                    Console.WriteLine("place you bets.");
                    playerBet = Console.Read();
                    PLAYER_MONEY -= playerBet;
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


