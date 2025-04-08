using System;



namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {


            bool quit = false;
            bool numbersHaveMatched = false;
            bool numberHasMatched = false; // bool set to false

            bool haveTheNumbersMatched;

            int[,] gameSlotsGrid = new int[3, 3]; // 3x3 2d grid 

            int PLAYER_MONEY = 500;
            Ui_Methods.DisplayCurrentAmountOfMoney();

            Ui_Methods.PromptingUserToSelectGameMode();

            //left off here!
            int gameSelection; // input game selection
            string userInput = Console.ReadLine();

            bool istheSelectionValid = false;
            Logic.ValidatingUserInputForGameSelection();

            int playerBet = 0;

            Ui_Methods.PromptingUserToPlaceBet();



            haveTheNumbersMatched = Logic.CheckForWin(gameSlotsGrid); // left off here 

            Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney();
            PLAYER_MONEY -= playerBet;

            //Console.WriteLine($"Balance is now: {PLAYER_MONEY}"); // amount after the player has bet
            Ui_Methods.DisplayingPlayerBalanceUpdate();


            //Random range = new Random(); // this is the random seed 

            bool gameModeRestart = false;
            bool numbersHasMactched = false;

            while (!quit || !gameModeRestart)
            {
                Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid); // correct!

                /////////////////////////////////////////////////////////////////////////////


                /////// Rows game check ///////////////
                if (ConstantVars.gameSelection == ConstantVars.SELECT_ROWS_GAME)
                {
                    bool allMatch = Logic.GameSelectionRows(gameSlotsGrid);


                    if (allMatch) // if all number in a row match is true
                    {
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser();
                        numberHasMatched = true;
                        gameModeRestart = true;
                        break; // add this after the method call
                    }
                }
                if (!numberHasMatched)
                {
                    Ui_Methods.DisplayingTheNumbersDoNotMatchMessage(); // replaced here because lines of code were repeated
                    gameModeRestart = true;
                }
            }
            /////////////////////////////////CenterLine check/////////////////////////////////////////

            if (ConstantVars.gameSelection == ConstantVars.SELECT_CENTER_LINE_GAME)
            {
                bool CenterArrayMatches = Logic.GameSelectionCenterLine(gameSlotsGrid); // replaced the lines of code with the method

                if (CenterArrayMatches)
                {
                    Ui_Methods.DisplayingWinningsAndBonusesToTheUser(); // replaced here because lines of code were repeated
                    gameModeRestart = true;
                }
                else
                {
                    Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();// replaced the lines of code with the method
                    gameModeRestart = true;
                }
            }


            if (ConstantVars.gameSelection == ConstantVars.SELECT_COLOUMNS_GAME)
            {
                Logic.GameSelectionColumns(gameSlotsGrid);// replaced the lines of code with the method

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

                    if (haveTheNumbersMatched) // if all number in a cols match is true
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage(); // replaced here because lines of code were repeated
                        gameModeRestart = true;
                        break;
                    }
                }

                if (!numbersHasMactched)
                {
                    Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                    gameModeRestart = true;
                }
            }
            ///////////////// Top Left diagonal check/////////////////

            if (ConstantVars.gameSelection == ConstantVars.SELECT_DIAGONAL_GAME)
            {
                int firstDiagonalValue = gameSlotsGrid[0, 0]; // start the check with firstDiagonalValue in the loop 
                bool allDiagonalMatch = true; // bool set to true

                Logic.GameSelectionTopLeftDiagonal(gameSlotsGrid); // replaced the lines of code with the method

                if (allDiagonalMatch)
                {
                    Ui_Methods.DisplayPlayerWinningBetMessage(); // placed here becasue the method does the same thing 
                    gameModeRestart = true;
                }
                if (!allDiagonalMatch) //this is needed do not delete allDiagonalMatch ///Left off here!!!
                {
                    Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();// replaced the lines of code with the method
                    gameModeRestart = true;
                }
                //////////////////////Top Right diagonal check/////////////////////////

                Logic.GameSelectionTopRightDiagonal(gameSlotsGrid);// replaced the lines of code with the method

                if (allDiagonalMatch)
                {
                    Ui_Methods.DisplayPlayerWinningBetMessage();
                    gameModeRestart = true;

                }
                if (!allDiagonalMatch)
                {
                    Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                    gameModeRestart = true;
                }
                ///////////////////////////////////////////////
                if (numbersHasMactched)
                {
                    Ui_Methods.DisplayPlayerWinningBetMessage();
                    gameModeRestart = true;
                }

                else
                {
                    Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                }
            }

            Ui_Methods.PromptingUserToClearTheSlotsGrid();

            Ui_Methods.DisplayingPlayerBalanceUpdate(); // this will display the players balance after the game has been played

            // make a methos for this

            Ui_Methods.DisplayingAskingUserToBetAgain();


            if (Ui_Methods.PlayerToContinueSelection() == ConstantVars.PLAYER_TO_CONTINUE_ACCEPT)
            {
                Ui_Methods.DisplayingPlayerContinueGameMessage();
                Console.WriteLine($"Select your Game: {ConstantVars.SELECT_ROWS_GAME}: Rows {ConstantVars.SELECT_COLOUMNS_GAME}: Columns {ConstantVars.SELECT_DIAGONAL_GAME}: Diagonal {ConstantVars.SELECT_CENTER_LINE_GAME}: Center ");
                
                Ui_Methods.UserInput();
                int gameSelectionReplay; // input game selection

                bool isTheSelectionValidForReplay = false;
                do // this will check if the user input is valid
                {

                    if (Int32.TryParse(userInput, out gameSelectionReplay)) // this will catch the user input if it is invalid
                    {

                        if (gameSelectionReplay == ConstantVars.SELECT_ROWS_GAME || gameSelectionReplay == ConstantVars.SELECT_COLOUMNS_GAME
                         || gameSelectionReplay == ConstantVars.SELECT_DIAGONAL_GAME || gameSelectionReplay == ConstantVars.SELECT_CENTER_LINE_GAME)
                       
                        {
                            Console.WriteLine($"you've have selected {gameSelectionReplay}");
                            isTheSelectionValidForReplay = true; // bool set to true and selection is valid
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
                while (!isTheSelectionValidForReplay); // loop until true

                Console.WriteLine("place you bets:");
                playerBet = Convert.ToInt32(Console.ReadLine()); // gets the bet amount from user
                PLAYER_MONEY -= playerBet; // takes away from User money total
            }

            if (Ui_Methods.PlayerToContinueSelection() == ConstantVars.PLAYER_TO_CONTINUE_DECLINE || PLAYER_MONEY <= 0) // check if player has selected n or had bet all of the money
            {
                quit = true;
                Ui_Methods.DisplayingGameOverMessage();
            }
        }
    }
}





