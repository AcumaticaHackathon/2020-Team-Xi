# 2020-Team-Xi

Credits:
This project is based on scripting work done by Brendan Hennelly. https://github.com/bhennelly/AcumaticaSourceControlDemo
We took the base scripts and style and automated it to allow staging and deployments of multiple versions of Acumatica.

Quick notes: 

/AcumaticaDownloader/Scripts/ProcessAcumaticaInstaller.ps1 - this script is currently hard coded to "{targetFolder}". 
This should be automatically setup to your install folder location when the file is copied to your install folder. 
If by chance you have issues with installation please confirm that the script in the root of you install folder has this value set correctly.

