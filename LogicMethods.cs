using System;
using System.Security.Cryptography.X509Certificates;

namespace Slot_Machine
{
    public class LogicMethods
    {
        const int COL_NUMBER = 3;
        const int ROW_NUMBER = 3;
        const int RDM_NUMBER_TOP_END = 11;
        
        /// <summary>
        /// Set SLot Machine random values
        /// </summary>
        /// <param name="width">grid width</param>
        /// <param name="length">gri length</param>
        /// <param name="topEndNumber">Top end number of random draw numbers</param>
        /// <returns></returns>
        public static int[,] SetSlotMachineRandomValues()
        {

            int[,] slotMachine = new int[COL_NUMBER, ROW_NUMBER]; //2D Array with numbers for each slot
            Random rng = new Random(); //Random generator

            for (int rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Generate random numbers for Slot per row
            {
                for (int colIndex = 0; colIndex < COL_NUMBER; colIndex++) //Generate random numbers for Slot per column
                {
                    slotMachine[rowIndex, colIndex] = rng.Next(RDM_NUMBER_TOP_END); //Random generator for each slot in machine
                }
            }//end Slot loop
            return slotMachine;
        }

        /// <summary>
        /// Returns the number of winning rows
        /// </summary>
        /// <param name="lineNumberSelection">how many lines to check</param>
        /// <param name="slotMachine"the grid</param>
        /// <returns>number of matched rows</returns>
        public static int GetRowMatch(int lineNumberSelection, int[,] slotMachine)
        {
            int rowMatch = 0;
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
        /// Returns the number of winning columns
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
        /// Returns winning diagonal, if start is Top left
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

            if (diagCounter == slotMachine.GetLength(1) - 1)
            {
                diagMatch = diagMatch + 1;
            }//end Diagonal for loop
            return diagMatch;
        }

        /// <summary>
        /// Returns winning diagonal, if start is Top right
        /// </summary>
        /// <param name="lineNumberSelection">how many lines to check</param>
        /// <param name="slotMachine">the grid</param>
        /// <returns>number of matched diagonals</returns>
        public static int GetDiagonalMatchTopRight(int[,] slotMachine)
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
    }
}

