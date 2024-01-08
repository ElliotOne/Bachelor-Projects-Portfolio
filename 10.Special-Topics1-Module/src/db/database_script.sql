-- Create Database
CREATE DATABASE IF NOT EXISTS studentblog;

-- Use Database
USE studentblog;

-- Users Table
CREATE TABLE IF NOT EXISTS user (
    id INT AUTO_INCREMENT PRIMARY KEY,
    firstname VARCHAR(255) NOT NULL,
    lastname VARCHAR(255) NOT NULL,
    username VARCHAR(255) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    isstudent INT NOT NULL,
    description TEXT,
    email VARCHAR(255),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Blog Posts Table
CREATE TABLE IF NOT EXISTS blogpost (
    id INT AUTO_INCREMENT PRIMARY KEY,
    user_id INT,
    pictureaddress VARCHAR(255),
    title VARCHAR(255),
    body TEXT,
    senddate DATETIME,
    fileaddress VARCHAR(255),
    FOREIGN KEY (user_id) REFERENCES user(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Comments Table
CREATE TABLE IF NOT EXISTS comment (
    id INT AUTO_INCREMENT PRIMARY KEY,
    blogpost_id INT,
    user_id INT,
    commentText TEXT,
    senddate DATETIME,
    isOk INT,
    FOREIGN KEY (blogpost_id) REFERENCES blogpost(id),
    FOREIGN KEY (user_id) REFERENCES user(id),
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);
