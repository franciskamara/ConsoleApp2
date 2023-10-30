using System;
using Slot_Machine;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    // Game play constants
    const int COL_NUMBER = 3;
    const int ROW_NUMBER = 3;
    const int RDM_NUMBER_TOP_END = 11;
    const int WIN_AMOUNT = 10;

    // User game selection constants
    const char USER_SELECTION_ROWS = 'r';
    const char USER_SELECTION_COLUMNS = 'c';
    const char USER_SELECTION_DIAGONALS = 'd';

    static void Main(string[] args)
    {
        int balance;

        bool startGame = true;
        while (startGame)
        {
            UIMethods.DisplayWelcomeMessage();// Method - Intro text

            balance = UIMethods.GetMoneyInput();//


            char gameTypeSelection = ' ';
            while (gameTypeSelection != USER_SELECTION_ROWS
                && gameTypeSelection != USER_SELECTION_COLUMNS
                && gameTypeSelection != USER_SELECTION_DIAGONALS)
            {
                gameTypeSelection = UIMethods.UserSelectsGamePlay(USER_SELECTION_ROWS, USER_SELECTION_COLUMNS, USER_SELECTION_DIAGONALS);
            }
            UIMethods.ClearUserOutput();

            while (balance > 0)
            {
                int[,] slotMachine = LogicMethods.SetSlotMachineRandomValues(COL_NUMBER, ROW_NUMBER, RDM_NUMBER_TOP_END);
                //slotMachine = UIMethods.RandomNumberGen(COL_NUMBER, ROW_NUMBER, RDM_NUMBER_TOP_END);

                /*
                       For future reference
                int[,] slotMachine = { { 1, 2, 1 }, { 4, 0, 6 }, { 1, 8, 1 } };
                slotMachine[0, 0] = 1;
                slotMachine[0, 1] = 2;
                slotMachine[0, 2] = 3;
                

                int rowIndex;
                int colIndex;
                for (rowIndex = 0; rowIndex < ROW_NUMBER; rowIndex++) //Generate random numbers for Slot per row
                {
                    for (colIndex = 0; colIndex < COL_NUMBER; colIndex++) //Generate random numbers for Slot per column
                    {
                        slotMachine[rowIndex, colIndex] = rng.Next(RDM_NUMBER_TOP_END); //Random generator for each slot in machine
                    }
                }//end Slot loop
                */

                //Winning Scenario: Row
                if (gameTypeSelection == USER_SELECTION_ROWS)
                {
                    int lineNumberSelection = UIMethods.QuestionForRowAndColumnsPlay();

                    if (balance >= lineNumberSelection) //Reduce money by how many lines to play
                    {
                    }
                    else //Where line selection is more than the available balance
                    {
                        while (balance < lineNumberSelection)
                        {
                            int userInput = UIMethods.RequestLineNumberReEntry(balance);//Method (Bal is displayed, Ask for another input, User input)
                        }
                    }
                    balance = balance - lineNumberSelection;
                    UIMethods.ClearUserOutput();

                    int rowMatch = LogicMethods.GetRowMatch(lineNumberSelection, slotMachine);
                    if (rowMatch > 0) //Counting matching pair values
                    {
                        Console.WriteLine("Row match");
                        balance = balance + WIN_AMOUNT * rowMatch;
                    }
                }//end Row if statement 

                // Winning Scenario: Column
                if (gameTypeSelection == USER_SELECTION_COLUMNS)
                {
                    int lineNumberSelection = UIMethods.QuestionForRowAndColumnsPlay();

                    if (balance >= lineNumberSelection) //Reduce money by how many lines to play
                    {
                    }
                    else //Where line selection is more than the available balance
                    {
                        while (balance < lineNumberSelection)
                        {
                            int userInput = UIMethods.RequestLineNumberReEntry(balance);
                        }
                    }
                    balance = balance - lineNumberSelection;
                    UIMethods.ClearUserOutput();

                    int colMatch = LogicMethods.GetColumnMatch(lineNumberSelection, slotMachine);
                    if (colMatch > 0) //Counting matching pair values - every time there is a Column match
                    {
                        Console.WriteLine("Column match");
                        balance = balance + WIN_AMOUNT * colMatch;
                    }
                }//end Winning Scenario: Column


                // Winning Scenario: Diagonal
                if (gameTypeSelection == USER_SELECTION_DIAGONALS)
                {
                    int lineNumberSelection = UIMethods.QuestionForDiagonalPlays();

                    if (balance >= lineNumberSelection) //Reduce money by how many lines to play
                    {
                    }
                    else //Where line selection is more than the available balance
                    {
                        while (balance < lineNumberSelection)
                        {
                            int userInput = UIMethods.RequestLineNumberReEntry(balance);
                        }
                    }
                    balance = balance - lineNumberSelection;
                    UIMethods.ClearUserOutput();

                    //} //end Diagonal Top left match
                    int diagMatch = LogicMethods.GetDiagonalMatchTopLeft(lineNumberSelection, slotMachine);
                    if (diagMatch > 0)
                    {
                        Console.WriteLine("Diagonal match");
                        balance = balance + WIN_AMOUNT * diagMatch;
                    }//end Diagonal match

                    int diagMatchTwo = LogicMethods.GetDiagonalMatchTopRight(lineNumberSelection, slotMachine);
                    if (diagMatchTwo > 0)
                    {
                        Console.WriteLine("Diagonal match 2");
                        balance = balance + WIN_AMOUNT * diagMatchTwo;
                    }
                } //end Diagonal if statement 

                //Print Slot numbers
                LogicMethods.PrintSlotMachineNumbers(slotMachine);

                Console.WriteLine($"Your balance is now: {balance}\n");

                char spinAgain = UIMethods.AskUserToSpinAgain();

                if (spinAgain != 'y')
                {
                    Console.WriteLine($"Balance returned: {balance}");
                    Console.WriteLine("\nThanks for playing");
                    return;
                }
            }//end (balance>0) While Loop

            string messageToInsertMoreMoney = UIMethods.MessageToInsertMoreMoney(balance);
            if (balance <= 0)//when the balance is 0 or less
            {
                Console.WriteLine("You ran out of money.");
                Console.WriteLine($"Insert more money to play again? y / n");
            }

            char restartGame = Console.ReadKey().KeyChar; //Option to restart the game by pressing 'y'; if not then end the game
            UIMethods.ClearUserOutput();
            if (restartGame != 'y')
            {
                Console.WriteLine("Thanks for playing!");
                break;
            }
        }//end startGame While loop
    }//end Main args

}//end class Program