namespace mEXTRADROPSedit.UI
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkProbabilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileWorker = new System.ComponentModel.BackgroundWorker();
            this.entriesListBox = new System.Windows.Forms.ListBox();
            this.entriesListBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteEntryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTextbox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.entryMonstersGroup = new System.Windows.Forms.GroupBox();
            this.monstersIdTextBox = new System.Windows.Forms.TextBox();
            this.monstersListBox = new System.Windows.Forms.ListBox();
            this.monstersListBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.entryTypeDropdown = new System.Windows.Forms.ComboBox();
            this.entryTypeGroup = new System.Windows.Forms.GroupBox();
            this.entryDropNumProbabilitiesGroup = new System.Windows.Forms.GroupBox();
            this.entryDrop7Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop7Label = new System.Windows.Forms.Label();
            this.entryDrop6Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop6Label = new System.Windows.Forms.Label();
            this.entryDrop5Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop5Label = new System.Windows.Forms.Label();
            this.entryDrop4Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop4Label = new System.Windows.Forms.Label();
            this.entryDrop3Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop3Label = new System.Windows.Forms.Label();
            this.entryDrop2Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop2Label = new System.Windows.Forms.Label();
            this.entryDrop1Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop1Label = new System.Windows.Forms.Label();
            this.entryDrop0Textbox = new System.Windows.Forms.TextBox();
            this.entryDrop0Label = new System.Windows.Forms.Label();
            this.entryDropItemsGroup = new System.Windows.Forms.GroupBox();
            this.dropItemsProbabilityTextBox = new System.Windows.Forms.TextBox();
            this.dropItemsIdTextBox = new System.Windows.Forms.TextBox();
            this.dropItemsListBox = new System.Windows.Forms.ListBox();
            this.dropItemsMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.entryNameTextBox = new System.Windows.Forms.TextBox();
            this.entryNameGroupBox = new System.Windows.Forms.GroupBox();
            this.menuStrip1.SuspendLayout();
            this.entriesListBoxMenu.SuspendLayout();
            this.entryMonstersGroup.SuspendLayout();
            this.monstersListBoxMenu.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.entryTypeGroup.SuspendLayout();
            this.entryDropNumProbabilitiesGroup.SuspendLayout();
            this.entryDropItemsGroup.SuspendLayout();
            this.dropItemsMenu.SuspendLayout();
            this.entryNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem2,
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(114, 22);
            this.newToolStripMenuItem2.Text = "New";
            this.newToolStripMenuItem2.Click += new System.EventHandler(this.newToolStripMenuItem2_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkProbabilitiesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // checkProbabilitiesToolStripMenuItem
            // 
            this.checkProbabilitiesToolStripMenuItem.Name = "checkProbabilitiesToolStripMenuItem";
            this.checkProbabilitiesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.checkProbabilitiesToolStripMenuItem.Text = "Check Entry Probabilities";
            this.checkProbabilitiesToolStripMenuItem.Click += new System.EventHandler(this.checkProbabilitiesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // fileWorker
            // 
            this.fileWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.fileWorker_DoWork);
            this.fileWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.fileWorker_RunWorkerCompleted);
            // 
            // entriesListBox
            // 
            this.entriesListBox.ContextMenuStrip = this.entriesListBoxMenu;
            this.entriesListBox.FormattingEnabled = true;
            this.entriesListBox.Location = new System.Drawing.Point(5, 25);
            this.entriesListBox.Name = "entriesListBox";
            this.entriesListBox.Size = new System.Drawing.Size(181, 329);
            this.entriesListBox.TabIndex = 1;
            this.entriesListBox.SelectedIndexChanged += new System.EventHandler(this.entriesListBox_SelectedIndexChanged);
            // 
            // entriesListBoxMenu
            // 
            this.entriesListBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newEntryMenuItem,
            this.cloneEntryMenuItem,
            this.deleteEntryMenuItem});
            this.entriesListBoxMenu.Name = "entriesListBoxMenu";
            this.entriesListBoxMenu.Size = new System.Drawing.Size(108, 70);
            // 
            // newEntryMenuItem
            // 
            this.newEntryMenuItem.Name = "newEntryMenuItem";
            this.newEntryMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newEntryMenuItem.Text = "New";
            this.newEntryMenuItem.Click += new System.EventHandler(this.newEntryMenuItem_Click);
            // 
            // cloneEntryMenuItem
            // 
            this.cloneEntryMenuItem.Name = "cloneEntryMenuItem";
            this.cloneEntryMenuItem.Size = new System.Drawing.Size(107, 22);
            this.cloneEntryMenuItem.Text = "Clone";
            this.cloneEntryMenuItem.Click += new System.EventHandler(this.cloneEntryMenuItem_Click);
            // 
            // deleteEntryMenuItem
            // 
            this.deleteEntryMenuItem.Name = "deleteEntryMenuItem";
            this.deleteEntryMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteEntryMenuItem.Text = "Delete";
            this.deleteEntryMenuItem.Click += new System.EventHandler(this.deleteEntryMenuItem_Click);
            // 
            // searchTextbox
            // 
            this.searchTextbox.Location = new System.Drawing.Point(5, 367);
            this.searchTextbox.Name = "searchTextbox";
            this.searchTextbox.Size = new System.Drawing.Size(100, 20);
            this.searchTextbox.TabIndex = 2;
            this.searchTextbox.Enter += new System.EventHandler(this.searchTextbox_Enter);
            this.searchTextbox.Leave += new System.EventHandler(this.searchTextbox_Leave);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(111, 367);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 20);
            this.searchButton.TabIndex = 3;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // entryMonstersGroup
            // 
            this.entryMonstersGroup.Controls.Add(this.monstersIdTextBox);
            this.entryMonstersGroup.Controls.Add(this.monstersListBox);
            this.entryMonstersGroup.Location = new System.Drawing.Point(403, 27);
            this.entryMonstersGroup.Name = "entryMonstersGroup";
            this.entryMonstersGroup.Size = new System.Drawing.Size(219, 177);
            this.entryMonstersGroup.TabIndex = 5;
            this.entryMonstersGroup.TabStop = false;
            this.entryMonstersGroup.Text = "Affected Mobs";
            // 
            // monstersIdTextBox
            // 
            this.monstersIdTextBox.Location = new System.Drawing.Point(6, 146);
            this.monstersIdTextBox.Name = "monstersIdTextBox";
            this.monstersIdTextBox.Size = new System.Drawing.Size(207, 20);
            this.monstersIdTextBox.TabIndex = 1;
            this.monstersIdTextBox.TextChanged += new System.EventHandler(this.monstersIdTextBox_TextChanged);
            this.monstersIdTextBox.Leave += new System.EventHandler(this.monstersIdTextBox_Leave);
            // 
            // monstersListBox
            // 
            this.monstersListBox.ContextMenuStrip = this.monstersListBoxMenu;
            this.monstersListBox.FormattingEnabled = true;
            this.monstersListBox.Location = new System.Drawing.Point(6, 19);
            this.monstersListBox.Name = "monstersListBox";
            this.monstersListBox.Size = new System.Drawing.Size(207, 121);
            this.monstersListBox.TabIndex = 0;
            this.monstersListBox.SelectedIndexChanged += new System.EventHandler(this.monstersListBox_SelectedIndexChanged);
            // 
            // monstersListBoxMenu
            // 
            this.monstersListBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.monstersListBoxMenu.Name = "monstersListBoxMenu";
            this.monstersListBoxMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 395);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(629, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(39, 17);
            this.statusLabel.Text = "Ready";
            // 
            // entryTypeDropdown
            // 
            this.entryTypeDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entryTypeDropdown.FormattingEnabled = true;
            this.entryTypeDropdown.Location = new System.Drawing.Point(6, 22);
            this.entryTypeDropdown.Name = "entryTypeDropdown";
            this.entryTypeDropdown.Size = new System.Drawing.Size(193, 21);
            this.entryTypeDropdown.TabIndex = 0;
            this.entryTypeDropdown.SelectedIndexChanged += new System.EventHandler(this.entryTypeDropdown_SelectedIndexChanged);
            // 
            // entryTypeGroup
            // 
            this.entryTypeGroup.Controls.Add(this.entryTypeDropdown);
            this.entryTypeGroup.Location = new System.Drawing.Point(192, 87);
            this.entryTypeGroup.Name = "entryTypeGroup";
            this.entryTypeGroup.Size = new System.Drawing.Size(205, 54);
            this.entryTypeGroup.TabIndex = 6;
            this.entryTypeGroup.TabStop = false;
            this.entryTypeGroup.Text = "Type";
            // 
            // entryDropNumProbabilitiesGroup
            // 
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop7Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop7Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop6Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop6Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop5Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop5Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop4Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop4Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop3Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop3Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop2Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop2Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop1Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop1Label);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop0Textbox);
            this.entryDropNumProbabilitiesGroup.Controls.Add(this.entryDrop0Label);
            this.entryDropNumProbabilitiesGroup.Location = new System.Drawing.Point(192, 147);
            this.entryDropNumProbabilitiesGroup.Name = "entryDropNumProbabilitiesGroup";
            this.entryDropNumProbabilitiesGroup.Size = new System.Drawing.Size(205, 240);
            this.entryDropNumProbabilitiesGroup.TabIndex = 8;
            this.entryDropNumProbabilitiesGroup.TabStop = false;
            this.entryDropNumProbabilitiesGroup.Text = "Drop Num Probabilities";
            // 
            // entryDrop7Textbox
            // 
            this.entryDrop7Textbox.Location = new System.Drawing.Point(79, 205);
            this.entryDrop7Textbox.Name = "entryDrop7Textbox";
            this.entryDrop7Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop7Textbox.TabIndex = 15;
            this.entryDrop7Textbox.TextChanged += new System.EventHandler(this.entryDrop7Textbox_TextChanged);
            // 
            // entryDrop7Label
            // 
            this.entryDrop7Label.AutoSize = true;
            this.entryDrop7Label.Location = new System.Drawing.Point(6, 208);
            this.entryDrop7Label.Name = "entryDrop7Label";
            this.entryDrop7Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop7Label.TabIndex = 14;
            this.entryDrop7Label.Text = "Drop 7 Items";
            // 
            // entryDrop6Textbox
            // 
            this.entryDrop6Textbox.Location = new System.Drawing.Point(79, 179);
            this.entryDrop6Textbox.Name = "entryDrop6Textbox";
            this.entryDrop6Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop6Textbox.TabIndex = 13;
            this.entryDrop6Textbox.TextChanged += new System.EventHandler(this.entryDrop6Textbox_TextChanged);
            // 
            // entryDrop6Label
            // 
            this.entryDrop6Label.AutoSize = true;
            this.entryDrop6Label.Location = new System.Drawing.Point(6, 182);
            this.entryDrop6Label.Name = "entryDrop6Label";
            this.entryDrop6Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop6Label.TabIndex = 12;
            this.entryDrop6Label.Text = "Drop 6 Items";
            // 
            // entryDrop5Textbox
            // 
            this.entryDrop5Textbox.Location = new System.Drawing.Point(79, 153);
            this.entryDrop5Textbox.Name = "entryDrop5Textbox";
            this.entryDrop5Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop5Textbox.TabIndex = 11;
            this.entryDrop5Textbox.TextChanged += new System.EventHandler(this.entryDrop5Textbox_TextChanged);
            // 
            // entryDrop5Label
            // 
            this.entryDrop5Label.AutoSize = true;
            this.entryDrop5Label.Location = new System.Drawing.Point(6, 156);
            this.entryDrop5Label.Name = "entryDrop5Label";
            this.entryDrop5Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop5Label.TabIndex = 10;
            this.entryDrop5Label.Text = "Drop 5 Items";
            // 
            // entryDrop4Textbox
            // 
            this.entryDrop4Textbox.Location = new System.Drawing.Point(79, 127);
            this.entryDrop4Textbox.Name = "entryDrop4Textbox";
            this.entryDrop4Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop4Textbox.TabIndex = 9;
            this.entryDrop4Textbox.TextChanged += new System.EventHandler(this.entryDrop4Textbox_TextChanged);
            // 
            // entryDrop4Label
            // 
            this.entryDrop4Label.AutoSize = true;
            this.entryDrop4Label.Location = new System.Drawing.Point(6, 130);
            this.entryDrop4Label.Name = "entryDrop4Label";
            this.entryDrop4Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop4Label.TabIndex = 8;
            this.entryDrop4Label.Text = "Drop 4 Items";
            // 
            // entryDrop3Textbox
            // 
            this.entryDrop3Textbox.Location = new System.Drawing.Point(79, 101);
            this.entryDrop3Textbox.Name = "entryDrop3Textbox";
            this.entryDrop3Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop3Textbox.TabIndex = 7;
            this.entryDrop3Textbox.TextChanged += new System.EventHandler(this.entryDrop3Textbox_TextChanged);
            // 
            // entryDrop3Label
            // 
            this.entryDrop3Label.AutoSize = true;
            this.entryDrop3Label.Location = new System.Drawing.Point(6, 104);
            this.entryDrop3Label.Name = "entryDrop3Label";
            this.entryDrop3Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop3Label.TabIndex = 6;
            this.entryDrop3Label.Text = "Drop 3 Items";
            // 
            // entryDrop2Textbox
            // 
            this.entryDrop2Textbox.Location = new System.Drawing.Point(79, 75);
            this.entryDrop2Textbox.Name = "entryDrop2Textbox";
            this.entryDrop2Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop2Textbox.TabIndex = 5;
            this.entryDrop2Textbox.TextChanged += new System.EventHandler(this.entryDrop2Textbox_TextChanged);
            // 
            // entryDrop2Label
            // 
            this.entryDrop2Label.AutoSize = true;
            this.entryDrop2Label.Location = new System.Drawing.Point(6, 78);
            this.entryDrop2Label.Name = "entryDrop2Label";
            this.entryDrop2Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop2Label.TabIndex = 4;
            this.entryDrop2Label.Text = "Drop 2 Items";
            // 
            // entryDrop1Textbox
            // 
            this.entryDrop1Textbox.Location = new System.Drawing.Point(79, 49);
            this.entryDrop1Textbox.Name = "entryDrop1Textbox";
            this.entryDrop1Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop1Textbox.TabIndex = 3;
            this.entryDrop1Textbox.TextChanged += new System.EventHandler(this.entryDrop1Textbox_TextChanged);
            // 
            // entryDrop1Label
            // 
            this.entryDrop1Label.AutoSize = true;
            this.entryDrop1Label.Location = new System.Drawing.Point(6, 52);
            this.entryDrop1Label.Name = "entryDrop1Label";
            this.entryDrop1Label.Size = new System.Drawing.Size(62, 13);
            this.entryDrop1Label.TabIndex = 2;
            this.entryDrop1Label.Text = "Drop 1 Item";
            // 
            // entryDrop0Textbox
            // 
            this.entryDrop0Textbox.Location = new System.Drawing.Point(79, 24);
            this.entryDrop0Textbox.Name = "entryDrop0Textbox";
            this.entryDrop0Textbox.Size = new System.Drawing.Size(115, 20);
            this.entryDrop0Textbox.TabIndex = 1;
            this.entryDrop0Textbox.TextChanged += new System.EventHandler(this.entryDrop0Textbox_TextChanged);
            // 
            // entryDrop0Label
            // 
            this.entryDrop0Label.AutoSize = true;
            this.entryDrop0Label.Location = new System.Drawing.Point(6, 27);
            this.entryDrop0Label.Name = "entryDrop0Label";
            this.entryDrop0Label.Size = new System.Drawing.Size(67, 13);
            this.entryDrop0Label.TabIndex = 0;
            this.entryDrop0Label.Text = "Drop 0 Items";
            // 
            // entryDropItemsGroup
            // 
            this.entryDropItemsGroup.Controls.Add(this.dropItemsProbabilityTextBox);
            this.entryDropItemsGroup.Controls.Add(this.dropItemsIdTextBox);
            this.entryDropItemsGroup.Controls.Add(this.dropItemsListBox);
            this.entryDropItemsGroup.Location = new System.Drawing.Point(403, 210);
            this.entryDropItemsGroup.Name = "entryDropItemsGroup";
            this.entryDropItemsGroup.Size = new System.Drawing.Size(219, 177);
            this.entryDropItemsGroup.TabIndex = 9;
            this.entryDropItemsGroup.TabStop = false;
            this.entryDropItemsGroup.Text = "Drop Items (0/256)";
            // 
            // dropItemsProbabilityTextBox
            // 
            this.dropItemsProbabilityTextBox.Location = new System.Drawing.Point(113, 146);
            this.dropItemsProbabilityTextBox.Name = "dropItemsProbabilityTextBox";
            this.dropItemsProbabilityTextBox.Size = new System.Drawing.Size(100, 20);
            this.dropItemsProbabilityTextBox.TabIndex = 2;
            this.dropItemsProbabilityTextBox.TextChanged += new System.EventHandler(this.dropItemsProbabilityTextBox_TextChanged);
            this.dropItemsProbabilityTextBox.Leave += new System.EventHandler(this.dropItemsProbabilityTextBox_Leave);
            // 
            // dropItemsIdTextBox
            // 
            this.dropItemsIdTextBox.Location = new System.Drawing.Point(6, 146);
            this.dropItemsIdTextBox.Name = "dropItemsIdTextBox";
            this.dropItemsIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.dropItemsIdTextBox.TabIndex = 1;
            this.dropItemsIdTextBox.TextChanged += new System.EventHandler(this.dropItemsIdTextBox_TextChanged);
            this.dropItemsIdTextBox.Leave += new System.EventHandler(this.dropItemsIdTextBox_Leave);
            // 
            // dropItemsListBox
            // 
            this.dropItemsListBox.ContextMenuStrip = this.dropItemsMenu;
            this.dropItemsListBox.FormattingEnabled = true;
            this.dropItemsListBox.Location = new System.Drawing.Point(6, 19);
            this.dropItemsListBox.Name = "dropItemsListBox";
            this.dropItemsListBox.Size = new System.Drawing.Size(207, 121);
            this.dropItemsListBox.TabIndex = 0;
            this.dropItemsListBox.SelectedIndexChanged += new System.EventHandler(this.dropItemsListBox_SelectedIndexChanged);
            // 
            // dropItemsMenu
            // 
            this.dropItemsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.deleteToolStripMenuItem1});
            this.dropItemsMenu.Name = "dropItemsMenu";
            this.dropItemsMenu.Size = new System.Drawing.Size(108, 48);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.newToolStripMenuItem1.Text = "New";
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // entryNameTextBox
            // 
            this.entryNameTextBox.Location = new System.Drawing.Point(6, 19);
            this.entryNameTextBox.MaxLength = 128;
            this.entryNameTextBox.Name = "entryNameTextBox";
            this.entryNameTextBox.Size = new System.Drawing.Size(193, 20);
            this.entryNameTextBox.TabIndex = 0;
            this.entryNameTextBox.TextChanged += new System.EventHandler(this.entryNameTextBox_TextChanged);
            this.entryNameTextBox.Leave += new System.EventHandler(this.entryNameTextBox_Leave);
            // 
            // entryNameGroupBox
            // 
            this.entryNameGroupBox.Controls.Add(this.entryNameTextBox);
            this.entryNameGroupBox.Location = new System.Drawing.Point(192, 27);
            this.entryNameGroupBox.Name = "entryNameGroupBox";
            this.entryNameGroupBox.Size = new System.Drawing.Size(205, 54);
            this.entryNameGroupBox.TabIndex = 10;
            this.entryNameGroupBox.TabStop = false;
            this.entryNameGroupBox.Text = "Name";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 417);
            this.Controls.Add(this.entryNameGroupBox);
            this.Controls.Add(this.entryDropItemsGroup);
            this.Controls.Add(this.entryDropNumProbabilitiesGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.entryTypeGroup);
            this.Controls.Add(this.entryMonstersGroup);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextbox);
            this.Controls.Add(this.entriesListBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "mEXTRADROPSedit - new";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.entriesListBoxMenu.ResumeLayout(false);
            this.entryMonstersGroup.ResumeLayout(false);
            this.entryMonstersGroup.PerformLayout();
            this.monstersListBoxMenu.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.entryTypeGroup.ResumeLayout(false);
            this.entryDropNumProbabilitiesGroup.ResumeLayout(false);
            this.entryDropNumProbabilitiesGroup.PerformLayout();
            this.entryDropItemsGroup.ResumeLayout(false);
            this.entryDropItemsGroup.PerformLayout();
            this.dropItemsMenu.ResumeLayout(false);
            this.entryNameGroupBox.ResumeLayout(false);
            this.entryNameGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker fileWorker;
        private System.Windows.Forms.ListBox entriesListBox;
        private System.Windows.Forms.TextBox searchTextbox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.GroupBox entryMonstersGroup;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ComboBox entryTypeDropdown;
        private System.Windows.Forms.GroupBox entryTypeGroup;
        private System.Windows.Forms.GroupBox entryDropNumProbabilitiesGroup;
        private System.Windows.Forms.TextBox entryDrop3Textbox;
        private System.Windows.Forms.Label entryDrop3Label;
        private System.Windows.Forms.TextBox entryDrop2Textbox;
        private System.Windows.Forms.Label entryDrop2Label;
        private System.Windows.Forms.TextBox entryDrop1Textbox;
        private System.Windows.Forms.Label entryDrop1Label;
        private System.Windows.Forms.TextBox entryDrop0Textbox;
        private System.Windows.Forms.Label entryDrop0Label;
        private System.Windows.Forms.TextBox entryDrop7Textbox;
        private System.Windows.Forms.Label entryDrop7Label;
        private System.Windows.Forms.TextBox entryDrop6Textbox;
        private System.Windows.Forms.Label entryDrop6Label;
        private System.Windows.Forms.TextBox entryDrop5Textbox;
        private System.Windows.Forms.Label entryDrop5Label;
        private System.Windows.Forms.TextBox entryDrop4Textbox;
        private System.Windows.Forms.Label entryDrop4Label;
        private System.Windows.Forms.GroupBox entryDropItemsGroup;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ContextMenuStrip entriesListBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem newEntryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneEntryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteEntryMenuItem;
        private System.Windows.Forms.TextBox entryNameTextBox;
        private System.Windows.Forms.GroupBox entryNameGroupBox;
        private System.Windows.Forms.TextBox monstersIdTextBox;
        private System.Windows.Forms.ListBox monstersListBox;
        private System.Windows.Forms.TextBox dropItemsProbabilityTextBox;
        private System.Windows.Forms.TextBox dropItemsIdTextBox;
        private System.Windows.Forms.ListBox dropItemsListBox;
        private System.Windows.Forms.ContextMenuStrip monstersListBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip dropItemsMenu;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem checkProbabilitiesToolStripMenuItem;
    }
}

