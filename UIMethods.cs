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
        /// Ask user how many lines they wish to play, for Rows and Columns
        /// </summary>
        /// <returns>Number entered by user</returns>
        public static int QuestionForRowAndColumnsPlay()
        {
            Console.WriteLine("\nSelect how many lines you wish to play? 1, 2, or 3");
            int lineNumberSelection = int.Parse(Console.ReadLine());
            return lineNumberSelection;
        }

        /// <summary>
        /// Ask user how manu lines they wish to play, for Diagonals only
        /// </summary>
        /// <returns></returns>
        public static int QuestionForDiagonalPlays()
        {
            Console.WriteLine("\nSelect how many lines you wish to play? 1 or 2");
            int lineNumberSelection = int.Parse(Console.ReadLine());
            return lineNumberSelection;
        }

        /// <summary>
        /// Notify user of current balance, Asks user to make another input based on current balance 
        /// </summary>
        /// <param name="balance">User money balance</param>
        /// <returns></returns>
        public static int RequestLineNumberReEntry(int balance)
        {
            Console.Clear();
            Console.WriteLine($"Your current balance: {balance}");
            Console.Write("\nNot enough money to play chosen amount of lines.\nEnter another number of lines to play: ");
            int lineNumberSelection = int.Parse(Console.ReadLine());
            return lineNumberSelection;
        }

        //public static int GetLineNumber(int balance, int lineNumberSelection)
        //{
        //    while (balance > 0)
        //    {
        //        if (lineNumberSelection < balance && lineNumberSelection  )
        //        {
                    
        //        }
        //    }
        //}

        /// <summary>
        /// Prompt to user if they want to carry on playing
        /// </summary>
        /// <returns>Returns user input for game play, char</returns>
        public static char AskUserToSpinAgain(int balance)
        {
            bool spinAgain;

            Console.WriteLine("Spin again? y / n");//User selects to spin again or not
            spinAgain = Console.ReadKey().KeyChar;

            if (spinAgain == 'y')
            {
            }
            else
            {
                Console.WriteLine($"Balance returned: {balance}");
                Console.WriteLine("\nThanks for playing");

            }
            Console.Clear();

            return spinAgain;
        }

        /// <summary>
        /// Notify user when balance is 0, Ask user if they want to input more money to continues playing
        /// </summary>
        /// <param name="balance"></param>
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

