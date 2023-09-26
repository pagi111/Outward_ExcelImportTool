
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
            this.btn_chooseFileWeapons = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_ChooseFileWeapons = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_chooseExportFolder = new System.Windows.Forms.Button();
            this.cbx_chooseFileWeapons = new System.Windows.Forms.ComboBox();
            this.txt_onCbxChooseFileWeapons = new System.Windows.Forms.TextBox();
            this.cbx_chooseExportFolder = new System.Windows.Forms.ComboBox();
            this.txt_onCbxChooseExportFolder = new System.Windows.Forms.TextBox();
            this.lbl_pleaseWait = new System.Windows.Forms.Label();
            this.chlb_worksheetsWeapons = new System.Windows.Forms.CheckedListBox();
            this.chbx_ExportDmgBonusAndRes = new System.Windows.Forms.CheckBox();
            this.chbx_autoGenAttackData = new System.Windows.Forms.CheckBox();
            this.txt_onCbxChooseFileArmor = new System.Windows.Forms.TextBox();
            this.cbx_chooseFileArmor = new System.Windows.Forms.ComboBox();
            this.lbl_ChooseFileArmor = new System.Windows.Forms.Label();
            this.btn_chooseFileArmor = new System.Windows.Forms.Button();
            this.chlb_worksheetsArmor = new System.Windows.Forms.CheckedListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.btn_import.Location = new System.Drawing.Point(182, 321);
            this.btn_import.Margin = new System.Windows.Forms.Padding(0);
            this.btn_import.Name = "btn_import";
            this.btn_import.Size = new System.Drawing.Size(171, 43);
            this.btn_import.TabIndex = 0;
            this.btn_import.TabStop = false;
            this.btn_import.Text = "Import Data";
            this.btn_import.UseVisualStyleBackColor = false;
            this.btn_import.Click += new System.EventHandler(this.btn_import_Click);
            // 
            // btn_chooseFileWeapons
            // 
            this.btn_chooseFileWeapons.BackColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileWeapons.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_chooseFileWeapons.BackgroundImage")));
            this.btn_chooseFileWeapons.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_chooseFileWeapons.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_chooseFileWeapons.FlatAppearance.BorderSize = 0;
            this.btn_chooseFileWeapons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileWeapons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileWeapons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chooseFileWeapons.ForeColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileWeapons.Location = new System.Drawing.Point(49, 226);
            this.btn_chooseFileWeapons.Margin = new System.Windows.Forms.Padding(0);
            this.btn_chooseFileWeapons.Name = "btn_chooseFileWeapons";
            this.btn_chooseFileWeapons.Size = new System.Drawing.Size(28, 28);
            this.btn_chooseFileWeapons.TabIndex = 1;
            this.btn_chooseFileWeapons.UseVisualStyleBackColor = false;
            this.btn_chooseFileWeapons.Click += new System.EventHandler(this.btn_ChooseFileWeapons_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(193, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(146, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // lbl_ChooseFileWeapons
            // 
            this.lbl_ChooseFileWeapons.AutoSize = true;
            this.lbl_ChooseFileWeapons.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChooseFileWeapons.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ChooseFileWeapons.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_ChooseFileWeapons.Location = new System.Drawing.Point(139, 204);
            this.lbl_ChooseFileWeapons.Name = "lbl_ChooseFileWeapons";
            this.lbl_ChooseFileWeapons.Size = new System.Drawing.Size(258, 18);
            this.lbl_ChooseFileWeapons.TabIndex = 6;
            this.lbl_ChooseFileWeapons.Text = "The Excel file with weapons stats";
            this.lbl_ChooseFileWeapons.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.OldLace;
            this.label1.Location = new System.Drawing.Point(140, 269);
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
            this.btn_chooseExportFolder.Location = new System.Drawing.Point(49, 291);
            this.btn_chooseExportFolder.Margin = new System.Windows.Forms.Padding(0);
            this.btn_chooseExportFolder.Name = "btn_chooseExportFolder";
            this.btn_chooseExportFolder.Size = new System.Drawing.Size(28, 28);
            this.btn_chooseExportFolder.TabIndex = 7;
            this.btn_chooseExportFolder.UseVisualStyleBackColor = false;
            this.btn_chooseExportFolder.Click += new System.EventHandler(this.btn_chooseExportFolder_Click);
            // 
            // cbx_chooseFileWeapons
            // 
            this.cbx_chooseFileWeapons.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbx_chooseFileWeapons.FormattingEnabled = true;
            this.cbx_chooseFileWeapons.IntegralHeight = false;
            this.cbx_chooseFileWeapons.ItemHeight = 15;
            this.cbx_chooseFileWeapons.Location = new System.Drawing.Point(84, 230);
            this.cbx_chooseFileWeapons.MaxDropDownItems = 5;
            this.cbx_chooseFileWeapons.Name = "cbx_chooseFileWeapons";
            this.cbx_chooseFileWeapons.Size = new System.Drawing.Size(368, 23);
            this.cbx_chooseFileWeapons.TabIndex = 10;
            this.cbx_chooseFileWeapons.TextChanged += new System.EventHandler(this.cbx_chooseFileWeapons_TextChanged);
            this.cbx_chooseFileWeapons.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbx_chooseFileWeapons_MouseClick);
            // 
            // txt_onCbxChooseFileWeapons
            // 
            this.txt_onCbxChooseFileWeapons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_onCbxChooseFileWeapons.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_onCbxChooseFileWeapons.Location = new System.Drawing.Point(218, 233);
            this.txt_onCbxChooseFileWeapons.Margin = new System.Windows.Forms.Padding(0);
            this.txt_onCbxChooseFileWeapons.Name = "txt_onCbxChooseFileWeapons";
            this.txt_onCbxChooseFileWeapons.Size = new System.Drawing.Size(100, 16);
            this.txt_onCbxChooseFileWeapons.TabIndex = 12;
            this.txt_onCbxChooseFileWeapons.Text = "Choose a file";
            this.txt_onCbxChooseFileWeapons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_onCbxChooseFileWeapons.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_onCbxChooseFileWeapons_MouseClick);
            // 
            // cbx_chooseExportFolder
            // 
            this.cbx_chooseExportFolder.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbx_chooseExportFolder.FormattingEnabled = true;
            this.cbx_chooseExportFolder.Location = new System.Drawing.Point(84, 295);
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
            this.txt_onCbxChooseExportFolder.Location = new System.Drawing.Point(218, 298);
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
            this.lbl_pleaseWait.Location = new System.Drawing.Point(176, 9);
            this.lbl_pleaseWait.Name = "lbl_pleaseWait";
            this.lbl_pleaseWait.Size = new System.Drawing.Size(177, 31);
            this.lbl_pleaseWait.TabIndex = 15;
            this.lbl_pleaseWait.Text = "Please wait...";
            this.lbl_pleaseWait.Visible = false;
            // 
            // chlb_worksheetsWeapons
            // 
            this.chlb_worksheetsWeapons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(5)))), ((int)(((byte)(35)))));
            this.chlb_worksheetsWeapons.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chlb_worksheetsWeapons.CheckOnClick = true;
            this.chlb_worksheetsWeapons.ColumnWidth = 96;
            this.chlb_worksheetsWeapons.ForeColor = System.Drawing.Color.OldLace;
            this.chlb_worksheetsWeapons.FormattingEnabled = true;
            this.chlb_worksheetsWeapons.Items.AddRange(new object[] {
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
            this.chlb_worksheetsWeapons.Location = new System.Drawing.Point(25, 0);
            this.chlb_worksheetsWeapons.MultiColumn = true;
            this.chlb_worksheetsWeapons.Name = "chlb_worksheetsWeapons";
            this.chlb_worksheetsWeapons.Size = new System.Drawing.Size(385, 60);
            this.chlb_worksheetsWeapons.TabIndex = 16;
            // 
            // chbx_ExportDmgBonusAndRes
            // 
            this.chbx_ExportDmgBonusAndRes.AutoSize = true;
            this.chbx_ExportDmgBonusAndRes.BackColor = System.Drawing.Color.Transparent;
            this.chbx_ExportDmgBonusAndRes.Checked = true;
            this.chbx_ExportDmgBonusAndRes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbx_ExportDmgBonusAndRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.chbx_ExportDmgBonusAndRes.ForeColor = System.Drawing.Color.OldLace;
            this.chbx_ExportDmgBonusAndRes.Location = new System.Drawing.Point(142, 389);
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
            this.chbx_autoGenAttackData.Location = new System.Drawing.Point(142, 412);
            this.chbx_autoGenAttackData.Name = "chbx_autoGenAttackData";
            this.chbx_autoGenAttackData.Size = new System.Drawing.Size(250, 19);
            this.chbx_autoGenAttackData.TabIndex = 18;
            this.chbx_autoGenAttackData.Text = "Weapons Use Autogenerated Attack Data";
            this.chbx_autoGenAttackData.UseVisualStyleBackColor = false;
            // 
            // txt_onCbxChooseFileArmor
            // 
            this.txt_onCbxChooseFileArmor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_onCbxChooseFileArmor.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txt_onCbxChooseFileArmor.Location = new System.Drawing.Point(218, 167);
            this.txt_onCbxChooseFileArmor.Margin = new System.Windows.Forms.Padding(0);
            this.txt_onCbxChooseFileArmor.Name = "txt_onCbxChooseFileArmor";
            this.txt_onCbxChooseFileArmor.Size = new System.Drawing.Size(100, 16);
            this.txt_onCbxChooseFileArmor.TabIndex = 22;
            this.txt_onCbxChooseFileArmor.Text = "Choose a file";
            this.txt_onCbxChooseFileArmor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_onCbxChooseFileArmor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_onCbxChooseFileArmor_MouseClick);
            // 
            // cbx_chooseFileArmor
            // 
            this.cbx_chooseFileArmor.Font = new System.Drawing.Font("Nirmala UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbx_chooseFileArmor.FormattingEnabled = true;
            this.cbx_chooseFileArmor.IntegralHeight = false;
            this.cbx_chooseFileArmor.ItemHeight = 15;
            this.cbx_chooseFileArmor.Location = new System.Drawing.Point(84, 164);
            this.cbx_chooseFileArmor.MaxDropDownItems = 5;
            this.cbx_chooseFileArmor.Name = "cbx_chooseFileArmor";
            this.cbx_chooseFileArmor.Size = new System.Drawing.Size(368, 23);
            this.cbx_chooseFileArmor.TabIndex = 21;
            this.cbx_chooseFileArmor.TextChanged += new System.EventHandler(this.cbx_chooseFileArmor_TextChanged);
            this.cbx_chooseFileArmor.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbx_chooseFileArmor_MouseClick);
            // 
            // lbl_ChooseFileArmor
            // 
            this.lbl_ChooseFileArmor.AutoSize = true;
            this.lbl_ChooseFileArmor.BackColor = System.Drawing.Color.Transparent;
            this.lbl_ChooseFileArmor.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_ChooseFileArmor.ForeColor = System.Drawing.Color.OldLace;
            this.lbl_ChooseFileArmor.Location = new System.Drawing.Point(139, 138);
            this.lbl_ChooseFileArmor.Name = "lbl_ChooseFileArmor";
            this.lbl_ChooseFileArmor.Size = new System.Drawing.Size(236, 18);
            this.lbl_ChooseFileArmor.TabIndex = 20;
            this.lbl_ChooseFileArmor.Text = "The Excel file with armor stats";
            this.lbl_ChooseFileArmor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_chooseFileArmor
            // 
            this.btn_chooseFileArmor.BackColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileArmor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_chooseFileArmor.BackgroundImage")));
            this.btn_chooseFileArmor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_chooseFileArmor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_chooseFileArmor.FlatAppearance.BorderSize = 0;
            this.btn_chooseFileArmor.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileArmor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileArmor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_chooseFileArmor.ForeColor = System.Drawing.Color.Transparent;
            this.btn_chooseFileArmor.Location = new System.Drawing.Point(49, 160);
            this.btn_chooseFileArmor.Margin = new System.Windows.Forms.Padding(0);
            this.btn_chooseFileArmor.Name = "btn_chooseFileArmor";
            this.btn_chooseFileArmor.Size = new System.Drawing.Size(28, 28);
            this.btn_chooseFileArmor.TabIndex = 19;
            this.btn_chooseFileArmor.UseVisualStyleBackColor = false;
            this.btn_chooseFileArmor.Click += new System.EventHandler(this.btn_ChooseFileArmor_Click);
            // 
            // chlb_worksheetsArmor
            // 
            this.chlb_worksheetsArmor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(5)))), ((int)(((byte)(35)))));
            this.chlb_worksheetsArmor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.chlb_worksheetsArmor.CheckOnClick = true;
            this.chlb_worksheetsArmor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlb_worksheetsArmor.ForeColor = System.Drawing.Color.OldLace;
            this.chlb_worksheetsArmor.FormattingEnabled = true;
            this.chlb_worksheetsArmor.Items.AddRange(new object[] {
            "Body",
            "Helmets",
            "Boots"});
            this.chlb_worksheetsArmor.Location = new System.Drawing.Point(0, 0);
            this.chlb_worksheetsArmor.MultiColumn = true;
            this.chlb_worksheetsArmor.Name = "chlb_worksheetsArmor";
            this.chlb_worksheetsArmor.Size = new System.Drawing.Size(84, 68);
            this.chlb_worksheetsArmor.TabIndex = 23;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(5)))), ((int)(((byte)(35)))));
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 447);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chlb_worksheetsWeapons);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.chlb_worksheetsArmor);
            this.splitContainer1.Size = new System.Drawing.Size(503, 68);
            this.splitContainer1.SplitterDistance = 415;
            this.splitContainer1.TabIndex = 24;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(503, 515);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txt_onCbxChooseFileArmor);
            this.Controls.Add(this.cbx_chooseFileArmor);
            this.Controls.Add(this.lbl_ChooseFileArmor);
            this.Controls.Add(this.btn_chooseFileArmor);
            this.Controls.Add(this.chbx_autoGenAttackData);
            this.Controls.Add(this.chbx_ExportDmgBonusAndRes);
            this.Controls.Add(this.lbl_pleaseWait);
            this.Controls.Add(this.btn_import);
            this.Controls.Add(this.txt_onCbxChooseExportFolder);
            this.Controls.Add(this.cbx_chooseExportFolder);
            this.Controls.Add(this.txt_onCbxChooseFileWeapons);
            this.Controls.Add(this.cbx_chooseFileWeapons);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_chooseExportFolder);
            this.Controls.Add(this.lbl_ChooseFileWeapons);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btn_chooseFileWeapons);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Outward Excel Import Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_import;
        private System.Windows.Forms.Button btn_chooseFileWeapons;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lbl_ChooseFileWeapons;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_chooseExportFolder;
        private System.Windows.Forms.ComboBox cbx_chooseFileWeapons;
        private System.Windows.Forms.TextBox txt_onCbxChooseFileWeapons;
        private System.Windows.Forms.ComboBox cbx_chooseExportFolder;
        private System.Windows.Forms.TextBox txt_onCbxChooseExportFolder;
        private System.Windows.Forms.Label lbl_pleaseWait;
        private System.Windows.Forms.CheckedListBox chlb_worksheetsWeapons;
        private System.Windows.Forms.CheckBox chbx_ExportDmgBonusAndRes;
        private System.Windows.Forms.CheckBox chbx_autoGenAttackData;
        private System.Windows.Forms.TextBox txt_onCbxChooseFileArmor;
        private System.Windows.Forms.ComboBox cbx_chooseFileArmor;
        private System.Windows.Forms.Label lbl_ChooseFileArmor;
        private System.Windows.Forms.Button btn_chooseFileArmor;
        private System.Windows.Forms.CheckedListBox chlb_worksheetsArmor;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

