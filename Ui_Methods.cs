using SlotMachineRefactored;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Ui_Methods
    {
        public static void DisplayPlayerWinningBetMessage()
        {
            Console.WriteLine($"You've Won Winning bet: ${ConstantVars.WINNING_BET} + Bonus: ${ConstantVars.BONUS}");
        }

        public static void DisplayingPlayerBalanceUpdate()
        {
            Console.WriteLine($"Balance is now: {ConstantVars.PLAYER_MONEY}"); // amount after the player has bet

        }
        public static void DisplayCurrentAmountOfMoney()
        {
            Console.WriteLine($"You have {ConstantVars.PLAYER_MONEY}!");
        }
        public static string PromptingUserToSelectGameMode()
        {
            Console.WriteLine($"Select your Game: {ConstantVars.SELECT_ROWS_GAME}:ROWS {ConstantVars.SELECT_COLOUMNS_GAME}:COLOUMS {ConstantVars.SELECT_DIAGONAL_GAME}:DIAGONAL {ConstantVars.SELECT_CENTER_LINE_GAME}:CENTER");
            string UserSelection = Console.ReadLine();
            return UserSelection;
        }
        public static void DisplayingTheNumbersDoNotMatchMessage()
        {
            Console.WriteLine("The numbers do not match");
            Console.WriteLine("Press and key to continue.....");
        }
        public static string UserInput()
        {
            string UserInputIntoSelection = Console.ReadLine();
            return UserInputIntoSelection;
        }

        public static void PromptingUserToPlaceBet()
        {
            Console.WriteLine("Place your Bet:");
            ConstantVars.playerBet = Convert.ToInt32(Console.ReadLine()); // user inputs bet
        }

        public static string PromptingUserToContinueGame()
        {
            Console.WriteLine("Do you want to continue? (Y/N)");
            string UserSelection = Console.ReadLine().ToLower();
            return UserSelection;
        }
        public static void DisplayingWinningsAndBonusesToTheUser()
        {

            ConstantVars.PLAYER_MONEY += ConstantVars.WINNING_BET + ConstantVars.BONUS;
            Console.WriteLine($"You've Won Wining bet: ${ConstantVars.WINNING_BET} + Bonus: ${ConstantVars.BONUS}");
            BooleansForRefactor.gameModeRestart = true; // use this in the new main file program // use this in the actual program gameModeRestart = false;
        }

        public static void PromptUserToRestartTheSlotsGrid()
        {
            // used because the screen needs to have a clean interface
            Console.ReadKey();
            Console.Clear(); // reset the Grid.
        }

        public static void DisplayingTotalAmountOfMoneyDifference()
        {
            ConstantVars.PLAYER_MONEY -= ConstantVars.playerBet;
        }   
        public static void DisplayingSlotGameGrid(int[,] grid)
        {
            Random range = new Random(); // this is used because it will randomize the number inbetween the range from low to high
            for (int rows = 0; rows < grid.GetLength(0); rows++) // loops through the rows 
            {
                for (int cols = 0; cols < grid.GetLength(1); cols++) // loops through the columns
                {
                    int randNumInArray = range.Next(ConstantVars.LOW, ConstantVars.HIGH); // variable to store the random number also so that "random" 'resets' after each loop 
                    Console.Write((grid[rows, cols] = randNumInArray) + " ");    // adding ranNumInArray value into elements of the array
                }
                Console.WriteLine(); // this makes sure that everything get printed on the next line.
            }
        }


        public static void GameSelectionRows(int[,] grid)
        {
            if (ConstantVars.gameSelection == ConstantVars.SELECT_ROWS_GAME)
            {
                bool numberHasMatched = false; // bool set to false
                                               // the  loops rows checks through the grid
                for (int rows = 0; rows < grid.GetLength(0); rows++) // this loops through the rows
                {
                    int checkEqualNumbers = grid[rows, 0]; // starts with the first element 
                    bool allMatch = true; // bool set to true

                    for (int cols = 0; cols < grid.GetLength(1); cols++)// this loops through cols
                    {
                        if (grid[rows, cols] != checkEqualNumbers) //checks if numbers are not the same
                        {
                            allMatch = false;
                            break; // breaks out of the loop if it finds a match
                        }
                    }
                }
            }
        }
        public static bool GameSelectionColumns(int[,] grid)
        {
            bool numbersHasMatched = false;
            // loops cols checks through the grid
            for (int cols = 0; cols < grid.GetLength(0); cols++) // this loops through the rows
            {
                int checkEqualNumbers = grid[0, cols]; // this will check the first element of the columns
                bool allMatch = true; // bool set

                for (int rows = 0; rows < grid.GetLength(1); rows++) // this loops through rows
                {
                    if (grid[rows, cols] != checkEqualNumbers) // checks if the numbers are not the same
                    {
                        allMatch = false;
                        break;
                    }
                }

                if (allMatch)
                {
                    return true;
                }
            }
                return false;   // if no match is found 
        }

        public static bool GameSelectionCenterLine(int[,] grid)
        {
            int firstCenterValue = grid[1, 0];
            bool CenterArrayMatches = true;
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                if (grid[1, i] != firstCenterValue) // this checks the middle row of gameSlotGrid
                {
                    CenterArrayMatches = false;
                    break;
                }
            }
            return CenterArrayMatches;
        }
        public static void GameSelectionDiagonal(int[,] grid)
        {
            if (ConstantVars.gameSelection == ConstantVars.SELECT_DIAGONAL_GAME)
            {
                int firstDiagonalValue = grid[0, 0]; // start the check with firstDiagonalValue in the loop 
                bool allDiagonalMatch = true; // bool set to true

                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    if (grid[i, i] != firstDiagonalValue) // compares each diagional element
                    {
                        allDiagonalMatch = false; // if the first element doesnt work the loop will break
                        break;
                    }
                }
            }
        }

        public static void GameSelectionTopRightDiagonal(int[,] grid)
        {
            if (ConstantVars.gameSelection == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
            {
                BooleansForRefactor.allDiagonalMatch = true;
                int firstDiagonalValue = grid[0, 0];
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    if (grid[i, grid.GetLength(1) - 1 - i] != firstDiagonalValue) // this starts at the end of the 1st dimension 
                    {
                        BooleansForRefactor.allDiagonalMatch = false;
                        break;
                    }
                }
            }
        }

        public static void DisplayingPlayerContinueGameMessage()
        {
            Logic.PlayerToContinueSelection = Console.ReadLine().ToLower();// gets user input for selection: (Y/N)
            if (Logic.PlayerToContinueSelection == ConstantVars.PLAYER_TO_CONTINUE_ACCEPT)
            {
                Console.WriteLine($"Select your Game: {ConstantVars.SELECT_ROWS_GAME}: Rows {ConstantVars.SELECT_COLOUMNS_GAME}: Columns {ConstantVars.SELECT_DIAGONAL_GAME}: Diagonal {ConstantVars.SELECT_CENTER_LINE_GAME}: Center ");
                string userInput = Ui_Methods.UserInput();
                int gameSelectionReplay; // input game selection


                bool istheSelectionValidReplay = false;
                do // this will check if the user input is valid
                {

                    if (Int32.TryParse(userInput, out gameSelectionReplay)) // this will catch the user input if it is invalid
                    {

                        if (gameSelectionReplay == ConstantVars.SELECT_ROWS_GAME || gameSelectionReplay == ConstantVars.SELECT_COLOUMNS_GAME || gameSelectionReplay == ConstantVars.SELECT_DIAGONAL_GAME || gameSelectionReplay == ConstantVars.SELECT_CENTER_LINE_GAME)
                        {
                            Console.WriteLine($"you've have selected {gameSelectionReplay}");
                            istheSelectionValidReplay = true; // bool set to true and selection is valid
                        }
                        else // this catches incorrect number inputs
                        {
                            Console.WriteLine("NUMBER ERROR! This is not the correct selection, Please try again"); // if the selection is not true
                            userInput = Console.ReadLine();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a vaild number ");
                        userInput = Console.ReadLine();
                    }
                }
                while (!istheSelectionValidReplay); // loop until true

                Console.WriteLine("place you bets:");
                ConstantVars.playerBet = Convert.ToInt32(Console.ReadLine()); // gets the bet amount from user
                ConstantVars.PLAYER_MONEY -= ConstantVars.playerBet; // takes away from User money total
            }

            if (Logic.PlayerToContinueSelection == ConstantVars.PLAYER_TO_CONTINUE_DECLINE || ConstantVars.PLAYER_MONEY <= 0) // check if player has selected n or had bet all of the money
            {
                BooleansForRefactor.quit = true;
                Console.WriteLine($"Game Over bets are closed, Your total: {ConstantVars.PLAYER_MONEY}");
            }
        }
    }
}

