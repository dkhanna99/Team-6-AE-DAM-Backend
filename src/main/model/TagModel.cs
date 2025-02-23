using Microsoft.Identity.Client;
using Org.BouncyCastle.Bcpg;

namespace backend.sql

{
    public enum Department {
            Elec,
            Mech,
            Civil,
            Software,
            Environment,
            Management,
            Other
        }
    public enum Type {
        Photo,
        Video,
        Drawing,
        Document,
        Other
    }



    public class TagModel

    // Metadata

    {

        public required int UserId { get; set; }

        public int ProjectId { get; set; }

        public string Phase { get; set; }
        // Ask developers
        
        public Department Dep { get; set; }

        public Type Type { get; set; }

        public required int FileId { get; set; }

        public required FileModel File { get; set; }



    }
}