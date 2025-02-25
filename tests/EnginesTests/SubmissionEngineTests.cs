using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using DAMBackend.Models;
using DAMBackend.SubmissionEngine;
using File = System.IO.File;

namespace backendTests.SubmissionEngineTests 
{   
    // for before/after all
    public class DatabaseFixture : IDisposable
    {
        public SubmissionEngine submissionEngine;
        public DatabaseFixture()
        {
            // Setup code (runs once before all tests)
            Console.WriteLine("BeforeAll: Database setup");
            // Arrange
            
            // Act
            submissionEngine = new SubmissionEngine();
        }

        public void Dispose()
        {
            // Teardown code (runs once after all tests)
            Console.WriteLine("AfterAll: Database cleanup");
        }
    }

    // for mock file testing (no need to use actual photo/video for some testing purpose)
    public class MockFormFile : IFormFile
    {

        public string ContentType { get; set; }
        public string ContentDisposition { get; set; }
        public IHeaderDictionary Headers { get; set; }
        public long Length { get; set; }
        public string Name { get; set; }
        public string FileName { get; set; }

        public Stream OpenReadStream()
        {
            return new MemoryStream(new byte[Length]);
        }

        public void CopyTo(Stream target)
        {
            OpenReadStream().CopyTo(target);
        }

        public Task CopyToAsync(Stream target, CancellationToken cancellationToken = default)
        {
            return OpenReadStream().CopyToAsync(target, cancellationToken);
        }
    }

    // to wrap actual image with Formfile for testing purpose
    public static class FileHelper
    {
        public static IFormFile GetTestFormFile(string filePath)
        {
            var fileName = Path.GetFileName(filePath);
            var fileStream = new FileStream(filePath, FileMode.Open);

            var formFile = new FormFile(fileStream, 0, fileStream.Length, "files", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = "image/jpeg" // You can set the content type accordingly
            };

            return formFile;
        }
    }

    // for list of IFormFile
    public class FormFileCollection : List<IFormFile>, IFormFileCollection
    {
        public IFormFile this[string name] => this.FirstOrDefault(f => f.Name == name);

        public IFormFile GetFile(string name)
        {
            return this.FirstOrDefault(f => f.Name == name);
        }

        public IReadOnlyList<IFormFile> GetFiles(string name)
        {
            return this.Where(f => f.Name == name).ToList();
        }
    }

    public class SubmissionEngineTests : IClassFixture<DatabaseFixture>
    //, IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly DatabaseFixture _fixture;

        public SubmissionEngineTests(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        //[Fact]
        public async Task UploadFiles_AcceptsUpTo100Files()
        {
            // Arrange
            var mockFiles = new FormFileCollection();

            for (int i = 0; i < 100; i++)
            {
                var fileMock = new MockFormFile
                {
                    FileName = $"file{i}.jpg",
                    Length = 1024 // 1 KB per file
                };
                mockFiles.Add(fileMock);
            }

            // Act
            var result = await _fixture.submissionEngine.UploadFiles(mockFiles);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("All files uploaded successfully.", okResult.Value);

            // Clean up
            for (int i = 0; i < 100; i++)
            {
                File.Delete($"../../../TestOutput/file{i}.jpg");
            }
        }

        //[Fact]
        public async Task UploadFiles_RejectToMoreThan100Files()
        {
            // Arrange
            var mockFiles = new FormFileCollection();

            for (int i = 0; i < 101; i++)
            {
                var fileMock = new MockFormFile
                {
                    FileName = $"file{i}.jpg",
                    Length = 1024 // 1 KB per file
                };
                mockFiles.Add(fileMock);
            }

            // Act
            var result = await _fixture.submissionEngine.UploadFiles(mockFiles);

            // Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("You can upload a maximum of 100 files at once.", badResult.Value);
        }

        //[Fact]
        public async Task UploadFiles_RejectToMoreThan500MBFile()
        {
            // Arrange
            var mockFiles = new FormFileCollection();
            var fileMock2 = new MockFormFile
            {
                FileName = $"file{20}.jpg",
                Length = 500 * 1024 * 1024 + 1 // 1 KB per file
            };
            mockFiles.Add(fileMock2);

            // Act
            var result = await _fixture.submissionEngine.UploadFiles(mockFiles);

            // Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("File file20.jpg exceeds the maximum allowed size.", badResult.Value);
        }

        //[Fact]
        public async Task UploadFiles_RejectToUnsupportedFile()
        {
            // Arrange
            var mockFiles = new FormFileCollection();
            var fileMock2 = new MockFormFile
            {
                FileName = $"file{20}.mov",
                Length = 1024 // 1 KB per file
            };
            mockFiles.Add(fileMock2);

            // Act
            var result = await _fixture.submissionEngine.UploadFiles(mockFiles);

            // Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("File file20.mov has an unsupported file type.", badResult.Value);
        }



        //[Fact]
        public async Task UploadFiles_SavesActualImageToCorrectDirectory()
        {
            // Arrange
            // Path to the actual image file in your test project
            string[] filePath =
            [
                "DSC05589.ARW", "DSC03135.JPG", "yeti_classic.png", "DSC03135.ARW", "DSC04569.ARW", "image1.jpeg",
                "jpgsample.JPG", "jpgsample.JPG", "C0004.MP4"
            ];

            var files = new FormFileCollection();
            // Read the image file into a byte array
            foreach (string file in filePath)
            {
                var imagePath = Path.Combine("../../../TestFiles", file);
                Console.WriteLine(imagePath);
                var testFile = FileHelper.GetTestFormFile(imagePath);
                files.Add(testFile);
            }

            // Act
            var result = await _fixture.submissionEngine.UploadFiles(files);
            Console.WriteLine(result);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("All files uploaded successfully.", okResult.Value);

            // Verify the file was saved to the correct directory

            // Clean up
            // File.Delete("../../../TestOutput/DSC05589.ARW");
        }

        [Fact]
        public async Task exifTest()
        {
            // Arrange
            string[] filePath =
            [
                "DSC05589.ARW", "DSC03135.JPG", "yeti_classic.png", "DSC03135.ARW", "DSC04569.ARW", "image1.jpeg",
                "jpgsample.JPG", "jpgsample.JPG"
            ];

            var testImagePath = Path.Combine("../../../TestFiles", filePath[5]);
            // Act
            _fixture.submissionEngine.PrintImageMetadata(testImagePath);
        }

        [Fact]
        public void ExtractExifMetadata_ShouldReturnCorrectFileModel()
        {
            string[] filePath =
            [
                "DSC05589.ARW", "DSC03135.JPG", "yeti_classic.png", "DSC03135.ARW", "DSC04569.ARW", "image1.jpeg",
                "jpgsample.JPG", "jpgsample.JPG"
            ];

            var testImagePath = Path.Combine("../../../TestFiles", filePath[5]);
            // Arrange

            // Act
            FileModel fileModel = _fixture.submissionEngine.ExtractExifMetadata(testImagePath);

            // Assert
            Assert.NotNull(fileModel); // Ensure the object is not null
            Assert.Equal("image.jpg", fileModel.Name); // Ensure the Name is correct
            Assert.Equal(".jpg", fileModel.Extension); // Ensure the Extension is correct
            Assert.Equal(testImagePath, fileModel.OriginalPath); // Ensure the OriginalPath is correct
            Assert.True(fileModel.PixelWidth > 0); // Ensure PixelWidth is greater than 0
            Assert.True(fileModel.PixelHeight > 0); // Ensure PixelHeight is greater than 0

            // Check if optional EXIF fields are null if not found in the image
            Assert.Null(fileModel.GPSLat);
            Assert.Null(fileModel.GPSLon);
            Assert.Null(fileModel.GPSAlt);
            Assert.Null(fileModel.DateTimeOriginal);

        }
    }
}


