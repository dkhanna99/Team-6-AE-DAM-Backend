using DAMBackend.services;
using System;
using System.Threading.Tasks;
using DAMBackend.Model.ProjectModel;
using DAMBackend.Model.TagModel;
using DAMBackend.Model.FileModel;
using DAMBackend.Model.UserModel;
using Xunit;

namespace DAMBackend.Tests
{   
    // after database implemented, replace void to async task 
    // in function definitions
    public class SQLEntryEngineTests
    {
        // mock user variables
            string firstName = "John";
            string lastName = "Doe";
            string email = "john.doe@example.com";
            Role role = Role.Admin;
            bool statusU = true;

        // mock project variables
            string name = "Project A";
            string statusP = "Active";
            string location = "Location A";
            string imagePath = "/images/projectA.jpg";
            string phase = "Phase 1";
            AccessLevel al = AccessLevel.Admin;  // Assuming AccessLevel is an Enum
            DateTime lastUpdate = DateTime.Now;
        
        // mock File
        FileClass file = new FileClass
                {
                    Name = "TestFile.jpg",
                    Extension = ".jpg",
                    ThumbnailPath = "path/to/thumbnail",
                    ViewPath = "path/to/view",
                    OriginalPath = "path/to/original",
                    DateTimeOriginal = DateTime.Now,
                    PixelWidth = 1920,
                    PixelHeight = 1080,
                };
         
        
        [Fact]
        public void AddUser_ShouldReturnUser()
        {
            
            var engine = new SQLEntryEngine();
            
            var user = engine.AddUser(firstName, lastName, email, role, statusU);

            
            Assert.NotNull(user);
            Assert.Equal(firstName, user.firstName);
            Assert.Equal(lastName, user.lastName);
            Assert.Equal(email, user.Email);
            Assert.Equal(role, user.Role);
            Assert.Equal(statusU, user.status);
        }



        [Fact]
        // change to async Task later
        public void AddFile_ShouldReturnFile()
        {
            var engine = new SQLEntryEngine();
            var user = engine.AddUser(firstName, lastName, email, role, statusU);
            var project = engine.addProject(name, statusP, location, imagePath, phase, al, lastUpdate);

            // Act
            var addedFile = engine.AddFile(file, user, project);

            // Assert
            Assert.NotNull(addedFile);
            Assert.Equal(user.Id, addedFile.UserId);
            Assert.Equal(user, addedFile.User);
            Assert.Equal(project.Id, addedFile.ProjectId);
            Assert.Equal(project, addedFile.Project);
        }

        [Fact]
        public void AddTags_ShouldReturnTag()
        {
            var engine = new SQLEntryEngine();

            var project = engine.addProject(name, statusP, location, imagePath, phase, al, lastUpdate);

            var dep = Department.Software;  // Assuming Department is an Enum
            var type = MediaType.Photo;  // Assuming MediaType is an Enum

            // Act
            var tag = engine.addTags(project, file, phase, dep, type);

            // Assert
            Assert.NotNull(tag);
            Assert.Equal(file.UserId, tag.UserId);
            Assert.Equal(phase, tag.Phase);
            Assert.Equal(dep, tag.Dep);
            Assert.Equal(type, tag.Type);
            Assert.Equal(file.Id, tag.FileId);
            Assert.Equal(file, tag.File);
            Assert.Equal(project.Id, tag.ProjectId);
        }

        [Fact]
        public void AddProject_ShouldReturnProject()
        {
            // Arrange
            var engine = new SQLEntryEngine();
            // Act
            var project = engine.addProject(name, statusP, location, imagePath, phase, al, lastUpdate);

            // Assert
            Assert.NotNull(project);
            Assert.Equal(name, project.Name);
            Assert.Equal(statusP, project.Status);
            Assert.Equal(location, project.location);
            Assert.Equal(imagePath, project.imagePath);
            Assert.Equal(phase, project.Phase);
            Assert.Equal(al, project.accessLevel);
            Assert.Equal(lastUpdate, project.LastUpdate);
        }
    }
}
