using SlotMachineRefactored;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;



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

            int playerMoney = 500;
            int gameSelection = 0; // input game selection

            Ui_Methods.DisplayingPlayerBalanceUpdate(playerMoney);// keep

            int userBet = Ui_Methods.GetUserBet();
            playerMoney -= userBet;

            Ui_Methods.DisplayingPlayerBalanceUpdate(playerMoney); 
           
            while (!quit) 
            {
                //////////////////ROWS GAME CHECK///////////////////////////////
                int selectedGameMode = Ui_Methods.GetValidGameMode();

                if (selectedGameMode == ConstantVars.SELECT_ROWS_GAME) 
                {
                    Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid); // this will display the grid
                   
                    bool allMatch = Logic.RowsGameCheck(gameSlotsGrid, selectedGameMode);

                    if (allMatch) // if all number in a row match is true
                    {
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(playerMoney);
                        numberHasMatched = true;
                        quit = true;
                        Ui_Methods.GetUserBet();
                    }

                    if (!numberHasMatched)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage(); 
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet); // this will display the players balance after the game has been played

                        Ui_Methods.GetUserBet();
                        quit = true;
                    }
                }
                /////////////////////////////////CenterLine check/////////////////////////////////////////

                if (selectedGameMode == ConstantVars.SELECT_COLOUMNS_GAME)
                {
                    Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid); // this will display the grid
                    bool numbersHaveMatched = Logic.ColumnsGameCheck(gameSlotsGrid, selectedGameMode);// 

                    if (haveTheNumbersMatched) // if all number in a cols match is true
                    {

                        Ui_Methods.DisplayPlayerWinningBetMessage(); 
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(playerMoney);
                        
                        quit = true;
                    }

                    if (!haveTheNumbersMatched)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet); // this will display the players balance after the game has been played
                     
                        quit = true;
                    }
                }
                /////////////////////// CenterLine game check/////////////////////////////////////////

                if (selectedGameMode == ConstantVars.SELECT_CENTER_LINE_GAME)
                {
                    Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid);// this will display the grid
                    bool CenterArrayMatches = Logic.CenterLineGameCheck(gameSlotsGrid, selectedGameMode); 

                    if (CenterArrayMatches) // if all the number that match is true
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(playerMoney); // replaced here because lines of code were repeated
                       
                        quit = true;
                    }

                    if (!CenterArrayMatches)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage(); // replaced the lines of code with the method
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet);
                       
                        quit = true;
                    }
                }

                /////////////////////// TOP RIGHT DIAGONAL check/////////////////////////////////////////
                if (selectedGameMode == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
                {
                    Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid);
                    bool allDiagonalMatch = Logic.TopRightDiagonalGameCheck(gameSlotsGrid, selectedGameMode);

                    if (allDiagonalMatch)
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(playerMoney);
                        
                        quit = true;
                    }
                    if (!allDiagonalMatch)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet);
                       
                        quit = true;
                    }
                }

                ///////////////// Top Left diagonal check/////////////////
                
                if (selectedGameMode == ConstantVars.SELECT_TOP_LEFT_DIAGONAL_GAME)
                {
                    Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid);
                    bool allDiagonalMatch = Logic.TopLeftDiagonalGameCheck(gameSlotsGrid, selectedGameMode); // replaced the lines of code with the method

                    if (allDiagonalMatch)
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage(); // placed here becasue the method does the same thing 
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(playerMoney);
                      
                        quit = true;
                    }

                    if (!allDiagonalMatch) // if allDiagonalMatch is false
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();// replaced the lines of code with the method
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet);
                        
                        quit = true;
                    }
                }
                
                //////////////////////Top Right diagonal check/////////////////////////
                if (selectedGameMode == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
                {
                    Ui_Methods.DisplayingSlotGameGrid(gameSlotsGrid);

                    bool allRightDiagonalMatch = Logic.TopRightDiagonalGameCheck(gameSlotsGrid, selectedGameMode);// replaced the lines of code with the method

                    if (allRightDiagonalMatch)
                    {
                        Ui_Methods.DisplayPlayerWinningBetMessage();
                        Ui_Methods.DisplayingWinningsAndBonusesToTheUser(playerMoney);
                       
                        quit = true;
                    }

                    if (!allRightDiagonalMatch)
                    {
                        Ui_Methods.DisplayingTheNumbersDoNotMatchMessage();
                        Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet);
                        
                        quit = true;
                    }
                }
                ///////////////////////////////////////////////

                Ui_Methods.PromptingUserToClearTheSlotsGrid();

                Ui_Methods.DisplayingPlayerBalanceUpdate(playerMoney); 
                
                string DecisionMadeByUser = Ui_Methods.PlayerToContinueSelection(); //stores the user input in a variable so that the Method doesn't repeat itself

                if (DecisionMadeByUser == ConstantVars.PLAYER_TO_CONTINUE_ACCEPT) // when selected the game continues 
                {
                    
                    Ui_Methods.DisplayingTotalDifferenceOfAmountOfMoney(playerMoney, userBet);
                   
                    quit = false;
                }

                if (DecisionMadeByUser == ConstantVars.PLAYER_TO_CONTINUE_DECLINE || playerMoney <= 0) // checks if player has selected n or had bet all of the money
                {
                    quit = true;
                    Ui_Methods.DisplayingGameOverMessage(playerMoney);
                }
            }
        }
    }
}







