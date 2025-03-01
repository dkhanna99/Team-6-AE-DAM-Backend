// *** Not using Data Annotations currently as am not sure how the searching 
// will work, fluent API is supposedly better, will ask team
using DAMBackend.Model.TagModel;
using DAMBackend.Model.ProjectModel;
using DAMBackend.Model.UserModel;
using System;

namespace DAMBackend.Model.FileModel
{
    // some of the data might not be found on exif, so i changed some collumn to be nullable
    public class FileClass // File is a property of System.IO.File
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Extension { get; set; }
        public string? Description { get; set; }
        public required string ThumbnailPath { get; set; }
        public required string ViewPath { get; set; }
        public required string OriginalPath { get; set; }
        public decimal? GPSLat { get; set; }
        public decimal? GPSLon { get; set; }
        public decimal? GPSAlt { get; set; }
        public DateTime? DateTimeOriginal { get; set; }
        public required int PixelWidth { get; set; }
        public required int PixelHeight { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? FocalLength { get; set; }
        public float? Aperture { get; set; }
        public string? Copyright { get; set; }
        public Tag? Tags { get; set; }
        public Guid? ProjectId { get; set; }
        public Project? Project { get; set; }

        public int UserId { get; set; }
        // change to be required 

        public User User { get; set; }
      // public class File 

    // EXIF QUALITIES

    // {
    //     public int Id { get; set; }

    //     public required string Name { get; set; }

    //     public required string Extenstion { get; set; }

    //     public string Description { get; set; }

    //     public required string ThumbnailPath { get; set; }

    //     public required string ViewPath { get; set; }

    //     public required string OriginalPath { get; set; }

    //     public required decimal GPSLat { get; set; }

    //     public required decimal GPSLon { get; set; }

    //     public required decimal GPSAlt { get; set; }

    //     public required DateTime DateTimeOriginal { get; set; }
    //     // *** NOTE *** switch this to a datetime object in sql

    //     public required int PixelWidth { get; set; }

    //     public required int PixelHeight { get; set; }

    //     public required string Make { get; set; }

    //     public required string Model { get; set; }

    //     public required int FocalLength { get; set; }

    //     public required float Apperture { get; set; }


    //     public required string Copyright { get; set; }

    //     public TagModel? Tags { get; set; }

    //     public int? ProjectId { get; set; }

    //     public ProjectModel? Project { get; set; }
        
    // }
}

}