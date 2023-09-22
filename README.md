# OutwardEnhanced_ExcelImportTool
C# GUI app that facilitates the mod-making process for Outward. It reads through the Excel file that contains modded stats for weapons in the game (an example file is attached to the repository, but of course you can modify it), imports data from it and exports it by creating text files that the game can use. 

v.0.3:
- working version
- importing data from Excel
- exporting to the XML files

v.0.4:
- added import/export of Damage Bonuses and Resistances on Weapons; can be toggled on/off with a checkbox
- added import/export of AttackData; AutoGenerateAttackData can be toggled on/off 
	- on: AutoGenerateAttackData is set to true in XML
	- off: AutoGenerateAttackData is set to false in XML and AttackData is taken from the Excel file (each weapon type has it's own attacks pattern)
- small visual changes

v.0.5:
- changed Project, Solution and some classes names
