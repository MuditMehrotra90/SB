
# ShopBridge
Assignment for thinkbridge

**Shop Bridge** is an inventory management built in using **asp.net core mvc**. It is basically used to manage different items. User can store some basic information
related to the item like category to which item belongs, name, description, price, item code.

The complete code can be found on git under **master** branch.

# Tools Used
* Visual Studio 2019 or higher
* SQL Server 2014

# Project Setup
* Download the project from repository or clone it using the git url https://github.com/MuditMehrotra90/SB in visual studio.
* Unzip the downloaded zip file and double click on SB.sln file.
* Open Package Manager Console in Visual Studio from Tool > Nuget Package Manage > Package Manager Console and select **SB.EntityFramework** as defalut project.
  ![image](https://user-images.githubusercontent.com/107866569/174657660-61b371e3-8e2d-4194-99ca-deac3b0f511e.png)
* Run PM > Update-Datebase command in Package Manager Console and hit enter to run the automatic migrations.

# Steps To Run The Project
* In solution explorer right click on SB.sln and select Set Startup Project.

  ![image](https://user-images.githubusercontent.com/107866569/174658497-21d1c0e7-d6c8-4e4d-a8ab-69ee1f715363.png)
* Choose Multiple Startup Projects option, for SB.API and SB.Web select start in the action dropdown. 
  ![image](https://user-images.githubusercontent.com/107866569/174658598-a3295bbd-6bab-4efd-b9e4-9efd6cec18bb.png)
* Run the projects by pressing F5 or from the Start option from tool bar in VS .

# Backend Flow
* Backend is developed using the async programming, reusable code and concepts of oops.
* Swagger is configured in order to run the API's.
  ![image](https://user-images.githubusercontent.com/107866569/174666458-ff1cf011-a528-4ea4-8250-a01f87ffa31d.png)

* New APIs can be created under SB.API project.
* All the service classes, their interfaces and the Dtos are created under SB.Application project.
* All the entities for database are created under SB.Core project
* SB.EntityFramework project handles the migrations of the database and also seeds the data for Category tables as soon as we run the migration.

# Frontend Flow
* User can view the listing of items on Item Listing page by clicking on the Item menu in the application.
  ![image](https://user-images.githubusercontent.com/107866569/174660814-7af6d1b2-d7d3-40af-95c4-171ac14b987b.png)
* User can add the item details from Create Item page.
  ![image](https://user-images.githubusercontent.com/107866569/174660954-4bfb58e7-458c-40fc-9f46-4a423c1cfdbc.png)
* Items details like price, description can be edited from the Edit Item page. This page can also be used just to see the details of the Item.
  ![image](https://user-images.githubusercontent.com/107866569/174661066-4f6343d3-e6fe-4a10-8920-e679f109ee48.png)
* Added items can also be deleted using delete button on the Item Listing page.
* Paging, searching and sorting is created using datatable server side processing.
* Searching can be performed for Category, Item Name and Item Code column of the listing.
* Data in the list can be sorted based on Item Name, Item Code and Price column. 
* Pagination option is also provided in order to improve user experience and loading time.

# Run Test Cases
* To run the test cases go to Test > Test Explorer > Run all test.

# Time Tracking
* Data Store Design - 2 hours
* API and Service logic - 10 hours
* Web Development With API Integration - 9 hours
* Unit Test Coverage - 2 hours
