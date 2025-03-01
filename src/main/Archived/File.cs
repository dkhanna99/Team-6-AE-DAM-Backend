using DAMBackend.Model.ProjectModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DAMBackend.Archived.FileArchivedModel
{
    public class FileArchivedClass

    {
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public int ProjectId { get; set; }

    [BindNever] public Project Project { get; set; }
    }

}
