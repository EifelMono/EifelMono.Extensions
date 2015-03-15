 #!/bin/sh
here="`dirname \"$0\"`"
echo "cd-ing to $here"
cd "$here" || exit 1
mono NuGet.exe pack EifelMono.Extensions.nuspec