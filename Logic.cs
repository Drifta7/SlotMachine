using SlotMachineRefactored;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Logic
    {

        public static void ValidatingUserInputForGameSelection()
        { ////-------note there needs to be a VAR to save the PromptingUserToSelectGameMode return value into the method ----/////
            bool istheSelectionValid = false;
            string userInput = Ui_Methods.PromptingUserToSelectGameMode(); // Note place this line when by itself in the Main program
            int gameSelection; // NOTE: CHECK this over again, when neccessary put into the actual program
            do // this will check if the user input is valid
            {

                if (Int32.TryParse(userInput, out gameSelection)) // this will catch the user input 
                {
                    if (gameSelection == ConstantVars.SELECT_ROWS_GAME || gameSelection == ConstantVars.SELECT_COLOUMNS_GAME || gameSelection == ConstantVars.SELECT_DIAGONAL_GAME || gameSelection == ConstantVars.SELECT_CENTER_LINE_GAME)
                    {
                        Console.WriteLine($"you've have selected {gameSelection}");
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
        }
        ////////////////////////-------------//////////////////////-------------------////////////////------------
        

        public static void ValidatingByParsingTheUserInput(string userInput, int gameSelection)
        {
            bool istheSelectionValid = false; // this is the bool that will be used to check if the user input is valid
            
            do // this will check if the user input is valid
            {

                if (Int32.TryParse(userInput, out gameSelection)) // this will catch the user input 
                {
                    if (gameSelection == ConstantVars.SELECT_ROWS_GAME || gameSelection == ConstantVars.SELECT_COLOUMNS_GAME || gameSelection == ConstantVars.SELECT_DIAGONAL_GAME || gameSelection == ConstantVars.SELECT_CENTER_LINE_GAME)
                    {
                        Console.WriteLine($"you've have selected {gameSelection}");
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
        }
        /////-------------------////////////////------------////////////-----------/////////----------////////  -----------------------
        public static bool GameSelectionRows(int[,] grid)
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

                    if (allMatch)
                    {
                        return numberHasMatched = true; // if the numbers are the same 
                    }
                }
            }
            return false;
        }
        ////////////////------------////////////-----------/////////----------////////  -----------------------
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

        ////////////////------------////////////-----------/////////----------////////  -----------------------/////////
        public static bool GameSelectionTopLeftDiagonal(int[,] grid) // logic issue with this 2 sets of if condtions with in logic and the Program
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
                if (allDiagonalMatch)
                {
                    return true; // if the numbers are the same 
                }
            }
            return false; // if no match is found
        }

        ////////////////------------////////////-----------/////////----------////////  -----------------------

        public static bool GameSelectionTopRightDiagonal(int[,] grid)
        {
            if (ConstantVars.gameSelection == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
            {
                bool allDiagonalMatch = true;
                int firstDiagonalValue = grid[0, 0];
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    if (grid[i, grid.GetLength(1) - 1 - i] != firstDiagonalValue) // this starts at the end of the 1st dimension 
                    {
                        allDiagonalMatch = false;
                        break;
                    }
                }
                if (allDiagonalMatch)
                {
                    return true; // if the numbers are the same 
                }
            }
            return false; // if no match is found
        }
        ////////////////------------////////////-----------/////////----------////////  -----------------------

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
            if (CenterArrayMatches)
            {
                return true; // if the numbers are the same 
            }
            return false; // if no match is found
        }
        
        public static bool CheckForWin(int[,] grid)
        {
            return GameSelectionRows(grid) || GameSelectionColumns(grid) || GameSelectionTopLeftDiagonal(grid)
                    || GameSelectionTopRightDiagonal(grid) || GameSelectionCenterLine(grid);
        }
    }
}

