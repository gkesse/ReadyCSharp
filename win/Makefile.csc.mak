GSRC = ..\code\GProject\src
GBIN = bin
GTARGET = $(GBIN)\gp_csharp.exe

GSRCS = \
    $(GSRC)\\*.cs \
    $(GSRC)\manager\\*.cs \

GLIBS =\
    /lib:"C:\Program Files (x86)\SQLite.NET\bin" \
    /r:System.Data.SQLite.dll

all: compile run

compile:
	@if not exist $(GBIN) @mkdir $(GBIN)
	csc $(GLIBS) /out:$(GTARGET) $(GSRCS)
run: 
	@$(GTARGET) $(argv)
