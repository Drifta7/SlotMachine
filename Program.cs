using SlotMachineRefactored;
using System;



namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            bool numberHasMatched = false; // bool set to false
            bool haveTheNumbersMatched;
            bool gameModeRestart = false;


            int[,] gameSlotsGrid = new int[3, 3]; // 3x3 2d grid 

            int PLAYER_MONEY = 500;
            int gameSelection = 0; // input game selection

            Ui_Methods.DisplayCurrentAmountOfMoney();


            Logic.ValidatingUserInputForGameSelection(); //????

            //  int playerBet = 0; // probably will delete this

            Ui_Methods.PromptingUserToPlaceBet();

            haveTheNumbersMatched = Logic.CheckForWin(gameSlotsGrid); // not sure if Im going to use this 

            Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney();
            Ui_Methods.DisplayingPlayerBalanceUpdate();


            while (!quit || !gameModeRestart) // loop within the methods
            {
                Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid);

                /////////////////////////////////////////////////////////////////////////////

                string TheUserInput = Ui_Methods.UserInput(); // this will get the user input

                /////// Rows game check ///////////////

                Logic.ValidatingByParsingTheUserInput(TheUserInput, gameSelection); // this will check if the user input is valid

                if (GameVariables.gameSelection == ConstantVars.SELECT_ROWS_GAME)
                {
                    bool allMatch = Logic.RowsGameCheck(gameSlotsGrid);

                    if (allMatch) // if all number in a row match is true
                    {
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser();
                        numberHasMatched = true;
                        gameModeRestart = true;
                        Ui_Methods.PromptingUserToPlaceBet();

                    }

                    if (!numberHasMatched)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage(); // replaced here because lines of code were repeated
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(); // this will display the players balance after the game has been played

                        Ui_Methods.PromptingUserToPlaceBet();
                        gameModeRestart = true;
                    }

                    /////////////////////////////////CenterLine check/////////////////////////////////////////

                    Logic.ValidatingByParsingTheUserInput(TheUserInput, gameSelection); // this will check if the user input is valid
                    if (GameVariables.gameSelection == ConstantVars.SELECT_CENTER_LINE_GAME)
                    {
                        bool CenterArrayMatches = Logic.CenterLineGameCheck(gameSlotsGrid); // replaced the lines of code with the method

                        if (CenterArrayMatches) // if all the number that match is true
                        {
                            Ui_Methods.DisplayingWinningsAndBonusesToTheUser(); // replaced here because lines of code were repeated
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }

                        if (!CenterArrayMatches)
                        {
                            Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();// replaced the lines of code with the method
                            Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney();
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }
                    }
                    /////////////////////// Columns game check/////////////////////////////////////////

                    Logic.ValidatingByParsingTheUserInput(TheUserInput, gameSelection); // this will check if the user input is valid
                    if (GameVariables.gameSelection == ConstantVars.SELECT_COLOUMNS_GAME)
                    {
                        bool numbersHaveMatched = Logic.ColumnsGameCheck(gameSlotsGrid);// 

                        if (haveTheNumbersMatched) // if all number in a cols match is true
                        {
                            Ui_Methods.DisplayPlayerWinningBetMessage(); // replaced here because lines of code were repeated
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }

                        if (!haveTheNumbersMatched)
                        {
                            Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                            Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(); // this will display the players balance after the game has been played
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }
                    }
                    ///////////////// Top Left diagonal check/////////////////

                    Logic.ValidatingByParsingTheUserInput(TheUserInput, gameSelection); // this will check if the user input is valid

                    if (GameVariables.gameSelection == ConstantVars.SELECT_DIAGONAL_GAME)
                    {
                        bool allDiagonalMatch = Logic.TopLeftDiagonalGameCheck(gameSlotsGrid); // replaced the lines of code with the method

                        if (allDiagonalMatch)
                        {
                            Ui_Methods.DisplayPlayerWinningBetMessage(); // placed here becasue the method does the same thing 
                            Ui_Methods.DisplayingWinningsAndBonusesToTheUser();
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }

                        if (!allDiagonalMatch) //this is needed do not delete allDiagonalMatch ///Left off here!!!
                        {
                            Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();// replaced the lines of code with the method
                            Ui_Methods.PromptingUserToPlaceBet();
                            gameModeRestart = true;
                        }

                        //////////////////////Top Right diagonal check/////////////////////////

                        Logic.ValidatingByParsingTheUserInput(TheUserInput, gameSelection); // this will check if the user input is valid
                        bool allRightDiagonalMatch = Logic.TopRightDiagonalGameCheck(gameSlotsGrid);// replaced the lines of code with the method

                        if (allRightDiagonalMatch)
                        {
                            Ui_Methods.DisplayPlayerWinningBetMessage();
                            Ui_Methods.DisplayingWinningsAndBonusesToTheUser();
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }

                        if (!allRightDiagonalMatch)
                        {
                            Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                            Ui_Methods.PromptingUserToPlaceBet();

                            gameModeRestart = true;
                        }
                        ///////////////////////////////////////////////

                    }

                    Ui_Methods.PromptingUserToClearTheSlotsGrid();

                    Ui_Methods.DisplayingPlayerBalanceUpdate(); // this will display the players balance after the game has been played


                    Ui_Methods.DisplayingAskingUserToBetAgain();


                    if (Ui_Methods.PlayerToContinueSelection() == ConstantVars.PLAYER_TO_CONTINUE_ACCEPT)
                    {
                        Ui_Methods.DisplayingPlayerContinueGameMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney();
                    }



                    if (Ui_Methods.PlayerToContinueSelection() == ConstantVars.PLAYER_TO_CONTINUE_DECLINE || PLAYER_MONEY <= 0) // check if player has selected n or had bet all of the money
                    {
                        quit = true;
                        Ui_Methods.DisplayingGameOverMessage();
                    }
                }
            }
        }
    }
}





