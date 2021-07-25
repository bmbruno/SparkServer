# SparkServer

This is the ASP.NET MVC backend and frontend for the blogging engine that powers SitecoreSpark.com.

Written and originally maintained by Brandon Bruno, copyright (c) 2017 - 2021. This code is provided as-is. See LICENSE file for further details.

# Notes

* Login functionality is provided by the SSO server at https://sso.brandonbruno.com - this requires a re-implementation of the Account controller to support other login systems.

* Certain pieces of the backend admin are written with specific workflows in mind and are not meant to always be user-friendly.

* This application is provided as-is: I will generally NOT be available to provide troubleshooting or support should you choose to compile and run it.

* Don't be surprised if you find plenty of half-finished code or interfaces without implementations - new features are always being worked on and aren't fully baked yet (and being a personal project, I don't always follow good branching strategies).

# Setup Instructions (local development)

_SparkServer_ requires the following software to build and run locally:

* Visual Studio 2019
* SQL Server 2016 or newer (Express is fine)

## Step 1

Clone repository.

## Step 2

Open the following file: `\SparkServer\SQLScripts\batchsql.bat`

Configure the `BLD_SQLSERV` variable to point to your SQL Server instance (line 7 by default):

```
SET BLD_SQLSERV=localhost
```

## Step 3

Create a SQL Server user in the `SparkServer` database. By default, the database connection string expects the following credentials:

Username: `sitecorespark`
Password: `spark1`

The connection string is located in `\SparkServer\Application\SparkServer\Web.config` (in `SparkServerEntities`) and can be modified as you see fit.

## Step 4

Debug in Visual Studio.