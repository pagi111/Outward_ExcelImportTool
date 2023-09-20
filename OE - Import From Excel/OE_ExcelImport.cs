using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Net.Http.Headers;

namespace OE_ExcelImport
{
    static class OE_ExcelImport
    {

        #region SideLoader Classes
        public class SL_Item
        {
            public SL_ItemStats StatsHolder;
            public List<OE_Effect> Effects;
            public int New_ItemID;
            public int Target_ItemID;
            public string Name;
        }
        public class SL_Weapon : SL_Item
        {
            public string WeaponType;
            
            public SL_Weapon() { }
            //SL_Weapon constructor for ClosedXML
            public SL_Weapon(IXLWorkbook wb, IXLWorksheet ws, IXLCell cell)
            {
                StatsHolder = new SL_WeaponStats
                {
                    Damage_Bonus = new float[9],
                    Damage_Resistance = new float[9],
                };
                var SH = ((SL_WeaponStats)StatsHolder);
                SH.BaseDamage = new List<SL_Damage>();
                Effects = new List<OE_Effect>();

                for (int i = 1; i <= ws.ColumnsUsed().Count(); i++)
                {
                    var heading = ws.Cell(1, i);
                    string headingName = heading.CachedValue.ToString();

                    var workingCell = ws.Cell(cell.Address.RowNumber, heading.Address.ColumnNumber);
                    var workingCell_nextCell = ws.Cell(cell.Address.RowNumber, heading.Address.ColumnNumber + 1);

                    if (string.IsNullOrEmpty(headingName)) { break; }
                    else if (string.IsNullOrEmpty(workingCell.CachedValue.ToString())) { continue; }
                    else
                    {
                        if (headingName == "Name") { Name = (string)workingCell.CachedValue; }
                        if (headingName == "ID") { Target_ItemID = New_ItemID = (int)Convert.ToSingle(workingCell.CachedValue); }

                        if (headingName == "DMG Physical") { SH.BaseDamage.Add(new SL_Damage { Damage = Convert.ToSingle(workingCell.CachedValue), Type = "Physical" }); }
                        if (headingName == "DMG 2") { SH.BaseDamage.Add(new SL_Damage { Damage = Convert.ToSingle(workingCell.CachedValue), Type = (string)workingCell_nextCell.CachedValue }); }
                        if (headingName == "DMG 3") { SH.BaseDamage.Add(new SL_Damage { Damage = Convert.ToSingle(workingCell.CachedValue), Type = (string)workingCell_nextCell.CachedValue }); }

                        //OPTION 1 for StatsHolder fields - doesn't work, throws an error ('Object of type 'System.Single' cannot be converted to type 'System.Int32')
                        //System.Reflection.FieldInfo[] fields = typeof(SL_WeaponStats).GetFields();
                        //foreach (var field in fields)
                        //{
                        //    if (headingName == field.Name) { field.SetValue(StatsHolder, Convert.ToSingle(workingCell.CachedValue)); }
                        //}


                        //OPTION 2 for StatsHolder fields
                        if (headingName == "MaxDurability") { SH.MaxDurability = (int)Convert.ToSingle(workingCell.CachedValue); }
                        if (headingName == "RawWeight") { SH.RawWeight = Convert.ToSingle(workingCell.CachedValue); }
                        if (headingName == "BaseValue") { SH.BaseValue = (int)Convert.ToSingle(workingCell.CachedValue); }

                        if (headingName == "StamCost") { SH.StamCost = Convert.ToSingle(workingCell.CachedValue); }
                        if (headingName == "AttackSpeed") { SH.AttackSpeed = Convert.ToSingle(workingCell.CachedValue); }
                        if (headingName == "Impact") { SH.Impact = Convert.ToSingle(workingCell.CachedValue); }

                        //Not working really well yet, but it's more about the Excel file than the code
                        //if (headingName == "Effect 1" || headingName == "Effect 2" || headingName == "Effect 3")
                        //{
                        //    if (!string.IsNullOrEmpty(workingCell_nextCell.CachedValue.ToString()))
                        //    { Effects.Add(new OE_Effect { StatusEffect = workingCell.CachedValue.ToString(), Buildup = (int)Convert.ToSingle(workingCell_nextCell.CachedValue) }); }
                        //}
                    }
                }

                if (wb.TryGetWorksheet("AttackData", out IXLWorksheet ws_AttackData))
                {
                    //((SL_WeaponStats)StatsHolder).Attacks = new SL_WeaponStats.AttackData[5];
                    var attacks = ((SL_WeaponStats)StatsHolder).Attacks = new SL_WeaponStats.AttackData[5];
                    for (int i = 0; i < attacks.Length; i++)
                    {
                        attacks[i] = new SL_WeaponStats.AttackData();
                    }

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
        public class SL_ItemStats
        {
            public int BaseValue;
            public float RawWeight; //Should be float but it doesn't read correctly from excel that way so I made it string
            public int MaxDurability;
        }
        public class SL_EquipmentStats : SL_ItemStats
        {
            public float Impact_Resistance;
            public float[] Damage_Bonus;
            public float[] Damage_Resistance;
        }

        public class SL_WeaponStats : SL_EquipmentStats
        {
            public List<SL_Damage> BaseDamage;
            public float StamCost;
            public float Impact;
            public float AttackSpeed; //Should be float but it doesn't read correctly from excel that way so I made it string
            public AttackData[] Attacks;
            public class AttackData
            {
                public float StamCost;
                public float Knockback;
                public float AttackSpeed;
                public List<float> Damage = new List<float>();
            }
        }
        #endregion

        static Dictionary<string, SL_Weapon> dict_Weapons = new Dictionary<string, SL_Weapon>();
        public static bool weaponsAddedToDictionary = false;

        #region Importing Excel: ClosedXML
        //This is the best solution. By far the fastest and reasonable to use (IronXL may be a little more convenient to use, but it's paid and slower).
        static public void LoadExcelDataClosedXML()
        {
            //Normally floats are imported as numbers with a comma, e.g. 12,5 rather than 12.5
            //Everywhere else in the code, the correct format is 12.5
            //When I printed the weapons' data into a file, the format was with a comma and this caused errors
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;

            XLWorkbook wb;
            try {
                wb = new XLWorkbook(Form1.chosenFile);
            }
            catch (IOException) {
                MessageBox.Show("The program could not open the specified Excel file. " +
                    "Maybe it doesn't exist anymore or is in use (you need to close the file if it's open)?", "Cannot open Excel file!");
                return;
            }

            foreach (var worksheetName in Form1.worksheetsList)
            {
                if (!wb.TryGetWorksheet(worksheetName, out IXLWorksheet ws)) { continue; }

                for (int x = 2; x < ws.RowsUsed().Count(); x++)
                {
                    var cell = ws.Cell(x, 2);
                    string cell_name = cell.Value.ToString();

                    if (string.IsNullOrEmpty(cell_name)) { break; }
                    dict_Weapons[cell_name] = new SL_Weapon(wb, ws, cell);
                    dict_Weapons[cell_name].WeaponType = ws.Name;
                }
            }

            if (wb.TryGetWorksheet("Damage_BonusOrRes", out IXLWorksheet ws_DmgOrRes))
            {
                AddDamageOrResistanceToWeapons(ws_DmgOrRes);
            }


            weaponsAddedToDictionary = true;
        }
        #endregion


        static public void WriteToXML()
        {
            Dictionary<string, SL_Weapon>.ValueCollection melee_weapons = dict_Weapons.Values;
            foreach (SL_Weapon weapon in melee_weapons)
            {
                string itemClass;
                if (weapon.WeaponType == "Bows" || weapon.WeaponType == "Pistols")
                { itemClass = "SL_ProjectileWeapon"; }
                else if (weapon.WeaponType == "Gauntlets")
                { itemClass = "SL_DualMeleeWeapon"; }
                else { itemClass = "SL_MeleeWeapon"; }

                var mySH = ((SL_WeaponStats)weapon.StatsHolder);
                //string baseDir = AppDomain.CurrentDomain.BaseDirectory; //The application's base directory - points to ...\bin\Debug\netcoreapp3.1\
                //string dir = @"C:\Users\Marcin\Desktop\Outward - Mody Moje\Outward Enhanced - Import From Excel - WindowApp\Weapons\";
                string dir = Form1.destinationFolder;
                System.IO.Directory.CreateDirectory(dir); //Create the dir if doesn't exist
                string path = (weapon.WeaponType + "_" + weapon.Name + ".xml").Replace(":", "-"); //Path to individual files

                using (StreamWriter writer = new StreamWriter(dir + path))
                {
                    writer.WriteLine("<?xml version=\"1.0\"?>");
                    writer.WriteLine("<" + itemClass + " xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
                    writer.WriteLine("  <Target_ItemID>" + weapon.Target_ItemID + "</Target_ItemID>");
                    writer.WriteLine("  <New_ItemID>-1</New_ItemID>");
                    writer.WriteLine("  <Name>" + weapon.Name + "</Name>");

                    writer.WriteLine("  <StatsHolder xsi:type=\"SL_WeaponStats\">");
                    writer.WriteLine("      <BaseValue>" + mySH.BaseValue + "</BaseValue>");
                    writer.WriteLine("      <RawWeight>" + mySH.RawWeight + "</RawWeight>");
                    writer.WriteLine("      <MaxDurability>" + mySH.MaxDurability + "</MaxDurability>");
                    writer.WriteLine("      <Impact>" + mySH.Impact + "</Impact>");
                    writer.WriteLine("      <StamCost>" + mySH.StamCost + "</StamCost>");

                    if (weapon.WeaponType == "Shields")
                    {
                        writer.WriteLine("      <Impact_Resistance>" + mySH.AttackSpeed + "</Impact_Resistance>"); //Shields always have AttackSpeed = 0; this column is used for ImpactResistance instead
                    }
                    else
                    {
                        writer.WriteLine("      <AttackSpeed>" + mySH.AttackSpeed + "</AttackSpeed>");
                    }

                    writer.WriteLine("      <BaseDamage>");
                    foreach (SL_Damage dmg in mySH.BaseDamage)
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
                    if (Form1.autoGenerateAttackData) {
                        writer.WriteLine("      <AutoGenerateAttackData>" + "true" + "</AutoGenerateAttackData>");
                    }
                    else {
                        writer.WriteLine("      <AutoGenerateAttackData>" + "false" + "</AutoGenerateAttackData>");
                        writer.WriteLine("      <Attacks>");
                        foreach (var attackData in mySH.Attacks)
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

                    //This data is only exported if the exportDmgBonusAndRes checkbox is checked
                    if (Form1.exportDmgBonusAndRes)
                    {
                        //Damage Bonus
                        writer.WriteLine("      <Damage_Bonus>");
                        foreach (float bonus in mySH.Damage_Bonus)
                        {
                            writer.WriteLine("          <float>" + bonus + "</float>");
                        }
                        writer.WriteLine("      </Damage_Bonus>");

                        //Damage Res
                        writer.WriteLine("      <Damage_Resistance>");
                        foreach (float res in mySH.Damage_Resistance)
                        {
                            writer.WriteLine("          <float>" + res + "</float>");
                        }
                        writer.WriteLine("      </Damage_Resistance>");
                    }

                    

                    writer.WriteLine("  </StatsHolder>");

                    //Effects

                    // => is called lambda expression. I don't fully understand it yet, but here it seems to mean sth like this:
                    // if (weapon.Effects contains Any OE_Effect 'a' such that a.StatusEffect is not empty or null) { ...do sth... }
                    if (weapon.Effects.Any(a => !string.IsNullOrEmpty(a.StatusEffect)))
                    {
                        writer.WriteLine("  <EffectTransforms>");
                        writer.WriteLine("      <SL_EffectTransform>");
                        writer.WriteLine("          <TransformName>HitEffects</TransformName> ");
                        writer.WriteLine("          <Position xsi:nil=\"true\" /> ");
                        writer.WriteLine("          <Rotation xsi:nil=\"true\" /> ");
                        writer.WriteLine("          <Scale xsi:nil=\"true\" /> ");
                        writer.WriteLine("          <Effects>");
                        foreach (var effect in weapon.Effects)
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

                if (dict_Weapons.TryGetValue(itemName, out SL_Weapon weapon) == false) { continue; }

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
