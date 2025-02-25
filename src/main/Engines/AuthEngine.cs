// using Microsoft.Data.Sqlite;
using System;
using System.Security.Cryptography;
using System.Text;

namespace DAMBackend.auth
{
    public class AuthService
    {
        private readonly string _connectionString = "Data Source=Auth/auth.db";

        // public AuthService()
        // {
        //     using var connection = new SqliteConnection(_connectionString);
        //     connection.Open();
        //     var command = connection.CreateCommand();
        //     command.CommandText = @"CREATE TABLE IF NOT EXISTS users (
        //                                 id INTEGER PRIMARY KEY AUTOINCREMENT,
        //                                 email TEXT UNIQUE NOT NULL,
        //                                 passwordHash TEXT NOT NULL
        //                             );";
        //     command.ExecuteNonQuery();
        // }

        // public async Task<bool> RegisterUserAsync(string email, string password)
        // {
        //     var hashedPassword = HashPassword(password);
        //     using var connection = new SqliteConnection(_connectionString);
        //     connection.Open();
        //     var command = connection.CreateCommand();
        //     command.CommandText = "INSERT INTO users (email, passwordHash) VALUES (@Email, @PasswordHash)";
        //     command.Parameters.AddWithValue("@Email", email);
        //     command.Parameters.AddWithValue("@PasswordHash", hashedPassword);

        //     try
        //     {
        //         await command.ExecuteNonQueryAsync();
        //         return true;
        //     }
        //     catch
        //     {
        //         return false;
        //     }
        // }

        // public async Task<bool> AuthenticateUserAsync(string email, string password)
        // {
        //     using var connection = new SqliteConnection(_connectionString);
        //     connection.Open();
        //     var command = connection.CreateCommand();
        //     command.CommandText = "SELECT passwordHash FROM users WHERE email = @Email";
        //     command.Parameters.AddWithValue("@Email", email);
        //     using var reader = await command.ExecuteReaderAsync();

        //     if (!reader.Read()) return false;

        //     string storedHash = reader.GetString(0);
        //     return VerifyPassword(password, storedHash);
        // }

        private static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        private static bool VerifyPassword(string input, string storedHash)
        {
            return HashPassword(input) == storedHash;
        }
    }
}
