using System;
using System.Reflection.Metadata.Ecma335;

namespace Slot_Machine
{
	public static class UIMethods
	{
		public static void DisplayWelcomeMessage()
		{
            Console.WriteLine("   Slot Machine"); //Intro text
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*");
        }

        public static int GetMoneyInput()
        {
            int balance = int.Parse(Console.ReadLine());
            return balance;
        }

        public static int[,] RandomNumberGen(int width,int length, int topEndNumber)
		{
          
            int[,] slotMachine = new int[width, length]; //2D Array with numbers for each slot
            Random rng = new Random(); //Random generator

            int rowIndex;
            int colIndex;
            for (rowIndex = 0; rowIndex < width; rowIndex++) //Generate random numbers for Slot per row
            {
                for (colIndex = 0; colIndex < length; colIndex++) //Generate random numbers for Slot per column
                {
                    slotMachine[rowIndex, colIndex] = rng.Next(topEndNumber); //Random generator for each slot in machine
                }
            }//end Slot loop
            return slotMachine;
        }

        public static char UserSelectsGamePlay(char row, char col, char diag)
        {
            Console.Clear();
     
            Console.WriteLine($"Choose your game!" +
                $"\n- Play for Rows ({row}) " +
                $"\n- Play for Columns ({col}) " +
                $"\n- Play for Diagonals ({diag})");
            Console.WriteLine();
            char gameTypeSelection = Console.ReadKey().KeyChar;
            return gameTypeSelection;
        }

        public static int QuestionForRowAndColumnsPlay()
        {
            Console.WriteLine("\nSelect how many lines you wish to play? 1, 2, or 3");
            int lineNumberSelection = int.Parse(Console.ReadLine());
            return lineNumberSelection;
        }

        public static int QuestionForDiagonalPlays()
        {
            Console.WriteLine("\nSelect how many lines you wish to play? 1 or 2");
            int lineNumberSelection = int.Parse(Console.ReadLine());
            return lineNumberSelection;
        }

        public static int WhenBalanceIsLessThanUserInput(int balance)
        {
            Console.Clear();
            Console.WriteLine($"Your current balance: {balance}");
            Console.Write("\nNot enough money to play chosen amount of lines.\nEnter another number of lines to play: ");
            int lineNumberSelection = int.Parse(Console.ReadLine());
            return lineNumberSelection;
        }

        public static int[,] getRowMatch(int lineNumberSelection, int COL_NUMBER, int slotMachine, int balance, int WIN_AMOUNT)
        {
            for (int rowIndex = 0; rowIndex < lineNumberSelection; rowIndex++) //Row match
            {
                int rowCounter = 0;
                for (int colIndex = 0; colIndex < COL_NUMBER - 1; colIndex++)
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
            }

    }
}

