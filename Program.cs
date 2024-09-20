using System;


namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            const int SELECT_ROWS_GAME = 1; // select for Rows
            const int SELECT_COLOUMNS_GAME = 2; //select for Columns
            const int SELECT_DIAGONAL_GAME = 3;// select for Diagonals
            const int SELECT_CENTER_LINE_GAME = 4; // select Center row

            const string PLAYER_TO_CONTINUE_ACCEPT = "y";
            const string PLAYER_TO_CONTINUE_DECLINE = "n";

            const int WINNING_BET = 10;
            const int BONUS = 50; // use for diagonal wins 
            const int BONUS_2 = 75; // use for diagonal wins

            bool quit = false;

            int[,] gameSlotsGrid = new int[3, 3]; // 3x3 2d grid 

            int PLAYER_MONEY = 500;
            Console.WriteLine($"You have ${PLAYER_MONEY}!"); // user prompt

            Console.WriteLine($"Select your Game: {SELECT_ROWS_GAME}:ROWS {SELECT_COLOUMNS_GAME}:COLOUMS {SELECT_DIAGONAL_GAME}:DIAGONAL {SELECT_CENTER_LINE_GAME}:CENTER");

            int gameSelection; // input game selection
            string userInput = Console.ReadLine();

            bool istheSelectionValid = false;
            do // this will check if the user input is valid
            {

                if (Int32.TryParse(userInput, out gameSelection)) // this will catch the user input 
                {
                    if (gameSelection == SELECT_ROWS_GAME || gameSelection == SELECT_COLOUMNS_GAME || gameSelection == SELECT_DIAGONAL_GAME || gameSelection == SELECT_CENTER_LINE_GAME)
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

            int playerBet = 0;

            Console.Write("Place your Bet: ");

            playerBet = Convert.ToInt32(Console.ReadLine()); // user inputs bet
            // if statment here to check if its a number and not a letter

            PLAYER_MONEY -= playerBet;

            Console.WriteLine($"Balance is now: {PLAYER_MONEY}"); // amount after the player has bet

            const int LOW = 0; // const low number 
            const int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random(); // this is the random seed 

            bool gameModeRestart = false;// I will get rid of this as it's not been used

            while (!quit || !gameModeRestart)
            {
                //////// the nested loop displays the grid //////////////////
                for (int rows = 0; rows < gameSlotsGrid.GetLength(0); rows++) // loops through the rows 
                {
                    for (int cols = 0; cols < gameSlotsGrid.GetLength(1); cols++) // loops through the columns
                    {
                        int randNumInArray = range.Next(LOW, HIGH); // variable to store the random number also so that "random" 'resets' after each loop 
                        Console.Write((gameSlotsGrid[rows, cols] = randNumInArray) + " ");    // adding ranNumInArray value into elements of the array
                    }
                    Console.WriteLine(); // this makes sure that everything get printed on the next line.
                }
                /////////////////////////////////////////////////////////////////////////////

                bool numbersHasMactched = false;

                /////// Rows game check ///////////////
                if (gameSelection == SELECT_ROWS_GAME)
                {
                    bool numberHasMatched = false; // bool set to false
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
                            numberHasMatched = true;
                            PLAYER_MONEY += WINNING_BET + BONUS;
                            Console.WriteLine($"You've Won Wining bet: ${WINNING_BET} + Bonus: ${BONUS}");
                            gameModeRestart = true;
                            break;
                        }
                    }
                    if (!numberHasMatched)
                    {
                        Console.WriteLine("there are no matching row numbers ");
                        Console.WriteLine("Press any key to continue.....");
                        gameModeRestart = true;
                    }
                }
                /////////////////////////////////CenterLine check/////////////////////////////////////////
                if (gameSelection == SELECT_CENTER_LINE_GAME)
                {
                    int firstCenterValue = gameSlotsGrid[1, 0];
                    bool CenterArrayMatches = true;
                    for (int i = 0; i < gameSlotsGrid.GetLength(1); i++)
                    {
                        if (gameSlotsGrid[1, i] != firstCenterValue) // this checks the middle row of gameSlotGrid
                        {
                            CenterArrayMatches = false;
                            break;
                        }
                    }
                    if (CenterArrayMatches)
                    {
                        PLAYER_MONEY += WINNING_BET + BONUS + playerBet;
                        Console.WriteLine($"You've won ${WINNING_BET} + ${BONUS}");
                        gameModeRestart = true;
                    }
                    else
                    {
                        Console.WriteLine("The center numbers do not match");
                        Console.WriteLine("Press and key to continue.....");
                        gameModeRestart = true;
                    }
                }

                if (gameSelection == SELECT_COLOUMNS_GAME)
                {
                    bool numbersHasMatched = false;
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

                        if (allMatch) // if all number in a cols match is true
                        {
                            numbersHasMatched = true;
                            PLAYER_MONEY += WINNING_BET + BONUS + playerBet;
                            Console.WriteLine($"You've won ${WINNING_BET} + ${BONUS}");
                            gameModeRestart = true;
                            break;
                        }
                    }

                    if (!numbersHasMactched)
                    {
                        Console.WriteLine("there are no matching Column numbers ");
                        Console.WriteLine("Press any key to continue.....");
                        gameModeRestart = true;
                    }
                }
                ///////////////// Top Left diagonal check/////////////////
                if (gameSelection == SELECT_DIAGONAL_GAME)
                {
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
                        gameModeRestart = true;
                    }
                    if (!allDiagonalMatch)
                    {
                        Console.WriteLine(" There are no matching Diagonal numbers");
                        Console.WriteLine(" Press any key to continue.......");
                        gameModeRestart = true;
                    }
                    //////////////////////Top Right diagonal check/////////////////////////

                    for (int i = 0; i < gameSlotsGrid.GetLength(0); i++)
                    {
                        if (gameSlotsGrid[i, gameSlotsGrid.GetLength(1) - 1 - i] != firstDiagonalValue) // this starts at the end of the 1st dimension 
                        {
                            allDiagonalMatch = false;
                            break;
                        }
                    }
                    if (allDiagonalMatch)
                    {
                        Console.WriteLine($"You've won {WINNING_BET} + {BONUS_2}");
                        PLAYER_MONEY += WINNING_BET + BONUS_2 + playerBet;
                        gameModeRestart = true;
                    }
                    if (!allDiagonalMatch)
                    {
                        Console.WriteLine("There are no matching Diagonal numbers");
                        Console.WriteLine("Press any key to continue");
                        gameModeRestart = true;
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
                        Console.WriteLine("Press any key to continue.....");
                    }
                }


                Console.ReadKey();
                Console.Clear(); // reset the Grid.

                Console.WriteLine($"Balance is now: {PLAYER_MONEY}");
                Console.WriteLine("Would you like to bet again? (Y/N)");


                string PlayerToContinueSelection = Console.ReadLine().ToLower();// gets user input for selection: (Y/N)
             

                if (PlayerToContinueSelection == PLAYER_TO_CONTINUE_ACCEPT)
                {
                    Console.WriteLine($"Select your Game: {SELECT_ROWS_GAME}: Rows {SELECT_COLOUMNS_GAME}: Columns {SELECT_DIAGONAL_GAME}: Diagonal {SELECT_CENTER_LINE_GAME}: Center ");
                    userInput = Console.ReadLine();
                    int gameSelectionReplay; // input game selection

                    bool istheSelectionValidReplay = false;
                    do // this will check if the user input is valid
                    {

                        if (Int32.TryParse(userInput, out gameSelectionReplay)) // this will catch the user input if it is invalid
                        {

                            if (gameSelectionReplay == SELECT_ROWS_GAME || gameSelectionReplay == SELECT_COLOUMNS_GAME || gameSelectionReplay == SELECT_DIAGONAL_GAME || gameSelectionReplay == SELECT_CENTER_LINE_GAME)
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
                    playerBet = Convert.ToInt32(Console.ReadLine()); // gets the bet amount from user
                    PLAYER_MONEY -= playerBet; // takes away from User money total
                }

                if (PlayerToContinueSelection == PLAYER_TO_CONTINUE_DECLINE || PLAYER_MONEY <= 0) // check if player has selected n or had bet all of the money
                {
                    quit = true;
                    Console.WriteLine($"Game Over bets are closed, Your total: {PLAYER_MONEY}");
                }
            }
        }
    }
}




