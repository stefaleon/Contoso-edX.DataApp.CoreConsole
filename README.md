# Contoso .NET Core Application with Entity Framework
[ edX: Microsoft: DEV256x Developing Data Client Applications and Services ](https://www.edx.org/course/developing-data-client-applications-microsoft-dev256x)

&nbsp;
## 00 Start the project
* In VS, create a Console App (.NET Core) project.


&nbsp;
## 01 Add the Entity Framework Core Library
* Click the View menu at the top of the Visual Studio window and then select the Solution Explorer option.
* In the Solution Explorer pane, expand the edX.DataApp.Lab.CoreConsole project to reveal the project files.
* Right-click the Dependencies node and select the Manage NuGet Packages... menu option.
* In the NuGet Package Manager dialog, click the Browse tab.
* In the Browse tab, perform the following actions:
* In the Search box, enter the text EntityFrameworkCore and then press the Enter/Return key.
* In the search results, locate and select the Microsoft.EntityFramework.Core.SqlServer by Microsoft result. A pane will appear to the right with details about the package.
* In the pane, select the 1.1.1 version.
* Click the Install button.
* In the Preview dialog, view the list of changes to your project dependencies. Click the OK button.
* In the License Acceptance dialog, view the license information for each package and then click the I Accept button.
* Close the NuGet Package Manager dialog.



&nbsp;
## 02 Implement A Model Class
* In the Solution Explorer pane, right-click the edX.DataApp.Lab.CoreConsole project, hover over the Add menu option and then select the New Item... menu option.
* In the Add New Item dialog, perform the following actions:
    * Expand the Visual C# Items node, and then select the Code node.
    * Select the Class template.
    *  In the Name box, enter the value Product.cs.
    *  Click the OK button.
* Once the file has been created, Visual Studio will automatically open the Product.cs class file. Leave this file open.
* In the currently open Product.cs file, ensure that an using statement exists for the System namespace:
```
using System;
```
* Add a new using statement for the System.ComponentModel.DataAnnotations namespace:
```
using System.ComponentModel.DataAnnotations;
```
* Update the Product class definition by setting a public accessor:
* Add a new int property named ProductId with public get and set accessors:
* Update the ProductId property by adding a Key attribute to the property:
* Add a new string property named Name with public get and set accessors:
* Add a new string property named ProductNumber with public get and set accessors:
* Add a new string property named Color with public get and set accessors:
* Add a new decimal property named StandardCost with public get and set accessors:
* Add a new decimal property named ListPrice with public get and set accessors:
* Your Product class should now look like this:
```
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }
    }
```
* Save and close the Product.cs class.

&nbsp;
## 03 Implement A Entity Framework Core Context Class
* In the Solution Explorer pane, right-click the edX.DataApp.Lab.CoreConsole project, hover over the Add menu option and then select the New Item... menu option.
* In the Add New Item dialog, perform the following actions:
    * Expand the Visual C# Items node, and then select the Code node.
    * Select the Class template.
    * In the Name box, enter the value ContosoContext.cs.
    * Click the OK button.
* Once the file has been created, Visual Studio will automatically open the ContosoContext.cs class file. Leave this file open.
* In the currently open ContosoContext.cs file, add a new using statement for the Microsoft.EntityFrameworkCore namespace:
```
using Microsoft.EntityFrameworkCore;
```
* Update the ContosoContext class definition by setting a public accessor and inheriting from the DbContext class:
```
public class ContosoContext : DbContext
```
* Add a new method named OnConfiguring to the ContosoContext class using the following signature:
```
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
```
* Within the OnConfiguring method, add a new line to create a string variable named connectionString with a value of Data
Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;:
```
    string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
```
* After the last line of code, add a another line of code to use the connectionString variable as a parameter to the UseSqlServer method of the optionsBuilder variable:
```
    optionsBuilder.UseSqlServer(connectionString);
```
* In the ContosoContext class, add a new DbSet property named Products with public get and set accessors and the virtual keyword:
```
    public virtual DbSet<Product> Products { get; set; }
```
* Your ContosoContext class should now look like this:
```
    public class ContosoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Product> Products { get; set; }
    }
```
* Save and close the ContosoContext.cs class.

&nbsp;
## 04 Implement Basic Entity Framework Core Logic
* In the currently open Program.cs file, ensure that an using statement exists for the System namespace:
```
    using System;
```
* Add a new using statement for the System.Threading.Tasks namespace:
```
    using System.Threading.Tasks;
```
* Add a new using statement for the Microsoft.EntityFrameworkCore.Infrastructure namespace:
```
    using Microsoft.EntityFrameworkCore.Infrastructure;
```
* Add a new using statement for the Microsoft.EntityFrameworkCore.Storage namespace:
```
    using Microsoft.EntityFrameworkCore.Storage;
```
* Add a new RunAsync method with the following signature:
```
    static async Task RunAsync()
```
* Within the RunAsync method, Add a using block that instantiates a new instance of the ContosoContext class:
```
    using (ContosoContext context = new ContosoContext())
    {
    }
```
* Within the using block, add a new line of code to get an instance of the IDatabaseCreator service using the generic GetService method of the context variable and cast the result to the RelationalDatabaseCreator type:
```
    var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
```
* After the last line of code within the using block, add a new line of code to await the asynchronous invocation of the creator variable's ExistsAsync method:
```
    await creator.ExistsAsync();
```
* After the last line of code within the using block, add a new line of code to write the message "Connection Successful" to the console window:
```
    Console.WriteLine("Connection Successful");
```
* Your RunAsync method should now look like this:
```
    static async Task RunAsync()
    {
        using (ContosoContext context = new ContosoContext())
        {
            var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            await creator.ExistsAsync();
            Console.WriteLine("Connection Successful");
        }
    }
```


&nbsp;
## 05 Validate Solution
* In the currently open Program.cs file, locate the Main method with the following signature:
```
    static void Main(string[] args)
```
* Within the Main method, delete the existing line of code that writes "Hello World!" to the console window. You should now have an empty Main method:
```
    static void Main(string[] args)
    {        
    }
```
* Add the following line of code to invoke the RunAsync method and wait for the asynchronous Task to complete:
```
    RunAsync().Wait();
```
* After the last line of code, add a new line of code to write the message "Application has completed execution. Press any key to exit." to the console window:
```
    Console.WriteLine("Application has completed execution. Press any key to exit.");
```
* After the last line of code, add a new line of code to read the new keypress from the console window:
```
    Console.ReadKey();
```
* Your Run method should now look like this:
```
    static void Main(string[] args)
    {
        RunAsync().Wait();
        Console.WriteLine("Application has completed execution. Press any key to exit.");
        Console.ReadKey();
    }
```
* At the top of the Visual Studio window; click the Debug menu, and then select the Start Debugging menu option.
* Observe the "Connection Successful" message in the console window. Press any key to close the console window.


&nbsp;
## 06 Modify a Database Table

* At the top of the Visual Studio window, click the View menu and then select the Server Explorer menu option.
* In the Server Explorer pane, right-click the Data Connections node and then select the Add Connection... option.
* In the Add Connection dialog, perform the following actions:
    * In the Server name box, enter the value (localdb)\MSSQLLOCALDB.
    * In the Authentication list, select the Windows Authentication option.
    * In the Connect to a database section, locate the Select or enter a database name list. Select the ContosoDB database in the list.
    * Click the Test Connection button at the bottom of the dialog.
    * The response popup window should state "Test connection succeeded".
    * Click the OK button to save the connection.
* In the Server Explorer pane, you should see a node for the connection to the localdb database instance.
* Right-click the localdb connection node and select the New Query option.
* In the query editor, enter the following query:
```
    ALTER TABLE
        Products
    ADD
        ReleaseDate datetime2 NULL,
        SafetyReviewResult bit NULL,
        ExternalId uniqueidentifier DEFAULT NEWSEQUENTIALID() NOT NULL
```
* Click the green arrow button to Execute the query. The query should return a message indicating that it has succeeded.
* In the query editor, replace the existing query with the following new query:
```
    UPDATE
        Products
    SET
        SafetyReviewResult = 1
    WHERE
        ProductNumber LIKE 'FR-%'
```
* Click the green arrow button to Execute the query. The query should return a message indicating that multiple rows have been affected by the query.
* At the top of the Visual Studio window, click the View menu and then select the Server Explorer menu option.
* In the Server Explorer pane; expand the localdb connection node and then expand the Tables node.
* Right-click the Tables node and then select the Refresh menu option.
* Right-click the Products table node and then select the Show Table Data menu option.
* Observe the new columns in your database table.


&nbsp;
## 07 Update an Entity Framework Model Class

* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* In the Solution Explorer pane; expand the edX.DataApp.Console project and then double-click the Product.cs file.
* In the currently open Product.cs file, ensure that an using statement exists for the System namespace:
```
    using System;
```
* Add a new nullable DateTime property named ReleaseDate with public get and set accessors:
```
    public DateTime? ReleaseDate { get; set; }
```
* Add a new nullable boolean property named SafetyReviewResult with public get and set accessors:
```
    public bool? SafetyReviewResult { get; set; }
```
* Add a new Guid property named ExternalId with public get and set accessors:
```
    public Guid ExternalId { get; set; }
```
* Your Product class should now look like this:
```
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool? SafetyReviewResult { get; set; }

        public Guid ExternalId { get; set; }
    }
```
* Save and close the Product.cs class.

&nbsp;
## 08 Implement Query Logic
* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* In the Solution Explorer pane; right-click the edX.DataApp.Console project, hover over the Add menu option, and then select the New Item... menu option.
* In the Add New Item dialog, perform the following actions:
    * Expand the Visual C# Items node, and then select the Code node.
    * Select the Class template.
    * In the Name box, enter the value ProductQuery.cs.
    * Click the OK button.
* Once the file has been created, Visual Studio will automatically open the ProductQuery.cs class file. Leave this file open.
* In the currently open ProductQuery.cs file, ensure that an using statement exists for the System namespace:
```
    using System;
```
* Ensure that an using statement exists for the System.Collections.Generic namespace:
```
    using System.Collections.Generic;
```
* Add a new using statement for the System.Linq namespace:
```
    using System.Linq;
```
* Update the ProductQuery class definition by setting a public accessor:
```
    public class ProductQuery
```
* Within the ProductQuery class, add a new RunLogic method with the following signature:
```
    public void RunLogic(ContosoContext context)
    {        
    }
```
* Within the RunLogic method, add a new line of code to get an IEnumerable variable that contains a query that would return all results in the Products table. (Note: Do not add a semicolon to the end of the line of code):
```
    IEnumerable<Product> products =   
```
* Add a new line of code to create a LINQ query using the from keyword and a product variable for local expression evaluation:
```
    IEnumerable<Product> products =
        from product in context.Products
```
* Add a new line of code to expand the LINQ query by filtering the results to records that have a value of true for the SafetyReviewResult property. To accomplish this, reference the SafetyReviewResult nullable property and use the null coalescing operator to return false if the property is null:
```
    IEnumerable<Product> products =
        from product in context.Products
        where product.SafetyReviewResult ?? false
```
* Add a new line of code to expand the LINQ query by enumerating the results to a IEnumerable variable:
```
    IEnumerable<Product> products =
        from product in context.Products
        where product.SafetyReviewResult ?? false
        select product;
```
* Add a new line of code to enumerator over the products variable using the foreach keyword:
```
    foreach(Product product in products)
    {
    }
```
* Within the foreach block, add a line of code to write information about each product to the console window:
```
    Console.WriteLine($"[{product.ProductNumber}]\t{product.Name, 35}\tPassed Review: {product.SafetyReviewResult}");
```


&nbsp;
## 09 Validate Solution

* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* Locate and expand the edX.DataApp.Console project.
* Within the edX.DataApp.Console project, locate and double-click the Program.cs file.
* Locate the RunAsync method with the following signature:
```
    static async Task RunAsync()
```
* Within the RunAsync method, locate the using block that instantiates a new instance of the ContosoContext class:
```
    using (ContosoContext context = new ContosoContext())
    {
        var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        await creator.ExistsAsync();
        Console.WriteLine("Connection Successful");
    }
```
* Within the using block, add the following line of code after the last line of existing code to create a new instance of the ProductQuery class and invoke the RunLogic method:
```
    new ProductQuery().RunLogic(context);
```
* Your RunAsync method should now look like this:
```
    static async Task RunAsync()
    {
        using (ContosoContext context = new ContosoContext())
        {
            var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            await creator.ExistsAsync();
            Console.WriteLine("Connection Successful");
            new ProductQuery().RunLogic(context);
        }
    }
```
* At the top of the Visual Studio window; click the Debug menu, and then select the Start Debugging menu option.
* Observe the list of products printed to the console window. Press any key to close the console window.


&nbsp;
## 10 Create a New Entity Framework Model Class

* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* In the Solution Explorer pane; right-click the edX.DataApp.Console project, hover over the Add menu option, and then select the New Item... menu option.
* In the Add New Item dialog, perform the following actions:
    * Expand the Visual C# Items node, and then select the Code node.
    * Select the Class template.
    * In the Name box, enter the value ProductCategory.cs.
    * Click the OK button.
* Once the file has been created, Visual Studio will automatically open the ProductCategory.cs class file. Leave this file open.
* In the currently open ProductCategory.cs file, ensure that an using statement exists for the System namespace:
```
    using System;
```
* Add a new using statement for the System.ComponentModel.DataAnnotations namespace:
```
    using System.ComponentModel.DataAnnotations;
```
* Update the ProductCategory class definition by setting a public accessor:
```
    public class ProductCategory
```
* Add a new int property named ProductCategoryId with public get and set accessors:
```
    public int ProductCategoryId { get; set; }
```
* Update the ProductCategoryId property by adding a Key attribute to the property:
```
    [Key]
    public int ProductCategoryId { get; set; }
```
* Add a new string property named Name with public get and set accessors:
```
    public string Name { get; set; }
```
* Your ProductCategory class should now look like this:
```
    public class ProductCategory
    {
        [Key]
        public int ProductCategoryId { get; set; }

        public string Name { get; set; }
    }
```
* Save and close the ProductCategory.cs class.


&nbsp;
## 11 Update an Existing Entity Framework Model Class

* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* In the Solution Explorer pane; expand the edX.DataApp.Console project and then double-click the Product.cs file.
* In the currently open Product.cs file, add a new ProductCategory property named ProductCategory with public get and set accessors and the virtual keyword:
```
    public virtual ProductCategory ProductCategory { get; set; }
```
* Your Product class should now look like this:
```
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        public string Name { get; set; }

        public string ProductNumber { get; set; }

        public string Color { get; set; }

        public decimal StandardCost { get; set; }

        public decimal ListPrice { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool? SafetyReviewResult { get; set; }

        public Guid ExternalId { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }
    }
```
* Save and close the Product.cs class.


&nbsp;
## 12 Update the Entity Framework Context Class
* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* In the Solution Explorer pane; expand the edX.DataApp.Console project and then double-click the ContosoContext.cs file.
* In the currently open ContosoContext.cs file, add a new DbSet property named ProductCategories with public get and set accessors and the virtual keyword:
```
    public virtual DbSet<ProductCategory> ProductCategories { get; set; }
```
* Your ContosoContext class should now look like this:
```
    public class ContosoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLOCALDB;Initial Catalog=ContosoDB;";
            optionsBuilder.UseSqlServer(connectionString);
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    }
```
* Save and close the ContosoContext.cs class.


&nbsp;
## 13 Implement Query Logic

* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* In the Solution Explorer pane; right-click the edX.DataApp.Console project, hover over the Add menu option, and then select the New Item... menu option.
* In the Add New Item dialog, perform the following actions:
    * Expand the Visual C# Items node, and then select the Code node.
    * Select the Class template.
    * In the Name box, enter the value ProductAndCategoryQuery.cs.
    * Click the OK button.
* Once the file has been created, Visual Studio will automatically open the ProductAndCategoryQuery.cs class file. Leave this file open.
* In the currently open ProductAndCategoryQuery.cs file, ensure that an using statement exists for the System namespace:
```
    using System;
```
* Ensure that an using statement exists for the System.Collections.Generic namespace:
```
    using System.Collections.Generic;
```
* Add a new using statement for the System.Threading.Tasks namespace:
```
    using System.Threading.Tasks;
```
* Add a new using statement for the System.Linq namespace:
```
    using System.Linq;
```
* Add a new using statement for the Microsoft.EntityFrameworkCore namespace:
```
    using Microsoft.EntityFrameworkCore;
```
* Update the ProductAndCategoryQuery class definition by setting a public accessor:
```
    public class ProductAndCategoryQuery
```
* Within the ProductAndCategoryQuery class, add a new RunLogic method with the following signature:
```
    public async Task RunLogic(ContosoContext context)
    {        
    }
```
* Within the RunLogic method, add a new line of code to get an IEnumerable variable that contains a query that would return all results in the Products table. (Note: Do not add a semicolon to the end of the line of code):
```
    IEnumerable<Product> products = await context.Products   
```
* Add a new line of code to fluently extend the last line of code by including the ProductCategory related entity:
```
    IEnumerable<Product> products = await context.Products
        .Include(p => p.ProductCategory)
```
* Add a new line of code to fluently extend the last line of code by filtering the results to only Product entities that have a ListPrice value between $1250.00 and $1450.00:
```
    IEnumerable<Product> products = await context.Products
        .Include(p => p.ProductCategory)
        .Where(p => p.ListPrice > 1250m && p.ListPrice < 1450m)
```
* Add a new line of code to fluently extend the last line of code by getting the top 20 records that match the query:
```
    IEnumerable<Product> products = await context.Products
        .Include(p => p.ProductCategory)
        .Where(p => p.ListPrice > 1250m && p.ListPrice < 1450m)
        .Take(20)
```
* Add a new line of code to fluently extend the last line of code by enumerating the results to a List asynchronously:
```
    IEnumerable<Product> products = await context.Products
        .Include(p => p.ProductCategory)
        .Where(p => p.ListPrice > 1250m && p.ListPrice < 1450m)
        .Take(20)
        .ToListAsync();
```
* Add a new line of code to enumerator over the products variable using the foreach keyword:
```
    foreach(Product product in products)
    {
    }
```
* Within the foreach block, add a line of code to write information about each product to the console window:
```
    Console.WriteLine($"[{product.ProductCategory.Name}]\t{product.Name,35}\t{product.ListPrice:C}");
```




&nbsp;
## 13 Validate Solution
* At the top of the Visual Studio window; click the View menu and then select the Solution Explorer option.
* Locate and expand the edX.DataApp.Console project.
* Within the edX.DataApp.Console project, locate and double-click the Program.cs file.
* Locate the RunAsync method with the following signature:
``
    static async Task RunAsync()
```
* Within the RunAsync method, locate the using block that instantiates a new instance of the ContosoContext class:
```
    using (ContosoContext context = new ContosoContext())
    {
        var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
        await creator.ExistsAsync();
        Console.WriteLine("Connection Successful");
        await new ProductQuery().RunLogic(context);
    }
```
* Within the using block, remove the following line of code:
```
    await new ProductQuery().RunLogic(context);
```
* Add the following line of code after the last line of existing code to create a new instance of the ProductAndCategoryQuery class and invoke the RunLogic method:
```
    await new ProductAndCategoryQuery().RunLogic(context);
```
* Your RunAsync method should now look like this:
```
    static async Task RunAsync()
    {
        using (ContosoContext context = new ContosoContext())
        {
            var creator = context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
            await creator.ExistsAsync();
            Console.WriteLine("Connection Successful");
            await new ProductAndCategoryQuery().RunLogic(context);
        }
    }
```
* At the top of the Visual Studio window; click the Debug menu, and then select the Start Debugging menu option.
* Observe the list of products printed to the console window. Press any key to close the console window.
