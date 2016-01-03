#!/bin/sh
here="`dirname \"$0\"`"
echo "cd-ing to $here"
cd "$here" || exit 1
xbuild /p:Configuration=Debug EifelMono.Extensions.sln
xbuild /p:Configuration=Release EifelMono.Extensions.sln
mono EifelMono.Nuget.exe nuspecversionfromdll $here/Pcl/EifelMono.Extensions/bin/Release/EifelMono.Extensions.dll
rm *.nupkg
mono NuGet.exe pack EifelMono.Extensions.nuspec 
mono NuGet.exe setApiKey 54d97fc4-b428-4b72-a212-54124778c643
mono NuGet.exe push *.nupkg