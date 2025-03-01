using System.Collections.Generic;
using System;
namespace DAMBackend.MetadataEngine
{
    public class MetadataManager
    {
        private string connectionString;

        // Constructor to initialize the connection string
        public MetadataManager(string server, string database)
        {
            this.connectionString = $"Server={server};Database={database};Integrated Security=True;";
        }

        // Add description to the corresponding file
        public void AddDescription(string file, string description)
        {
            // TODO: Implement method to update the description in the database
            Console.WriteLine($"Adding description to {file}: {description}");
        }

        // Apply the same description to all files
        public void AddDescriptionToAll(List<string> files, string description)
        {
            // TODO: Implement method to update the description for all files
            foreach (var file in files)
            {
                Console.WriteLine($"Applying description to {file}: {description}");
            }
        }

        // Add tags to the corresponding file
        public void AddTag(string file, List<string> tags)
        {
            // TODO: Implement method to update the tags in the database
            Console.WriteLine($"Adding tags to {file}: {string.Join(", ", tags)}");
        }

        // Apply the same tags to all files
        public void AddTagsToAll(List<string> files, List<string> tags)
        {
            // TODO: Implement method to update the tags for all files
            foreach (var file in files)
            {
                Console.WriteLine($"Applying tags to {file}: {string.Join(", ", tags)}");
            }
        }

        // Add location to the corresponding file (overwrite EXIF if available)
        public void AddLocation(string file, string location)
        {
            // TODO: Implement method to update the location in the database (EXIF overwrite)
            Console.WriteLine($"Adding location to {file}: {location}");
        }

        // Apply the same location to all files
        public void AddLocationToAll(List<string> files, string location)
        {
            // TODO: Implement method to update the location for all files
            foreach (var file in files)
            {
                Console.WriteLine($"Applying location to {file}: {location}");
            }
        }

        // Add date to the corresponding file
        public void AddDate(string file, DateTime date)
        {
            // TODO: Implement method to update the date in the database
            Console.WriteLine($"Adding date to {file}: {date.ToShortDateString()}");
        }

        // Apply the same date to all files
        public void AddDateToAll(List<string> files, DateTime date)
        {
            // TODO: Implement method to update the date for all files
            foreach (var file in files)
            {
                Console.WriteLine($"Applying date to {file}: {date.ToShortDateString()}");
            }
        }
    }
}