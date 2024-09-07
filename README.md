# Use Sqlite db for EntityFrameworkCore

Simple CRUD API using entity code and sqllite

Steps to create a database context using Sqlite db in entity core project 

Step 0 : Add the required depandancy from the nuget package [.csproj]

    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="6.0.33" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="6.0.33">
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="6.0.33" />


Step 1 : Add the connection string in [appsetting.json]

    {
        "ConnectionStrings": {
        "DefaultConnectionString": "Data Source=apiwithsqlite.db"
        }
    }


step 2 : Create the model which will be used as mapper [Employee.cs]

    public class Employee
    {
        [Key] //one primary is mandatory
        public int EmpID { get; set; }
        public string Name { get; set; } = string.Empty;
        public int DeptID { get; set; }
        public string DeptName { get; set; } = string.Empty;    
    }

step 3 : Create the context class for the sqllite db [DataContext.cs]

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees => Set<Employee>(); 
    }


Step 4 : Add the dbcontext services in program.cs file
```
//Add the dependancy
builder.Services.AddDbContext<DataContext>
                                        (options => 
                                        options.UseSqlite(
                                            builder.Configuration.GetConnectionString("DefaultConnectionString")
                                            )
                                        );
```

Step 5: 
```
Create the migration : dotnet ef migrations add initial
Apply the migrations : dotnet ef database update

OR

Create the migration : Add-Migration "Initail"
Apply the migrations : update database

```
Steps to use this CRUD API project
1) Git clone the repo
```
git clone https://github.com/AniketDeshmane/APIwithSqliteDb.git
```
2) DotNet restore and build
```
dotnet restore
dotnet build
```
3) Add and Apply the Migration  
```
dotnet ef migrations add initial
dotnet ef database update
```


# EF Core CLI
```
Install EF Specific version : dotnet tool install --global dotnet-ef --version 6.0
```
```
dotnet tool install --global dotnet-ef
dotnet tool uninstall --global dotnet-ef
```
```
Create the migration : dotnet ef migrations add initial
Apply the migrations : dotnet ef database update
```
