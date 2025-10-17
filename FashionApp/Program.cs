using FashionApp_Business_Logic;
using FashionApp_Data_Logic;
using System.Configuration;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace FashionApp.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["FashionAppDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                Console.WriteLine("Error: Database connection string not found in config file");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Testing database connection...");
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("✓ Successfully connected to database");

                    var testRepo = new SqlServerOutfitRepository(connectionString);
                    var testOutfits = testRepo.GetAllOutfits();
                    Console.WriteLine($"✓ Found {testOutfits.Count} existing outfits");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DATABASE ERROR: {ex.Message}");
                Console.WriteLine("Please check your SQL Server configuration and try again.");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }

            Console.Clear();

            IOutfitRepository outfitRepository = new SqlServerOutfitRepository(connectionString);
            var outfitService = new OutfitService(outfitRepository);

            string userEmail = GetUserEmail();
            outfitService.SetUserEmail(userEmail);

            Console.WriteLine("WELCOME TO STYLE SELECTOR");

            bool exitApp = false;
            while (!exitApp)
            {
                try
                {
                    string[] outfits = outfitService.GetAvailableOutfitNames();
                    string[] actions = new string[]
                    {
                        "1. View All Styles",
                        "2. Select an Outfit",
                        "3. Add New Style",
                        "4. Search Styles",
                        "5. Update Style",
                        "6. Delete Style",
                        "7. Exit"
                    };

                    DisplayActions(actions);
                    int userAction = GetUserChoice(1, actions.Length);

                    exitApp = ProcessUserAction(userAction, outfits, outfitService);

                    if (!exitApp)
                    {
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nAn error occurred: {ex.Message}");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }

            Console.WriteLine("\nThank you for using Style Selector. Goodbye!");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static string GetUserEmail()
        {
            Console.WriteLine("STYLE SELECTOR - Email Notification Setup");
            Console.WriteLine("=========================================");

            while (true)
            {
                Console.Write("Enter your email address for style recommendations (or press Enter to skip): ");
                string email = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(email))
                {
                    Console.WriteLine("Email notifications disabled for this session.\n");
                    return null;
                }

                if (IsValidEmail(email))
                {
                    Console.WriteLine($"Email notifications enabled for: {email}\n");
                    return email;
                }
                else
                {
                    Console.WriteLine("Invalid email format. Please try again.\n");
                }
            }
        }

        static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
                return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
            }
            catch
            {
                return false;
            }
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
                    AddNewStyle(outfitService);
                    return false;
                case 4:
                    SearchStyles(outfitService);
                    return false;
                case 5:
                    UpdateStyle(outfitService);
                    return false;
                case 6:
                    DeleteStyle(outfitService);
                    return false;
                case 7:
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
            if (outfits.Length == 0)
            {
                Console.WriteLine("\nNo styles available. Please add some styles first.");
                return;
            }

            DisplayOutfits(outfits);
            Console.Write("Your choice: ");
            int outfitChoice = GetUserChoice(1, outfits.Length);

            string selectedStyle = outfits[outfitChoice - 1];
            string recommendation = outfitService.GetRecommendation(selectedStyle);

            Console.WriteLine($"\nYou selected the {selectedStyle} style!");
            Console.WriteLine($"Recommendation: {recommendation}");

            outfitService.SendOutfitRecommendationEmail(selectedStyle);
        }

        static void AddNewStyle(OutfitService outfitService)
        {
            Console.WriteLine("\nADD NEW STYLE");

            string name = "";
            bool isValidName = false;

            while (!isValidName)
            {
                Console.Write("Enter style name: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Style name cannot be empty. Please try again.");
                }
                else
                {
                    isValidName = true;
                }
            }

            Console.Write("Enter style recommendation: ");
            string recommendation = Console.ReadLine();

            bool success = outfitService.AddNewOutfit(name, recommendation, true);

            if (success)
            {
                Console.WriteLine($"\nStyle '{name}' was added successfully!");
            }
            else
            {
                Console.WriteLine("\nFailed to add style. The style name may already exist.");
            }
        }

        static void SearchStyles(OutfitService outfitService)
        {
            Console.WriteLine("\nSEARCH STYLES");
            Console.Write("Enter search term (or press Enter to show all): ");
            string searchTerm = Console.ReadLine();

            List<OutfitModel> results = outfitService.SearchOutfits(searchTerm);

            if (results.Count == 0)
            {
                Console.WriteLine("\nNo styles found matching your search.");
                return;
            }

            Console.WriteLine($"\nFound {results.Count} style(s):");
            foreach (OutfitModel outfit in results)
            {
                string availabilityStatus = outfit.IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"ID: {outfit.Id} | {outfit.Name} - {outfit.Recommendation} ({availabilityStatus})");
            }
        }

        static void UpdateStyle(OutfitService outfitService)
        {
            Console.WriteLine("\nUPDATE STYLE");

            List<OutfitModel> allOutfits = outfitService.GetAllOutfits();
            if (allOutfits.Count == 0)
            {
                Console.WriteLine("No styles available to update.");
                return;
            }

            DisplayAllStyles(allOutfits);

            while (true)
            {
                Console.Write("\nEnter the ID of the style to update (or 0 to cancel): ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID format. Please try again.");
                    continue;
                }

                if (id == 0)
                {
                    Console.WriteLine("Update canceled.");
                    return;
                }

                OutfitModel existingOutfit = outfitService.GetOutfitById(id);
                if (existingOutfit == null)
                {
                    Console.WriteLine($"No style found with ID {id}. Please try again.");
                    continue;
                }

                Console.WriteLine($"Updating style: {existingOutfit.Name}");

                Console.Write($"Enter new name (or press Enter to keep '{existingOutfit.Name}'): ");
                string newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    newName = existingOutfit.Name;
                }

                Console.Write($"Enter new recommendation (or press Enter to keep '{existingOutfit.Recommendation}'): ");
                string newRecommendation = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newRecommendation))
                {
                    newRecommendation = existingOutfit.Recommendation;
                }

                bool isAvailable = existingOutfit.IsAvailable;
                bool validAvailability = false;

                while (!validAvailability)
                {
                    Console.Write($"Is this style available? (Y/N) [Current: {(existingOutfit.IsAvailable ? "Y" : "N")}]: ");
                    string availableInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(availableInput))
                    {
                        validAvailability = true;
                    }
                    else if (availableInput.ToUpper() == "Y")
                    {
                        isAvailable = true;
                        validAvailability = true;
                    }
                    else if (availableInput.ToUpper() == "N")
                    {
                        isAvailable = false;
                        validAvailability = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }

                bool success = outfitService.UpdateOutfit(id, newName, newRecommendation, isAvailable);

                if (success)
                {
                    Console.WriteLine($"\nStyle with ID {id} was updated successfully!");
                    return;
                }
                else
                {
                    Console.WriteLine("\nFailed to update style. The style name may already exist.");
                    return;
                }
            }
        }

        static void DisplayAllStyles(List<OutfitModel> outfits)
        {
            Console.WriteLine("\nAvailable styles:");
            foreach (OutfitModel outfit in outfits)
            {
                string availabilityStatus = outfit.IsAvailable ? "Available" : "Not Available";
                Console.WriteLine($"ID: {outfit.Id} | {outfit.Name} - {outfit.Recommendation} ({availabilityStatus})");
            }
        }

        static void DeleteStyle(OutfitService outfitService)
        {
            Console.WriteLine("\nDELETE STYLE");

            List<OutfitModel> allOutfits = outfitService.GetAllOutfits();
            if (allOutfits.Count == 0)
            {
                Console.WriteLine("No styles available to delete.");
                return;
            }

            DisplayAllStyles(allOutfits);

            while (true)
            {
                Console.Write("\nEnter the ID of the style to delete (or 0 to cancel): ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("Invalid ID format. Please try again.");
                    continue;
                }

                if (id == 0)
                {
                    Console.WriteLine("Deletion canceled.");
                    return;
                }

                OutfitModel outfitToDelete = outfitService.GetOutfitById(id);
                if (outfitToDelete == null)
                {
                    Console.WriteLine($"No style found with ID {id}. Please try again.");
                    continue;
                }

                while (true)
                {
                    Console.Write($"Are you sure you want to delete style '{outfitToDelete.Name}'? (Y/N): ");
                    string confirmation = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(confirmation))
                    {
                        Console.WriteLine("Please enter Y or N.");
                    }
                    else if (confirmation.ToUpper() == "Y")
                    {
                        bool success = outfitService.DeleteOutfit(id);
                        if (success)
                        {
                            Console.WriteLine($"\nStyle with ID {id} was deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine($"\nFailed to delete style. No style found with ID {id}.");
                        }
                        return;
                    }
                    else if (confirmation.ToUpper() == "N")
                    {
                        Console.WriteLine("Deletion cancelled.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter Y or N.");
                    }
                }
            }
        }
    }
}