# OutwardEnhanced_ExcelImportTool
C# GUI app that facilitates the mod-making process for Outward. It reads through the Excel file that contains modded stats for weapons in the game (an example file is attached to the repository, but of course you can modify it), imports data from it and exports it by creating XML files that the game can use. 


---- WHY TO USE ---- 

If you're planning to modify one or two weapons (or even ten), then probably it's not even worth it to download this program. But if you want to make modifications to a lot of weapons at once, then you probably know that opening each individual XML file (and creating it with SideLoader, first) takes way too much time. This is exactly what I had in mind and why I created this program. You can use the Excel file (already loaded with all - unless I omitted something - the weapons in Outward) to easily modify stats like damage, attack speed, stamina cost, weight, etc. of all the weapons you want (more on using the Excel file later) - it's much easier than editing XML file as you only need to edit cells in Excel. After saving and closing the Excel file, you can use this program to import all the data from the spreadsheets and export it as ready-to-use XML files.


---- HOW TO USE ----
1) download and unpack the file to whatever folder you want
2) download the Excel file with weapons' stats
3) open the app (double-click the Outward_ExcelImportTool.exe file in the unpacked folder)
	- in the first textbox specify the path to the Excel file (you can click the magnifying glass icon next to the textbox to browse for the file)
	- in the second texbox specify the folder that the XML files will be exported to
	- at the very bottom there are checkboxes with the names of weapon types (that correspond to the worksheets in the Excel file) - make sure the ones that you want to be exported are checked (normally you don't need to change anything, unless you only want to export certain weapon types)
	- click 'Import Data' button and wait a little bit (loading bar should appear and it should take a few seconds to import everything)
4) put the exported files in your mod folder (your mod folder should be in SideLoader's plugins folder; of course you need to have SideLoader to use the files, but you probably already know that since you're making a mod :) )


---- HOW TO USE THE EXCEL FILE ----

There are quite a few worksheets in the Excel file. Most of them correspond to weapon types and list all the weapons of that type that appear in the game. In each of those worksheets you can either manually modify weapons' stats or... you can use the first worksheet named 'GeneralValues' for that. 

I wanted to make editing different weapons' stats fast and consistent and that's why this worksheet is there. In it, there are 3 tables: 
- the first and the biggest one is 'BaseDmg' table: in this table I listed base damage and other stats depending on what kind of weapon it is (usually based on the 'material', like steel or obsidian, but there also other types, like 'unique' or 'maelstrom'). This helps with keeping things consistent as no matter if a weapon is a 1h or 2h mace, a sword or whatever, it will use the same base stats. 
- the second table is 'Modifiers': in this table there are modifiers for each waepon type, like 1h sword or halberd, that are applied to this weapon type on top of the stats from the 'BaseDmg' table (so, e.g. if Obsidian 'material' has 10 base damage, and the weapon is a 1h sword, it will multiply the base damage times the modifier for damage for 1h swords from the 'Modifiers' table. If it's an Obsidian 2h mace, it will multiply 10 (base damage for Obsidian) times the damage modifier of 2h maces). And there are base values and modifiers for other stats, like Impact, Attack Speed, etc. as well. 
- finally, there is the third table 'Tab_RoundTo' below 'Modifiers' table: here you can specify how the stats of individual weapons are to be rounded after calculations 

Each weapon in the weapon type worksheets use formulas to calculate their stats based on the 3 tables described above. Of course you can modify each cell in the weapon stats individually (especially if some weapons are more unique and do not really fit into 'material' categories), but it's usually much easier to modify the values in GeneralValues and it keeps the weapons consistent.


---- IMPORTANT ----
- do not ever change the names of worksheets (otherwise the program will not be able to read them)
- if you add or remove any weapon from the table, make sure there are no empty rows in the ID and Name columns - the program reads the data row by row until it finds an empty cell in the Name column (this way, you can make some comments below, after leaving at least one empty row)
- you can sort the tables in Excel, the order does not matter, so you can easily see which weapons have the most damage, or highest attack speed, etc.
- there is a 'Backpacks' worksheet in the file but it is not used as of now
- individual ATTACK DATA: if you want to modify each waepon type's individual attacks data (e.g. you think that the special attack (attack 3) of swords should deal more damage and cost less stamina - you can do that in the 'AttackData' worksheet (it's pretty self-explanatory: use only the first table - the other one lists vanilla values, you can modify Damage, Knockback, Attack Speed and Stamina Cost of each attack of each weapon type).
- DAMAGE and RESISTANCE BONUSES: if you want to change what damage or resistance bonuses a certain weapon gives you, you need to do that in the 'Damage_BonusOrRes' worksheet. In the name column you need to enter the weapon's name (exactly as it appears in its corresponding weapon type worksheet - otherwise it won't work) and then specify the bonuses you want (leave the rest empty). NOTE: I don't think this is particularly convenient to modify these bonuses this way - I might change it in future releases.


---- FUTURE PLANS ---- 
- add support for armour
- change the way damage and resistance bonuses are edited in Excel
- add support for status effects imposed by the weapons
- MAYBE: add support for items such as potions, food, backpacks, etc. 


---- CHANGELOG ---- 
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