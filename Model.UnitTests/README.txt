Unit Tests for the Model Project

Running Code Coverage:
1. Open Developer Command Prompt for VS 2017
2. Navigate to bph-back-end/Model.UnitTests folder
3. Enter command:  dotnet add package coverlet.msbuild
4. Enter command:  dotnet test /p:CollectCoverage=true
5. The output in the command prompt has a code coverage chart.
   A coverage.json file is created under Model.UnitTests/
  6. test commit