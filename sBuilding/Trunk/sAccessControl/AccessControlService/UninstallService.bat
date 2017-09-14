@echo off
color 0A
title Uninstall SPARKING Device Service
 
:start
echo Welcome, %USERNAME%
echo What would you like to do?
echo.
echo 1. Remove sParking server from windows services list
echo. 
echo 0. Quit
echo.
 
set /p choice="Enter your choice: "
if "%choice%"=="1" goto install
if "%choice%"=="0" exit
echo Invalid choice: %choice%
echo.
pause
cls
goto start
 
:install
cls
%~dp0InstallUtil.exe /u %~dp0AccessControlService.exe
echo.
pause
exit