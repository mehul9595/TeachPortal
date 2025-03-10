# Running the Portal

### Backend
cd into ```TeachPortal``` directory. Backend service is located in ```TeachService``` folder. Build the project from the root directory or specify the project name.

    dotnet build
    dotnet run

### Frontend
Frontend code is saved in TeachWeb\teach-web. 
Frontend is using React + Typescript, and using Vite for build and development tool.

cd into ```TeachWeb\teach-web``` directory

Start frontend using below command

    npm run dev


### Ports
Frontend: http://localhost:5173

Backend: https://localhost:7297

Note: Frontend port is whitelisted in the backend service's appsettings.config. In any case, if the port is not the same then make sure to update the config.


# TODO

### Backend
- [x] Setup ASP.NET Core Web API Project with Students/Teachers controllers
- [x] Setup Repository Context for Students/Teachers
- [x] Perform initial migration
- [x] Add AuthController, and Models
- [x] Add Students/Teachers Controller, and models
- [x] Add EntityFramework Core & SQLite Database with Code First Approach
- [x] Add JWT Authentication
- [x] Add Logging
- [x] Add AutoMapper
- [x] Add API calls for Teacher registerstration and login using JWT Token
- [x] Add API calls for Creating Students using logged in Teacher using JWT Token
- [x] Add API calls for Getting Students using logged in Teacher using JWT Token
- [x] Add Support for Paged Query Helpers
- [x] Add API Calls for returning Paged results of the Teachers
- [x] Create .http files for testing the API calls
- [x] Basic Error Handling
- [x] Add Documentation
- [x] Add basic logging

### Frontend
- [x] Students list page for the logged in teacher
- [x] add students to the logged in teacher
- [x] teachers can see the list of other teachers and the student counts
- [ ] GetTeachers is not calling paged api yet
- [x] Added basic field validations for all the fields including password. Scope to add more stronger password generatio.
- [x] Token is stored in localstorage. scope to move to session storage.

# Further Improvements
- [ ] Implement OTEL for tracing
- [ ] Add Unit Tests
- [ ] Add Integration Tests
- [ ] Add Docker Support
- [ ] Add CI/CD Pipeline
- [ ] Add Authorization
- [ ] Add Caching
- [ ] Add Health Checks
- [ ] Add Versioning
- [ ] Standardize Error Responses from the API
- [ ] Delete teachers API call
- [ ] Unit tests for frontend
- [ ] test scrollbar for student and teacher list 



## Managing SQLLite Database

I've attached a sample SQLite database with dummy users to work with this project. The same can be used for testing or demo, or else we can follow the steps given below create a new database.

johndoe : password123

mehul4 : password123

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
