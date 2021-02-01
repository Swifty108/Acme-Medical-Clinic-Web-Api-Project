# Medical Clinic Web Api Demo Project

This is an ASP.NET Core Web API demo app used as a backend API for a fictional medical clinic.

## Technology Stacks Used

ASP.NET Core 3.1 Web API, EF Core 3.1, Automapper 10.1.1, SQL Server, Microsoft SQL Server Management Studio, Postman, Git for Version Control, Azure DevOps for project management.

Design and architectural patterns used: generic repository pattern, unit of work pattern, 3-layered architecture.

For productivity purposes, the following Visual Studio extensions were used: Productivity Power Tools, CodeMaid, Github extension for Visual Studio 2019, and Snippet Designer. 

These Android apps were used to facilitate effective time management: Microsoft To-Do app, Trello app, and the Pomodoro app.

## Application Features

There are two primary roles in the application, `Employee`, and `Patient`. And there are six Web API controllers with respective resource endpoints, Acccount, Appointments, Auth, LabOrders, LabResults, and Records controllers. The LabResults API is an association API which serve only the child Results entity of the LabOrder entity.
