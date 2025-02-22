using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAMBackend.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime LastUpdated { get; set; }

        [BindNever]
        public List<File> Files { get; set; } = new List<File>();
    }

}
