GSRC = ..\code\GProject\src
GBIN = bin
GBUILD = build
GTARGET = $(GBIN)\gp_csharp.exe

GSRCS = \
    $(GSRC)\\*.cs \
    $(GSRC)\manager\\*.cs \
    
all: compile run

compile:
	@if not exist "$(GBIN)" @mkdir $(GBIN)
	csc /out:$(GTARGET) $(GSRCS)
run: 
	@$(GTARGET)
