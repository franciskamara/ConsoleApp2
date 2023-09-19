using System;

namespace SlotMachine; // Note: actual namespace depends on the project name.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Slot Machine");

        int[,] slotMachine = new int[3, 3]; //2D Array with numbers for each slot
        slotMachine[0, 0] = (int)0.5;
        slotMachine[0, 1] = (int)0.2;
        slotMachine[0, 2] = (int)0.3;

        slotMachine[1, 0] = (int)0.4;
        slotMachine[1, 1] = (int)0.3;
        slotMachine[1, 2] = (int)0.3;

        slotMachine[2, 0] = (int)0.6;
        slotMachine[2, 1] = (int)0.4;
        slotMachine[2, 2] = (int)0.3;

        //Output array
        foreach (int number in slotMachine)
        {
            Console.WriteLine(number);
        }
    }
}