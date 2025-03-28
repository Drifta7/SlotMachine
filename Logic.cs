using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Logic
    {
         public static string PlayerToContinueSelection = Console.ReadLine().ToLower();// gets user input for selection: (Y/N) FIGURE OUT WHAT TO DO WITH THIS!!!!

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

    }
}
