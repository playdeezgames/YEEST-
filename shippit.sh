rm -rf ./pub-linux
rm -rf ./pub-windows
rm -rf ./pub-mac
dotnet publish ./src/YEEST/YEEST.vbproj -o ./pub-linux -c Release --sc -p:PublishSingleFile=true -r linux-x64
dotnet publish ./src/YEEST/YEEST.vbproj -o ./pub-windows -c Release --sc -p:PublishSingleFile=true -r win-x64
dotnet publish ./src/YEEST/YEEST.vbproj -o ./pub-mac -c Release --sc -p:PublishSingleFile=true -r osx-x64
butler push pub-windows thegrumpygamedev/yeest:windows
butler push pub-linux thegrumpygamedev/yeest:linux
butler push pub-mac thegrumpygamedev/yeest:mac
git add -A
git commit -m "shipped it!"