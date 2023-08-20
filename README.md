# Demo Backend

## Start SQL Server 2022
    docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest

## Create database

### Ensure dotnet-ef tool is installed
    dotnet tool install --global dotnet-ef

### Run migrations to create database
    dotnet ef database update
