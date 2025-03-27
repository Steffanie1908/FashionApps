using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionApp.BusinessAndDataLogic;
public static class UserInputHelper
{
    public static int GetUserChoice(int minValue, int maxValue)
    {
        int choice;
        bool isValid = false;

        do
        {
            Console.Write($"Enter choice ({minValue}-{maxValue}): ");
            isValid = int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue;

            if (!isValid)
                Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");

        } while (!isValid);

        return choice;
    }
}