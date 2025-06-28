using FashionApp_Data_Logic;
using System.Collections.Generic;
using System.Linq;

namespace FashionApp_Business_Logic
{
    public class DataService
    {
        private readonly IOutfitRepository _outfitRepository;
        private readonly OutfitService _outfitService; 


        public DataService(string repositoryType, string connectionString = null)
        {
 
            switch (repositoryType.ToLower())
            {
                case "sqlserver":
                    _outfitRepository = new SqlServerOutfitRepository(connectionString);
                    break;
                case "jsonfile":
                    _outfitRepository = new JsonFileOutfitRepository("outfits.json"); 
                    break;
                case "textfile":
                    _outfitRepository = new TextFileOutfitRepository("outfits.txt"); 
                    break;
                case "inmemory":
                default:
                    _outfitRepository = new InMemoryOutfitRepository();
                    break;
            }

            _outfitService = new OutfitService(_outfitRepository);
        }

        public OutfitService GetOutfitService()
        {
            return _outfitService;
        }
        public string[] GetAvailableOutfits()
        {
            return _outfitService.GetAvailableOutfitNames();
        }

        public string[] GetAvailableActions()
        {
            return new string[]
            {
                "1. Display all available styles",
                "2. Select a style and get recommendation",
                "3. Add a new style",
                "4. Search styles",
                "5. Update a style",
                "6. Delete a style",
                "7. Exit"
            };
        }
    }
}