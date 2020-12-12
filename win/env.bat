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
set "GPROJECT_SRC=%GPROJECT_PATH%\code\GProject\src"
::===============================================
set "GBIN_PATH=%GPROJECT_PATH%\win\bin\gp_csharp.exe"
set "GDATA_PATH=%GPROJECT_PATH%\win\data"
set "GSTYLE_PATH=%GDATA_PATH%\css\style.css"
set "GSQLITE_DB_PATH=%GDATA_PATH%\sqlite\config.dat"
set "GFONT_PATH=%GDATA_PATH%\font"
set "GIMG_PATH=%GDATA_PATH%\img"
set "GPDF_PATH=%GDATA_PATH%\pdf\config.pdf"
set "GCMD_PATH=%GDATA_PATH%\cmd\script.bat"
::===============================================
set "GNUGET_PACKAGE_NAME=Emgu.CV"
set "GNUGET_PACKAGE_DIR=lib"
::===============================================
set "GDOTNET_PROJECT_PATH=%GPROJECT_PATH%\win"
set "GDOTNET_PROJECT_NAME=ReadyApp"
set "GDOTNET_PACKAGE_NAME=System.Data.SQLite"
::===============================================
