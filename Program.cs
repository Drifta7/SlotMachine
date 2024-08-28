using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            

            const int LOW = 0; // const low number 
            int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random();
            int randNumInArray = range.Next(LOW, HIGH);// variable to store the random number 



            int[,] array2d = new int[3, 3]; // 3x3 grid created 
         


            Console.Write(" PLace your wager ");
            Console.WriteLine(randNumInArray); // (for testing purposes)
            int wager = 0;
            Console.ReadLine();


            // the nested for loop prints out the game in grid display
            for (int rows = 0; rows < array2d.GetLength(0); rows++) 
            {
                for (int cols = 0; cols <array2d.GetLength(1); cols++)
                {
                    Console.Write(array2d[rows,cols] + " "); // displays the array
                    Console.Write(array2d[rows, cols] = randNumInArray);    // adding ranNumInArray value into elements
                }
                Console.WriteLine(); // this makes sure that everthing get printed on the next line.
            }


            //create check for: (center lines) (horizontal lines) (vertical) (diagonal) 
        }
    }
}
