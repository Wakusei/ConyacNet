cd ..\ConyacNet
..\Scripts\NuGet.exe pack
$package= @(ls *.nupkg)[0]
..\Scripts\NuGet.exe push $package

pause
