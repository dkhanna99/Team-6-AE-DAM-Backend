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
using ExifLibNet;



namespace DAMBackend.SubmissionEngine

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

        // public IActionResult ExtractExifData([FromForm] List<IFormFile> files)
        // {
        //     if (files == null || files.Count == 0)
        //     {
        //         return BadRequest("No files were uploaded.");
        //     }

        //     var exifDataList = new List<object>();

        //     foreach (var file in files)
        //     {
        //         if (file.Length > 0)
        //         {
        //             using var stream = file.OpenReadStream();
        //             using var image = Image.Load(stream); // Load image using ImageSharp

        //             // Get image metadata (EXIF, IPTC, XMP, etc.)
        //             var metadata = image.Metadata;

        //             var exifData = metadata.ExifProfile; // Extract EXIF profile if available

        //             if (exifData != null)
        //             {
        //                 var extractedExif = new Dictionary<string, string>();

        //                 foreach (var value in exifData.Values)
        //                 {
        //                     extractedExif[value.Tag.ToString()] = value.GetValue().ToString();
        //                 }

        //                 exifDataList.Add(new
        //                 {
        //                     FileName = file.FileName,
        //                     Exif = extractedExif
        //                 });
        //             }
        //             else
        //             {
        //                 exifDataList.Add(new
        //                 {
        //                     FileName = file.FileName,
        //                     Exif = "No EXIF data found"
        //                 });
        //             }
        //         }
        //     }

        //     return Ok(exifDataList);
        // }

        // Helper functions for each file format

        public void ExifImageSharp(string file)
        {
            // Load the image
            var exif = new ExifReader(file);
            var metadata = exif.GetExifTags();

            foreach (var tag in metadata)
            {
                Console.WriteLine($"{tag.Key}: {tag.Value}");
            }
        }

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