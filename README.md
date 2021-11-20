<p align="center"> 
  <img width=182 src="https://user-images.githubusercontent.com/19508650/136642653-f364610f-daba-4ec4-8838-8c7d97494729.png">
</p>

# Medical Clinic Demo Web Api Project

This is an ASP.NET Core RESTful Web API demo application used as a back-end API for a fictional medical clinic.

## Technology Stacks and Tools Used

ASP.NET Core 3.1 Web API, EF Core 3.1, Automapper 10.1.1, SQL Server, Microsoft SQL Server Management Studio, Postman, Git for Version Control, Azure DevOps for project management.

Design and architectural patterns used: generic repository pattern, unit of work pattern, 3-layered architecture.

For productivity purposes, the following Visual Studio extensions were used: Productivity Power Tools, CodeMaid, Github extension for Visual Studio 2019, and Snippet Designer. 

These Android apps were used to facilitate effective time management: Microsoft To-Do app, Trello app, and the Pomodoro app.

## Application Features

There are two primary roles in the application, `Employee`, and `Patient`. And there are six web API controllers with respective resource endpoints: Acccount, Appointments, Auth, LabOrders, LabResults, and Records controllers. The LabResults API is an association API which serves the LabOrder entity's child Results entity.


