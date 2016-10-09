#addin nuget:?package=Cake.NSwag

var target = Argument("target", "Default");
var configuration = Argument("configuration", "Debug");


//////////////////////////////////////////////////////////////////////
// PREPARATION
//////////////////////////////////////////////////////////////////////

// Define directories.

var binDirectory = Directory("bin") + Directory(configuration) + Directory("net452/win7-x64");
var apiDir = Directory("./src/WebApi");
var apiOutputDir = apiDir + binDirectory;

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////

Task("Clean")
    .Does(() =>
{
    CleanDirectory(apiOutputDir);
});

Task("Restore")
    .Does(() =>
{
    DotNetCoreRestore(apiDir.ToString());
});

Task("Build")
    .IsDependentOn("Restore")
    .Does(() =>
{
    var settings = new DotNetCoreBuildSettings
    {
        Configuration = configuration
    };
    DotNetCoreBuild(apiDir.ToString(), settings);
});

Task("Rebuild")
    .IsDependentOn("Clean")
    .IsDependentOn("Build")
    .Does(() =>
{
});

Task("GenerateDevAppClient")
    .IsDependentOn("Rebuild")
  .Does(() =>
{
  NSwag.FromWebApiAssembly(apiOutputDir.ToString() + "/WebApi.exe").ToSwaggerSpecification("./webApi.swagger.json");
});

RunTarget(target);