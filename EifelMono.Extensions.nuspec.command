 #!/bin/sh
here="`dirname \"$0\"`"
echo "cd-ing to $here"
cd "$here" || exit 1
xbuild /p:Configuration=Debug EifelMono.Extensions.sln
xbuild /p:Configuration=Release EifelMono.Extensions.sln
mono NuGet.exe pack EifelMono.Extensions.nuspec