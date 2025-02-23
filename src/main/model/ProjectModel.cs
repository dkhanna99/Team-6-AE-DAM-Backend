using System.Data.SqlTypes;

namespace backend.sql

{
    public class ProjectModel 

    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Status { get; set; }

        public string? location { get; set; }

        public required DateTime LastUpdate { get; set; }
        // change in ER diagram

        public ICollection<FileModel>? Files { get; set; }

    }
}