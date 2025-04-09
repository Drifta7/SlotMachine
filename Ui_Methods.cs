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
        public static string PlayerToContinueSelection()
        {
            string PlayerToContinueSelection = Console.ReadLine().ToLower();// gets user input for selection: (Y/N)
            return PlayerToContinueSelection;
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
            ConstantVars.PLAYER_MONEY -= ConstantVars.playerBet; // takes away from User money total
        }

        public static string PromptingUserToContinueGame()
        {
            Console.WriteLine("Do you want to continue? (Y/N)");
            string UserSelection = Console.ReadLine().ToLower();
            return UserSelection;
        }
        public static void DisplayingGameOverMessage()
        {
            Console.WriteLine($"Game Over bets are closed, Your total: {ConstantVars.PLAYER_MONEY}");
        }
        public static void ValidatingUserEntryToContinueGame() // not sire if im going to use this.....
        {

        }

        public static void DisplayingAskingUserToBetAgain()
        {
            Console.WriteLine("Would you like to bet again? (Y/N)");
        }
        public static void DisplayingWinningsAndBonusesToTheUser()
        {
            ConstantVars.PLAYER_MONEY += ConstantVars.WINNING_BET + ConstantVars.BONUS;
            Console.WriteLine($"You've Won Wining bet: ${ConstantVars.WINNING_BET} + Bonus: ${ConstantVars.BONUS}");
            bool gameModeRestart = true; // use this in the new main file program // use this in the actual program gameModeRestart = false;
        }

        public static void PromptingUserToClearTheSlotsGrid()
        {
            // used because the screen needs to have a clean interface
            Console.WriteLine("Press Enter to clear screen");
            Console.ReadKey();
            Console.Clear(); // reset the Grid.
        }

        public static int DisplayingTotalDifferenceOfAmountOfMoney() // might have to change this to return a value
        {
            return ConstantVars.retuningBothValues = ConstantVars.PLAYER_MONEY -= ConstantVars.playerBet;
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

        public static void DisplayingPlayerContinueGameMessage()
        {
    
            if (Ui_Methods.PlayerToContinueSelection() == ConstantVars.PLAYER_TO_CONTINUE_ACCEPT)
            {
                Console.WriteLine($"Select your Game: {ConstantVars.SELECT_ROWS_GAME}: Rows {ConstantVars.SELECT_COLOUMNS_GAME}: Columns {ConstantVars.SELECT_DIAGONAL_GAME}: Diagonal {ConstantVars.SELECT_CENTER_LINE_GAME}: Center ");
                string userInput = Ui_Methods.UserInput();
                int gameSelectionReplay; // input game selection
                bool quit = false; // this is used to check if the user has selected to quit the game

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
                            userInput = Ui_Methods.UserInput();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a vaild number ");
                        userInput = Ui_Methods.UserInput();
                    }
                }
                while (!istheSelectionValidReplay); // loop until true

                PromptingUserToPlaceBet(); // this will ask the user to place a bet

            }

            if (Ui_Methods.PlayerToContinueSelection() == ConstantVars.PLAYER_TO_CONTINUE_DECLINE || ConstantVars.PLAYER_MONEY <= 0) // check if player has selected n or had bet all of the money
            {
                quit = true;
                Console.WriteLine($"Game Over bets are closed, Your total: {ConstantVars.PLAYER_MONEY}");
            }
        }
    }
}

