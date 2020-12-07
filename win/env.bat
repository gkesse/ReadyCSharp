@echo off
::===============================================
set "PATH=C:\MinGW\bin;%PATH%" 
set "PATH=C:\Windows\Microsoft.NET\Framework\v4.0.30319;%PATH%" 
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
set "GDOTNET_PROJECT_SRC=C:\Users\Admin\Downloads\Programs\ReadyCSharp\win\test\test2"
set "GDOTNET_PROJECT_NAME=MyConsoleApp"
set "GDOTNET_PACKAGE_NAME=System.Data.SQLite.Core"
::===============================================
