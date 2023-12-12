using System;
using System.Reflection.Metadata.Ecma335;
using SlotMachine;

namespace Slot_Machine
{
    public static class UIMethods
    {
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("   Slot Machine"); //Intro text
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*");
        }

        /// <summary>
        /// Ask user to input money in order to play
        /// </summary>
        /// <returns>User value input</returns>
        public static int MoneyInputRequestMessage()
        {
            Console.Write("\nInsert coins to play: ");
            int balance = int.Parse(Console.ReadLine());
            return balance;
        }

        /// <summary>
        /// Ask user to select which lines they want to play
        /// </summary>
        /// <param name="USER_SELECTION_ROWS">stands for 'r' selection</param>
        /// <param name="USER_SELECTION_COLUMNS">stands for 'c' selection</param>
        /// <param name="USER_SELECTION_DIAGONALS">stands for 'd' selection</param>
        /// <returns></returns>
        public static char PrintGamePlaySelection()
        {
            Console.Clear();

            Console.WriteLine($"Choose your game!" +
                              $"\n- Play for Rows ({Program.USER_SELECTION_ROWS}) " +
                              $"\n- Play for Columns ({Program.USER_SELECTION_COLUMNS}) " +
                              $"\n- Play for Diagonals ({Program.USER_SELECTION_DIAGONALS})");
            Console.WriteLine();
            char gameTypeSelection = Console.ReadKey().KeyChar;

            Console.Clear();
            return gameTypeSelection;
        }

        /// <summary>
        /// Ask user how many lines they want to play
        /// </summary>
        /// <param name="balance">User's money balance</param>
        /// <param name="gameTypeSelection">Game selected by user</param>
        /// <returns>Number of lines user wants to play</returns>
        public static int LineNumberInput(int balance, char gameTypeSelection)
        {
            int maxLineNumber = Program.MAX_LINE_WIN_NUMBER_HOR_VER;
            int lineNumberSelection = 0;
            if (gameTypeSelection == Program.USER_SELECTION_DIAGONALS)
            {
                maxLineNumber = Program.MAX_LINE_WIN_NUMBER_DIAG;

            }
            while (balance > 0)
            {
                Console.Clear();
                Console.WriteLine($"Select how many lines you wish to play?\nBetween 1 and {maxLineNumber}");
                lineNumberSelection = int.Parse(Console.ReadLine());
                if (lineNumberSelection <= balance && lineNumberSelection <= maxLineNumber)
                { 
                    break;
                }
                Console.Write("Input invalid. Try another input.");
            }
            return lineNumberSelection;
        }

        /// <summary>
        /// Print Slot Machine numbers
        /// </summary>
        /// <param name="slotMachine">the grid</param>
        public static void PrintSlotMachineNumbers(int[,] slotMachine)
        {
            Console.Clear();

            for (int rowIndex = 0; rowIndex < slotMachine.GetLength(1); rowIndex++)
            {
                for (int colIndex = 0; colIndex < slotMachine.GetLength(0); colIndex++)
                {
                    Console.Write(slotMachine[rowIndex, colIndex] + "\t"); //Print random numbers for slot
                }
                Console.WriteLine();
            }//end Print Slot numbers for statement
        }

        /// <summary>
        /// Question user if they want to carry on playing or not
        /// </summary>
        /// <returns>User char input for game play</returns>
        public static bool PrintSpinAgainMessage(int balance)
        {
            bool spinAgain = false;

            Console.WriteLine($"Spin again? {Program.USER_SELECT_YES} / {Program.USER_SELECT_NO}");//User selects to spin again or not
            char input = Console.ReadKey().KeyChar;

            if (input == 'y')
            {
                spinAgain = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Balance returned: {balance}");
                Console.WriteLine("Thanks for playing!");

            }
            return spinAgain;
        }


        /// <summary>
        /// Clear console
        /// </summary>
        public static void ClearUserOutput()
        {
            Console.Clear();
        }

        /// <summary>
        /// Row Win message
        /// </summary>
        public static void PrintRowWinMessage()
        {
            Console.WriteLine("Row match");
        }
        /// <summary>
        /// Column Win message
        /// </summary>
        public static void PrintColumnWinMessage()
        {
            Console.WriteLine("Column match");
        }
        /// <summary>
        /// Diagonal One Win message
        /// </summary>
        public static void PrintDiagonalOneWinMessage()
        {
            Console.WriteLine("Diagonal match");
        }
        /// <summary>
        /// Diagonal 2 Win message
        /// </summary>
        public static void PrintDiagonalTwoWinMessage()
        {
            Console.WriteLine("Diagonal match 2");
        }

        /// <summary>
        /// Notify balance to user
        /// </summary>
        /// <param name="balance"> User's balance</param>
        public static void PrintRemainingBalance(int balance)
        {
            Console.WriteLine($"Your balance is now: {balance}\n");
        }
        /// <summary>
        /// Where balance is 0, Notify user and ask if they wish to play again 
        /// </summary>
        public static bool AskToPlayAgain()
        {
            bool gameRestart;

            Console.WriteLine("You ran out of money.");
            Console.WriteLine($"Insert more money to play again? {Program.USER_SELECT_YES} / {Program.USER_SELECT_NO}");

            char input = Console.ReadKey().KeyChar; //Option to restart the game by pressing 'y'; if not then end the game

            Console.Clear();
            if (input == Program.USER_SELECT_YES)
            {
                gameRestart = true;
            }
            else
            {
                gameRestart = false;
            }
            return gameRestart;
        }

        /// <summary>
        /// Thanks for playing message
        /// </summary>
        public static void PrintEndGameMessage()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
        }
    }
}