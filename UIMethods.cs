using System;
using System.Reflection.Metadata.Ecma335;
using SlotMachine;

namespace Slot_Machine
{
	public static class UIMethods
	{
		public static void DisplayWelcomeMessage()
		{
            Console.WriteLine("   Slot Machine"); //Intro text
            Console.WriteLine("*-*-*-*-*-*-*-*-*-*");
        }

        /// <summary>
        /// Ask user to input money in order to play
        /// </summary>
        /// <returns>User value input</returns>
        public static int GetMoneyInput()
        {
            Console.Write("\nInsert coins: ");
            int balance = int.Parse(Console.ReadLine());
            return balance;
        }

        /// <summary>
        /// Ask user to select which lines they want to play
        /// </summary>
        /// <param name="row">stands for 'r' selection</param>
        /// <param name="col">stands for 'c' selection</param>
        /// <param name="diag">stands for 'd' selection</param>
        /// <returns></returns>
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

        /// <summary>
        /// Ask user how many lines they want to play
        /// </summary>
        /// <param name="balance">User's money balance</param>
        /// <param name="gameTypeSelection">Game selected by user</param>
        /// <returns>Number of lines user wants to play</returns>
        public static int GetLineNumber(int balance, char gameTypeSelection)
        {
            int maxLineNumber = 3;
            int lineNumberSelection = 0;
            if (gameTypeSelection == Program.USER_SELECTION_DIAGONALS)
            {
                maxLineNumber = 2;

            }
            while (balance > 0)
            {
                Console.WriteLine($"\nSelect how many lines you wish to play? Between 1 and {maxLineNumber}");
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
        /// Question user if they want to carry on playing or not
        /// </summary>
        /// <returns>User char input for game play</returns>
        public static bool AskUserToSpinAgain(int balance)
        {
            bool spinAgain = false;

            Console.WriteLine("Spin again? y / n");//User selects to spin again or not
            char input = Console.ReadKey().KeyChar;

            if (input == 'y')
            {
                spinAgain = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Balance returned: {balance}");
                Console.WriteLine("\nThanks for playing");

            }

            return spinAgain;
        }

        /// <summary>
        /// Notify user when balance is 0, Ask user if they want to input more money to continues playing
        /// </summary>
        /// <param name="balance"></param>
        public static void WhereBalanceIsZeroAndAskUserIfTheyWantToPlayAgain(int balance)
        {
            if (balance <= 0)//When the balance is 0 or less
            {
                Console.WriteLine("You ran out of money.");
                Console.WriteLine($"Insert more money to play again? y / n");
            }
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
        public static void RowWinMessage()
        {
            Console.WriteLine("Row match");
        }
        /// <summary>
        /// Column Win message
        /// </summary>
        public static void ColumnWinMessage()
        {
            Console.WriteLine("Column match");
        }
        /// <summary>
        /// Diagonal One Win message
        /// </summary>
        public static void Diagonal1WinMessage()
        {
            Console.WriteLine("Diagonal match");
        }
        /// <summary>
        /// Diagonal 2 Win message
        /// </summary>
        public static void Diagonal2WinMessage()
        {
            Console.WriteLine("Diagonal match 2");
        }

        /// <summary>
        /// Notify balance to user
        /// </summary>
        /// <param name="balance"> User's balance</param>
        public static void BalanceNotification(int balance)
        {
            Console.WriteLine($"Your balance is now: {balance}\n");
        }
        /// <summary>
        /// Thanks for playing message
        /// </summary>
        public static void ThanksForPlayingMessage()
        {
            Console.WriteLine("Thanks for playing!");
        }
    }
}

