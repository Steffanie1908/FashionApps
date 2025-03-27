using System;
using FashionApp.BusinessAndDataLogic;

namespace FashionApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WELCOME TO STYLE SELECTOR");

            var dataService = new DataService();
            var outfitService = new OutfitService();

            string[] outfits = dataService.GetAvailableOutfits();
            string[] actions = dataService.GetAvailableActions();

            DisplayActions(actions);
            int userAction = GetUserChoice(1, 3);

            ProcessUserAction(userAction, outfits, outfitService);

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static void DisplayActions(string[] actions)
        {
            Console.WriteLine("\nWhat would you like to do?");
            foreach (var action in actions)
            {
                Console.WriteLine(action);
            }
        }

        static int GetUserChoice(int minValue, int maxValue)
        {
            int choice;
            bool isValid;

            do
            {
                Console.Write($"Enter choice ({minValue}-{maxValue}): ");
                isValid = int.TryParse(Console.ReadLine(), out choice) && choice >= minValue && choice <= maxValue;

                if (!isValid)
                    Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");

            } while (!isValid);

            return choice;
        }

        static void ProcessUserAction(int action, string[] outfits, OutfitService outfitService)
        {
            switch (action)
            {
                case 1:
                    outfitService.DisplayOutfits(outfits);
                    break;
                case 2:
                    outfitService.SelectOutfit(outfits);
                    break;
                case 3:
                    Console.WriteLine("Thank you for using Style Selector. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice selected.");
                    break;
            }
        }
    }
}