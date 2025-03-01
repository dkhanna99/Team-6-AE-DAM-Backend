using DAMBackend.Archived.FileArchivedModel;
using DAMBackend.Model.FileModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAMBackend.Archived.ProjectArchivedModel
{
    public class ProjectArchived
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime LastUpdated { get; set; }

        [BindNever]
        public List<FileClass> Files { get; set; } = new List<FileClass>();
    }

}
