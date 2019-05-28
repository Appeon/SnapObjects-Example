﻿# <b>SqlModelMapper Example</b>

This C# project uses SqlModelMapper from [SnapObjects.Data](https://www.nuget.org/packages/SnapObjects.Data/) for creating Web APIs.  It makes use of the latest released Appeon PowerBuilder 2019, including SnapDevelop (PB Edition), and shows how CRUD operations and transaction management works in SqlModelMapper.

##### Sample Project Structure

The sample contains two projects: 

1. A C# project. This project uses SqlModelMapper from [SnapObjects.Data](https://www.nuget.org/packages/SnapObjects.Data/). 

   Four different sets of project files are included, respectively for working with different databases (SQL Server, Oracle, SQL Anywhere, and PostgreSQL).

   The project is structured as follows.

   ```
   |—— Appeon.SqlModelMapperDemo		Implemented with SqlModelMapper from SnapObjects.Data
       |—— Appeon.SqlModelMapperDemo.SqlServer      For working with SQL Server
       |—— Appeon.SqlModelMapperDemo.Oracle         For working with Oracle
       |—— Appeon.SqlModelMapperDemo.SQLAnywhere    For working with SQL Anywhere
       |—— Appeon.SqlModelMapperDemo.PostgreSQL     For working with PostgreSQL
   ```

2. A PowerBuilder project. This project is a sales demo application. The project is structured as follows.
   
   ```
   |—— .NET-DataStore-Example		
   	|—— Appeon.SalesDemo.PB           			PowerBuilder project source code
   ```

##### Setting Up the Project

1. Open the PowerBuilder project in PowerBuilder 2019.

2. Open the C# project in SnapDevelop (PB Edition). 

3. In NuGet Package Manager window in SnapDevelop, make sure that Internet connection is available and the option "Include prerelease" is selected, so that the NuGet package can be restored.

4. Download the database backup file from [.NET-Project-Example-Database](https://github.com/Appeon/.NET-Project-Example-Database) according to the database you are using, and restore the database using the downloaded database backup file.

5. In SnapDevelop (PB Edition), keep the C# project that works with the database you have installed, and remove the other C# projects. 

   For example, if you have installed the Oracle database, keep the Appeon.SqlModelMapperDemo.Oracle project, and remove the Appeon.SqlModelMapperDemo.PostgreSQL, Appeon.SqlModelMapperDemo.SqlAnywhere, and Appeon.SqlModelMapperDemo.SqlServer projects.

6. Open the configuration file *appsettings.json* in the project, modify the ConnectionStrings with the actual database connection information. 

   If your project is Appeon.SqlModelMapperDemo.SqlServer:

   ```json
   /* Keep the database connection name as the default “AdventureWorks” or change it to a name you prefer to use, and change the Data Source, User ID, Password and Initial Catalog according to the actual settings */
   "ConnectionStrings": { "AdventureWorks": "Data Source=127.0.0.1; Initial Catalog=AdventureWorks; Integrated Security=False; User ID=sa; Password=123456; Connect Timeout=15; Encrypt=False; TrustServerCertificate=True; ApplicationIntent=ReadWrite;MultiSubnetFailover= False; Pooling=true; Max Pool Size=2;"  } 
   ```

   If your project is Appeon.SqlModelMapperDemo.Oracle:

   ```json
   /*Keep the database connection name as the default “AdventureWorks” or change it to a name you prefer to use, and change the HOST, User ID, Password to the actual settings*/
   "ConnectionStrings": { "AdventureWorks": "User Id=sa;Password=123456; Data Source=(DESCRIPTIOn=(ADDRESS=(PROTOCOL=Tcp)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=ADVENTUREWORKS)));"  }   
   ```

   If your project is Appeon.SqlModelMapperDemo.SqlAnywhere:

   ```json
   /*Keep the database connection name as the default “AdventureWorks” or change it to a name you prefer to use, and change the uid, pwd to the actual settings */
   "ConnectionStrings": { "AdventureWorks": "DSN=ASA_AdventureWorks;uid=sa;pwd=123456"  } 
   ```

   If your project is Appeon.SqlModelMapperDemo.PostgreSQL:

   ```json
   /*Keep the database connection name as the default “AdventureWorks” or change it to a name //you prefer to use, and change the HOST, User ID, Password to the actual settings  */
   "ConnectionStrings": { "AdventureWorks":  "PORT=5432;DATABASE=AdventureWorks;HOST=127.0.0.1;PASSWORD=sa;USER ID=123456"  } 
   ```

7. In the ConfigureServices method of *Startup.cs*, go to the following line, and make sure the ConnectionString name is the same as the database connection name specified in step #6.

   If your project is Appeon.SqlModelMapperDemo.SqlServer:

   ```C#
   /* Note: Change "OrderContext" if you have changed the default DataContext file name; change the "AdventureWorks" if you have changed the database connection name in appsettings.json */
   services.AddDataContext<OrderContext>(m => m.UseSqlServer(Configuration["ConnectionStrings:AdventureWorks"])); 
   ```

   If your project is Appeon.SqlModelMapperDemo.Oracle:

   ```C#
   /* Note: Change "OrderContext" if you have changed the default DataContext file name; change the "AdventureWorks" if you have changed the database connection name in appsettings.json */
   services.AddDataContext<OrderContext>(m => m.UseOracle(Configuration["ConnectionStrings:AdventureWorks"]));  
   ```

   If your project is Appeon.SqlModelMapperDemo.SqlAnywhere:

   ```C#
   /* Note: Change "OrderContext" if you have changed the default DataContext file name; change the "AdventureWorks" if you have changed the database connection name in appsettings.json */
   services.AddDataContext<OrderContext>(m => m.UseOdbc(Configuration["ConnectionStrings:AdventureWorks"])); 
   ```

   If your project is Appeon.SqlModelMapperDemo.PostgreSQL:

   ```C#
   /* Note: Change "OrderContext" if you have changed the default DataContext file name; change the "AdventureWorks" if you have changed the database connection name in appsettings.json */
   services.AddDataContext<OrderContext>(m => m.UsePostgreSql(Configuration["ConnectionStrings:AdventureWorks"])); 
   ```
