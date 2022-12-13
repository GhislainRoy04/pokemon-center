# pokemon-center

This is a basic application with a .Net Core 6 REST API backend, React client and MySql.

To initiate the project, first run the `initial_setup_script.sql` that can be found under DB.
For this script you will need to move the .csv from `resources` into the MySQL Server `Uploads` folder and update the path inside the script to match it.
This will create the schema, create the table, create a user used by the API and load the .csv into the table.

Follow up with running `dotnet restore` on the same level as the `.csproj` file via a terminal.
Once that has been run, you can start the API by using `dotnet run` .
You can test the API via Swagger if you want. The url should be https://localhost:7100/swagger .

Alternatively, you can open the solution in Visual Studio, restore the nuget packages and launch the API that way.

Have fun!

Created by Ghislain Roy

