namespace SlotMachine
{
    class Logic
    {
        /////-------------------////////////////------------////////////-----------/////////----------////////  -----------------------
        public static bool CheckingRowsGame(int[,] grid, int gameChoice)
        {
            if (gameChoice == ConstantVars.SELECT_ROWS_GAME)
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
            return false; // if no match is found
        }
        ////////////////------------////////////-----------/////////----------////////  -----------------------
        public static bool CheckingColumnsGame(int[,] grid, int gameChoice)
        {
            if (gameChoice == ConstantVars.SELECT_COLOUMNS_GAME)
            {
                // loops cols checks through the grid
                for (int cols = 0; cols < grid.GetLength(0); cols++) // this loops through the rows
                {
                    int checkEqualNumbers = grid[0, cols]; // this will check the first element of the columns
                    bool allMatch = true; // bool set to true

                    for (int rows = 0; rows < grid.GetLength(1); rows++) // this loops through rows
                    {
                        if (grid[rows, cols] != checkEqualNumbers) // checks if the numbers are not the same
                        {
                            allMatch = false; // if the numbers are not the same then the bool is set to false
                        }
                    }

                    if (allMatch)
                    {
                        return true; // if match is found
                    }
                }
            }
            return false;   // if no match is found 
        }

        ////////////////------------////////////-----------/////////----------////////  -----------------------/////////
        public static bool CheckingTopLeftDiagonalGame(int[,] grid, int gameChoice) 
        {
            if (gameChoice == ConstantVars.SELECT_TOP_LEFT_DIAGONAL_GAME)
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

        public static bool CheckingTopRightDiagonalGame(int[,] grid, int gameChoice)
        {
            if (gameChoice == ConstantVars.SELECT_TOP_RIGHT_DIAGONAL_GAME)
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

        public static bool CheckingCenterLineGame(int[,] grid, int gameChoice)
        {
            if (gameChoice == ConstantVars.SELECT_CENTER_LINE_GAME)
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
            }
            return false; // if no match is found
        }
    }
}

