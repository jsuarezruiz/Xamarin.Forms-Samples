module BuildHelpers

open Fake
open Fake.XamarinHelper
open System
open System.IO
open System.Linq

let Exec command args =
    let result = Shell.Exec(command, args)

    if result <> 0 then failwithf "%s exited with error %d" command result

let RestorePackages solutionFile =
    Exec "tools/NuGet/NuGet.exe" ("restore " + solutionFile)
    solutionFile |> RestoreComponents (fun defaults -> {defaults with ToolPath = "tools/xpkg/xamarin-component.exe" })

let RunNUnitTests dllPath xmlPath =
    Exec "tools/NUnit/nunit-console" (dllPath + " -xml=" + xmlPath) 
    TeamCityHelper.sendTeamCityNUnitImport xmlPath
	
let RunUITests appPath =
    let testAppFolder = Path.Combine("tests/Calculator.UITests", "testapps")

    if Directory.Exists(testAppFolder) then Directory.Delete(testAppFolder, true)
    Directory.CreateDirectory(testAppFolder) |> ignore

    let testAppPath = Path.Combine(testAppFolder, DirectoryInfo(appPath).Name)

    Directory.Move(appPath, testAppPath)

    RestorePackages "Calculator.sln"

    MSBuild "tests/Calculator.UITests/bin/Debug" "Build" [ ("Configuration", "Debug"); ("Platform", "Any CPU") ] [ "tests/Calculator.UITests/Calculator.UITests.csproj" ] |> ignore

    RunNUnitTests "tests/Calculator.UITests/bin/Debug/Calculator.UITests.dll" "tests/Calculator.UITests/bin/Debug/testresults.xml"

let GetBuildCounter (str:Option<string>) =
    match str with
    | Some(v) -> v
    | None -> "Local"
