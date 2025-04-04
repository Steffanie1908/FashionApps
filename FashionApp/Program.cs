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
            bool exitApp = false;

            while (!exitApp)
            {
                // gets data from services
                string[] outfits = dataService.GetAvailableOutfits();
                string[] actions = dataService.GetAvailableActions();

                // this display the menu and get user choice
                DisplayActions(actions);
                int userAction = GetUserChoice(1, actions.Length);

                // this process the actions
                exitApp = ProcessUserAction(userAction, outfits, outfitService);

                if (!exitApp)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("\nThank you for using Style Selector. Goodbye!");
            Console.WriteLine("Press any key to exit...");
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
            string input;
            bool isValid;

            do
            {
                Console.Write($"Enter choice ({minValue}-{maxValue}): ");
                input = Console.ReadLine();
                isValid = UserInputHelper.TryParseChoice(input, minValue, maxValue, out choice);

                if (!isValid)
                    Console.WriteLine($"Invalid input. Please enter a number between {minValue} and {maxValue}.");
            } while (!isValid);

            return choice;
        }

        static bool ProcessUserAction(int action, string[] outfits, OutfitService outfitService)
        {
            switch (action)
            {
                case 1:
                    DisplayOutfits(outfits);
                    return false;
                case 2:
                    SelectOutfit(outfits, outfitService);
                    return false;
                case 3:
                    return true; 
                default:
                    Console.WriteLine("Invalid choice selected.");
                    return false;
            }
        }

        static void DisplayOutfits(string[] outfits)
        {
            Console.WriteLine("\nAVAILABLE STYLES:");
            for (int i = 0; i < outfits.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {outfits[i]}");
            }
        }

        static void SelectOutfit(string[] outfits, OutfitService outfitService)
        {
            DisplayOutfits(outfits);
            Console.Write("Your choice: ");
            int outfitChoice = GetUserChoice(1, outfits.Length);

            // gets selected style and recommendations from business logic
            string selectedStyle = outfits[outfitChoice - 1];
            string recommendation = outfitService.GetRecommendation(selectedStyle);

            // this display results to user
            Console.WriteLine($"\nYou selected the {selectedStyle} style!");
            Console.WriteLine($"Recommendation: {recommendation}");
        }
    }
}