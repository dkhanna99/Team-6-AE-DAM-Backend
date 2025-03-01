using DAMBackend.Model.FileModel;
using System;

namespace DAMBackend.Model.TagModel
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
    public enum MediaType {
        Photo,
        Video,
        Drawing,
        Document,
        Other
    }



    public class Tag

    // Metadata

    {

        public required int UserId { get; set; }

        public Guid ProjectId { get; set; }

        public string Phase { get; set; }
        // Ask developers
        
        public Department Dep { get; set; }

        public MediaType Type { get; set; }

        public required Guid FileId { get; set; }

        public required FileClass File { get; set; }



    }
}