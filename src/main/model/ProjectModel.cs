using System.Data.SqlTypes;

namespace DAMBackend.Models


{

    public enum AccessLevel {
        Admin,
        Everyone
    }
    public class ProjectModel 

    {
        public Guid Id { get; set; }

        public required string Name { get; set; }

        public required string Status { get; set; }

        public string? location { get; set; }

        public string? imagePath {get; set; }

        public required AccessLevel accessLevel {get; set;}

        public required string Phase { get; set;}

        public required DateTime LastUpdate { get; set; }
        // change in ER diagram

        public ICollection<FileModel> Files { get; set;} = new HashSet<FileModel>();

        public ICollection<UserModel> Users { get; set;} = new HashSet<UserModel>();

    }
}