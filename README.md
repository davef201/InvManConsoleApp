# InvManConsoleApp
 InvManConsoleApp is a console applcation to automate the inventory management process. It takes a file of current inventory and outputs a file that lists the new inventory.
 
## Pre-requisites
This app has been developed using Visual Studio 2019 and targets .Net Core 3.1 .

Before building the app, it would be benefical to have these available. I can make other .Net targets available on request

## Building the app
After cloning the repository and opening the solution in visual studio, you'll need to set the path names for the folders that contain the files to be processed (ImportFileLocation), the current inventory files that have been processed (ProcessedFileLocation) and the new inventory files (ExportFileLocation). The path names are aet in the appsettings.json file of the InvManConsoleApp project.

## Testing the app

## Running the app
As this is a console application, it can be run in a couple of ways: <br />
-- From the command prompt <br />
-- From the windows task scheduler or equivalent


## Improvements / Questions
This applcation has been developed based on the information provided. As such certain assumptions had to be made, for example, item names do not contain more than two words.

