# ASP.NET Core Microservice: IdentityServer

## Overview

Welcome to the IdentityServer microservices! This project consists of four interconnected microservices: Api, Client, IdentityServer, and MvcClient. Each microservice plays a distinct role in providing secure authentication, authorization, and resource access.

## Api

### Overview

The `Api` microservice serves as a protected API requiring authentication and authorization. It includes controllers and policies for access control based on scopes.

### Features

- **Protected API:**
  - Implements controllers with restricted access based on configured policies.
  - Validates access tokens for authentication and authorization.

### Usage

- **1. Configure Api:**
  - Update the Identity Server URL in the `ConfigureServices` method of the `Startup.cs` file. 
```csharp
  options.Authority = "https://your-identity-server-url";
```

- **2. Run the Microservice:**
  - Execute the `Main` method in the `Startup.cs` file or run the project from your preferred development environment.

- **3. Access Protected Endpoints:**
  - Utilize the controllers within the `Api` microservice with valid access tokens.

Protect your resources with this `Api` microservice!


## Client

### Overview
The `Client` microservice is a console application that simulates a client requesting an access token from the Identity Server and calling a protected API.

### Features

- **Token Request:**
  - Discovers Identity Server endpoints from metadata.
  - Requests a client credentials token for accessing a specific API.

- **API Access:**
  - Calls the protected API using the obtained access token.

### Usage

- **1. Configure Identity Server URL:**
  - Update the Identity Server URL and client information in the `Program.cs` file.
```csharp
  var disco = await client.GetDiscoveryDocumentAsync("https://localhost:10001");
  options.Authority = disco.TokenEndpoint;
  options.ClientId = "client";
  options.ClientSecret = "secret";
  options.Scope = "api1";
```

- **2. Run the Microservice:**
  - Execute the `Main` method in the `Program.cs` file.

- **3. Obtain Access Token:**
  - View the obtained access token and use it to call the protected API.
  - Simulate client-server interaction with the `Client` microservice!

Simulate client-server interaction with the `Client` microservice!


## IdentityServer

### Overview

The `IdentityServer` project is a secure and extensible authentication and authorization server. It's designed to protect APIs and web applications by providing robust identity management capabilities.

### Key Components:

- **Configuration:**
Utilizes Entity Framework to store client configurations, identity resources, and API resources.

- **Test Users:**
Predefined test users are set up for demonstration purposes, including users like "Alice" and "Bob."

- **Authentication:**
Supports various authentication methods, including username/password and external providers like Google.

- **Client Configurations:**
Configures clients with specific settings, such as client IDs, client secrets, and allowed scopes.

- **Seed Data:**
Initializes the database with essential data during application startup.

- **Security Headers:**
Implements security headers to enhance web application security.

- **Logging:**
Utilizes Serilog for logging, allowing easy integration with different logging sinks.

- **User Management:**
Integrates with ASP.NET Core Identity for user management.

### Login and Logout Workflow:

The `AccountController` manages user interactions, handling actions like login, logout, and access denial. It orchestrates the authentication process, interacts with external providers, and ensures a secure logout experience.

### Client Configuration:

Defines clients with specific characteristics, such as allowed grant types, redirect URIs, and scopes.

### Identity Resources and API Scopes:

Specifies identity resources and API scopes, determining the user information and access levels available to clients.

### Usage:

  - Clients can obtain access tokens by authenticating with IdentityServer, ensuring secure communication with protected APIs.
  - User data, including claims and profile information, is managed and secured by IdentityServer.
  - Seamless integration with ASP.NET Core Identity simplifies user management.


In summary, IdentityServer is a comprehensive identity management solution, offering robust security features and flexibility for authenticating and authorizing applications and APIs.


## MVC Client

### Overview

The `MvcClient` project is an MVC-based web application designed to interact with the Identity Server. It utilizes OpenID Connect for authentication and authorization, enabling secure access to protected resources.

### Features

- **MVC Web Application:**
  - Implements an MVC architecture for the user interface.
  - Includes controllers for home, calling APIs, and error handling.

- **Authentication and Authorization:**
  - Configures authentication using cookies and OpenID Connect.
  - Manages user sign-in and sign-out.
 
 - **Calling APIs:**
  - Provides a controller action (`CallApi`) for calling a protected API after obtaining an access token.

### Usage

- **1. Configure Identity Server URL:**
  - Update the Identity Server URL and client information in the Startup.cs file.
```csharp
Copy code
options.Authority = "https://your-identity-server-url";
options.ClientId = "mvc";
options.ClientSecret = "secret";
options.ResponseType = "code";
options.Scope.Add("api1");
```
- **2. Run the MVC Client:**
  - Execute the `Main` method in the `Program.cs` file or run the MVC Client project from your preferred development environment.

- **3. Access Home Page:**
  - Open a web browser and navigate to the MVC Client home page (`/Home/Index`).
 
- **4. Call API:**
  - Navigate to the "Call API" section to obtain an access token and call a protected API.

- **5. Sign-Out:**
  - Use the "Logout" option to sign out from the MVC Client.


Secure your applications with this Identity Server microservice!
