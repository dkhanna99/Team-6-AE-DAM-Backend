using System;
// using MySql.Data.MySqlClient;

namespace DAMBackend.EnginePlus
{
    public class EnginePlus
    {
        private string connectionString;

         public EnginePlus(string server, string database)
        {
            this.connectionString = $"Server={server};Database={database};Integrated Security=True;";
        }

        // Method to download a file from a project visible to the user
        public void DownloadFileFromProject(string projectId, string userId)
        {
            // TODO: generate query string query 
            // execute query
            // handle result (resolve or not)
        }

        // Method to email file link to self
        public void EmailFileLinkToSelf(string fileLink, string userId)
        {
            // TODO: Implement the logic to send an email to the user
            Console.WriteLine($"Sending file link to {userId}: {fileLink}");
        }

        // Method to email file link to another user
        public void EmailFileLinkToOther(string fileLink, string fromUserId, string toUserId)
        {
            // TODO: Implement the logic to send an email to another user
            Console.WriteLine($"Sending file link from {fromUserId} to {toUserId}: {fileLink}");
        }

        
    }
}

