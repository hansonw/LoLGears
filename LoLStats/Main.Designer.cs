namespace LoLStats
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
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.summonerTable = new System.Windows.Forms.DataGridView();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.resetButton = new System.Windows.Forms.Button();
      this.goButton = new System.Windows.Forms.Button();
      this.botGamesCheckbox = new System.Windows.Forms.CheckBox();
      this.spectateCheckbox = new System.Windows.Forms.CheckBox();
      this.currentGameLabel = new System.Windows.Forms.Label();
      this.championSearch = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.summonerSearch = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.mapComboBox = new System.Windows.Forms.ComboBox();
      this.gameTable = new System.Windows.Forms.DataGridView();
      this.menuStrip1.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.summonerTable)).BeginInit();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gameTable)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(973, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem1});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
      this.exitToolStripMenuItem.Text = "Refresh games...";
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
      // 
      // exitToolStripMenuItem1
      // 
      this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
      this.exitToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
      this.exitToolStripMenuItem1.Text = "Exit";
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
      this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
      this.aboutToolStripMenuItem.Text = "About...";
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Location = new System.Drawing.Point(14, 31);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(945, 488);
      this.tabControl1.TabIndex = 3;
      this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabSelected);
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage1.Controls.Add(this.summonerTable);
      this.tabPage1.Location = new System.Drawing.Point(4, 24);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(937, 460);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Summoner List";
      // 
      // summonerTable
      // 
      this.summonerTable.AllowUserToAddRows = false;
      this.summonerTable.AllowUserToDeleteRows = false;
      this.summonerTable.AllowUserToResizeRows = false;
      dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.summonerTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
      this.summonerTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.summonerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.summonerTable.BackgroundColor = System.Drawing.Color.White;
      this.summonerTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.summonerTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.summonerTable.ColumnHeadersHeight = 20;
      this.summonerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.summonerTable.Location = new System.Drawing.Point(7, 7);
      this.summonerTable.MultiSelect = false;
      this.summonerTable.Name = "summonerTable";
      this.summonerTable.ReadOnly = true;
      this.summonerTable.RowHeadersVisible = false;
      this.summonerTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.summonerTable.Size = new System.Drawing.Size(922, 442);
      this.summonerTable.TabIndex = 3;
      this.summonerTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.summonerTableCellFormatting);
      this.summonerTable.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
      // 
      // tabPage2
      // 
      this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage2.Controls.Add(this.resetButton);
      this.tabPage2.Controls.Add(this.goButton);
      this.tabPage2.Controls.Add(this.botGamesCheckbox);
      this.tabPage2.Controls.Add(this.spectateCheckbox);
      this.tabPage2.Controls.Add(this.currentGameLabel);
      this.tabPage2.Controls.Add(this.championSearch);
      this.tabPage2.Controls.Add(this.label3);
      this.tabPage2.Controls.Add(this.label2);
      this.tabPage2.Controls.Add(this.summonerSearch);
      this.tabPage2.Controls.Add(this.label1);
      this.tabPage2.Controls.Add(this.mapComboBox);
      this.tabPage2.Controls.Add(this.gameTable);
      this.tabPage2.Location = new System.Drawing.Point(4, 24);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(937, 460);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Game List";
      // 
      // resetButton
      // 
      this.resetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.resetButton.Location = new System.Drawing.Point(876, 7);
      this.resetButton.Name = "resetButton";
      this.resetButton.Size = new System.Drawing.Size(52, 23);
      this.resetButton.TabIndex = 15;
      this.resetButton.Text = "Reset";
      this.resetButton.UseVisualStyleBackColor = true;
      this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
      // 
      // goButton
      // 
      this.goButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.goButton.Location = new System.Drawing.Point(828, 7);
      this.goButton.Name = "goButton";
      this.goButton.Size = new System.Drawing.Size(42, 23);
      this.goButton.TabIndex = 14;
      this.goButton.Text = "Go";
      this.goButton.UseVisualStyleBackColor = true;
      this.goButton.Click += new System.EventHandler(this.goButton_Click);
      // 
      // botGamesCheckbox
      // 
      this.botGamesCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.botGamesCheckbox.AutoSize = true;
      this.botGamesCheckbox.Checked = true;
      this.botGamesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.botGamesCheckbox.Location = new System.Drawing.Point(170, 435);
      this.botGamesCheckbox.Name = "botGamesCheckbox";
      this.botGamesCheckbox.Size = new System.Drawing.Size(124, 19);
      this.botGamesCheckbox.TabIndex = 13;
      this.botGamesCheckbox.Text = "Include bot games";
      this.botGamesCheckbox.UseVisualStyleBackColor = true;
      this.botGamesCheckbox.CheckedChanged += new System.EventHandler(this.botGamesCheckbox_CheckedChanged);
      // 
      // spectateCheckbox
      // 
      this.spectateCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.spectateCheckbox.AutoSize = true;
      this.spectateCheckbox.Checked = true;
      this.spectateCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.spectateCheckbox.Location = new System.Drawing.Point(7, 435);
      this.spectateCheckbox.Name = "spectateCheckbox";
      this.spectateCheckbox.Size = new System.Drawing.Size(157, 19);
      this.spectateCheckbox.TabIndex = 12;
      this.spectateCheckbox.Text = "Include spectated games";
      this.spectateCheckbox.UseVisualStyleBackColor = true;
      this.spectateCheckbox.CheckedChanged += new System.EventHandler(this.spectateCheckbox_CheckedChanged);
      // 
      // currentGameLabel
      // 
      this.currentGameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.currentGameLabel.Location = new System.Drawing.Point(754, 436);
      this.currentGameLabel.Name = "currentGameLabel";
      this.currentGameLabel.Size = new System.Drawing.Size(175, 15);
      this.currentGameLabel.TabIndex = 11;
      this.currentGameLabel.Text = "Game 0/0";
      this.currentGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // championSearch
      // 
      this.championSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.championSearch.Location = new System.Drawing.Point(693, 7);
      this.championSearch.Name = "championSearch";
      this.championSearch.Size = new System.Drawing.Size(126, 23);
      this.championSearch.TabIndex = 10;
      this.championSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldKeyDown);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(609, 10);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(77, 15);
      this.label3.TabIndex = 9;
      this.label3.Text = "or Champion";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(325, 10);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(123, 15);
      this.label2.TabIndex = 8;
      this.label2.Text = "Search by: Summoner";
      // 
      // summonerSearch
      // 
      this.summonerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.summonerSearch.Location = new System.Drawing.Point(462, 7);
      this.summonerSearch.Name = "summonerSearch";
      this.summonerSearch.Size = new System.Drawing.Size(139, 23);
      this.summonerSearch.TabIndex = 7;
      this.summonerSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldKeyDown);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 10);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(34, 15);
      this.label1.TabIndex = 6;
      this.label1.Text = "Map:";
      // 
      // mapComboBox
      // 
      this.mapComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.mapComboBox.FormattingEnabled = true;
      this.mapComboBox.Items.AddRange(new object[] {
            "",
            "Summoner\'s Rift",
            "Howling Abyss",
            "Twisted Treeline",
            "Proving Grounds",
            "Crystal Scar"});
      this.mapComboBox.Location = new System.Drawing.Point(50, 7);
      this.mapComboBox.Name = "mapComboBox";
      this.mapComboBox.Size = new System.Drawing.Size(140, 23);
      this.mapComboBox.TabIndex = 5;
      this.mapComboBox.SelectedIndexChanged += new System.EventHandler(this.mapComboBox_SelectedIndexChanged);
      // 
      // gameTable
      // 
      this.gameTable.AllowUserToAddRows = false;
      this.gameTable.AllowUserToDeleteRows = false;
      this.gameTable.AllowUserToResizeRows = false;
      dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.gameTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
      this.gameTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gameTable.BackgroundColor = System.Drawing.Color.White;
      this.gameTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.gameTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.gameTable.ColumnHeadersHeight = 20;
      this.gameTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gameTable.Location = new System.Drawing.Point(7, 36);
      this.gameTable.MultiSelect = false;
      this.gameTable.Name = "gameTable";
      this.gameTable.ReadOnly = true;
      this.gameTable.RowHeadersVisible = false;
      this.gameTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gameTable.Size = new System.Drawing.Size(922, 393);
      this.gameTable.TabIndex = 4;
      this.gameTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewGameDetails);
      this.gameTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gameTableCellFormatting);
      this.gameTable.CurrentCellChanged += new System.EventHandler(this.gameTableCellChange);
      this.gameTable.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(973, 533);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.menuStrip1);
      this.DoubleBuffered = true;
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(989, 571);
      this.Name = "Main";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "LoL Stats";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.summonerTable)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gameTable)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private System.Windows.Forms.DataGridView summonerTable;
    private System.Windows.Forms.TabPage tabPage2;
    private System.Windows.Forms.TextBox championSearch;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox summonerSearch;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox mapComboBox;
    private System.Windows.Forms.DataGridView gameTable;
    private System.Windows.Forms.CheckBox botGamesCheckbox;
    private System.Windows.Forms.CheckBox spectateCheckbox;
    private System.Windows.Forms.Label currentGameLabel;
    private System.Windows.Forms.Button resetButton;
    private System.Windows.Forms.Button goButton;
  }
}

