# UrlShortener
# Project Setup Instructions

To setup and run the project on your local machine, follow these steps.

## Prerequisites

1. **Install Required Software:**
- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0) (select 32-bit or 64-bit based on your machine).
- [SQL Server(Developer Mode)](https://www.microsoft.com/en-us/sql-server/sql-server-downloads).
- [SQL Server Management Studio (SSMS)](https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) with the ASP.NET and web development workload.

2. **Modify Hosts File:**
- In the path, go to `C:\Windows\System32\drivers\etc`.
- Open the file called `hosts` in any text editor as an administrator.
- Go to the bottom of this file and edit: 127.0.0.1 localhost.
- If this line has a `#` at the start, remove the `#`.
- Replace `localhost` with `short.link`. This step redirects requests to `short.link` to your local machine.

## Configuring the Database

1. Open Visual Studio 2022 and load the project.
2. Go to **Tools** > **NuGet Package Manager** > **Package Manager Console**.
3. To create the database and run the migrations, execute the following in the command line: update-database
This will create the database in your local SQL Server instance with the required tables.

## Running the Application

1. Press the **Start** button in Visual Studio 2022 or start the application using the HTTPS option.
2. After the above command is executed, the application will be available at `https://short.link` in your browser or https://localhost:7043

---
### Notes
- Make sure that all the prerequisites are properly installed and configured before running.
- If anything goes wrong, check whether the database is created successfully or not and also check the `hosts` file configuration.
- The above application runs locally and uses `short.link` as a custom domain for testing purposes.
