# ASP.NET Core Microservice: Elasticsearch

## Overview

Welcome to the Elasticsearch ASP.NET Core microservice! This microservice is designed to provide logging functionality using Serilog with Elasticsearch support. It includes endpoints to log messages and audit events, along with configuration for Elasticsearch sink.

## Features

- **Logging Endpoints:**
  - The `LoggerController` provides endpoints to log messages and audit events.

- **Elasticsearch Support:**
  - Configured with Serilog to support Elasticsearch sink.
  - Utilizes AutoMapper for mapping log levels between ASP.NET Core and Elasticsearch.

- **Configuration:**
  - Reads configuration from `appsettings.json` and environment-specific settings.
  - Elasticsearch is configured with the URI specified in `ElasticConfiguration` in `appsettings.json`.

## Usage

1. Configure Elasticsearch:
   - Set up Elasticsearch and update the Elasticsearch URI in `appsettings.json` (`ElasticConfiguration:Uri`).

2. Run the Microservice:
   - Execute the `Main` method in the `Program.cs` file.

3. Log Messages:
   - Use the `/api/logger/log` endpoint to log messages.
   - Use the `/api/logger/logaudit` endpoint to log audit events.

4. Observe Elasticsearch:
   - Check your configured Elasticsearch instance for logs and audit events.

## Configuration

- Configure Elasticsearch URI in `appsettings.json` (`ElasticConfiguration:Uri`).
- Update the log index format in `ConfigureElasticSink` method.

```json
"ElasticConfiguration": {
  "Uri": "http://localhost:9200"
},
```

## Dependencies

- Serilog
- Elasticsearch Sink for Serilog
- AutoMapper
- Audit.Net

Explore and utilize this Elasticsearch ASP.NET Core microservice for efficient logging with Elasticsearch support!
