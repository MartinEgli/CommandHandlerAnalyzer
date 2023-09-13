# CommandHandlerAnalyzer
This example shows how to create an analyser that forces the ending of a class that implements a specific interface.
The project is not optimised. It is a simple example.

## Use
The solution builds several nuget packages that are used in projects in this solution.

1. Create a folder for NuGet packages.
2. Create a new nuget source with source of the new folder.
3. Build the CommandHandlerAttributes project.
4. Copy nuget into nuget Folder.
5. Build the project CommandHandlerAnalyser.Package.
6. Copy nuget into nuget Folder.
7. Build the CommandHandlerInterfaces project.
8. Copy nuget into nuget Folder.
9. Build the project CommandHandlerSample.
This should now fail due to the analyser.

If you have problems, restart Visual studio.
