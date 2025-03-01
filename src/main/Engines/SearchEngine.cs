using System;


namespace DAMBackend.SearchEngine
{
    public class SearchEngine
    {
        private string connectionString;

        // Constructor to initialize the connection string
        public SearchEngine(string server, string database)
        {
            // TODO: Use Integrated Security for Windows Authentication or handle SSO token management here
            connectionString = $"Server={server};Database={database};Integrated Security=True;";
        }

        // Method to search by date
        public void SearchByDate(DateTime startDate, DateTime endDate)
        {
            // TODO: Placeholder for actual implementation
            // Example: Querying the database with date range to update data
            UpdateQuery("searchByDate", startDate, endDate);
        }

        // Method to search by tags
        public void SearchByTags(string[] tags)
        {
            // TODO: Placeholder for actual implementation
            // Example: Querying the database with tags to update data
            UpdateQuery("searchByTags", tags);
        }

        // Method to search by location
        public void SearchByLocation(string location)
        {
            // TODO: Placeholder for actual implementation
            // Example: Querying the database with location to update data
            UpdateQuery("searchByLocation", location);
        }

        // Method to search by description
        public void SearchByDescription(string description)
        {
            // TODO: Placeholder for actual implementation
            // Example: Querying the database with description to update data
            UpdateQuery("searchByDescription", description);
        }

        // Helper method to execute the query and update the database
        private void UpdateQuery(string searchType, params object[] parameters)
        {
            // try
            // {
            //     using (var connection = new MySqlConnection(connectionString))
            //     {
            //         connection.Open();

            //         using (var cmd = new MySqlCommand($"UPDATE search_queries SET {searchType} = @params WHERE query_id = 1", connection))
            //         {
            //             // Execute query or set parameters if needed
            //             cmd.ExecuteNonQuery();
            //         }
            //     }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"An error occurred: {ex.Message}");
            // }
        }

    }
}
