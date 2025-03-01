using System.Data.SqlTypes;

using DAMBackend.Model.FileModel;
using DAMBackend.Model.UserModel;

namespace DAMBackend.Model.ProjectModel


{

    public enum AccessLevel {
        Admin,
        Everyone
    }
    public class Project 

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

        public ICollection<FileClass> Files { get; set;} = new HashSet<FileClass>();

        public ICollection<User> Users { get; set;} = new HashSet<User>();

    }
}