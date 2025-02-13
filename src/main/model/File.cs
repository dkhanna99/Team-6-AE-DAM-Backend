using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAMBackend.Models
{
    public class File
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int ProjectId { get; set; }

        [BindNever]
        public Project Project { get; set; }
    }

}
