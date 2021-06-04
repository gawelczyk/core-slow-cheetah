
REM msbuild  /nr:false /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU" -m 
REM msbuild  /nr:false /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU" /P:PublishProfile="publish" -m 
REM msbuild ".\ConsoleApp-slow\ConsoleApp-slow.csproj" /nr:false /t:Rebuild /p:Configuration=Release /p:Platform="Any CPU" /P:PublishProfile="publish" -m 

msbuild ".\ConsoleApp-slow\ConsoleApp-slow.csproj" /nr:false /t:Rebuild /p:Configuration=prod /p:Platform="Any CPU" -m 
