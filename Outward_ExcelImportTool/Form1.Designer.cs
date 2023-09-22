
namespace Outward_ExcelImportTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_import = new System.Windows.Forms.Button();
            this.btn_ChooseFile = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_ChooseFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_chooseExportFolder = new System.Windows.Forms.Button();
            this.cbx_chooseFile = new System.Windows.Forms.ComboBox();
            this.txt_onCbxChooseFile = new System.Windows.Forms.TextBox();
            this.cbx_chooseExportFolder = new System.Windows.Forms.ComboBox();
            this.txt_onCbxChooseExportFolder = new System.Windows.Forms.TextBox();
            this.lbl_pleaseWait = new System.Windows.Forms.Label();
            this.chlb_worksheets = new System.Windows.Forms.CheckedListBox();
            this.chbx_ExportDmgBonusAndRes = new System.Windows.Forms.CheckBox();
            this.chbx_autoGenAttackData = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_import
            // 
            this.btn_import.BackColor = System.Drawing.Color.Transparent;
            this.btn_import.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_import.CausesValidation = false;
            this.btn_import.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_import.FlatAppearance.BorderSize = 0;
            this.btn_import.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_import.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_import.Font = new System.Drawing.Font("Monotype Corsiva", 22F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btn_import.ForeColor = System.Drawing.Color.OldLace;
            this.btn_import.Location = new System.Drawing.Point(184, 271);
            this.btn_import.Margin = new System.Windows.Forms.Padding(0);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(171, 43);
            this.btn_import.TabIndex = 0;
            this.btn_import.TabStop = false;
            this.btn_import.Text = "Import Data";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_ChooseFile
            // 
            this.btn_ChooseFile.BackColor = System.Drawing.Color.Transparent;
            this.btn_ChooseFile.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ChooseFile.BackgroundImage")));
            this.btn_ChooseFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ChooseFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ChooseFile.FlatAppearance.BorderSize = 0;
            this.btn_ChooseFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_ChooseFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_ChooseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ChooseFile.ForeColor = System.Drawing.Color.Transparent;
            this.btn_ChooseFile.Location = new System.Drawing.Point(51, 176);
            this.btn_ChooseFile.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ChooseFile.Name = "btn_ChooseFile";
            this.btn_ChooseFile.Size = new System.Drawing.Size(28, 28);
            this.btn_ChooseFile.TabIndex = 1;
            this.btn_ChooseFile.UseVisualStyleBackColor = false;
            this.btn_ChooseFile.Click += new System.EventHandler(this.btn_ChooseFile_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(195, 100);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(146, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // lbl_ChooseFile
            // 
            this.lbl_ChooseFile.AutoSize = true;
            this.lbl_ChooseFile.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChooseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ChooseFile.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_ChooseFile.Location = new System.Drawing.Point(141, 154);
            this.lbl_ChooseFile.Name = "lbl_ChooseFile";
            this.lbl_ChooseFile.Size = new System.Drawing.Size(258, 18);
            this.lbl_ChooseFile.TabIndex = 6;
            this.lbl_ChooseFile.Text = "The Excel file with weapons stats";
            this.lbl_ChooseFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(142, 219);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "The Folder to export XML files to";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_chooseExportFolder
            // 
            this.btn_chooseExportFolder.BackColor = System.Drawing.Color.Transparent;
            this.btn_chooseExportFolder.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_chooseExportFolder.BackgroundImage")));
            this.btn_chooseExportFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_chooseExportFolder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_chooseExportFolder.FlatAppearance.BorderSize = 0;
            this.btn_chooseExportFolder.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_chooseExportFolder.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_chooseExportFolder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chooseExportFolder.ForeColor = System.Drawing.Color.Transparent;
            this.btn_chooseExportFolder.Location = new System.Drawing.Point(51, 241);
            this.btn_chooseExportFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btn_chooseExportFolder.Name = "btn_chooseExportFolder";
            this.btn_chooseExportFolder.Size = new System.Drawing.Size(28, 28);
            this.btn_chooseExportFolder.TabIndex = 7;
            this.btn_chooseExportFolder.UseVisualStyleBackColor = false;
            this.btn_chooseExportFolder.Click += new System.EventHandler(this.btn_chooseExportFolder_Click);
            // 
            // cbx_chooseFile
            // 
            this.cbx_chooseFile.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbx_chooseFile.FormattingEnabled = true;
            this.cbx_chooseFile.IntegralHeight = false;
            this.cbx_chooseFile.ItemHeight = 15;
            this.cbx_chooseFile.Location = new System.Drawing.Point(86, 180);
            this.cbx_chooseFile.MaxDropDownItems = 5;
            this.cbx_chooseFile.Name = "cbx_chooseFile";
            this.cbx_chooseFile.Size = new System.Drawing.Size(368, 23);
            this.cbx_chooseFile.TabIndex = 10;
            this.cbx_chooseFile.TextChanged += new System.EventHandler(this.cbx_chooseFile_TextChanged);
            this.cbx_chooseFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbx_chooseFile_MouseClick);
            // 
            // txt_onCbxChooseFile
            // 
            this.txt_onCbxChooseFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_onCbxChooseFile.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_onCbxChooseFile.Location = new System.Drawing.Point(220, 183);
            this.txt_onCbxChooseFile.Margin = new System.Windows.Forms.Padding(0);
            this.txt_onCbxChooseFile.Name = "txt_onCbxChooseFile";
            this.txt_onCbxChooseFile.Size = new System.Drawing.Size(100, 16);
            this.txt_onCbxChooseFile.TabIndex = 12;
            this.txt_onCbxChooseFile.Text = "Choose a file";
            this.txt_onCbxChooseFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_onCbxChooseFile.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_onCbxChooseFile_MouseClick);
            // 
            // cbx_chooseExportFolder
            // 
            this.cbx_chooseExportFolder.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbx_chooseExportFolder.FormattingEnabled = true;
            this.cbx_chooseExportFolder.Location = new System.Drawing.Point(86, 245);
            this.cbx_chooseExportFolder.Name = "cbx_chooseExportFolder";
            this.cbx_chooseExportFolder.Size = new System.Drawing.Size(368, 23);
            this.cbx_chooseExportFolder.TabIndex = 13;
            this.cbx_chooseExportFolder.TextChanged += new System.EventHandler(this.cbx_chooseExportFolder_TextChanged);
            this.cbx_chooseExportFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbx_chooseExportFolder_MouseClick);
            // 
            // txt_onCbxChooseExportFolder
            // 
            this.txt_onCbxChooseExportFolder.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_onCbxChooseExportFolder.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_onCbxChooseExportFolder.Location = new System.Drawing.Point(220, 248);
            this.txt_onCbxChooseExportFolder.Margin = new System.Windows.Forms.Padding(0);
            this.txt_onCbxChooseExportFolder.Name = "txt_onCbxChooseExportFolder";
            this.txt_onCbxChooseExportFolder.Size = new System.Drawing.Size(100, 16);
            this.txt_onCbxChooseExportFolder.TabIndex = 14;
            this.txt_onCbxChooseExportFolder.Text = "Choose a file";
            this.txt_onCbxChooseExportFolder.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_onCbxChooseExportFolder.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_onCbxChooseExportFolder_MouseClick);
            // 
            // lbl_pleaseWait
            // 
            this.lbl_pleaseWait.AutoSize = true;
            this.lbl_pleaseWait.BackColor = System.Drawing.Color.Transparent;
            this.lbl_pleaseWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_pleaseWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_pleaseWait.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_pleaseWait.Location = new System.Drawing.Point(178, 66);
            this.lbl_pleaseWait.Name = "lbl_pleaseWait";
            this.lbl_pleaseWait.Size = new System.Drawing.Size(177, 31);
            this.lbl_pleaseWait.TabIndex = 15;
            this.lbl_pleaseWait.Text = "Please wait...";
            this.lbl_pleaseWait.Visible = false;
            // 
            // chlb_worksheets
            // 
            this.chlb_worksheets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(5)))), ((int)(((byte)(35)))));
            this.chlb_worksheets.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chlb_worksheets.CheckOnClick = true;
            this.chlb_worksheets.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chlb_worksheets.ForeColor = System.Drawing.Color.OldLace;
            this.chlb_worksheets.FormattingEnabled = true;
            this.chlb_worksheets.Items.AddRange(new object[] {
            "Swords_1h",
            "Swords_2h",
            "Axes_1h",
            "Axes_2h",
            "Maces_1h",
            "Maces_2h",
            "Halberds",
            "Staves",
            "Spears",
            "Gauntlets",
            "Bows",
            "Shields",
            "Chakrams",
            "Daggers",
            "Pistols"});
            this.chlb_worksheets.Location = new System.Drawing.Point(0, 405);
            this.chlb_worksheets.MultiColumn = true;
            this.chlb_worksheets.Name = "chlb_worksheets";
            this.chlb_worksheets.Size = new System.Drawing.Size(505, 60);
            this.chlb_worksheets.TabIndex = 16;
            // 
            // chbx_ExportDmgBonusAndRes
            // 
            this.chbx_ExportDmgBonusAndRes.AutoSize = true;
            this.chbx_ExportDmgBonusAndRes.BackColor = System.Drawing.Color.Transparent;
            this.chbx_ExportDmgBonusAndRes.Checked = true;
            this.chbx_ExportDmgBonusAndRes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_ExportDmgBonusAndRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbx_ExportDmgBonusAndRes.ForeColor = System.Drawing.Color.OldLace;
            this.chbx_ExportDmgBonusAndRes.Location = new System.Drawing.Point(144, 343);
            this.chbx_ExportDmgBonusAndRes.Name = "chbx_ExportDmgBonusAndRes";
            this.chbx_ExportDmgBonusAndRes.Size = new System.Drawing.Size(257, 19);
            this.chbx_ExportDmgBonusAndRes.TabIndex = 17;
            this.chbx_ExportDmgBonusAndRes.Text = "Export Damage Bonuses and Resistances";
            this.chbx_ExportDmgBonusAndRes.UseVisualStyleBackColor = false;
            // 
            // chbx_autoGenAttackData
            // 
            this.chbx_autoGenAttackData.AutoSize = true;
            this.chbx_autoGenAttackData.BackColor = System.Drawing.Color.Transparent;
            this.chbx_autoGenAttackData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbx_autoGenAttackData.ForeColor = System.Drawing.Color.OldLace;
            this.chbx_autoGenAttackData.Location = new System.Drawing.Point(144, 366);
            this.chbx_autoGenAttackData.Name = "chbx_autoGenAttackData";
            this.chbx_autoGenAttackData.Size = new System.Drawing.Size(250, 19);
            this.chbx_autoGenAttackData.TabIndex = 18;
            this.chbx_autoGenAttackData.Text = "Weapons Use Autogenerated Attack Data";
            this.chbx_autoGenAttackData.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(505, 465);
            this.Controls.Add(this.chbx_autoGenAttackData);
            this.Controls.Add(this.chbx_ExportDmgBonusAndRes);
            this.Controls.Add(this.chlb_worksheets);
            this.Controls.Add(this.lbl_pleaseWait);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.txt_onCbxChooseExportFolder);
            this.Controls.Add(this.cbx_chooseExportFolder);
            this.Controls.Add(this.txt_onCbxChooseFile);
            this.Controls.Add(this.cbx_chooseFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_chooseExportFolder);
            this.Controls.Add(this.lbl_ChooseFile);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_ChooseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outward Enhanced XML Creator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_ChooseFile;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_ChooseFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_chooseExportFolder;
        private System.Windows.Forms.ComboBox cbx_chooseFile;
        private System.Windows.Forms.TextBox txt_onCbxChooseFile;
        private System.Windows.Forms.ComboBox cbx_chooseExportFolder;
        private System.Windows.Forms.TextBox txt_onCbxChooseExportFolder;
        private System.Windows.Forms.Label lbl_pleaseWait;
        private System.Windows.Forms.CheckedListBox chlb_worksheets;
        private System.Windows.Forms.CheckBox chbx_ExportDmgBonusAndRes;
        private System.Windows.Forms.CheckBox chbx_autoGenAttackData;
    }
}

