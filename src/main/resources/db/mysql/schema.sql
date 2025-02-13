CREATE TABLE Project (
                         project_id INT PRIMARY KEY,
                         project_name VARCHAR(40),
                         status VARCHAR(8)
);

CREATE TABLE File (
                      file_id INT PRIMARY KEY,
                      file_name VARCHAR(25),
                      file_extension VARCHAR(5),
                      file_description VARCHAR(255),
                      thumbnail_path VARCHAR(255),
                      view_path VARCHAR(255),
                      original_path VARCHAR(255),
                      gps_latitude DECIMAL(9,6),
                      gps_longitude DECIMAL(10,6),
                      gps_altitude DECIMAL(7,2),
                      date_time_original TIMESTAMP,
                      pixel_width INT,
                      pixel_height INT,
                      make VARCHAR(20),
                      model VARCHAR(50),
                      focal_length SMALLINT,
                      aperture FLOAT(3,2),
    profile_copyright VARCHAR(50)
);

CREATE TABLE Tag (
                     tag_id INT PRIMARY KEY,
                     tag_name VARCHAR(20)
);

CREATE TABLE User (
                      user_id INT PRIMARY KEY,
                      first_name VARCHAR(20),
                      last_name VARCHAR(20),
                      role VARCHAR(5)
);

CREATE TABLE Logger (
                        log_id INT PRIMARY KEY,
                        timestamp TIMESTAMP,
                        action VARCHAR(8)
);

CREATE TABLE Palette (
                         palette_id INT PRIMARY KEY,
                         media_count TINYINT UNSIGNED
);
