
help:
	@nuget help
install:
	@nuget install $(GNUGET_PACKAGE_NAME) -OutputDirectory $(GNUGET_PACKAGE_DIR) 
