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

        double[,] slotMachine = new double[ROW_NUMBER, COL_NUMBER]; //2D Array with numbers for each slot

        var rng = new Random(); //Random generator

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
            Console.WriteLine("");
        }//end Slot Print loop

        //Check for Winning scenarios
        for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++)
        {
            for (colIndex = 1; colIndex < COL_NUMBER; colIndex++)
            {
                if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex, colIndex -1])
                {  
                    Console.WriteLine("Winning row");
                }
            }
        }


    }//end Main args
}//end class Program