
using System;

namespace SlotMachine
{
    class Ui_Methods
    {
        public static void DisplayPlayerWinningBetMessage()
        {
            Console.WriteLine($"You've Won Winning bet: ${ConstantVars.WINNING_BET} + Bonus: ${ConstantVars.BONUS}");
        }

        public static void DisplayingPlayerBalanceUpdate(int userbalance)
        {
            Console.WriteLine($"Balance is now: ${userbalance}"); // amount after the player has bet PLayer money isn't a constant
        }

        public static string PlayerToContinueSelection()
        {
            Console.WriteLine("Would you like to continue?....");
            string PlayerToContinueSelection = Console.ReadLine().ToLower(); // gets user input for selection: (Y/N)
            return PlayerToContinueSelection;
        }
        public static void PlayerHasContinuedTheGameMessage()
        {
            Console.WriteLine("You have decided to continue the game Good luck :D");
        }
        public static void DisplayingTheNumbersDoNotMatchMessage()
        {
            Console.WriteLine("The numbers do not match");
            Console.WriteLine("Press any key to continue.....");
            Console.ReadKey(); // waits for user input.
        }
        public static string UserInput()
        {
            string UserInputIntoSelection = Console.ReadLine();
            return UserInputIntoSelection;
        }
        public static int GetUserBet(int userMoney)
        {
            Console.WriteLine("Place your Bet:");
            int input = Convert.ToInt32(Console.ReadLine()); // user inputs bet
            {
                do
                {
                    if (input < 0) // Checks to see if the user input is less than 0 and not greater that usermoney amount
                    {
                        Console.WriteLine("Invalid Amount! please re-enter betting amount:");
                        input = Convert.ToInt32(Console.ReadLine()); // user inputs bet
                    }
                    if (input > userMoney)
                    {
                        Console.WriteLine("Bet amount exceedes that of the player amount, please re-enter betting amount lower than account");
                        input = Convert.ToInt32(Console.ReadLine()); // user inputs bet 
                    }

                }
                while (input < 0 || input > userMoney); // loop until user input is greater than 0

                return input;
            }
        }

        public static void DisplayingGameOverMessage(int userBalance)
        {
            Console.WriteLine($"Game Over bets are closed, Your total: ${userBalance}");
        }

        public static void DisplayingWinningsAndBonusesToTheUser(int UserBalance)
        {
            UserBalance += ConstantVars.WINNING_BET + ConstantVars.BONUS;
            Console.WriteLine($"You've Won Wining bet: ${ConstantVars.WINNING_BET} + Bonus: ${ConstantVars.BONUS}");
        }

        public static void PromptingUserToClearTheSlotsGrid()
        {
            // used because the screen needs to have a clean interface
            Console.WriteLine("Press Enter to clear screen");
            Console.ReadKey();
            Console.Clear(); // reset the Grid.
        }

        public static int DisplayingTotalDifferenceOfAmountOfMoney(int Money, int userBetVar) // might have to change this to return a value
        {
            int retuningBothValues = Money -= userBetVar;
            Console.WriteLine($"You Have this much: ${retuningBothValues}");
            return retuningBothValues;
        }
        public static void DisplaySlotGameGrid(int[,] grid)
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

        public static int GetValidGameMode()
        {
            bool istheSelectionValid = false; // this is the bool that will be used to check if the user input is valid
            Console.WriteLine($"Select your Game: " +
               $"{ConstantVars.SELECT_ROWS_GAME}:ROWS " +
               $"{ConstantVars.SELECT_COLOUMNS_GAME}:COLOUMS " +
               $"{ConstantVars.SELECT_TOP_LEFT_DIAGONAL_GAME}:DIAGONAL " +
               $"{ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME}:TOP RIGHT DIAGONAL " +
               $"{ConstantVars.SELECT_CENTER_LINE_GAME}:CENTER");

            string userInput = Ui_Methods.UserInput();
            int gameSelection;
            do // this will check if the user input is valid
            {
                
                if (Int32.TryParse(userInput, out gameSelection)) // this will catch the user input 
                {
                    if (gameSelection == ConstantVars.SELECT_ROWS_GAME || // all gameselection 
                        gameSelection == ConstantVars.SELECT_COLOUMNS_GAME ||
                        gameSelection == ConstantVars.SELECT_TOP_LEFT_DIAGONAL_GAME ||
                        gameSelection == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME ||
                        gameSelection == ConstantVars.SELECT_CENTER_LINE_GAME)
                    {
                        Console.WriteLine($"you've selected Game Mode: {gameSelection}");
                        istheSelectionValid = true; // bool set to true and selection is valid
                    }
                    else
                    {
                        Console.WriteLine(" ERROR! This is not the correct selection, Please try again"); // if the selection is not true
                        userInput = Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a vaild number ");
                    userInput = Console.ReadLine();
                }
            }
            while (!istheSelectionValid); // loop until true

            return gameSelection; // return the valid game selection
        }

    }
}

