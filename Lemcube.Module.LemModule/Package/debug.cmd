XCOPY "..\Client\bin\Debug\net8.0\Lemcube.Module.LemModule.Client.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Client\bin\Debug\net8.0\Lemcube.Module.LemModule.Client.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Server\bin\Debug\net8.0\Lemcube.Module.LemModule.Server.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Server\bin\Debug\net8.0\Lemcube.Module.LemModule.Server.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Shared\bin\Debug\net8.0\Lemcube.Module.LemModule.Shared.Oqtane.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Shared\bin\Debug\net8.0\Lemcube.Module.LemModule.Shared.Oqtane.pdb" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
XCOPY "..\Server\wwwroot\*" "..\..\oqtane.framework\Oqtane.Server\wwwroot\" /Y /S /I

XCOPY "..\Client\bin\Debug\net8.0\MudBlazor.dll" "..\..\oqtane.framework\Oqtane.Server\bin\Debug\net8.0\" /Y
