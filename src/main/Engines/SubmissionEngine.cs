using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Metadata;
using SixLabors.ImageSharp.Metadata.Profiles.Exif;
using SixLabors.ImageSharp.Processing;
//using DAMBackend.Models;




namespace DAMBackend.Engines.SubmissionEngine
{
    public class SubmissionEngine : ControllerBase
    {

        private readonly string _uploadPath = "../../../TestOutput"; //hard coded value

        public SubmissionEngine()
        {
        }
      
        // Method to upload files, extracts EXIF metadata for each file
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
        {
            if (!Directory.Exists(_uploadPath))
            {
                Directory.CreateDirectory(_uploadPath);
                Console.WriteLine($"Directory created: {_uploadPath}");
            }
            else
            {
                Console.WriteLine($"Directory already exists: {_uploadPath}");
            }

            // Check if the number of files exceeds 100
            if (files.Count > 100)
            {
                return BadRequest("You can upload a maximum of 100 files at once.");
            }
            Console.WriteLine("the length of files is: ", files.Count);
            // Validate and process each file
            foreach (var file in files)
            {
                // Validate file extension (e.g., allow only images and videos)
                var allowedExtensionsphoto = new[] { ".jpg", ".jpeg", ".png", ".raw", ".arw" };
                var allowedExtensionsvideo = new[] { ".mp4" };
                // to be supported: .tiff, .jpg, .gif, .mov 
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensionsphoto.Contains(fileExtension) && !allowedExtensionsvideo.Contains(fileExtension))
                {
                    return BadRequest($"File {file.FileName} has an unsupported file type.");
                }

                // Validate file size (e.g., 500MB limit)
                if (file.Length > 500 * 1024 * 1024) // 100MB
                {
                    return BadRequest($"File {file.FileName} exceeds the maximum allowed size.");
                }

                // extract exif metadata of the image

                // Save the file to the upload directory
                using (var stream = System.IO.File.Create($"../../../TestOutput/{file.FileName}"))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok("All files uploaded successfully.");
        }
        
        // public FileModel ExtractExifMetadata(string imagePath)
        // {
        //     var fileModel = new FileModel
        //     {
        //         Name = System.IO.Path.GetFileName(imagePath),
        //         Extension = System.IO.Path.GetExtension(imagePath),
        //         OriginalPath = imagePath,
        //         ThumbnailPath = "path/to/thumbnail", // Provide actual thumbnail path
        //         ViewPath = "path/to/view", // Provide actual view path
        //         PixelWidth = 0, // Extract if needed
        //         PixelHeight = 0, // Extract if needed
        //         GPSLat = null,
        //         GPSLon = null,
        //         GPSAlt = null,
        //         DateTimeOriginal = null,
        //         Make = null,
        //         Model = null,
        //         FocalLength = null,
        //         Aperture = null,
        //         Copyright = null,
        //         Tags = null,
        //         ProjectId = null
        //     };
    
        //     // Load the image
        //     using (Image image = Image.Load(imagePath))
        //     {
        //         // EXIF Metadata
        //         if (image.Metadata.ExifProfile != null)
        //         {
        //             // Extract EXIF data
        //             var exif = image.Metadata.ExifProfile;
    
        //             // DateTimeOriginal
        //             var dateTimeOriginalTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.DateTimeOriginal);
        //             if (dateTimeOriginalTag != null)
        //             {
        //                 fileModel.DateTimeOriginal = dateTimeOriginalTag.GetValue() as DateTime?;
        //             }
    
        //             // GPS data
        //             var gpsLatTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.GPSLatitude);
        //             if (gpsLatTag != null)
        //             {
        //                 fileModel.GPSLat = (decimal?)((Rational[])gpsLatTag.GetValue())?.FirstOrDefault().ToDouble();
        //             }
    
        //             var gpsLonTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.GPSLongitude);
        //             if (gpsLonTag != null)
        //             {
        //                 fileModel.GPSLon = (decimal?)((Rational[])gpsLonTag.GetValue())?.FirstOrDefault().ToDouble();
        //             }
    
        //             var gpsAltTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.GPSAltitude);
        //             if (gpsAltTag != null)
        //             {
        //                 fileModel.GPSAlt = (decimal?)((Rational[])gpsAltTag.GetValue())?.FirstOrDefault().ToDouble();
        //             }
    
        //             // Make and Model
        //             var makeTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.Make);
        //             if (makeTag != null)
        //             {
        //                 fileModel.Make = makeTag.GetValue()?.ToString();
        //             }
    
        //             var modelTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.Model);
        //             if (modelTag != null)
        //             {
        //                 fileModel.Model = modelTag.GetValue()?.ToString();
        //             }
    
        //             // Focal Length
        //             var focalLengthTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.FocalLength);
        //             if (focalLengthTag != null)
        //             {
        //                 fileModel.FocalLength = Convert.ToInt32(focalLengthTag.GetValue());
        //             }
    
        //             // Aperture
        //             var apertureTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.ApertureValue);
        //             if (apertureTag != null)
        //             {
        //                 fileModel.Aperture = Convert.ToSingle(apertureTag.GetValue());
        //             }
    
        //             // Copyright
        //             var copyrightTag = exif.Values.FirstOrDefault(tag => tag.Tag == ExifTag.Copyright);
        //             if (copyrightTag != null)
        //             {
        //                 fileModel.Copyright = copyrightTag.GetValue()?.ToString();
        //             }
        //         }
    
        //         // Set Pixel Width and Height
        //         fileModel.PixelWidth = image.Width;
        //         fileModel.PixelHeight = image.Height;
        //     }
    
        //     return fileModel;
        // }


        public  void PrintImageMetadata(string imagePath)
        {
            // Load the image
            using (Image image = Image.Load(imagePath))
            {
                Console.WriteLine($"Image loaded with dimensions: {image.Width}x{image.Height}");

                // Check for EXIF metadata
                if (image.Metadata.ExifProfile != null)
                {
                    Console.WriteLine("\nEXIF Metadata:");
                    foreach (var tag in image.Metadata.ExifProfile.Values)
                    {
                        Console.WriteLine($"Tag: {tag.Tag}, Value: {tag.GetValue()}");
                    }
                }
                else
                {
                    Console.WriteLine("\nNo EXIF metadata found in the image.");
                }
            }
        }

        // Helper functions for each file format

        // public void ExifImageSharp(string file)
        // {
        //     // Load the image
        //     var exif = new ExifReader(file);
        //     var metadata = exif.GetExifTags();
        //
        //     foreach (var tag in metadata)
        //     {
        //         Console.WriteLine($"{tag.Key}: {tag.Value}");
        //     }
        // }

        // Extract EXIF data from the file using ExifTool
        private Dictionary<string, string> ExtractExifData(string file)
        {
            var metadata = new Dictionary<string, string>();

            try
            {
                // TODO:  Run ExifTool on the file and capture output
                // nedded fields can be seen on ER diagram
              
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting EXIF data from {file}: {ex.Message}");
            }

            return metadata;
        }

        public void EditFile(string file, string action)
        {
            // Stub for editing file actions (crop, rotate, highlight, resize)
            // Call respective helper for each action

            switch (action.ToLower())
            {
                case "crop":
                    // TODO: Call Crop function
                    break;
                case "rotate":
                    // TODO: Call Rotate function
                    break;
                case "highlight":
                    // TODO: Call Highlight function
                    break;
                case "resize":
                    // TODO: Call Resize function
                    break;
                default:
                    throw new ArgumentException("Unknown action");
            }
        }
        
        // Method to upload files to a project
        public void UploadToProject(int projectId)
        {
            // Stub for uploading files to project
            // TODO:
            // - Validate if files are added
            // - Ensure project is selected
            // - Set resolution (low, medium, high)
        }
    }
}