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
            int playerBet = 0;
            const int WINNING_BET = 10;

            const int BONUS = 50; // use for diagonal wins 
            const int BONUS_2 = 75; // use for diagonal wins

         
            int[,] gameSlotsGrid = new int[3, 3]; // 3x3 grid 

            Console.WriteLine($"You have ${PLAYER_MONEY}!"); // user prompt
            Console.Write("Place your Bet: "); playerBet = Console.Read(); // user inputs bet

           
            PLAYER_MONEY -= playerBet;

            Console.WriteLine($"Balance is now: {PLAYER_MONEY}"); // amount after the player has bet

            const int LOW = 0; // const low number 
            const int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random(); // this is the random seed 


            while (!quit)
            {
                //////// the nested loop displays the grid //////////////////
                for (int rows = 0; rows < gameSlotsGrid.GetLength(0); rows++) // loops through the rows 
                {
                    for (int cols = 0; cols < gameSlotsGrid.GetLength(1); cols++) // loops through the columns
                    {
                        int randNumInArray = range.Next(LOW, HIGH); // variable to store the random number also so that "random" 'resets' after each loop 
                        Console.Write((gameSlotsGrid[rows, cols] = randNumInArray) + " ");    // adding ranNumInArray value into elements
                    }
                    Console.WriteLine(); // this makes sure that everthing get printed on the next line.
                }
                /////////////////////////////////////////////////////////////////////////////

                // the  loops rows checks through the grid
                for (int rows = 0; rows < gameSlotsGrid.GetLength(0); rows++) // this loops through the rows
                {
                    int checkEqualNumbers = gameSlotsGrid[rows, 0]; // starts with the first element 
                    bool allMatch = true; // bool set to true

                    for (int cols = 0; cols < gameSlotsGrid.GetLength(1); cols++)// this loops through cols
                    {
                        if (gameSlotsGrid[rows, cols] != checkEqualNumbers) //checks if numbers are not the same
                        {
                            allMatch = false;
                            break; // breaks out of the loop if it finds a match
                        }
                    }

                    if (allMatch) // if all number in a row match is true
                    {
                        //numbersHasMactched = true;
                        PLAYER_MONEY += WINNING_BET + BONUS;
                        Console.WriteLine($"You've Won Wining bet: ${WINNING_BET} + Bonus: ${BONUS}");
                        break;
                    }

                }
                // loops cols checks through the grid
                for (int cols = 0; cols < gameSlotsGrid.GetLength(0); cols++) // this loops through the rows
                {
                    int checkEqualNumbers = gameSlotsGrid[0, cols]; // this will check the first element of the columns
                    bool allMatch = true; // bool set

                    for (int rows = 0; rows < gameSlotsGrid.GetLength(1); rows++) // this loops through rows
                    {
                        if (gameSlotsGrid[rows, cols] != checkEqualNumbers) // checks if the numbers are not the same
                        {
                            allMatch = false;
                            break;
                        }
                    }

                    if (allMatch) //  if all number in a cols match is true
                    {
                        //numbersHasMactched = true;
                        PLAYER_MONEY += WINNING_BET + BONUS + playerBet;
                        Console.WriteLine($"You've won ${WINNING_BET} + ${BONUS}");
                        break;
                    }
                }

                ///////////////// Top Left diagonal check/////////////////
                int firstDiagonalValue = gameSlotsGrid[0, 0]; // start the check with firstDiagonalValue in the loop 
                bool allDiagonalMatch = true; // bool set to true

                for (int i = 0; i < gameSlotsGrid.GetLength(0); i++)
                {
                    if (gameSlotsGrid[i, i] != firstDiagonalValue) // compares each diagional element
                    {
                        allDiagonalMatch = false; // if the first element doesnt work the loop will break
                        break;
                    }

                }

                if (allDiagonalMatch)
                {
                    PLAYER_MONEY += WINNING_BET + BONUS_2 + playerBet;
                    Console.WriteLine($" You've won ${WINNING_BET} + ${BONUS_2}");
                }
               
                //////////////////////Top Right diagonal check/////////////////////////

                for (int i = 0; i < gameSlotsGrid.GetLength(0); i++)
                {
                    if (gameSlotsGrid[i, gameSlotsGrid.GetLength(1) - 1 - i] != firstDiagonalValue) // this starts at the end of the 1st diamension 
                    {
                        allDiagonalMatch = false;
                        break;
                    }
                }
                if (allDiagonalMatch)
                {
                    Console.WriteLine($"You've won {WINNING_BET} + {BONUS_2}");
                    PLAYER_MONEY += WINNING_BET + BONUS_2 + playerBet;
                }

                ///////////////////////////////////////////////
                if (numbersHasMactched) 
                {
                    Console.WriteLine($"You've have Won: ${WINNING_BET}");
                    PLAYER_MONEY += WINNING_BET; // add wining numbers
                }

                else
                {
                    Console.WriteLine("there are no matching numbers ");
                }

                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();

                Console.Clear(); // reset the Grid.

                Console.WriteLine($"Balance is now: {PLAYER_MONEY}");
                Console.WriteLine("Would you like to bet again? (Y/N)");

                string PlayerToContinueSelection = Console.ReadLine().ToLower();// gets user input for selection 

                if (PlayerToContinueSelection == "y")
                {
                    Console.WriteLine("place you bets:");
                    playerBet = Convert.ToInt32(Console.ReadLine()); // gets the bet amount from user
                    PLAYER_MONEY -= playerBet;
                }

                if (PlayerToContinueSelection == "n" || PLAYER_MONEY <= 0) // check if player has selected n or had bet all of the money
                {
                    quit = true;
                    Console.WriteLine($"Game Over bets are closed, Your total: {PLAYER_MONEY}");
                }
            }
        }
    }
}




