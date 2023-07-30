string NuGetVersionV2 = "";
string SolutionFileName = "src/StoneAssemblies.EntityFrameworkCore.sln";

string[] DockerFiles = System.Array.Empty<string>();

string[] OutputImages = System.Array.Empty<string>();

string[] ComponentProjects  = new [] {
	"src/StoneAssemblies.EntityFrameworkCore/StoneAssemblies.EntityFrameworkCore.csproj"
};

string TestProject = "src/StoneAssemblies.EntityFrameworkCore.Tests/StoneAssemblies.EntityFrameworkCore.Tests.csproj";

string SonarProjectKey = "stoneassemblies_StoneAssemblies.EntityFrameworkCore";
string SonarOrganization = "stoneassemblies";