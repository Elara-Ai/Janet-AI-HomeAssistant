# Define project names
$fileManagerService = "FileManagerService"
$userManagerService = "UserManagerService"
$configurationManagementService = "ConfigurationManagementService"

# Navigate to the solution directory
cd "AIProjects"

# Create .NET Core class library projects
dotnet new classlib -n $fileManagerService -f net8
dotnet new classlib -n $userManagerService -f net8
dotnet new classlib -n $configurationManagementService -f net8