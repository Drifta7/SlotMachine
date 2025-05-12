namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            bool numberHasMatched = false; // bool set to false
            bool haveTheNumbersMatched = false;

            int[,] gameSlotsGrid = new int[3, 3]; // 3x3 2d grid 

            int PLAYER_MONEY = 500;
            int gameSelection = 0; // input game selection

            Ui_Methods.DisplayingPlayerBalanceUpdate(PLAYER_MONEY);// keep

            int userBet = Ui_Methods.GetUserBet(PLAYER_MONEY);
            PLAYER_MONEY -= userBet;

            Ui_Methods.DisplayingPlayerBalanceUpdate(PLAYER_MONEY);

            while (!quit)
            {
                //////////////////ROWS GAME CHECK///////////////////////////////
                int selectedGameMode = Ui_Methods.GetValidGameMode();
                Ui_Methods.DisplaySlotGameGrid(gameSlotsGrid); // this will display the grid

                if (selectedGameMode == ConstantVars.SELECT_ROWS_GAME)
                {
                    bool allMatch = Logic.CheckingRowsGame(gameSlotsGrid, selectedGameMode);

                    if (allMatch) // if all number in a row match is true
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(PLAYER_MONEY);
                    }

                    if (!numberHasMatched)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet); // this will display the players balance after the game has been played
                    }
                }
                /////////////////////////////////CenterLine check/////////////////////////////////////////

                if (selectedGameMode == ConstantVars.SELECT_COLOUMNS_GAME)
                {
                    bool numbersHaveMatched = Logic.CheckingColumnsGame(gameSlotsGrid, selectedGameMode);// 

                    if (haveTheNumbersMatched) // if all number in a cols match is true
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(PLAYER_MONEY);
                    }

                    if (!haveTheNumbersMatched)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet); // this will display the players balance after the game has been played

                    }
                }
                /////////////////////// CenterLine game check/////////////////////////////////////////

                else if (selectedGameMode == ConstantVars.SELECT_CENTER_LINE_GAME)
                {
                    bool CenterArrayMatches = Logic.CheckingCenterLineGame(gameSlotsGrid, selectedGameMode);

                    if (CenterArrayMatches) // if all the number that match is true
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(PLAYER_MONEY); // replaced here because lines of code were repeated
                    }

                    if (!CenterArrayMatches)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage(); // replaced the lines of code with the method
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet);
                    }
                }

                /////////////////////// TOP RIGHT DIAGONAL check/////////////////////////////////////////
                else if (selectedGameMode == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
                {
                    bool allDiagonalMatch = Logic.CheckingTopRightDiagonalGame(gameSlotsGrid, selectedGameMode);

                    if (allDiagonalMatch)
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(PLAYER_MONEY);
                    }
                    
                    if (!allDiagonalMatch)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet);
                    }
                }

                ///////////////// Top Left diagonal check/////////////////

                else if (selectedGameMode == ConstantVars.SELECT_TOP_LEFT_DIAGONAL_GAME)
                {
                    bool allDiagonalMatch = Logic.CheckingTopLeftDiagonalGame(gameSlotsGrid, selectedGameMode); // replaced the lines of code with the method

                    if (allDiagonalMatch)
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage(); // placed here becasue the method does the same thing 
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(PLAYER_MONEY);
                    }

                    if (!allDiagonalMatch) // if allDiagonalMatch is false
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();// replaced the lines of code with the method
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet);
                    }
                }

                //////////////////////Top Right diagonal check/////////////////////////
                if (selectedGameMode == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
                {
                    bool allRightDiagonalMatch = Logic.CheckingTopRightDiagonalGame(gameSlotsGrid, selectedGameMode);// replaced the lines of code with the method

                    if (allRightDiagonalMatch)
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(PLAYER_MONEY);
                    }

                    if (!allRightDiagonalMatch)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet);
                    }
                }
                ///////////////////////////////////////////////

                Ui_Methods.PromptingUserToClearTheSlotsGrid();

                Ui_Methods.DisplayingPlayerBalanceUpdate(PLAYER_MONEY);

                string DecisionMadeByUser = Ui_Methods.PlayerToContinueSelection(); //stores the user input in a variable so that the Method doesn't repeat itself

                if (DecisionMadeByUser == ConstantVars.PLAYER_TO_CONTINUE_ACCEPT) // when selected the game continues 
                {
                    Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(PLAYER_MONEY, userBet);

                    Ui_Methods.PlayerHasContinuedTheGameMessage();
                }

                if (DecisionMadeByUser == ConstantVars.PLAYER_TO_CONTINUE_DECLINE || PLAYER_MONEY <= 0) // checks if player has selected n or had bet all of the money
                {
                    quit = true;
                    Ui_Methods.DisplayingGameOverMessage(PLAYER_MONEY);
                }
            }
        }
    }
}







