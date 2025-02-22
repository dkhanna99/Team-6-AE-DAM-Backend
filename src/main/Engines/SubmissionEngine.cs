namespace DAMBackend.SubmissionEngine
{
    public class SubmissionEngine
    {
        // private ExifTool _exifTool;
        // private ExifToolWrapper.ExifTool _exifTool;

        public SubmissionEngine()
        {
            // Initialize ExifToolWrapper
            // _exifTool = new ExifTool();
            // _exifTool = new ExifToolWrapper.ExifTool();
        }
      
        // Method to upload files, extracts EXIF metadata for each file
        public void UploadFiles(List<string> listOfImages)
        {
            // Stub for uploading files and extracting EXIF metadata
            // TODO:
            // - Check if no files are added or file count exceeds 100
            // - Validate supported formats
            // - Extract EXIF data to put into File fields on daabase or leave NULL for missing fields
            // Future implementation required for each file format handler

            foreach (var file in listOfImages)
            {
                // TODO: Call respective helper based on file type (jpeg, png, mp4, etc.)
                // Example: HandleJpeg(file);
            }
        }

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
