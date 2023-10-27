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
        /// <summary>
        /// returns the number of winning rows
        /// </summary>
        /// <param name="lineNumberSelection">how many lines to check</param>
        /// <param name="slotMachine"the grid</param>
        /// <returns>number of matched rows</returns>
        public static int GetRowMatch(int lineNumberSelection, int[,] slotMachine)
        {
                int rowMatch=0;
            for (int rowIndex = 0; rowIndex < lineNumberSelection; rowIndex++) //Row match
            {
                int rowCounter = 0;
                for (int colIndex = 0; colIndex < slotMachine.GetLength(0) - 1; colIndex++)
                {
                    if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex, colIndex + 1])
                    {
                        rowCounter += 1; //counter of matches increases
                    }
                }
                if (rowCounter == slotMachine.GetLength(0) - 1) //Counting matching pair values
                {
                    rowMatch = rowMatch + 1;
                }
            }//end Row for loop
            return rowMatch;
        }
        /// <summary>
        /// returns the number of winning columns
        /// </summary>
        /// <param name="lineNumberSelection">how many lines to check</param>
        /// <param name="slotMachine">the grid</param>
        /// <returns>number of matched columns</returns>
        public static int GetColumnMatch(int lineNumberSelection, int[,] slotMachine)
        {
            int colMatch = 0;
            for (int colIndex = 0; colIndex < lineNumberSelection; colIndex++) //Column match
            {
                int colCounter = 0;
                for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1) - 1; rowIndex++)
                {
                    if (slotMachine[rowIndex, colIndex] == slotMachine[rowIndex + 1, colIndex])
                    {
                        colCounter += 1; //counter of matches increases
                    }
                }
                if (colCounter == slotMachine.GetLength(1) - 1) //Counting matching pair values 
                {
                    colMatch = colMatch + 1;
                }
            }//end Column for loop
            return colMatch;
        }
        /// <summary>
        /// Returns the number of winning diagonals
        /// </summary>
        /// <param name="lineNumberSelection">how many lines to check</param>
        /// <param name="slotMachine">the grid</param>
        /// <returns>number of matched diagonals</returns>
        public static int GetDiagonalMatchTopLeft(int lineNumberSelection, int[,] slotMachine)
        {
            int diagCounter = 0; //Diagonal match - top Left
            int diagMatch = 0;
            for (int index = 0; index < lineNumberSelection - 1; index++)
            {
                if (slotMachine[index, index] == slotMachine[index + 1, index + 1])
                {
                    diagCounter += 1;
                }
            } //end Diagonal Top left match

            if (diagCounter == slotMachine.GetLength(1) -1)
            {
                diagMatch = diagMatch + 1;
            }//end Diagonal for loop
            return diagMatch;
        }

        public static int GetDiagonalMatchTopRight(int lineNumberSelection, int[,] slotMachine)
        {
            int diag2Counter = 0; //Diagonal match - top Right
            int diagMatchTwo = 0;
            for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1) - 1; rowIndex++)
            {
                int colSpecial = (slotMachine.GetLength(0) - 1) - rowIndex;
                if (slotMachine[rowIndex, colSpecial] == slotMachine[rowIndex + 1, colSpecial - 1])
                {
                    diag2Counter += 1;
                }
            }
            if (diag2Counter == slotMachine.GetLength(1) - 1)
            {
                diagMatchTwo = diagMatchTwo + 1;
            }
            return diagMatchTwo;
        }

        public static int[,] PrintSlotMachineNumbers(int[,] slotMachine)
        {
            for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1); rowIndex++)
            {
                for (int colIndex = 0; colIndex < slotMachine.GetLength(0); colIndex++)
                {
                    Console.Write(slotMachine[rowIndex, colIndex] + "\t"); //Print random numbers for slot
                }
                Console.WriteLine();
            }//end Print Slot numbers for statement

            return slotMachine;
        }

        public static char AskUserToSpinAgain()
        {
            Console.WriteLine("Spin again? y / n");//User selects to spin again or not
            char spinAgain = Console.ReadKey().KeyChar;
            Console.Clear();

            return spinAgain;
        }

        public static void WhereBalanceIsEqualToOrLessThanZero(int balance)
        {
            if (balance <= 0)//When the balance is 0 or less
            {
                Console.WriteLine("You ran out of money.");
                Console.WriteLine($"Insert more money to play again? y / n");
            }
        }
    }
}

