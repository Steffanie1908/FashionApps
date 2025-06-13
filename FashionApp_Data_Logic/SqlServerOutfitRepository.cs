using System.Data.SqlClient;

namespace FashionApp_Data_Logic
{
    public class SqlServerOutfitRepository : IOutfitRepository, IDisposable
    {
        private readonly SqlConnection _connection;
        private readonly string _connectionString;

        public SqlServerOutfitRepository(string connectionString)
        {
            _connectionString = connectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        public bool AddOutfit(OutfitModel outfit)
        {
            const string sql = @"INSERT INTO Outfits (Name, Recommendation, IsAvailable) 
                               VALUES (@Name, @Recommendation, @IsAvailable);
                               SELECT SCOPE_IDENTITY();";

            using (var cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@Name", outfit.Name);
                cmd.Parameters.AddWithValue("@Recommendation", outfit.Recommendation);
                cmd.Parameters.AddWithValue("@IsAvailable", outfit.IsAvailable);

                var result = cmd.ExecuteScalar();
                return result != null;
            }
        }

        public List<OutfitModel> GetAllOutfits()
        {
            var outfits = new List<OutfitModel>();
            const string sql = "SELECT Id, Name, Recommendation, IsAvailable FROM Outfits";

            using (var cmd = new SqlCommand(sql, _connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    outfits.Add(new OutfitModel
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Recommendation = reader.GetString(2),
                        IsAvailable = reader.GetBoolean(3)
                    });
                }
            }
            return outfits;
        }

        public OutfitModel GetOutfitById(int id)
        {
            const string sql = "SELECT Id, Name, Recommendation, IsAvailable FROM Outfits WHERE Id = @Id";

            using (var cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new OutfitModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Recommendation = reader.GetString(2),
                            IsAvailable = reader.GetBoolean(3)
                        };
                    }
                }
            }
            return null;
        }

        public bool UpdateOutfit(OutfitModel outfit)
        {
            const string sql = @"UPDATE Outfits 
                               SET Name = @Name, 
                                   Recommendation = @Recommendation, 
                                   IsAvailable = @IsAvailable,
                                   ModifiedDate = GETDATE()
                               WHERE Id = @Id";

            using (var cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", outfit.Id);
                cmd.Parameters.AddWithValue("@Name", outfit.Name);
                cmd.Parameters.AddWithValue("@Recommendation", outfit.Recommendation);
                cmd.Parameters.AddWithValue("@IsAvailable", outfit.IsAvailable);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteOutfit(int id)
        {
            const string sql = "DELETE FROM Outfits WHERE Id = @Id";

            using (var cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            var outfits = new List<OutfitModel>();
            const string sql = @"SELECT Id, Name, Recommendation, IsAvailable 
                               FROM Outfits 
                               WHERE Name LIKE @SearchTerm 
                               OR Recommendation LIKE @SearchTerm";

            using (var cmd = new SqlCommand(sql, _connection))
            {
                cmd.Parameters.AddWithValue("@SearchTerm", $"%{searchTerm}%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        outfits.Add(new OutfitModel
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Recommendation = reader.GetString(2),
                            IsAvailable = reader.GetBoolean(3)
                        });
                    }
                }
            }
            return outfits;
        }

        public string[] GetAvailableOutfitNames()
        {
            var names = new List<string>();
            const string sql = "SELECT Name FROM Outfits WHERE IsAvailable = 1";

            using (var cmd = new SqlCommand(sql, _connection))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    names.Add(reader.GetString(0));
                }
            }
            return names.ToArray();
        }

        public void Dispose()
        {
            _connection?.Close();
            _connection?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}