using FashionApp_Data_Logic;

namespace FashionApp_Business_Logic
{
    public class DataService
    {
        private readonly OutfitService _outfitService;

        public DataService()
        {
            // Default InMemory repository
            IOutfitRepository repository = new InMemoryOutfitRepository();
            _outfitService = new OutfitService(repository);
        }

        public DataService(string dataSourceType, string connectionStringOrPath = null)
        {
            IOutfitRepository repository = dataSourceType.ToLower() switch
            {
                "inmemory" => new InMemoryOutfitRepository(),
                "textfile" => new TextFileOutfitRepository(connectionStringOrPath ?? "outfits.txt"),
                "jsonfile" => new JsonFileOutfitRepository(connectionStringOrPath ?? "outfits.json"),
                "sqlserver" => new SqlServerOutfitRepository(connectionStringOrPath ?? GetDefaultConnectionString()),
                _ => throw new ArgumentException("Invalid data source type")
            };

            _outfitService = new OutfitService(repository);
        }

        private string GetDefaultConnectionString()
        {
            return "Server=.;Database=FashionAppDB;Integrated Security=True;";
        }
        public string[] GetAvailableOutfits()
        {
            return _outfitService.GetAvailableOutfits();
        }

        public string[] GetAvailableActions()
        {
            return new string[]
            {
                "[1] View Available Styles",
                "[2] Select Outfit",
                "[3] Add New Style",
                "[4] Search Styles",
                "[5] Update Style",
                "[6] Delete Style",
                "[7] Exit"
            };
        }

        public OutfitService GetOutfitService()
        {
            return _outfitService;
        }
    }
}