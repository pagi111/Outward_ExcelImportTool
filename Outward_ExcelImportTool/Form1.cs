using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Outward_ExcelImportTool
{
    public partial class Form1 : Form
    {
        List<string> listImportFilesHistory_Weapons = new List<string>();
        List<string> listImportFilesHistory_Armor = new List<string>();
        List<string> listExportFoldersHistory = new List<string>();
        public static string excelFile_Weapons;
        public static string excelFile_Armor;
        public static string destinationFolder;
        public static List<string> worksheetsList_Weapons = new List<string>();
        public static List<string> worksheetsList_Armor = new List<string>();
        public static bool exportDmgBonusAndRes = true;
        public static bool autoGenerateAttackData = false;

        public Form1()
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;


            InitializeComponent();
            InitTimer();
            ReadHistoryFile();

            for (int i = 0; i < chlb_worksheetsWeapons.Items.Count; i++)
            {
                chlb_worksheetsWeapons.SetItemChecked(i, true);
            }
            for (int i = 0; i < chlb_worksheetsArmor.Items.Count; i++)
            {
                chlb_worksheetsArmor.SetItemChecked(i, true);
            }
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(excelFile_Weapons) && string.IsNullOrEmpty(excelFile_Armor)) {
                MessageBox.Show("Enter the path for at least one Excel file");
                return;
            }
            if (string.IsNullOrEmpty(cbx_chooseExportFolder.Text)) {
                MessageBox.Show("Enter the path to the export folder");
                return;
            }
            
            worksheetsList_Weapons.Clear();
            worksheetsList_Armor.Clear();
            foreach (var item in chlb_worksheetsWeapons.CheckedItems)
            {
                worksheetsList_Weapons.Add(item.ToString());
            }
            foreach (var item in chlb_worksheetsArmor.CheckedItems)
            {
                worksheetsList_Armor.Add(item.ToString());
            }

            //SO thread on waiting animations: https://stackoverflow.com/questions/36076924/how-can-i-display-a-loading-control-while-a-process-is-waiting-for-be-finished
            // start the waiting animation
            progressBar1.Visible = true;
            progressBar1.Style = ProgressBarStyle.Marquee;
            lbl_pleaseWait.Visible = true;
            
            // simply start and await the loading task
            btn_import.Enabled = false;
            
            if (chbx_ExportDmgBonusAndRes.Checked) { exportDmgBonusAndRes = true; }
            else { exportDmgBonusAndRes = false; }
            if (chbx_autoGenAttackData.Checked) { autoGenerateAttackData = true; }
            else { autoGenerateAttackData = false; }

            if (!string.IsNullOrEmpty(excelFile_Weapons))
            {
                if (ExcelImport.weaponsAddedToDictionary == true)
                {
                    if (MessageBox.Show("Weapons have already been imported from Excel file. Do you want to do it again? \n" +
                        "Yes: data will be imported again and exported to folder. \n" +
                        "No: data will NOT be imported again, but data from the last successful import will still be exported to folder",
                        "Weapons Already Imported", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        await Task.Run(() => ExcelImport.LoadExcelDataClosedXML(ExcelImport.EquipmentType.Weapons, excelFile_Weapons));
                    }
                }
                else
                {
                    await Task.Run(() => ExcelImport.LoadExcelDataClosedXML(ExcelImport.EquipmentType.Weapons, excelFile_Weapons));
                }
            }

            if (!string.IsNullOrEmpty(excelFile_Armor))
            {
                if (ExcelImport.armorAddedToDictionary == true)
                {
                    if (MessageBox.Show("Armour have already been imported from Excel file. Do you want to do it again? \n" +
                        "Yes: data will be imported again and exported to folder. \n" +
                        "No: data will NOT be imported again, but data from the last successful import will still be exported to folder",
                        "Armour Already Imported", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        await Task.Run(() => ExcelImport.LoadExcelDataClosedXML(ExcelImport.EquipmentType.Armour, excelFile_Armor));
                    }
                }
                else
                {
                    await Task.Run(() => ExcelImport.LoadExcelDataClosedXML(ExcelImport.EquipmentType.Armour, excelFile_Armor));
                }
            }

            await Task.Run(() => ExcelImport.WriteToXML());
            
            // re-enable things
            btn_import.Enabled = true;
            progressBar1.Visible = false;
            lbl_pleaseWait.Visible = false;
        }
        
        
        private void btn_ChooseFileWeapons_Click(object sender, EventArgs e) 
        {
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.Filter = "Excel files | *.xlsx; *.xlsm; *.xltx; *.xltm";

            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                cbx_chooseFileWeapons.Text = chooseFile.FileName;
                ChooseFileWeapons_AddToHistory();
                excelFile_Weapons = cbx_chooseFileWeapons.Text;
            }
        }

        private void btn_ChooseFileArmor_Click(object sender, EventArgs e)
        {
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.Filter = "Excel files | *.xlsx; *.xlsm; *.xltx; *.xltm";

            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                cbx_chooseFileArmor.Text = chooseFile.FileName;
                ChooseFileArmor_AddToHistory();
                excelFile_Armor = cbx_chooseFileArmor.Text;
            }
        }

        private void ChooseFileWeapons_AddToHistory()
        {
            bool fileNameAlreadyExists = false;
            foreach (var item in cbx_chooseFileWeapons.Items) {
                if (item.ToString() == cbx_chooseFileWeapons.Text) { fileNameAlreadyExists = true; }
            }
            if (!fileNameAlreadyExists) {  cbx_chooseFileWeapons.Items.Add(cbx_chooseFileWeapons.Text);  }
        }

        private void ChooseFileArmor_AddToHistory()
        {
            bool fileNameAlreadyExists = false;
            foreach (var item in cbx_chooseFileArmor.Items)
            {
                if (item.ToString() == cbx_chooseFileArmor.Text) { fileNameAlreadyExists = true; }
            }
            if (!fileNameAlreadyExists) { cbx_chooseFileArmor.Items.Add(cbx_chooseFileArmor.Text); }
        }

        private void ChooseFolder_AddToHistory()
        {
            bool folderNameAlreadyExists = false;
            foreach (var item in cbx_chooseExportFolder.Items) {
                if (item.ToString() == cbx_chooseExportFolder.Text) { folderNameAlreadyExists = true; }
            }
            if (!folderNameAlreadyExists) { cbx_chooseExportFolder.Items.Add(cbx_chooseExportFolder.Text); }
        }


        private void btn_chooseExportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog chooseFolder = new FolderBrowserDialog();
            if (chooseFolder.ShowDialog() == DialogResult.OK) {
                cbx_chooseExportFolder.Text = chooseFolder.SelectedPath; // + @"\Weapons\";
                ChooseFolder_AddToHistory();
                //destinationFolder = cbx_chooseExportFolder.Text;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        


        private void txt_onCbxChooseFileWeapons_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseFileWeapons.Visible = false;
            cbx_chooseFileWeapons.Focus();
            cbx_chooseFileWeapons.DroppedDown = true;
        }

        private void cbx_chooseFileWeapons_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseFileWeapons.Visible = false;
            cbx_chooseFileWeapons.DroppedDown = true;
        }

        private void txt_onCbxChooseFileArmor_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseFileArmor.Visible = false;
            cbx_chooseFileArmor.Focus();
            cbx_chooseFileArmor.DroppedDown = true;
        }

        private void cbx_chooseFileArmor_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseFileArmor.Visible = false;
            cbx_chooseFileArmor.DroppedDown = true;
        }

        private void txt_onCbxChooseExportFolder_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseExportFolder.Visible = false;
            cbx_chooseExportFolder.Focus();
            cbx_chooseExportFolder.DroppedDown = true;
        }

        private void cbx_chooseExportFolder_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseExportFolder.Visible = false;
            cbx_chooseExportFolder.DroppedDown = true;
        }

        

        private void cbx_chooseFileWeapons_TextChanged(object sender, EventArgs e)
        {
            excelFile_Weapons = cbx_chooseFileWeapons.Text;
        }

        private void cbx_chooseFileArmor_TextChanged(object sender, EventArgs e)
        {
            excelFile_Armor = cbx_chooseFileArmor.Text;
        }

        private void cbx_chooseExportFolder_TextChanged(object sender, EventArgs e)
        {
            destinationFolder = cbx_chooseExportFolder.Text + @"\";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChooseFileWeapons_AddToHistory();
            ChooseFileArmor_AddToHistory();
            ChooseFolder_AddToHistory();
            WriteHistoryFile();
        }

        
        private void WriteHistoryFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            const int maxHistoryItems = 5;
            
            foreach (var item in cbx_chooseFileWeapons.Items) {
                if (!string.IsNullOrEmpty(item.ToString())) {
                    listImportFilesHistory_Weapons.Insert(0, item.ToString());
                }
            }

            foreach (var item in cbx_chooseFileArmor.Items) {
                if (!string.IsNullOrEmpty(item.ToString())) {
                    listImportFilesHistory_Armor.Insert(0, item.ToString());
                }
            }

            foreach (var item in cbx_chooseExportFolder.Items) {
                if (!string.IsNullOrEmpty(item.ToString())) {
                    listExportFoldersHistory.Insert(0, item.ToString());
                }
            }

            if (listImportFilesHistory_Weapons.Count > maxHistoryItems) {
                listImportFilesHistory_Weapons.RemoveRange(maxHistoryItems, listImportFilesHistory_Weapons.Count - maxHistoryItems);
            }

            if (listImportFilesHistory_Armor.Count > maxHistoryItems)
            {
                listImportFilesHistory_Armor.RemoveRange(maxHistoryItems, listImportFilesHistory_Armor.Count - maxHistoryItems);
            }

            if (listExportFoldersHistory.Count > maxHistoryItems) {
                listExportFoldersHistory.RemoveRange(maxHistoryItems, listExportFoldersHistory.Count - maxHistoryItems);
            }

            StreamWriter writer = new StreamWriter(baseDir + @"\history.txt");
            writer.WriteLine("Import Weapons Files History:");
            foreach (var line in listImportFilesHistory_Weapons) {
                writer.WriteLine(line);
            }
            writer.WriteLine();
            writer.WriteLine("Import Armor Files History:");
            foreach (var line in listImportFilesHistory_Armor)
            {
                writer.WriteLine(line);
            }
            writer.WriteLine();
            writer.WriteLine("Export Folders History:");
            foreach (var line in listExportFoldersHistory) {
                writer.WriteLine(line);
            }

            writer.Close();
        }
        private void ReadHistoryFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string currentLine;
            if (File.Exists(baseDir + @"\history.txt"))
            {
                using (StreamReader reader = new StreamReader(baseDir + @"\history.txt")) {
                    int historyPart = 0;
                    for (int i = 0; i < 100; i++) {
                        currentLine = reader.ReadLine();
                        if (!string.IsNullOrEmpty(currentLine)) {
                            if (currentLine == "Import Weapons Files History:") { historyPart = 1;  continue; }
                            if (currentLine == "Import Armor Files History:") { historyPart = 2; continue; }
                            if (currentLine == "Export Folders History:") { historyPart = 3; continue; }

                            if (historyPart == 1) { cbx_chooseFileWeapons.Items.Add(currentLine); }
                            if (historyPart == 2) { cbx_chooseFileArmor.Items.Add(currentLine); }
                            if (historyPart == 3) { cbx_chooseExportFolder.Items.Add(currentLine); }
                        }
                        else {
                            if (historyPart == 3) { break; }
                            else { continue; }
                        }
                    }
                    reader.Close();
                }
            }
        }
        public void InitTimer()
        {
            Timer timer = new Timer();
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Interval = 100; // in miliseconds
            timer.Start();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cbx_chooseFileWeapons.Focused == false)
            {
                if (string.IsNullOrEmpty(cbx_chooseFileWeapons.Text)) { txt_onCbxChooseFileWeapons.Visible = true; }
                else { txt_onCbxChooseFileWeapons.Visible = false; }
            }

            if (cbx_chooseFileArmor.Focused == false)
            {
                if (string.IsNullOrEmpty(cbx_chooseFileArmor.Text)) { txt_onCbxChooseFileArmor.Visible = true; }
                else { txt_onCbxChooseFileArmor.Visible = false; }
            }

            if (cbx_chooseExportFolder.Focused == false)
            {
                if (string.IsNullOrEmpty(cbx_chooseExportFolder.Text)) { txt_onCbxChooseExportFolder.Visible = true; }
                else { txt_onCbxChooseExportFolder.Visible = false; }
            }
        }

    }
}
