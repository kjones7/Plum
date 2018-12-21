# Contributing

## Setting up your development environment

### Code

1. Clone this repository.
2. Open the solution with **Visual Studio 2017** or **Rider**.
3. Go to https://console.developers.google.com to get a client ID and client secret for using Google OAuth
4. Run the following commands to add the OAuth keys as secrets:
    - dotnet user-secrets set "Authentication:Google:ClientSecret" "**ENTER YOUR CLIENT SECRET HERE**"
    - dotnet user-secrets set "Authentication:Google:ClientId" "**ENTER YOUR CLIENT ID HERE**"

### Database

1. Download and install [PostgreSQL 10.5](https://www.postgresql.org/download/) on your machine for local development.
2. Use **pgAdmin 4** to create a new database for this project.
3. Run the following commands to add connection strings to your secrets
    - dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Username=postgres;Password=password;Database=Plum;"
    - dotnet user-secrets set "ConnectionStrings:TestConnection" "Host=localhost;Username=postgres;Password=password;Database=TestPlum;"
    - dotnet user-secrets set "ConnectionStrings:PostgresConnection" "Host=localhost;Username=postgres;Password=password;Database=postgres;"
    - **NOTE** - Make sure that the password used in the PostgresConnection connection string is the same password used when setting up your postgres server
    - **NOTE** - You may (and should) change the default passwords of the database strings given above
4. Run the ToBeRenamed.Database project. This will apply all migrations to setup an initial database.
    - Running "dotnet run -delete" will attempt to drop the databases and recreate them

You can now build and run the web application.

## Contributing to the project

1. Create a branch off of `master` called something descriptive like `AddUserLibraries`, preferably in PascalCase.
2. Commit your changes to this branch. Use descriptive commit messages. Or at the very least, your messages should start with an uppercase, present-tense verb. [Here are some tips.](https://chris.beams.io/posts/git-commit/)
3. When your feature or bug fix is ready for peer review, submit a pull request on GitHub to merge your changes into master. Do not squash your commits.

I recommend **pgAdmin 4** for writing SQL and interacting with your local database.
