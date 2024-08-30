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

            int wager = 0;
            Console.ReadLine();


            const int LOW = 0; // const low number 
            const int HIGH = 9; // since 9 is the biggest "ones"

            Random range = new Random(); // this is the random seed 

            for (int rows = 0; rows < Grid2D.GetLength(0); rows++)
            {
                for (int cols = 0; cols < Grid2D.GetLength(1); cols++)
                {
                    int randNumInArray = range.Next(LOW, HIGH); // variable to store the random number 
                    Console.Write((Grid2D[rows, cols] = randNumInArray) + " ");    // adding ranNumInArray value into elements
                }
                Console.WriteLine(); // this makes sure that everthing get printed on the next line.
            }

            Console.ReadKey();
            Console.Clear(); // reset the Grid.


            for (int rows = 0; rows < Grid2D.GetLength(0); rows++)
            {
                for (int cols = 0; cols < Grid2D.GetLength(1); cols++)
                {
                    int randNumInArray = range.Next(LOW, HIGH); // variable to store the random number 
                    Console.Write((Grid2D[rows, cols] = randNumInArray) + " ");    
                }
                Console.WriteLine(); // this makes sure that everthing get printed on the next line.
            }
            /////// horizonatal checks///////
            if (Grid2D[0,0] == Grid2D[0,1] && Grid2D[0,1] == Grid2D[0,2]) // check from 0 to 2(3rd element) horizontal 
            {
                
            }
            if (Grid2D[1, 0] == Grid2D[1, 1] && Grid2D[1, 1] == Grid2D[1, 2]) // 2nd row
            { 
            
            }
            if (Grid2D[2, 0] == Grid2D[2, 1] && Grid2D[2, 1] == Grid2D[2, 2]) // 3rd row
            { 
            
            }
            //////////vertaical checks ///////////////////

            if (Grid2D[0, 0] == Grid2D[1, 0] && Grid2D[1, 0] == Grid2D[2, 0])
            { 
            }
            if (Grid2D[1, 0] == Grid2D[1, 1] && Grid2D[1, 1] == Grid2D[1, 2])
            { 
            
            }
            if (Grid2D[2, 0] == Grid2D[1,2] && Grid2D[1, 2] == Grid2D[2, 2])
            { 
            
            
           }
            //create check for: (center lines) (horizontal lines) (vertical) (diagonal) 
        }
    }
}

