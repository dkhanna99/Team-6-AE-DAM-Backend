using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using DAMBackend.SubmissionEngine;

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

        [Fact]
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
        }

        [Fact]
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

        [Fact]
        public async Task UploadFiles_RejectToMoreThan100MBFile()
        {
            // Arrange
            var mockFiles = new FormFileCollection();
            var fileMock2 = new MockFormFile
            {
                FileName = $"file{20}.jpg",
                Length = 100*1024*1024 + 1 // 1 KB per file
            };
            mockFiles.Add(fileMock2);

            // Act
            var result = await _fixture.submissionEngine.UploadFiles(mockFiles);

            // Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("File file20.jpg exceeds the maximum allowed size.", badResult.Value);
        }

        [Fact]
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

    [Fact]
    public async Task UploadFiles_SavesActualImageToCorrectDirectory()
    {
        // Arrange
        // Path to the actual image file in your test project
        var imagePath = Path.Combine("../../../TestFiles", "DSC05589.ARW");

        // Read the image file into a byte array
        var fileBytes = File.ReadAllBytes(imagePath);

        var testFile = FileHelper.GetTestFormFile("../../../TestFiles/DSC05589.ARW");

        var files = new List<IFormFile> { testFile };

        // Act
        var result = await _fixture.submissionEngine.UploadFiles(files);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal("All files uploaded successfully.", okResult.Value);

        // Verify the file was saved to the correct directory

        Assert.True(File.Exists("../../../TestOutput/DSC05589.ARW"));

        // Verify the saved file content matches the original file
        var savedFileBytes = File.ReadAllBytes("../../../TestOutput/DSC05589.ARW");
        Assert.Equal(fileBytes, savedFileBytes);

        // Clean up
        File.Delete("../../../TestOutput/DSC05589.ARW");
    }
    }
}


