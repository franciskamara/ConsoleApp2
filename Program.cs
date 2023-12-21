using Slot_Machine;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    // Game play constants
    // const int COL_NUMBER = 3;
    // const int ROW_NUMBER = 3;
    // const int RDM_NUMBER_TOP_END = 11;
    const int WIN_AMOUNT = 10;
    public const int MAX_LINE_WIN_NUMBER_HOR_VER = 3; //Max input for Column/Row
    public const int MAX_LINE_WIN_NUMBER_DIAG = 2; //Max input for Diagonal

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
        while (startGame)//gameplay sequence
        {
            UIMethods.PrintWelcomeMessage();// Method - Intro text

            balance = UIMethods.MoneyInputRequestMessage();//Ask user to input funds
            
            char gameTypeSelection = ' ';
            while (gameTypeSelection != USER_SELECTION_ROWS
                   && gameTypeSelection != USER_SELECTION_COLUMNS
                   && gameTypeSelection != USER_SELECTION_DIAGONALS)
            {
                gameTypeSelection = UIMethods.PrintGamePlaySelection();
            }

            while (balance > 0)//Play session while user balance is greater than 0
            {
                int[,] slotMachine = LogicMethods.SetSlotMachineRandomValues();

                int lineNumberSelection = UIMethods.LineNumberInput(balance, gameTypeSelection);

                //Winning Scenario: Row
                if (gameTypeSelection == USER_SELECTION_ROWS)
                {
                    balance = balance - lineNumberSelection;

                    int rowMatch = LogicMethods.GetRowMatch(lineNumberSelection, slotMachine);
                    if (rowMatch > 0) //Counting matching pair values
                    {
                        UIMethods.PrintRowWinMessage();
                        balance = balance + WIN_AMOUNT * rowMatch;
                    }
                }//end Winning Scenario: Row

                // Winning Scenario: Column
                if (gameTypeSelection == USER_SELECTION_COLUMNS)
                {
                    balance = balance - lineNumberSelection;

                    int colMatch = LogicMethods.GetColumnMatch(lineNumberSelection, slotMachine);
                    if (colMatch > 0) //Counting matching pair values - every time there is a Column match
                    {
                        UIMethods.PrintColumnWinMessage();
                        balance = balance + WIN_AMOUNT * colMatch;
                    }
                }//end Winning Scenario: Column
                
                // Winning Scenario: Diagonal
                if (gameTypeSelection == USER_SELECTION_DIAGONALS)
                {
                    balance = balance - lineNumberSelection;

                    //} //end Diagonal Top left match
                    int diagMatch = LogicMethods.GetDiagonalMatchTopLeft(lineNumberSelection, slotMachine);
                    if (diagMatch > 0)
                    {
                        UIMethods.PrintDiagonalOneWinMessage();
                        balance = balance + WIN_AMOUNT * diagMatch;
                    }//end Diagonal match

                    int diagMatchTwo = LogicMethods.GetDiagonalMatchTopRight(slotMachine);
                    if (diagMatchTwo > 0)
                    {
                        UIMethods.PrintDiagonalTwoWinMessage();
                        balance = balance + WIN_AMOUNT * diagMatchTwo;
                    }
                } //end Winning Scenarios: Diagonal

                UIMethods.PrintSlotMachineNumbers(slotMachine);//Print Slot numbers

                UIMethods.PrintRemainingBalance(balance);//Notify user of balance

                if (balance <= 0) //Where balance is 0, Ask user if they want to insert more money.
                {
                    bool gameRestart = UIMethods.AskToPlayAgain();

                    if (gameRestart == true)
                    {
                        continue;
                    }
                    else
                    {
                        UIMethods.PrintEndGameMessage();
                        return;
                    }
                }

                if (!UIMethods.PrintSpinAgainMessage(balance))//Ask user if they wish to spin again 
                {
                    return;
                }
                else
                    continue;
            }//end While loop where (balance > 0)
        }//end startGame While loop
    }//end Main args
}//end class Program