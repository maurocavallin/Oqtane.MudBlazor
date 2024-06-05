del "*.nupkg"
"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Lemcube.Module.LemModule.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\Packages\" /Y

