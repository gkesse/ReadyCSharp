@echo off
::===============================================
set "PATH=C:\MinGW\bin;%PATH%" 
set "PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319;%PATH%"
set "PATH=C:\Users\Admin\Downloads;%PATH%"
set "PATH=C:\Emgu\emgucv-windesktop 3.2.0.2682\bin\x64;%PATH%"
set "PATH=C:\Qt\5.15.0\mingw81_64\bin;%PATH%"
set "PATH=C:\Users\Admin\Downloads\QtSharp-0.7.6-Qt-5.12.4-MinGW;%PATH%"
::===============================================
set "GPROJECT_ROOT=C:\Users\Admin\Downloads\Programs"
set "GPROJECT_PATH=%GPROJECT_ROOT%\ReadyCSharp"
set "GPROJECT_SRC=%GPROJECT_PATH%\app\code\readyapp\src"
set "GPROJECT_EXE=%GPROJECT_PATH%\app\win\bin\rdcsharp.exe"
set "GPROJECT_DATA=%GPROJECT_PATH%\data"
::===============================================
set "GSTYLE_PATH=%GPROJECT_DATA%\css\style.css"
set "GSQLITE_DB_PATH=%GPROJECT_DATA%\sqlite\config.dat"
set "GFONT_PATH=%GPROJECT_DATA%\font"
set "GIMG_PATH=%GPROJECT_DATA%\img"
set "GPDF_PATH=%GPROJECT_DATA%\pdf\config.pdf"
set "GCMD_PATH=%GPROJECT_DATA%\cmd\script.bat"
::===============================================
set "GNUGET_PACKAGE_NAME=Emgu.CV"
set "GNUGET_PACKAGE_DIR=lib"
::===============================================
set "GDOTNET_PROJECT_PATH=%GPROJECT_PATH%\win"
set "GDOTNET_PROJECT_NAME=ReadyApp"
set "GDOTNET_PACKAGE_NAME=System.Data.SQLite"
::===============================================
set "GGIT_URL=https://github.com/gkesse/ReadyCSharp.git"
set "GGIT_NAME=ReadyCSharp"
::===============================================
