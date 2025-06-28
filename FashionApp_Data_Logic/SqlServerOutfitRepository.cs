using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq; 

namespace FashionApp_Data_Logic
{
    public class SqlServerOutfitRepository : IOutfitRepository
    {
        private readonly string _connectionString;

        public SqlServerOutfitRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public bool AddOutfit(OutfitModel outfit)
        {
            const string sql = @"INSERT INTO Outfits (Name, Recommendation, IsAvailable) 
                                 VALUES (@Name, @Recommendation, @IsAvailable);
                                 SELECT SCOPE_IDENTITY();"; 

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", outfit.Name);
                    cmd.Parameters.AddWithValue("@Recommendation", outfit.Recommendation);
                    cmd.Parameters.AddWithValue("@IsAvailable", outfit.IsAvailable);

                    try
                    {
                        var result = cmd.ExecuteScalar();

                        if (result != null && int.TryParse(result.ToString(), out int newId))
                        {
                            outfit.Id = newId;
                            return true;
                        }
                        return false;
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"SQL Error during AddOutfit: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public List<OutfitModel> GetAllOutfits()
        {
            var outfits = new List<OutfitModel>();
            const string sql = "SELECT Id, Name, Recommendation, IsAvailable FROM Outfits ORDER BY Name";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
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

        public OutfitModel GetOutfitById(int id)
        {
            const string sql = "SELECT Id, Name, Recommendation, IsAvailable FROM Outfits WHERE Id = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
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
            }
            return null;
        }

        public bool UpdateOutfit(OutfitModel outfit)
        {
            const string sql = @"UPDATE Outfits 
                                 SET Name = @Name, 
                                     Recommendation = @Recommendation, 
                                     IsAvailable = @IsAvailable,
                                 WHERE Id = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", outfit.Id);
                    cmd.Parameters.AddWithValue("@Name", outfit.Name);
                    cmd.Parameters.AddWithValue("@Recommendation", outfit.Recommendation);
                    cmd.Parameters.AddWithValue("@IsAvailable", outfit.IsAvailable);

                    try
                    {
                        return cmd.ExecuteNonQuery() > 0;
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"SQL Error during UpdateOutfit: {ex.Message}");
                        return false;
                    }
                }
            }
        }

        public bool DeleteOutfit(int id)
        {
            const string sql = "DELETE FROM Outfits WHERE Id = @Id";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<OutfitModel> SearchOutfits(string searchTerm)
        {
            var outfits = new List<OutfitModel>();
            const string sql = @"SELECT Id, Name, Recommendation, IsAvailable 
                                 FROM Outfits 
                                 WHERE Name LIKE @SearchTerm 
                                 OR Recommendation LIKE @SearchTerm";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
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
            }
            return outfits;
        }

        public string[] GetAvailableOutfitNames()
        {
            var names = new List<string>();
            const string sql = "SELECT Name FROM Outfits WHERE IsAvailable = 1 ORDER BY Name";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(0));
                    }
                }
            }
            return names.ToArray();
     
        }
        public string[] GetAllOutfitNames()
        {
            var names = new List<string>();
            const string sql = "SELECT Name FROM Outfits ORDER BY Name";

            using (var connection = GetConnection())
            {
                connection.Open();
                using (var cmd = new SqlCommand(sql, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString(0));
                    }
                }
            }
            return names.ToArray();
        }
    }
}