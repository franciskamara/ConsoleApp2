using System;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    const int COL_NUMBER = 3;
    const int ROW_NUMBER = 3;
    const int RDM_NUMBER_TOP_END = 11;


    static void Main(string[] args)
    {


        Console.WriteLine(" Slot Machine"); //Intro text
        Console.WriteLine("*-*-*-*-*-*-*-*\n");

        double[,] slotMachine = new double[ROW_NUMBER, COL_NUMBER]; //2D Array with numbers for each slot

        var rng = new Random(); //Random generator

        int rowIndex;
        int colIndex;
        for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Random number for slots
        {
            for (colIndex = 0; colIndex < COL_NUMBER; colIndex++)
            {
                slotMachine[rowIndex, colIndex] = rng.Next(RDM_NUMBER_TOP_END); //Random generator for each slot in machine
            }
        }//end Slot loop

        for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Random number for slots
        {
            for (colIndex = 0; colIndex < COL_NUMBER; colIndex++)
            {
                Console.Write(slotMachine[rowIndex, colIndex] + "\t"); //Print random numbers for slot
            }
            Console.WriteLine("");
        }//end Slot Print loop


        for (int horizontalWinScenario = 0; horizontalWinScenario < ROW_NUMBER; horizontalWinScenario++)
        {
            //Winning scenario - Horizontal
            if (slotMachine[0,0] == slotMachine[0,1] && slotMachine[0,1] == slotMachine[0,2])
            {
                Console.WriteLine("Top line win");
            }
            if (slotMachine[1,0] == slotMachine[1,1] && slotMachine[1,1] == slotMachine[1,2])
            {
                Console.WriteLine("Middle line win");
            }
            if (slotMachine[2,0] == slotMachine[2,1] && slotMachine[2,1] == slotMachine[2,2])
            {
                Console.WriteLine("Bottom line win");
            }
        }


    }//end Main args
}//end class Program