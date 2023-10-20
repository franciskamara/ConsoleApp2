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

        public static void InsertMoneyToPlay()
        {
            Console.Write("\nInsert coins to play: ");
            int balance = int.Parse(Console.ReadLine());
        }

        public static void RandomNumberGen()
		{
            int ROW_NUMBER = 0;
            int COL_NUMBER = 0;
            int[,] slotMachine = new int[ROW_NUMBER, COL_NUMBER]; //2D Array with numbers for each slot
            Random rng = new Random(); //Random generator
            return;
        }

        public static char UserSelectsGamePlay()
        {
            Console.Clear();
            object USER_SELECTION_ROWS = 'r';
            object USER_SELECTION_COLUMNS = 'c';
            object USER_SELECTION_DIAGONALS = 'd';
            Console.WriteLine($"Choose your game!" +
                $"\n- Play for Rows ({USER_SELECTION_ROWS}) " +
                $"\n- Play for Columns ({USER_SELECTION_COLUMNS}) " +
                $"\n- Play for Diagonals ({USER_SELECTION_DIAGONALS})");
            Console.WriteLine();
            char gameTypeSelection = Console.ReadKey().KeyChar;
            return gameTypeSelection;
        }

        public static void QuestionForRowAndColumnsPlay()
        {
            Console.WriteLine("\nSelect how many lines you wish to play? 1, 2, or 3");
        }

        public static void QuestionForDiagonalPlays()
        {
            Console.WriteLine("\nSelect how many lines you wish to play? 1 or 2");
        }
    }
}

