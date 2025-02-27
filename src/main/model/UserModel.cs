namespace DAMBackend.Models

{
    public enum Role {
            User, 
            Admin
        }

    public class UserModel
    {
        public int Id {get; set;}

        public required string firstName {get; set;}
        public required string lastName {get; set;}
        public required string Email {get; set;} = string.Empty;

        public required Role Role {get; set;}

        // true is active, false is inactive
        public required bool status {get; set;}

        // public required string PasswordHash {get; set;} = string.Empty;

        public ICollection<FileModel> Files { get; set; } = new HashSet<FileModel>();
        public ICollection<ProjectModel> Projects { get; set;} = new HashSet<ProjectModel>();
    }
}