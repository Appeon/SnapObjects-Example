# SnapObjects-Example

This Class Library (.Net Core) project uses SqlModelMapper from [SnapObjects.Data](https://www.nuget.org/packages/SnapObjects.Data/) for creating services.  It shows how CRUD operations and transaction management works in SqlModelMapper.

##### Sample Project Structure

The sample contains a Class Library (.Net Core) project. This project uses SqlModelMapper from [SnapObjects.Data](https://www.nuget.org/packages/SnapObjects.Data/), and is structured as follows.

```
|——Appeon.SnapObjectsDemo.Service.SqlServer Project implemented with SqlModelMapper
    |——Datacontext      	Includes the class that manages database connection to SQL Server
    |——Models          		Includes the model classes
    |——Services             Includes the service interfaces and implementations
```
##### Running the Project

Note that the Class Library project cannot run alone. You shall define a web project to call the classes and methods defined in the project, or download and run the [SnapObjects-Asp.NetCore-Example](https://github.com/Appeon/SnapObjects-Asp.NetCore-Example) project that reference to this Class Library project.

Currently, this project can only work with the SQL Server database. 