GSRC = ..\code\GProject\src
GBIN = bin
GTARGET = $(GBIN)\gp_csharp.exe

GSRCS = \
    $(GSRC)\\*.cs \
    $(GSRC)\manager\\*.cs \

GLIBS =\
    /lib:bin \
    /r:System.Data.SQLite.dll \
    /r:QtWidgets.Sharp.dll \
    /r:QtGui.Sharp.dll \
    /r:QtCore.Sharp.dll \

GCFLAGS =\
    -unsafe \
    
all: clean compile run

compile:
	@if not exist $(GBIN) @mkdir $(GBIN)
	csc $(GCFLAGS) $(GLIBS) /out:$(GTARGET) $(GSRCS)
run: 
	@$(GTARGET) $(argv)
clean: 
	@if not exist $(GBIN) @mkdir $(GBIN)
	@del /q $(GBIN)\*.exe
    
