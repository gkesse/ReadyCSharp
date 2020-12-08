
help:
	@dotnet help
new:
	@dotnet new console -n $(GDOTNET_PROJECT_NAME) -o $(GDOTNET_PROJECT_PATH)
add:
	@dotnet add package $(GDOTNET_PACKAGE_NAME)
build:
	@dotnet build
run:
	@dotnet run
