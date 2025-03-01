using DAMBackend.Model.FileModel;
using DAMBackend.Model.ProjectModel;

namespace DAMBackend.Model.UserModel

{
    public enum Role {
            User, 
            Admin
        }

    public class User
    {
        public int Id {get; set;}

        public required string firstName {get; set;}
        public required string lastName {get; set;}
        public required string Email {get; set;} = string.Empty;

        public required Role Role {get; set;}

        // true is active, false is inactive
        public required bool status {get; set;}

        // public required string PasswordHash {get; set;} = string.Empty;

        public ICollection<FileClass> Files { get; set; } = new HashSet<FileClass>();
        public ICollection<Project> Projects { get; set;} = new HashSet<Project>();
    }
}