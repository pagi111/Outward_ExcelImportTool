using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Outward_ExcelImportTool
{
    static class ExcelImport
    {

        #region SideLoader Classes
        public class SL_Item
        {
            public SL_ItemStats StatsHolder;
            public List<OE_Effect> Effects = new List<OE_Effect>();
            public int New_ItemID;
            public int Target_ItemID;
            public string Name;
            public string ItemType;
        }
        public class SL_Weapon : SL_Item
        {
            public SL_Weapon() { }

            //SL_Weapon constructor for ClosedXML
            public SL_Weapon(IXLWorkbook wb, IXLWorksheet ws, IXLCell cell)
            {
                var SH = (SL_WeaponStats)(StatsHolder = new SL_WeaponStats());
                ItemType = ws.Name;

                for (int i = 1; i <= ws.ColumnsUsed().Count(); i++)
                {
                    var colHeaderCell = ws.Cell(1, i);
                    string colHeaderName = colHeaderCell.CachedValue.ToString();

                    var workingCell = ws.Cell(cell.Address.RowNumber, colHeaderCell.Address.ColumnNumber);
                    var workingCell_nextCell = ws.Cell(cell.Address.RowNumber, colHeaderCell.Address.ColumnNumber + 1);

                    if (string.IsNullOrEmpty(colHeaderName)) { break; }
                    if (string.IsNullOrEmpty(workingCell.CachedValue.ToString())) { continue; }

                    if (colHeaderName == "Name") { Name = (string)workingCell.CachedValue; }
                    else if (colHeaderName == "ID") { Target_ItemID = New_ItemID = (int)Convert.ToSingle(workingCell.CachedValue); }

                    else if (colHeaderName == "DMG Physical") { SH.BaseDamage.Add(new SL_Damage { Damage = Convert.ToSingle(workingCell.CachedValue), Type = "Physical" }); }
                    else if (colHeaderName == "DMG 2") { SH.BaseDamage.Add(new SL_Damage { Damage = Convert.ToSingle(workingCell.CachedValue), Type = (string)workingCell_nextCell.CachedValue }); }
                    else if (colHeaderName == "DMG 3") { SH.BaseDamage.Add(new SL_Damage { Damage = Convert.ToSingle(workingCell.CachedValue), Type = (string)workingCell_nextCell.CachedValue }); }

                    //OPTION 1
                    else
                    {
                        foreach (var field in typeof(SL_WeaponStats).GetFields())
                        {
                            if (colHeaderName == field.Name) { field.SetValue(StatsHolder, Convert.ToSingle(workingCell.CachedValue)); break; }
                        }
                    }

                    //OPTION 2 for StatsHolder fields
                    //else if (headingName == "MaxDurability") { SH.MaxDurability = Convert.ToSingle(workingCell.CachedValue); }
                    //else if (headingName == "RawWeight") { SH.RawWeight = Convert.ToSingle(workingCell.CachedValue); }
                    //else if (headingName == "BaseValue") { SH.BaseValue = Convert.ToSingle(workingCell.CachedValue); }

                    //else if (headingName == "StamCost") { SH.StamCost = Convert.ToSingle(workingCell.CachedValue); }
                    //else if (headingName == "AttackSpeed") { SH.AttackSpeed = Convert.ToSingle(workingCell.CachedValue); }
                    //else if (headingName == "Impact") { SH.Impact = Convert.ToSingle(workingCell.CachedValue); }

                    //Not working really well yet, but it's more about the Excel file than the code
                    //if (headingName == "Effect 1" || headingName == "Effect 2" || headingName == "Effect 3")
                    //{
                    //    if (!string.IsNullOrEmpty(workingCell_nextCell.CachedValue.ToString()))
                    //    { Effects.Add(new OE_Effect { StatusEffect = workingCell.CachedValue.ToString(), Buildup = (int)Convert.ToSingle(workingCell_nextCell.CachedValue) }); }
                    //}
                }

                SH.MaxDurability = (float)Math.Round(SH.MaxDurability, 0, MidpointRounding.AwayFromZero);   //To make sure it's a whole number
                SH.BaseValue = (float)Math.Round(SH.BaseValue, 0, MidpointRounding.AwayFromZero);           //To make sure it's a whole number

                if (wb.TryGetWorksheet("AttackData", out IXLWorksheet ws_AttackData))
                {
                    var attacks = ((SL_WeaponStats)StatsHolder).Attacks;
                    for (int i = 1; i <= ws_AttackData.RowsUsed().Count(); i++)
                    {
                        string weaponType = ws_AttackData.Cell(i, 1).CachedValue.ToString();
                        
                        if (weaponType == ws.Name)  //weaponType in ws_AttackData worksheet must be the same as the worksheet of the currently created SL_Weapon
                        {
                            for (int j = 0; j < 5; j++)    //for each attackData (there are 5, so 1-6) - each attack in different column
                            {
                                for (int k = 0; k < 4; k++) //4 AttackData fields (Damage, Knockback, AttackSpeed, StamCost) - each in different row
                                {
                                    //add k to the weaponType row (i), add j to the column number, starting with 2
                                    float cellValue = Convert.ToSingle(ws_AttackData.Cell(i + k, 2 + j).CachedValue); 

                                    if (k == 0) {   //Damage
                                        foreach (SL_Damage dmg in SH.BaseDamage)
                                        {
                                            attacks[j].Damage.Add(dmg.Damage * cellValue);
                                        }
                                    }
                                    else if (k == 1){  //Knockback
                                        attacks[j].Knockback = SH.Impact * cellValue;
                                    }
                                    else if (k == 2) {  //AttackSpeed
                                        attacks[j].AttackSpeed = SH.AttackSpeed * cellValue;
                                    }
                                    else if (k == 3) {  //StamCost
                                        attacks[j].StamCost = SH.StamCost * cellValue;
                                    }
                                }
                            }
                            break;
                        }
                    }
                }

                //OPTION 2 - or go through this worksheet LoadExcelDataClosedXML method
                //IXLWorksheet ws_DmgOrRes;
                //if (wb.TryGetWorksheet("Damage_BonusOrRes", out ws_DmgOrRes))
                ////IXLWorksheet ws_DmgOrRes = wb.Worksheet("Damage_BonusOrRes");     //or this but first check if it exists
                //{
                //    var item_dmgBonus = ((SL_EquipmentStats)StatsHolder).Damage_Bonus;
                //    var item_dmgResistance = ((SL_EquipmentStats)StatsHolder).Damage_Resistance;

                //    for (int i = 1; i <= ws_DmgOrRes.RowsUsed().Count(); i++)
                //    {
                //        string itemName = ws_DmgOrRes.Cell(i, 1).CachedValue.ToString();
                //        if (string.IsNullOrEmpty(itemName)) { break; }
                //        else if (itemName == cell.CachedValue.ToString())
                //        {
                //            for (int j = 0; j < 6; j++)
                //            {
                //                if (!ws_DmgOrRes.Cell(i, j + 2).IsEmpty()) //y = array index; y+2 = column B in Excel
                //                {
                //                    item_dmgBonus[j] = Convert.ToSingle(ws_DmgOrRes.Cell(i, j + 2).CachedValue);
                //                }
                //                if (!ws_DmgOrRes.Cell(i, j + 8).IsEmpty()) //y+8 = column H where resistances begin
                //                {
                //                    item_dmgResistance[j] = Convert.ToSingle(ws_DmgOrRes.Cell(i, j + 8).CachedValue);
                //                    //The above line can also be: item_dmgResistance[j] = ws_DmgOrRes.Cell(i, j + 8).GetValue<float>();
                //                    //'Okreslone rzutowanie jest nieprawidowe' gdy powyższa linia to (WTF???): item_dmgResistance[j] = (float)ws_DmgOrRes.Cell(i, j + 8).CachedValue;
                //                }

                //            }
                //        }
                //    }
                //}

            }
        }

        public class SL_Armor : SL_Item
        {
            public SL_Armor(IXLWorkbook wb, IXLWorksheet ws, IXLCell cell)
            {
                var SH = (SL_EquipmentStats)(StatsHolder = new SL_EquipmentStats());
                ItemType = ws.Name;

                for (int i = 1; i <= ws.ColumnsUsed().Count(); i++)
                {
                    var colHeaderCell = ws.Cell(1, i);
                    string colHeaderName = colHeaderCell.CachedValue.ToString();

                    var workingCell = ws.Cell(cell.Address.RowNumber, i);
                    var workingCell_nextCell = ws.Cell(cell.Address.RowNumber, i + 1);

                    if (string.IsNullOrEmpty(colHeaderName)) { break; }
                    if (string.IsNullOrEmpty(workingCell.CachedValue.ToString()) && colHeaderName != "Physical Resistance") { continue; }

                    if (colHeaderName == "ID") { Target_ItemID = New_ItemID = (int)Convert.ToSingle(workingCell.CachedValue); }
                    else if (colHeaderName == "Name") { Name = (string)workingCell.CachedValue; }

                    else if (colHeaderName == "Physical Resistance") 
                    { 
                        for (int j = 0; j < 6; j++)
                        {
                            SH.Damage_Resistance[j] = Convert.ToSingle(ws.Cell(cell.Address.RowNumber, i + j).CachedValue);
                        }
                    }
                    else if (colHeaderName == "Ethereal Resistance" || colHeaderName == "Decay Resistance" || colHeaderName == "Lightning Resistance"
                         || colHeaderName == "Frost Resistance" || colHeaderName == "Fire Resistance" || colHeaderName == "Raw Resistance")
                    {
                        continue;
                    }

                    else
                    {
                        foreach (var field in typeof(SL_EquipmentStats).GetFields())
                        {
                            if (colHeaderName == field.Name) { field.SetValue(StatsHolder, Convert.ToSingle(workingCell.CachedValue)); break; }
                        }
                    }
                }

                SH.MaxDurability = (float)Math.Round(SH.MaxDurability, 0, MidpointRounding.AwayFromZero);   //To make sure it's a whole number
                SH.BaseValue = (float)Math.Round(SH.BaseValue, 0, MidpointRounding.AwayFromZero);           //To make sure it's a whole number


            }
        }


        public class OE_Effect
        {
            public string StatusEffect;
            public int Buildup;
        }
        public class SL_Damage
        {
            public float Damage;
            public string Type;
        }
        public class AttackData
        {
            public float StamCost;
            public float Knockback;
            public float AttackSpeed;
            public List<float> Damage = new List<float>();
        }
        public class SL_ItemStats
        {
            public float BaseValue;     //This should be int, but as float I can make a simpler function to import data; then I round it to whole numbers anyway
            public float RawWeight; 
            public float MaxDurability; //This should be int, but as float I can make a simpler function to import data; then I round it to whole numbers anyway
        }
        public class SL_EquipmentStats : SL_ItemStats
        {
            public float Impact_Resistance;
            public float Damage_Protection;
            public float BarrierProtection;
            public float Stamina_Use_Penalty;
            public float Movement_Penalty;
            public float Mana_Use_Modifier;
            public float Corruption_Protection;
            public float Cooldown_Reduction;
            public float Pouch_Bonus;
            public float Heat_Protection;
            public float Cold_Protection;
            public float GlobalStatusEffectResistance;
            public float Health_Regen;
            public float StaminaRegenModifier;
            public float Mana_Regen;
            //Damage Types (used in Damage_Bonus and Damage_Resistance)
            //0 = Physical
            //1 = Ethereal
            //2 = Decay
            //3 = Electric
            //4 = Frost
            //5 = Fire
            //6 = DarkOLD (unused)
            //7 = LightOLD (unused)
            //8 = Raw
            public float[] Damage_Bonus = new float[9];
            public float[] Damage_Resistance = new float[9];
        }

        public class SL_WeaponStats : SL_EquipmentStats
        {
            public List<SL_Damage> BaseDamage = new List<SL_Damage>();
            public float StamCost;
            public float Impact;
            public float AttackSpeed; //Should be float but it doesn't read correctly from excel that way so I made it string
            public AttackData[] Attacks = new AttackData[5] { new AttackData(), new AttackData(), new AttackData(), new AttackData(), new AttackData() };
            
        }
        #endregion

        static Dictionary<string, SL_Weapon> dict_Weapons = new Dictionary<string, SL_Weapon>();
        static Dictionary<string, SL_Armor> dict_Armor = new Dictionary<string, SL_Armor>();
        static Dictionary<string, SL_Item> dict_Items = new Dictionary<string, SL_Item>();
        public static bool weaponsAddedToDictionary = false;
        public static bool armorAddedToDictionary = false;

        #region Importing Excel: ClosedXML
        public enum EquipmentType
        {
            Weapons,
            Armour
        }
        
        
        //This is the best solution. By far the fastest and reasonable to use (IronXL may be a little more convenient to use, but it's paid and slower).
        static public void LoadExcelDataClosedXML(EquipmentType equipmentType, string filepath)
        {
            //Normally floats are imported as numbers with a comma, e.g. 12,5 rather than 12.5
            //Everywhere else in the code, the correct format is 12.5
            //When I printed the weapons' data into a file, the format was with a comma and this caused errors
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            XLWorkbook wb;
            try {
                wb = new XLWorkbook(filepath);
            }
            catch (IOException) {
                MessageBox.Show("The program could not open the specified Excel file. " +
                    "Maybe it doesn't exist anymore or is in use (you need to close the file if it's open)?", "Cannot open Excel file!");
                return;
            }

            List<string> worksheetsList;
            if (equipmentType == EquipmentType.Weapons) { worksheetsList = Form1.worksheetsList_Weapons; }
            else /* if (equipmentType == EquipmentType.Armour) */ { worksheetsList = Form1.worksheetsList_Armor; }

            foreach (var worksheetName in worksheetsList)
            {
                if (!wb.TryGetWorksheet(worksheetName, out IXLWorksheet ws)) { continue; }

                for (int x = 2; x < ws.RowsUsed().Count(); x++)
                {
                    var cell = ws.Cell(x, 2);
                    string cell_name = cell.Value.ToString();

                    if (string.IsNullOrEmpty(cell_name)) { break; }
                    
                    if (equipmentType == EquipmentType.Weapons)
                    {
                        //dict_Weapons[cell_name] = new SL_Weapon(wb, ws, cell);
                        dict_Items[cell_name] = new SL_Weapon(wb, ws, cell);
                    }
                    else if (equipmentType == EquipmentType.Armour)
                    {
                        dict_Items[cell_name] = new SL_Armor(wb, ws, cell);
                    }
                }
            }

            if (wb.TryGetWorksheet("Damage_BonusOrRes", out IXLWorksheet ws_DmgOrRes))
            {
                if (equipmentType == EquipmentType.Weapons)
                {
                    AddDamageOrResistanceToWeapons(ws_DmgOrRes);
                }
            }

            if (equipmentType == EquipmentType.Weapons)
            {
                weaponsAddedToDictionary = true;
            }
            else if (equipmentType == EquipmentType.Armour)
            {
                armorAddedToDictionary = true;
            }
        }
        #endregion

        
        static public void WriteToXML()
        {
            //Dictionary<string, SL_Weapon>.ValueCollection melee_weapons = dict_Weapons.Values;
            foreach (SL_Item item in dict_Items.Values)
            {
                string itemClass;
                string statsHolderType;
                if (item.ItemType == "Bows" || item.ItemType == "Pistols")
                { itemClass = "SL_ProjectileWeapon"; statsHolderType = "\"SL_WeaponStats\""; }
                else if (item.ItemType == "Gauntlets")
                { itemClass = "SL_DualMeleeWeapon"; statsHolderType = "\"SL_WeaponStats\""; }
                else if (item.ItemType == "Body" || item.ItemType == "Helmets" || item.ItemType == "Boots")
                { itemClass = "SL_Armor"; statsHolderType = "\"SL_EquipmentStats\""; }
                else { itemClass = "SL_MeleeWeapon"; statsHolderType = "\"SL_WeaponStats\""; }

                SL_EquipmentStats mySH = (SL_EquipmentStats)item.StatsHolder;
                //string baseDir = AppDomain.CurrentDomain.BaseDirectory; //The application's base directory - points to ...\bin\Debug\netcoreapp3.1\
                //string dir = @"C:\Users\Marcin\Desktop\Outward - Mody Moje\Outward Enhanced - Import From Excel - WindowApp\Weapons\";
                string dir = Form1.destinationFolder;
                string itemTypeFolder = item.GetType() == typeof(SL_Weapon) ? "Weapons\\" : "Armor\\";
                System.IO.Directory.CreateDirectory(dir + itemTypeFolder); //Create the dir if doesn't exist
                string fileName = (item.ItemType + "_" + item.Name + ".xml").Replace(":", "-"); //Path to individual files
                


                using (StreamWriter writer = new StreamWriter(dir + itemTypeFolder + fileName))
                {
                    writer.WriteLine("<?xml version=\"1.0\"?>");
                    writer.WriteLine("<" + itemClass + " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
                    writer.WriteLine("  <Target_ItemID>" + item.Target_ItemID + "</Target_ItemID>");
                    writer.WriteLine("  <New_ItemID>-1</New_ItemID>");
                    writer.WriteLine("  <Name>" + item.Name + "</Name>");

                    writer.WriteLine("  <StatsHolder xsi:type=" + statsHolderType + ">");

                    foreach (var field in typeof(SL_ItemStats).GetFields())
                    {
                        writer.WriteLine("      <" + field.Name + ">" + field.GetValue(mySH).ToString() + "</" + field.Name + ">");
                    }
                    foreach (var field in typeof(SL_EquipmentStats).GetFields())
                    {
                        //To keep things in the right order (first ItemStats, then EquipmentStats, then WeaponStats)
                        //If I just iterate over field in typeof(SL_WeaponStats) right away, then the order in which the fields appear is
                        //first fields from WeaponStats, then EquipmentStats, then ItemStats - that's not super important but still :) 
                        if (field.DeclaringType == typeof(SL_ItemStats)) { continue; } 
                        if (field.Name == "Damage_Bonus" || field.Name == "Damage_Resistance")  {  continue;  }
                        writer.WriteLine("      <" + field.Name + ">" + field.GetValue(mySH).ToString() + "</" + field.Name + ">");
                    }

                    if (item.GetType() == typeof(SL_Weapon))
                    {
                        writer.WriteLine("      <StamCost>" + ((SL_WeaponStats)mySH).StamCost + "</StamCost>");
                        writer.WriteLine("      <Impact>" + ((SL_WeaponStats)mySH).Impact + "</Impact>");
                        writer.WriteLine("      <AttackSpeed>" + ((SL_WeaponStats)mySH).AttackSpeed + "</AttackSpeed>");

                        writer.WriteLine("      <BaseDamage>");
                        foreach (SL_Damage dmg in ((SL_WeaponStats)mySH).BaseDamage)
                        {
                            if (dmg.Damage > 0)
                            {
                                writer.WriteLine("          <SL_Damage>");
                                writer.WriteLine("              <Damage>" + dmg.Damage + "</Damage>");
                                writer.WriteLine("              <Type>" + dmg.Type + "</Type>");
                                writer.WriteLine("          </SL_Damage>");
                            }
                        }
                        writer.WriteLine("      </BaseDamage>");

                        //Exporting this data depends on whether the autoGenerateAttackData checkbox is checked or not
                        if (Form1.autoGenerateAttackData)
                        {
                            writer.WriteLine("      <AutoGenerateAttackData>" + "true" + "</AutoGenerateAttackData>");
                        }
                        else
                        {
                            writer.WriteLine("      <AutoGenerateAttackData>" + "false" + "</AutoGenerateAttackData>");
                            writer.WriteLine("      <Attacks>");
                            foreach (var attackData in ((SL_WeaponStats)mySH).Attacks)
                            {
                                writer.WriteLine("          <AttackData>");
                                writer.WriteLine("              <StamCost>" + attackData.StamCost + "</StamCost>");
                                writer.WriteLine("              <Knockback>" + attackData.Knockback + "</Knockback>");
                                writer.WriteLine("              <AttackSpeed>" + attackData.AttackSpeed + "</AttackSpeed>");
                                writer.WriteLine("              <Damage>");
                                foreach (float dmg in attackData.Damage)
                                {
                                    writer.WriteLine("                  <float>" + dmg + "</float>");
                                }
                                writer.WriteLine("              </Damage>");
                                writer.WriteLine("          </AttackData>");
                            }
                            writer.WriteLine("      </Attacks>");
                        }
                    }
                    

                    //This data is only exported if the exportDmgBonusAndRes checkbox is checked
                    if (Form1.exportDmgBonusAndRes)
                    {
                        //Damage Res
                        writer.WriteLine("      <Damage_Resistance>");
                        foreach (float res in mySH.Damage_Resistance)
                        {
                            writer.WriteLine("          <float>" + res + "</float>");
                        }
                        writer.WriteLine("      </Damage_Resistance>");
                        
                        //Damage Bonus
                        writer.WriteLine("      <Damage_Bonus>");
                        foreach (float bonus in mySH.Damage_Bonus)
                        {
                            writer.WriteLine("          <float>" + bonus + "</float>");
                        }
                        writer.WriteLine("      </Damage_Bonus>");
                    }

                    writer.WriteLine("  </StatsHolder>");

                    //Effects
                    //Default EffectBehaviour is 'Destroy', but then if I don't add the whole behaviour of how bows shoot arrows, 
                    //you cannot shoot with bows. If I get it right, 'OverrideEffects' means that vanilla effects stay intact, unless
                    //there is the same effect specified, in which case the new effect values are used (but this just my speculation)
                    //'Destroy' means that all effects are destroyed and then the specified ones are applied (if there are none, then the weapon has no effects)
                    //Need some more testing to see how it works. It may be necessary to leave this as 'Destroy' (so no need to insert the line, as this is default)
                    //and then specify all the effects + the bow shooting effect.
                    writer.WriteLine("  <EffectBehaviour>" + "OverrideEffects" + "</EffectBehaviour>");

                    // => is called lambda expression. I don't fully understand it yet, but here it seems to mean sth like this:
                    // if (weapon.Effects contains Any OE_Effect 'a' such that a.StatusEffect is not empty or null) { ...do sth... }
                    if (item.Effects.Any(a => !string.IsNullOrEmpty(a.StatusEffect)))
                    {
                        writer.WriteLine("  <EffectTransforms>");
                        writer.WriteLine("      <SL_EffectTransform>");
                        writer.WriteLine("          <TransformName>HitEffects</TransformName> ");
                        writer.WriteLine("          <Position xsi:nil=\"true\" /> ");
                        writer.WriteLine("          <Rotation xsi:nil=\"true\" /> ");
                        writer.WriteLine("          <Scale xsi:nil=\"true\" /> ");
                        writer.WriteLine("          <Effects>");
                        foreach (var effect in item.Effects)
                        {
                            if (!string.IsNullOrEmpty(effect.StatusEffect))
                            {
                                writer.WriteLine("          <SL_Effect xsi:type=\"SL_AddStatusEffectBuildUp\"> ");
                                writer.WriteLine("              <StatusEffect>" + effect.StatusEffect + "</StatusEffect>");
                                writer.WriteLine("              <Buildup>" + effect.Buildup + "</Buildup>");
                                writer.WriteLine("          </SL_Effect> ");
                            }
                        }
                        writer.WriteLine("          </Effects>");
                        writer.WriteLine("      </SL_EffectTransform>");
                        writer.WriteLine("  </EffectTransforms>");
                    }
                    writer.WriteLine("</" + itemClass + ">");
                }

            }
        }

        static void AddDamageOrResistanceToWeapons(IXLWorksheet ws_DmgOrRes)
        {
            for (int i = 1; i <= ws_DmgOrRes.RowsUsed().Count(); i++)
            {
                string itemName = ws_DmgOrRes.Cell(i, 1).CachedValue.ToString();
                if (string.IsNullOrEmpty(itemName)) { break; }

                if (dict_Items.TryGetValue(itemName, out SL_Item weapon) == false) { continue; }

                var item_dmgBonus = ((SL_EquipmentStats)weapon.StatsHolder).Damage_Bonus;
                var item_dmgResistance = ((SL_EquipmentStats)weapon.StatsHolder).Damage_Resistance;

                for (int j = 0; j < 6; j++)
                {
                    if (!ws_DmgOrRes.Cell(i, j + 2).IsEmpty()) //y = array index; y+2 = column B in Excel
                    {
                        item_dmgBonus[j] = Convert.ToSingle(ws_DmgOrRes.Cell(i, j + 2).CachedValue);
                    }
                    if (!ws_DmgOrRes.Cell(i, j + 8).IsEmpty()) //y+8 = column H where resistances begin
                    {
                        item_dmgResistance[j] = Convert.ToSingle(ws_DmgOrRes.Cell(i, j + 8).CachedValue);
                        //The above line can also be: item_dmgResistance[j] = ws_DmgOrRes.Cell(i, j + 8).GetValue<float>();
                        //'Okreslone rzutowanie jest nieprawidowe' gdy powyższa linia to (WTF???): item_dmgResistance[j] = (float)ws_DmgOrRes.Cell(i, j + 8).CachedValue;
                    }

                }
            }
        }




        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
