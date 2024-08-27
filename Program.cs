using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            int playerBet = 0;
            int playerChips = 0; // will set this at "0" for now 
            int choice;

            const int LOW = 0; // const low number 
            int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random();
            int randomNumberforArray = range.Next(LOW, HIGH);// might shorten the name 


            int[,] array2d = new int[3, 3]; // 3x3 grid created 


            //create check for: (center lines) (horizontal lines) (vertical) (diagonal) 

            Console.Write(" PLace your wager ");

            int wager = 0;
            Console.ReadLine();


            
            //for (int i = 0; i < length; i++)
            //{
            //    for (int i = 0; i < length; i++)
            //    {

            //    }

            //}
        }
    }
}
