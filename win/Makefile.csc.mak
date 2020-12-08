GSRC = ..\code\GProject\src
GBIN = bin
GTARGET = $(GBIN)\gp_csharp.exe

GSRCS = \
    $(GSRC)\\*.cs \
    $(GSRC)\manager\\*.cs \

GLIBS =\
    /lib:lib\Stub.System.Data.SQLite.Core.NetFramework.1.0.113.3\lib\net40 \
    /r:System.Data.SQLite.dll \

all: clean compile run

compile:
	@if not exist $(GBIN) @mkdir $(GBIN)
	csc $(GLIBS) /out:$(GTARGET) $(GSRCS)
run: 
	@$(GTARGET) $(argv)
clean: 
	@if not exist $(GBIN) @mkdir $(GBIN)
	@del /q $(GBIN)\*.exe
    
