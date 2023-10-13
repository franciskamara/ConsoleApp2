using System;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    const int COL_NUMBER = 3;
    const int ROW_NUMBER = 3;
    const int RDM_NUMBER_TOP_END = 11;
    const int WIN_AMOUNT = 3;

    static void Main(string[] args)
    {
        Console.WriteLine("   Slot Machine"); //Intro text
        Console.WriteLine("*-*-*-*-*-*-*-*-*-*\n");

        Console.Write("Insert coins: ");
        int balance = int.Parse(Console.ReadLine());

        int[,] slotMachine = new int[ROW_NUMBER, COL_NUMBER]; //2D Array with numbers for each slot
        Random rng = new Random(); //Random generator

        while (balance > 0)
        {
            /*
                   For future reference
            int[,] slotMachine = { { 1, 2, 1 }, { 4, 0, 6 }, { 1, 8, 1 } };
            slotMachine[0, 0] = 1;
            slotMachine[0, 1] = 2;
            slotMachine[0, 2] = 3;
            */

            balance = balance - 1;

            int rowIndex;
            int colIndex;
            for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Generate random numbers for Slot per row
            {
                for (colIndex = 0; colIndex < COL_NUMBER; colIndex++) //Generate random numbers for Slot per column
                {
                    slotMachine[rowIndex, colIndex] = rng.Next(RDM_NUMBER_TOP_END); //Random generator for each slot in machine
                }
            }//end Slot loop


            //Print Slot numbers
            for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++)
            {
                for (colIndex = 0; colIndex < COL_NUMBER; colIndex++)
                {
                    Console.Write(slotMachine[rowIndex, colIndex] + "\t"); //Print random numbers for slot
                }
                Console.WriteLine();
            }//end Slot Print loop

            //Winning Scenarios
            for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Row match
            {
                int rowCounter = 0;
                for (colIndex = 0; colIndex < COL_NUMBER - 1; colIndex++)
                {
                    if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex, colIndex + 1])
                    {
                        rowCounter += 1; //counter of matches increases
                    }
                }
                if (rowCounter == COL_NUMBER - 1) //Counting matching pair values
                {
                    Console.WriteLine("Row match");
                    balance = balance + WIN_AMOUNT;
                }
            } //end Row match 

            for (colIndex = 0; colIndex < COL_NUMBER; colIndex++) //Column match
            {
                int colCounter = 0;
                for (rowIndex = 0; rowIndex < ROW_NUMBER - 1; rowIndex++)
                {
                    if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex + 1, colIndex])
                    {
                        colCounter += 1; //counter of matches increases
                    }
                }
                if (colCounter == ROW_NUMBER - 1) //Counting matching pair values 
                {
                    Console.WriteLine("Column match");
                    balance = balance + WIN_AMOUNT;
                }
            }//end Column match 

            int diagCounter = 0; //Diagonal match - top Left
            for (int index = 0; index < ROW_NUMBER - 1; index++)
            {
                if (slotMachine[index, index] == slotMachine[index + 1, index + 1])
                {
                    diagCounter += 1;

                }
            } //end Diagonal Top left match
            if (diagCounter == ROW_NUMBER - 1)
            {
                Console.WriteLine("Diagonal match");
                balance = balance + WIN_AMOUNT;
            }//end Diagonal match

            int diag2Counter = 0; //Diagonal match - top Right
            for (rowIndex = 0; rowIndex < ROW_NUMBER - 1; rowIndex++)
            {
                int colSpecial = (COL_NUMBER - 1) - rowIndex;
                if (slotMachine[rowIndex, colSpecial] == slotMachine[rowIndex + 1, colSpecial - 1])
                {
                    diag2Counter += 1;
                }
            }
            if (diagCounter == ROW_NUMBER - 1)
            {
                Console.WriteLine("Diagonal match 2");
                balance = balance + WIN_AMOUNT;
            }

            Console.WriteLine($"Your balance is now: {balance}\n");

            //prompts user to Restart or Exit game
            Console.WriteLine("Spin again? y / n");
            char endGame = Console.ReadKey().KeyChar;
            if (endGame == 'y')
            {
                Console.Clear();
            }
            else if (endGame == 'n')
            {
                Console.Clear();
                Console.WriteLine($"Balance returned: {balance}");
                return;
            }
        }//end while Loop
        if (balance <= 0)
        {
            Console.WriteLine("Game over. You ran out of money.");
            Console.WriteLine($"Insert more money to play again? y / n");
        }
        char restartGame = Console.ReadKey().KeyChar;
        Console.Clear();

        if (restartGame == 'y')
        {
            Main(args);
        }
        else if (restartGame == 'n')
        {
            Console.WriteLine("Thanks for playing.");
        }

    }//end Main args
}//end class Program