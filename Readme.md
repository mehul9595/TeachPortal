## Managing SQLLite Database

#### ConnectionString
SQLLite db path is defined in `appsettings.json` file. Default path is `Data/teachportal.db`. If it is changed, make sure to update the path in `appsettings.json` file.

```
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Data/teachportal.db"
  }
}
```

#### EntityFramework Tools
EF tools are required to create migration and update database.
To use EntityFramework tools, install the following package.

    dotnet tool install --global dotnet-ef
    

#### EntityFramework Create Migration
To create migration, run the following command.

    dotnet ef migrations add <InitialCreate>

EntityFramework will create a migration file in `Migrations` folder and update the database.

#### EntityFramework Update Database
When making changes to the model, run the following command to update the database.

    dotnet ef migrations add <MigrationName>
    dotnet ef database update

#### EntityFramework Remove Migration
To remove the last migration, run the following command.

    dotnet ef migrations remove

#### EntityFramework List Migrations
To list all migrations, run the following command.

    dotnet ef migrations list

#### EntityFramework Script Migration
To generate a SQL script for migration, run the following command.

    dotnet ef migrations script

#### EntityFramework Drop Database
To drop the database, run the following command.

    dotnet ef database drop

#### EntityFramework Drop Database and Create Migration
To drop the database and create a new migration, run the following command.
    
    dotnet ef database drop --force

#### Tools to view/explore SQLite Database
- Visual Studio Code Extension: SQLite
- SQLiteStudio
- DB Browser for SQLite
- SQLite CLI