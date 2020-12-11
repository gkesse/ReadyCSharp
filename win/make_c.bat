@echo off
::===============================================
set "args=%*"             
setlocal ENABLEDELAYEDEXPANSION
set "_args=%*"             
set "_args=!_args:*%1 =!"  
endlocal && ( set "args=%_args%" )
echo  aa %args%
::===============================================

mingw32-make -f Makefile.csc.mak %1 arg2=%2
::===============================================
