using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Outward_ExcelImportTool
{
    public partial class Form1 : Form
    {
        List<string> listImportFilesHistory = new List<string>();
        List<string> listExportFoldersHistory = new List<string>();
        public static string chosenFile;
        public static string destinationFolder;
        public static List<string> worksheetsList = new List<string>();
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

            for (int i = 0; i < chlb_worksheets.Items.Count; i++)
            {
                chlb_worksheets.SetItemChecked(i, true);
            }
        }

        private async void btn_import_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbx_chooseFile.Text)) {
                MessageBox.Show("Enter the path for the Excel file");
                return;
            }
            if (string.IsNullOrEmpty(cbx_chooseExportFolder.Text)) {
                MessageBox.Show("Enter the path to the export folder");
                return;
            }
            
            worksheetsList.Clear();
            foreach (var item in chlb_worksheets.CheckedItems)
            {
                worksheetsList.Add(item.ToString());
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

            if (ExcelImport.weaponsAddedToDictionary == true)
            {
                if (MessageBox.Show("Data has already been imported from Excel file. Do you want to do it again?" +
                    "Yes: data will be imported again and exported to folder." +
                    "No: data will NOT be imported again, but data from the last successful import will still be exported to folder", 
                    "Data Already Imported", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await Task.Run(() => ExcelImport.LoadExcelDataClosedXML());
                }
            }
            else
            {
                await Task.Run(() => ExcelImport.LoadExcelDataClosedXML());
            }
            await Task.Run(() => ExcelImport.WriteToXML());
            
            // re-enable things
            btn_import.Enabled = true;
            progressBar1.Visible = false;
            lbl_pleaseWait.Visible = false;
        }
        
        
        private void btn_ChooseFile_Click(object sender, EventArgs e) 
        {
            OpenFileDialog chooseFile = new OpenFileDialog();
            chooseFile.Filter = "Excel files | *.xlsx; *.xlsm; *.xltx; *.xltm";

            

            if (chooseFile.ShowDialog() == DialogResult.OK)
            {
                cbx_chooseFile.Text = chooseFile.FileName;
                ChooseFile_AddToHistory();
                chosenFile = cbx_chooseFile.Text;
            }
        }
        
        private void ChooseFile_AddToHistory()
        {
            bool fileNameAlreadyExists = false;
            foreach (var item in cbx_chooseFile.Items) {
                if (item.ToString() == cbx_chooseFile.Text) { fileNameAlreadyExists = true; }
            }
            if (!fileNameAlreadyExists) {  cbx_chooseFile.Items.Add(cbx_chooseFile.Text);  }
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
                cbx_chooseExportFolder.Text = chooseFolder.SelectedPath + @"\Weapons\";
                ChooseFolder_AddToHistory();
                destinationFolder = cbx_chooseExportFolder.Text;
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            this.ActiveControl = null;
        }

        


        private void txt_onCbxChooseFile_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseFile.Visible = false;
            cbx_chooseFile.Focus();
            cbx_chooseFile.DroppedDown = true;
        }

        private void cbx_chooseFile_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseFile.Visible = false;
            cbx_chooseFile.DroppedDown = true;
        }

        private void cbx_chooseExportFolder_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseExportFolder.Visible = false;
            cbx_chooseExportFolder.DroppedDown = true;
        }

        private void txt_onCbxChooseExportFolder_MouseClick(object sender, MouseEventArgs e)
        {
            txt_onCbxChooseExportFolder.Visible = false;
            cbx_chooseExportFolder.Focus();
            cbx_chooseExportFolder.DroppedDown = true;
        }

        private void cbx_chooseFile_TextChanged(object sender, EventArgs e)
        {
            chosenFile = cbx_chooseFile.Text;
        }

        private void cbx_chooseExportFolder_TextChanged(object sender, EventArgs e)
        {
            destinationFolder = cbx_chooseExportFolder.Text + @"\";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ChooseFile_AddToHistory();
            ChooseFolder_AddToHistory();
            WriteHistoryFile();
        }

        
        private void WriteHistoryFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            const int maxHistoryItems = 5;
            
            foreach (var item in cbx_chooseFile.Items) {
                if (!string.IsNullOrEmpty(item.ToString())) {
                    listImportFilesHistory.Insert(0, item.ToString());
                }
            }

            foreach (var item in cbx_chooseExportFolder.Items) {
                if (!string.IsNullOrEmpty(item.ToString())) {
                    listExportFoldersHistory.Insert(0, item.ToString());
                }
            }

            if (listImportFilesHistory.Count > maxHistoryItems) {
                listImportFilesHistory.RemoveRange(maxHistoryItems, listImportFilesHistory.Count - maxHistoryItems);
            }

            if (listExportFoldersHistory.Count > maxHistoryItems) {
                listExportFoldersHistory.RemoveRange(maxHistoryItems, listExportFoldersHistory.Count - maxHistoryItems);
            }

            StreamWriter writer = new StreamWriter(baseDir + @"\history.txt");
            writer.WriteLine("Import Files History:");
            foreach (var line in listImportFilesHistory) {
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
                    bool exportFoldersPart = false;
                    for (int i = 0; i < 100; i++) {
                        currentLine = reader.ReadLine();
                        if (!string.IsNullOrEmpty(currentLine)) {
                            if (currentLine == "Import Files History:") {  continue;  }
                            if (currentLine == "Export Folders History:") {
                                exportFoldersPart = true;
                                continue;
                            }
                            if (exportFoldersPart == false) {  cbx_chooseFile.Items.Add(currentLine); }
                            if (exportFoldersPart == true) { cbx_chooseExportFolder.Items.Add(currentLine); }
                        }
                        else {
                            if (exportFoldersPart) { break; }
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
            if (cbx_chooseFile.Focused == false)
            {
                if (string.IsNullOrEmpty(cbx_chooseFile.Text)) { txt_onCbxChooseFile.Visible = true; }
                else { txt_onCbxChooseFile.Visible = false; }
            }

            if (cbx_chooseExportFolder.Focused == false)
            {
                if (string.IsNullOrEmpty(cbx_chooseExportFolder.Text)) { txt_onCbxChooseExportFolder.Visible = true; }
                else { txt_onCbxChooseExportFolder.Visible = false; }
            }
        }

    }
}
