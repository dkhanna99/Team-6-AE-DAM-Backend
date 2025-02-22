DROP TABLE IF EXISTS File;

DROP TABLE IF EXISTS Project;

DROP TABLE IF EXISTS Tag;

DROP TABLE IF EXISTS Logger;

DROP TABLE IF EXISTS User;

DROP TABLE IF EXISTS Palette;

INSERT INTO Project (project_id, project_name, status) VALUES
                                                           (1, 'project1', 'Active'),
                                                           (2, 'project2', 'Completed'),
                                                           (3, 'project3', 'In Progress'),
                                                           (4, 'project4', 'Active'),
                                                           (5, 'project5', 'Completed');
INSERT INTO User (user_id, first_name, last_name, role) VALUES
                                                            (1, 'A', 'B', 'Admin'),
                                                            (2, 'C', 'D', 'User'),
                                                            (3, 'E', 'F', 'Admin'),
                                                            (4, 'G', 'H', 'Admin'),
                                                            (5, 'I', 'J', 'Admin');
INSERT INTO Tag (tag_id, tag_name) VALUES
                                       (1, 'Construction'),
                                       (2, 'Building'),
                                       (3, 'Construction'),
                                       (4, 'Architecture'),
                                       (5, 'Building');
INSERT INTO Logger (log_id, timestamp, action) VALUES
                                                   (1, '2025-02-01 14:30:00', 'Insert'),
                                                   (2, '2025-02-02 09:45:00', 'Update'),
                                                   (3, '2025-02-03 11:15:00', 'Delete'),
                                                   (4, '2025-02-04 13:20:00', 'Search'),
                                                   (5, '2025-02-05 16:50:00', 'Insert');
INSERT INTO Palette (palette_id, media_count) VALUES
                                                  (1, 10),
                                                  (2, 20),
                                                  (3, 15),
                                                  (4, 8),
                                                  (5, 30);