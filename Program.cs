using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;





            int[,] Grid2D = new int[3, 3]; // 3x3 grid created 



            Console.Write(" PLace your wager ");

            //int wager = 0;
            //Console.ReadLine();


            const int LOW = 0; // const low number 
            const int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random();

            for (int rows = 0; rows < Grid2D.GetLength(0); rows++)
            {
                for (int cols = 0; cols < Grid2D.GetLength(1); cols++)
                {
                    int randNumInArray = range.Next(LOW, HIGH);// variable to store the random number 
                    Console.Write(Grid2D[rows, cols] = randNumInArray);    // adding ranNumInArray value into elements
                }
                Console.WriteLine(); // this makes sure that everthing get printed on the next line.
            }


            //create check for: (center lines) (horizontal lines) (vertical) (diagonal) 
        }
    }
}

//Console.Write(array2d[rows,cols] + " "); // displays the array