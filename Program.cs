using System;
using System.Net.Quic;
using Slot_Machine;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    // Game play constants
    const int COL_NUMBER = 3;
    const int ROW_NUMBER = 3;
    const int RDM_NUMBER_TOP_END = 11;
    const int WIN_AMOUNT = 10;
    const int MAX_LINE_WIN_NUMBER_HOR_VER = 3; //Max input for Column/Row
    const int MAX_LINE_WIN_NUMBER_DIAG = 2; //Max input for Diagonal

    // User game selection constants
    public const char USER_SELECTION_ROWS = 'r';
    public const char USER_SELECTION_COLUMNS = 'c';
    public const char USER_SELECTION_DIAGONALS = 'd';
    public const char USER_SELECT_YES = 'y';//User selects Yes
    public const char USER_SELECT_NO = 'n';//User selects No

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
                UIMethods.ClearUserOutput();
                gameTypeSelection = UIMethods.UserSelectsGamePlay(USER_SELECTION_ROWS, USER_SELECTION_COLUMNS, USER_SELECTION_DIAGONALS);
            }
            UIMethods.ClearUserOutput();

            while (balance > 0)
            {
                int[,] slotMachine = LogicMethods.SetSlotMachineRandomValues(COL_NUMBER, ROW_NUMBER, RDM_NUMBER_TOP_END);

                int lineNumberSelection = UIMethods.GetLineNumber(balance, gameTypeSelection, MAX_LINE_WIN_NUMBER_HOR_VER, MAX_LINE_WIN_NUMBER_DIAG);
                //Winning Scenario: Row
                if (gameTypeSelection == USER_SELECTION_ROWS)
                {

                    balance = balance - lineNumberSelection;
                    UIMethods.ClearUserOutput();

                    int rowMatch = LogicMethods.GetRowMatch(lineNumberSelection, slotMachine);
                    if (rowMatch > 0) //Counting matching pair values
                    {
                        UIMethods.RowWinMessage();
                        balance = balance + WIN_AMOUNT * rowMatch;
                    }
                }//end Winning Scenario: Row

                // Winning Scenario: Column
                if (gameTypeSelection == USER_SELECTION_COLUMNS)
                {

                    balance = balance - lineNumberSelection;
                    UIMethods.ClearUserOutput();

                    int colMatch = LogicMethods.GetColumnMatch(lineNumberSelection, slotMachine);
                    if (colMatch > 0) //Counting matching pair values - every time there is a Column match
                    {
                        UIMethods.ColumnWinMessage();
                        balance = balance + WIN_AMOUNT * colMatch;
                    }
                }//end Winning Scenario: Column


                // Winning Scenario: Diagonal
                if (gameTypeSelection == USER_SELECTION_DIAGONALS)
                {

                    balance = balance - lineNumberSelection;
                    UIMethods.ClearUserOutput();

                    //} //end Diagonal Top left match
                    int diagMatch = LogicMethods.GetDiagonalMatchTopLeft(lineNumberSelection, slotMachine);
                    if (diagMatch > 0)
                    {
                        UIMethods.Diagonal1WinMessage();
                        balance = balance + WIN_AMOUNT * diagMatch;
                    }//end Diagonal match

                    int diagMatchTwo = LogicMethods.GetDiagonalMatchTopRight(lineNumberSelection, slotMachine);
                    if (diagMatchTwo > 0)
                    {
                        UIMethods.Diagonal2WinMessage();
                        balance = balance + WIN_AMOUNT * diagMatchTwo;
                    }
                } //end Winning Scenarios: Diagonal

                UIMethods.PrintSlotMachineNumbers(slotMachine);//Print Slot numbers

                UIMethods.OutputRemainingBalance(balance);//Notify user of balance

                if (balance <= 0) //Where balance is 0, Ask user if they want to insert more money.
                {
                    UIMethods.OutputNoMoneyMessage();

                    char input = Console.ReadKey().KeyChar; //Option to restart the game by pressing 'y'; if not then end the game
                    UIMethods.ClearUserOutput();
                    if (input == USER_SELECT_YES)
                    {
                        continue;
                    }
                    else
                    {
                        UIMethods.ClearUserOutput();
                        UIMethods.OutputEndGameMessage();
                        return;
                    }
                }

                if (!UIMethods.AskUserToSpinAgain(balance))//Ask user if they wish to spin again 
                {
                    return;
                }
                else
                    continue;

            }//end While loop where (balance > 0)
        }//end startGame While loop
    }//end Main args
}//end class Program