#!/bin/sh
here="`dirname \"$0\"`"
echo "cd-ing to $here"
cd "$here" || exit 1
xbuild /p:Configuration=Debug EifelMono.Extensions.sln
xbuild /p:Configuration=Release EifelMono.Extensions.sln
mono EifelMono.Nuget.exe nuspecversionfromdll $here/Pcl/EifelMono.Extensions/bin/Release/EifelMono.Extensions.dll
rm *.nupkg
mono NuGet.exe pack EifelMono.Extensions.nuspec
echo "\e[1;31m-----------------------------------------"
echo "No Upload to NuGet"
echo "-----------------------------------------\e[0m"