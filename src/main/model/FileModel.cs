// *** Not using Data Annotations currently as am not sure how the searching 
// will work, fluent API is supposedly better, will ask team

using System.Runtime.CompilerServices;

namespace backend.sql
{
    public class FileModel 

    // EXIF QUALITIES

    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Extenstion { get; set; }

        public string Description { get; set; }

        public required string ThumbnailPath { get; set; }

        public required string ViewPath { get; set; }

        public required string OriginalPath { get; set; }

        public required decimal GPSLat { get; set; }

        public required decimal GPSLon { get; set; }

        public required decimal GPSAlt { get; set; }

        public required DateTime DateTimeOriginal { get; set; }
        // *** NOTE *** switch this to a datetime object in sql

        public required int PixelWidth { get; set; }

        public required int PixelHeight { get; set; }

        public required string Make { get; set; }

        public required string Model { get; set; }

        public required int FocalLength { get; set; }

        public required float Apperture { get; set; }


        public required string Copyright { get; set; }

        public TagModel? Tags { get; set; }

        public int? ProjectId { get; set; }

        public ProjectModel? Project { get; set; }
        
    }

}