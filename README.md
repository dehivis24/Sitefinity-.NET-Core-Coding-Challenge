# Sitefinity .NET Core Coding Challenge

This repository contains our entry project for the Sitefinity .NET Core Coding Challenge.

This project displays information about COVID-19 vaccination sites in Costa Rica. 
In order to display this information we created a dynamic content module with information about vaccination sites and the doses administered in each site.

This project contains 6 widgets that use most of the features provided in the Sitefinity .NET Core samples. Some of the features we use are:

* Designer properties.
* Custom layout.
* Forms.
* Sitefinity Data.
* Content Selectors.

These are the widgets that we created:

* Vaccination Graph: Displays the amount of total COVID-19 vaccination doses administered by country in realtime. Has two display modes which can be configured in the designer.
* Vaccination Gallery: Displays images for every vaccination site created in the Vaccination Site dynamic content type.
* Vaccination Site Detail: Displays the detail information of a vaccination site.
* Vaccination Appointment Form: Allows an user to schedule an appointment in one of the vaccination sites. The appointment information is stored in a dynamic content type.
* Vaccination Site Search: Allows an user to search for the nearest vaccination site in their location. The coordinates are retrieved from the vaccination site content type.
* Content Block Display: Displays a content block stored in Sitefinity. It is selected from the widget designer.

# Prerequisites
In order for the widgets to be displayed we had to load some data into the dynamic content types that we created.
We attached a Sitefinity project (13.3.7600) and its database backup so all the data is available.
The Sitefinity project is located in the SitefinityCoreApp_Project folder.

You need to attach the database backup files to your SQL Server (Microsoft SQL Server 14). To do this:

* Navigate to the SitefinityCoreApp_Project -> App_Data folder.
* Unzip the SitefinityCoreApp_Backup.zip file.
* In SQL Management Studio, open the context menu of Databases and click Attach...
* Click the Add... button and navigate to the folder where you unzipped the SitefinityCoreApp_Backup.zip file.
* Select the Sitefinity.mdf file and click OK.
* Click OK.

# Nuget package restoration
The Sitefinity project solution in this repository relies on NuGet packages with Nuget Package Restore enabled. Sitefinity's Nuget Repository and the instructions on how to add the Sitefinity NuGet server are available here : http://nuget.sitefinity.com/#/home.

# Installation instructions:
In Solution Explorer, navigate to SitefinityCoreApp -> App_Data -> Sitefinity -> Configuration and select the DataConfig.config file.
Modify the connectionString value to match your server address.

One of the widgets uses the Google Maps plugin, so a Google Maps API key must be provided: 
* In the Renderer project, open the _Layout.cshtml file.
* Locate the following script tag: <script src="https://maps.googleapis.com/maps/api/js?libraries=places&key=[yourKey]" type="text/javascript"></script>.
* Replace "[yourKey]" with a Google Maps API key.
* Build the solution.


# Login
To login to the Sitefinity CMS backend, use the following credentials:

Username: admin@sitefinity.com Password: admin1234
