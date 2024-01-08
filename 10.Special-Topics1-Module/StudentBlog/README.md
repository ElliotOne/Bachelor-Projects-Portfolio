# Node.js Application: Student Blog Application

## Introduction

This is a simple web application for a student blog built using Node.js, Express, and MySQL. The application allows users to sign in, sign up, create blog posts, view a list of blog posts, and manage comments.

## Features

- **User Authentication**: Users can sign up, sign in, and sign out securely. Passwords are hashed using bcrypt for security.
- **Blog Post Management**: Users can create, edit, and delete their blog posts. Each post includes a title, body, and optional image attachment.
- **Comment System**: Users can leave comments on blog posts, and blog owners can manage and moderate comments.
- **Handlebars**: The views are in Handlebars (hbs) format.

## Getting Started

### Prerequisites

- Node.js installed
- MySQL installed
- MySQL database created (see `schema.sql` for the required database schema)

### Installation

1. **Clone the repository**
2. **Install Dependencies**
3. **Configure the Database**
  - Create a MySQL database and update the connection details in server.js
  ```javascript
    let connection = mysql.createConnection({
    host: 'localhost',
    port: 1111,
    user: 'root',
    password: '',
    database: 'studentblog'
});
```
  - Import the database schema from `db/database_script.sql` to set up the required tables.
4. **Run the Application**
  - The application will be accessible at http://localhost:5000.

### Usage

- Visit http://localhost:5000 to access the home page.
- Sign up for a new account or sign in if you already have one.
- Explore the blog section, add new posts, and interact with comments.
- Users with administrative access can manage comments and delete inappropriate content.

## Screenshots

<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/10.Special-Topics1-Module/StudentBlog/Screenshots/1.png"/>
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/10.Special-Topics1-Module/StudentBlog/Screenshots/2.png"/>
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/10.Special-Topics1-Module/StudentBlog/Screenshots/3.png"/>
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/10.Special-Topics1-Module/StudentBlog/Screenshots/4.png"/>
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/10.Special-Topics1-Module/StudentBlog/Screenshots/5.png"/>
<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/10.Special-Topics1-Module/StudentBlog/Screenshots/6.png"/>


Feel free to adjust it based on your specific project details.
