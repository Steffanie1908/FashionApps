using FashionApp_Business_Logic;
using FashionApp_Data_Logic;
using System.Configuration;
using System.Data.SqlClient;

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

           
            var dataService = new DataService("sqlserver", connectionString);
            var outfitService = dataService.GetOutfitService();

            Console.WriteLine("WELCOME TO STYLE SELECTOR");

           
            bool exitApp = false;
            while (!exitApp)
            {
                try
                {
                    // Gets data from services
                    string[] outfits = dataService.GetAvailableOutfits();
                    string[] actions = dataService.GetAvailableActions();

                    // Displays the menu and get user choice
                    DisplayActions(actions);
                    int userAction = GetUserChoice(1, actions.Length);

                    // Process the actions
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

            // Gets selected style and recommendations from business logic
            string selectedStyle = outfits[outfitChoice - 1];
            string recommendation = outfitService.GetRecommendation(selectedStyle);

            // Display results to user
            Console.WriteLine($"\nYou selected the {selectedStyle} style!");
            Console.WriteLine($"Recommendation: {recommendation}");
        }

       
        static void AddNewStyle(OutfitService outfitService)
        {
            Console.WriteLine("\nADD NEW STYLE");

            // Get style name
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

            // Get style recommendation (instead of description)
            Console.Write("Enter style recommendation: ");
            string recommendation = Console.ReadLine();

            // Adds the new style
            bool success = outfitService.AddNewOutfit(name, recommendation);

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

            // Shows all styles first
            List<OutfitModel> allOutfits = outfitService.GetAllOutfits();
            if (allOutfits.Count == 0)
            {
                Console.WriteLine("No styles available to update.");
                return;
            }

            DisplayAllStyles(allOutfits);

            // Keeps trying until valid ID is entered or canceled
            while (true)
            {
                // Get ID to update
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

                // Checks if style exists
                OutfitModel existingOutfit = outfitService.GetOutfitDetails(id);
                if (existingOutfit == null)
                {
                    Console.WriteLine($"No style found with ID {id}. Please try again.");
                    continue;
                }

                // Get updated values
                Console.WriteLine($"Updating style: {existingOutfit.Name}");

                // Get new name
                Console.Write($"Enter new name (or press Enter to keep '{existingOutfit.Name}'): ");
                string newName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newName))
                {
                    newName = existingOutfit.Name;
                }

                // Get new recommendation
                Console.Write($"Enter new recommendation (or press Enter to keep '{existingOutfit.Recommendation}'): ");
                string newRecommendation = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(newRecommendation))
                {
                    newRecommendation = existingOutfit.Recommendation;
                }

                // Get availability
                bool isAvailable = existingOutfit.IsAvailable;
                bool validAvailability = false;

                while (!validAvailability)
                {
                    Console.Write($"Is this style available? (Y/N) [Current: {(existingOutfit.IsAvailable ? "Y" : "N")}]: ");
                    string availableInput = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(availableInput))
                    {
                        validAvailability = true; // Keep current value
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

                // Updates the style
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

            // Shows all styles first
            List<OutfitModel> allOutfits = outfitService.GetAllOutfits();
            if (allOutfits.Count == 0)
            {
                Console.WriteLine("No styles available to delete.");
                return;
            }

            DisplayAllStyles(allOutfits);

            // Keeps trying until valid ID is entered or canceled
            while (true)
            {
                // Get ID to delete
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

                // Checks if style exists
                OutfitModel outfitToDelete = outfitService.GetOutfitDetails(id);
                if (outfitToDelete == null)
                {
                    Console.WriteLine($"No style found with ID {id}. Please try again.");
                    continue;
                }

                // Confirms deletion
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
                        // Deletes the style
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