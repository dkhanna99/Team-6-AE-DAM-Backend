using DAMBackend.Model.UserModel;

using Microsoft.EntityFrameworkCore;
using DAMBackend.Model.FileModel;
using DAMBackend.Model.ProjectModel;
using DAMBackend.Model.TagModel;

namespace DAMBackend.services

{
    public class SQLEntryEngine {

        // Connecting to database
        // private readonly AppDbContext database;

        // parameter will be AppDbContext db
        public SQLEntryEngine() {
            // database = db;
        }

        // change to async task when uploading to database
        public User AddUser(string first, string last, string email, Role role, bool stat) {
            var user = new User
            {
                firstName = first,
                lastName = last,
                Email = email,
                Role = role,
                status = stat
            };

            // database.Users.Add(user); 
            // await database.SaveChanges();
            // add when database implemented

            return user;
        }

        // take result from extractExifData
        public FileClass AddFile(FileClass file, User user, Project project) {
            if (project != null) {
                file.Project = project;
                file.ProjectId = project.Id;
            }

            file.User = user;
            file.UserId = user.Id;
            
            // database.Files.Add(file);
            // await database.SaveChanges();
            return file;
        }

        public Tag addTags(Project project, FileClass file, string phase, Department dep, MediaType type) {
            var tags = new Tag 
            {   
                UserId = file.UserId,
                Phase = phase,
                Dep = dep,
                Type = type,
                FileId = file.Id,
                File = file
            };
            if (project != null) {
                tags.ProjectId = project.Id;
            }

            // database.Tags.Add(tag);
            // await database.SaveChanges();
            return tags;
        }

        public Project addProject(string name, string status, string location, string imagePath, string phase, AccessLevel al, DateTime lastUp) {
            var project = new Project
            {
                Name = name,
                Status = status,
                location = location,
                imagePath = imagePath,
                accessLevel = al,
                LastUpdate = lastUp,
                Phase = phase
            };
            // database.Tags.Add(tag);
            // await database.SaveChanges();
            return project;
        }
    }
}