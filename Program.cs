using System;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    const int COL_NUMBER = 3;
    const int ROW_NUMBER = 3;
    const int RDM_NUMBER_TOP_END = 11;

    static void Main(string[] args)
    {
        Console.WriteLine("   Slot Machine"); //Intro text
        Console.WriteLine("*-*-*-*-*-*-*-*-*-*\n");


        // int[,] slotMachine = new int[ROW_NUMBER, COL_NUMBER]; //2D Array with numbers for each slot
        var rng = new Random(); //Random generator

        int[,] slotMachine = { { 1, 2, 1 }, { 4, 1, 6 }, { 1, 8, 1 } };
        //slotMachine[0, 0] = 1;
        //slotMachine[0, 1] = 2;
        //slotMachine[0, 2] = 3;


        int rowIndex;
        int colIndex;
        /*   for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Generate random numbers for Slot per row
           {
               for (colIndex = 0; colIndex < COL_NUMBER; colIndex++) //Generate random numbers for Slot per column
               {
                 //  slotMachine[rowIndex, colIndex] = array[0];

                   slotMachine[rowIndex, colIndex] = rng.Next(RDM_NUMBER_TOP_END); //Random generator for each slot in machine
               }
           }//end Slot loop
         */

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
        for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Winning scenario - Row
        {
            int rowCounter = 0;
            for (colIndex = 0; colIndex < COL_NUMBER - 1; colIndex++)
            {
                if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex, colIndex + 1])
                {
                    //  Console.WriteLine("Winning row");
                    rowCounter += 1; //counter of matches increases
                }
            }
            if (rowCounter == COL_NUMBER - 1) //Counting matching pair values
            {
                Console.WriteLine("Row match");
            }
        } //end Row match 

        for (rowIndex = 0; rowIndex < ROW_NUMBER - 1; rowIndex++) //Winning scenario - Column
        {
            int colCounter = 0;
            for (colIndex = 0; colIndex < COL_NUMBER; colIndex++)
            {
                if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex + 1, colIndex])
                {
                    //Console.WriteLine("Winning column");
                    colCounter += 1; //counter of matches increases
                }
            }
            if (colCounter == ROW_NUMBER - 1) //Counting matching pair values 
            {
                Console.WriteLine("Column match");
            }
        }//end Column match 

        for (int index = 0; index < ROW_NUMBER - 1; index++) //Diagonal match - top left
        {
            int diagCounter = 0;
            if (slotMachine[index, index] == slotMachine[index + 1, index + 1])
            {
                diagCounter += 1;
            }
            if (diagCounter == ROW_NUMBER - 1)
            {
                Console.WriteLine("Diagonal match");
            }
        } //end Diagonal Top left match 

        for (rowIndex = 0; rowIndex < ROW_NUMBER - 1; rowIndex++) //Diagonal match - top right
        {
            int diagCounter = 0;
            for (colIndex = COL_NUMBER - 1; colIndex < COL_NUMBER - 1; colIndex--)
            {
                if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex, colIndex + 1])
                {
                    diagCounter += 1; //counter of matches increases
                }
            }
            if (diagCounter == ROW_NUMBER - 1) //Counting matching pair values
            {
                Console.WriteLine("Diagonal match");
            }

            } //end Diagonal Top right match 
        }//end Main args
}//end class Program