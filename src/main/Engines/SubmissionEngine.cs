namespace DAMBackend.SubmissionEngine

{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    public class SubmissionEngine : ControllerBase
    {
        // private ExifTool _exifTool;
        // private ExifToolWrapper.ExifTool _exifTool;

        private readonly string _uploadPath = "../../../TestOutput"; //hard coded value

        public SubmissionEngine()
        {
            // Initialize ExifToolWrapper
            // _exifTool = new ExifTool();
            // _exifTool = new ExifToolWrapper.ExifTool();
        }
      
        // Method to upload files, extracts EXIF metadata for each file
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm] List<IFormFile> files)
        {

            // Ensure the upload directory exists
            // if (!Directory.Exists(_uploadPath))
            // {
            //     Directory.CreateDirectory(_uploadPath);
            // }

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

            // Validate and process each file
            foreach (var file in files)
            {
                // Validate file size (e.g., 100MB limit)
                if (file.Length > 100 * 1024 * 1024) // 100MB
                {
                    return BadRequest($"File {file.FileName} exceeds the maximum allowed size.");
                }

                // Validate file extension (e.g., allow only images and videos)
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".mp4", ".raw", ".arw" };
                // to be supported: .tiff, .jpg, .gif, .mov 
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (!allowedExtensions.Contains(fileExtension))
                {
                    return BadRequest($"File {file.FileName} has an unsupported file type.");
                }

                // Save the file to the upload directory
                // var filePath = Path.GetTempFileName();
                // Console.WriteLine(filePath);
                using (var stream = System.IO.File.Create($"../../../TestOutput/{file.FileName}"))
                {
                    await file.CopyToAsync(stream);
                }
            }

            return Ok("All files uploaded successfully.");
        }

        // public void UploadFiles(List<string> listOfImages)
        // {
        //     // Stub for uploading files and extracting EXIF metadata
        //     // TODO:
        //     // - Check if no files are added or file count exceeds 100
        //     // - Validate supported formats
        //     // - Extract EXIF data to put into File fields on daabase or leave NULL for missing fields
        //     // Future implementation required for each file format handler

        //     foreach (var file in listOfImages)
        //     {
        //         // TODO: Call respective helper based on file type (jpeg, png, mp4, etc.)
        //         // Example: HandleJpeg(file);
        //     }
        // }

        // Helper functions for each file format
        private void HandleJpeg(string file)
        {
            // TODO: Extract EXIF data for JPEG
        }

        private void HandlePng(string file)
        {
            // TODO: Extract EXIF data for PNG
        }

        private void HandleMp4(string file)
        {
            // TODO: Extract EXIF data for MP4
        }

        private void HandleRaw(string file)
        {
            // TODO: Extract EXIF data for RAW
        }

        private void HandleHeic(string file)
        {
            // TODO: Extract EXIF data for HEIC
        }

        private void HandleTiff(string file)
        {
            // TODO: Extract EXIF data for TIFF
        }

        private void HandleMov(string file)
        {
            // TODO: Extract EXIF data for MOV
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