# 2020-Team-Xi

Credits:
This project is based on scripting work done by Brendan Hennelly. https://github.com/bhennelly/AcumaticaSourceControlDemo
We took the base scripts and style and automated it to allow staging and deployments of multiple versions of Acumatica.


Notes:
  If compiling by hand the PowerShell scripts involved require you to set your Execution-Policy to Unrestricted.
  Open Powershell as admin and run:
    Set-ExecutionPolicy -ExecutionPolicy unrestricted -Force; Get-ExecutionPolicy

Standalone installer.
  Installer sets the execution policy for you. If you do not wish to have it changed please don't use installer or make note and change it back.
https://github.com/AcumaticaHackathon/2020-Team-Xi/raw/master/AcuDevDeployerSetup.zip
