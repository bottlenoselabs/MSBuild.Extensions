# common-cs

Common code and MSBuild extensions for all C# projects at Bottlenose Labs.

## Developers: How to use

1. Add the NuGet package to your `.csproj`. The `PrivateAssets` with value `all` means that the NuGet project doesn't propagate to other C# projects vai transitive property.

```xml
<PackageReference Include="bottlenoselabs.Common.Tools" Version="*.*">
    <PrivateAssets>all</PrivateAssets>
</PackageReference>
```

2. Create `Directory.Build.props` file above the directory of your C# projects with a `UseArtifactsOutput` set to `true` in a property group. This will cause all `bin` and `obj` folders to be placed under the `artifacts` directory at the root of the Git repository. To change this directory set `ArtifactsPath`.

```xml
<Project>
  <PropertyGroup>
    <UseArtifactsOutput>true</UseArtifactsOutput> <!-- Only available in .NET 8 -->
    <ArtifactsPath>$([MSBuild]::GetDirectoryNameOfFileAbove($(MSBuildProjectDirectory), .gitignore))/artifacts</ArtifactsPath> <!-- Only available in .NET 8 -->
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="StyleCop.Analyzers.Unstable" Version="*" PrivateAssets="all" />
  </ItemGroup>
</Project>
```

3. Create a `.globalconfig` file to configure C# Roslyn analyzers:

```xml
# NOTE: Requires .NET 5 SDK (VS2019 16.8 or later)
# https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/configuration-files#global-analyzerconfig
is_global = true

# StyleCop Rules
# Description: StyleCop code analysis rules for C# projects.
dotnet_diagnostic.SA1309.severity = error
```
