using static Bullseye.Targets;
using static SimpleExec.Command;

Target("build", () => RunAsync("dotnet", "build --configuration Release --nologo --verbosity quiet"));
Target("test", dependsOn: ["build"], () => RunAsync("dotnet", "test --configuration Release --no-build --nologo --verbosity quiet"));
Target("default", dependsOn: ["test"]);

await RunTargetsAndExitAsync(args, ex => ex is SimpleExec.ExitCodeException).ConfigureAwait(false);