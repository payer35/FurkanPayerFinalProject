using SQLite;
using FurkanPayerFinalProject.Models;
using System.IO;
using System.Threading.Tasks;

namespace FurkanPayerFinalProject.Services
{
    public class DatabaseService
    {
        private static SQLiteAsyncConnection database;

        public static async Task InitializeDatabase()
        {
            if (database == null)
            {
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "UserDatabase.db");
                database = new SQLiteAsyncConnection(databasePath);

                await database.CreateTableAsync<User>();
            }
        }

        public static SQLiteAsyncConnection GetDatabase()
        {
            return database;
        }
    }
}
