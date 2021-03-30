#================================================
GSRC = $(GPROJECT_SRC)
GBIN = bin
GTARGET = $(GBIN)/rdcsharp.exe

GSRCS =\
    $(GSRC)/*.cs \

GLIBS =\
    -lib:bin \
    -r:Emgu.CV.World.dll \
    
GCFLAGS =\

#================================================
all: clean compile run

compile:
	@if ! [ -d $(GBIN) ] ; then mkdir -p $(GBIN) ; fi
	@csc $(GCFLAGS) $(GLIBS) /out:$(GTARGET) $(GSRCS)
run: 
	@$(GTARGET) $(argv)
clean:
	@if ! [ -d $(GBIN) ] ; then mkdir -p $(GBIN) ; fi
	rm -f $(GBIN)/*
#================================================
# mono
mono_install:
	@pacman -S --needed -y mingw-w64-i686-mono
#================================================
# sqlite
sqlite_install:
	@pacman -S --needed -y mingw-w64-i686-sqlite3
sqlite_libs:
	@pkg-config --libs sqlite3
sqlite_flags:
	@pkg-config --cflags sqlite3
sqlite_search:
	pkg-config --list-all | grep -ie "sqlite"
#================================================
# git
git_install:
	@pacman -S --needed -y git
	@pacman -S --needed -y vim
git_config:
	@git config --global user.name "Gerard KESSE"
	@git config --global user.email "tiakagerard@hotmail.com"
	@git config --global core.editor "vim"
	@git config --list
git_store:
	@git config credential.helper store
git_push:
	@cd $(GPROJECT_PATH) && git pull && git add --all && git commit -m "Initial Commit" && git push -u origin master
git_push_o:
	@cd $(GPROJECT_PATH) && git add --all && git commit -m "Initial Commit" && git push -u origin master
git_clone:
	@cd $(GPROJECT_ROOT) && git clone $(GGIT_URL) $(GGIT_NAME) 
#================================================
