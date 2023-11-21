# Common.Tools

Common MSBuild extensions for all C# projects at Bottlenose Labs.

## Developers: How to use

1. Create `Directory.Build.props` file above the directory of your C# projects.
   
   - Set `UseArtifactsOutput` to `true` in a property group. This will cause all `bin` and `obj` folders to be placed under the `artifacts` directory at the root of the Git repository. To change this directory set `ArtifactsPath`.
   - Set `ArtifactsPath` to a directory where the `bin/ProjectName` and `obj/ProjectName` folders will be generated.
   - Add `bottlenoselabs.Common.Tools` NuGet package with wildcard version.

```xml
<Project>
  <PropertyGroup>
    <UseArtifactsOutput>true</UseArtifactsOutput> <!-- Only available in .NET 8 -->
    <ArtifactsPath>$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildProjectDirectory), .gitignore))/artifacts</ArtifactsPath> <!-- Only available in .NET 8 -->
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="bottlenoselabs.Common.Tools" Version="*">
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>

    <PackageReference Include="StyleCop.Analyzers.Unstable" Version="*">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
  </ItemGroup>
</Project>
```

1. Create a `.globalconfig` file to configure C# Roslyn analyzers:

```xml
# NOTE: Requires .NET 5 SDK (VS2019 16.8 or later)
# https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/configuration-files#global-analyzerconfig
is_global = true

# StyleCop Rules
# Description: StyleCop code analysis rules for C# projects.
dotnet_diagnostic.SA1309.severity = error
```
