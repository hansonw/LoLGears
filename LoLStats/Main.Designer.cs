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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
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
      this.menuStrip1.Size = new System.Drawing.Size(834, 24);
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
      this.tabControl1.Location = new System.Drawing.Point(12, 27);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(810, 423);
      this.tabControl1.TabIndex = 3;
      this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabSelected);
      // 
      // tabPage1
      // 
      this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
      this.tabPage1.Controls.Add(this.summonerTable);
      this.tabPage1.Location = new System.Drawing.Point(4, 22);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage1.Size = new System.Drawing.Size(802, 397);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Summoner List";
      // 
      // summonerTable
      // 
      this.summonerTable.AllowUserToAddRows = false;
      this.summonerTable.AllowUserToDeleteRows = false;
      this.summonerTable.AllowUserToResizeRows = false;
      dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.summonerTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle13;
      this.summonerTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.summonerTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.summonerTable.BackgroundColor = System.Drawing.Color.White;
      this.summonerTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.summonerTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.summonerTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
      this.summonerTable.ColumnHeadersHeight = 20;
      this.summonerTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.summonerTable.DefaultCellStyle = dataGridViewCellStyle15;
      this.summonerTable.Location = new System.Drawing.Point(6, 6);
      this.summonerTable.MultiSelect = false;
      this.summonerTable.Name = "summonerTable";
      this.summonerTable.ReadOnly = true;
      dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.summonerTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle16;
      this.summonerTable.RowHeadersVisible = false;
      this.summonerTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.summonerTable.Size = new System.Drawing.Size(790, 385);
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
      this.tabPage2.Location = new System.Drawing.Point(4, 22);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage2.Size = new System.Drawing.Size(802, 397);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Game List";
      // 
      // resetButton
      // 
      this.resetButton.Location = new System.Drawing.Point(751, 4);
      this.resetButton.Name = "resetButton";
      this.resetButton.Size = new System.Drawing.Size(45, 23);
      this.resetButton.TabIndex = 15;
      this.resetButton.Text = "Reset";
      this.resetButton.UseVisualStyleBackColor = true;
      this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
      // 
      // goButton
      // 
      this.goButton.Location = new System.Drawing.Point(709, 4);
      this.goButton.Name = "goButton";
      this.goButton.Size = new System.Drawing.Size(36, 23);
      this.goButton.TabIndex = 14;
      this.goButton.Text = "Go";
      this.goButton.UseVisualStyleBackColor = true;
      this.goButton.Click += new System.EventHandler(this.goButton_Click);
      // 
      // botGamesCheckbox
      // 
      this.botGamesCheckbox.AutoSize = true;
      this.botGamesCheckbox.Checked = true;
      this.botGamesCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
      this.botGamesCheckbox.Location = new System.Drawing.Point(157, 377);
      this.botGamesCheckbox.Name = "botGamesCheckbox";
      this.botGamesCheckbox.Size = new System.Drawing.Size(113, 17);
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
      this.spectateCheckbox.Location = new System.Drawing.Point(6, 377);
      this.spectateCheckbox.Name = "spectateCheckbox";
      this.spectateCheckbox.Size = new System.Drawing.Size(145, 17);
      this.spectateCheckbox.TabIndex = 12;
      this.spectateCheckbox.Text = "Include spectated games";
      this.spectateCheckbox.UseVisualStyleBackColor = true;
      this.spectateCheckbox.CheckedChanged += new System.EventHandler(this.spectateCheckbox_CheckedChanged);
      // 
      // currentGameLabel
      // 
      this.currentGameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.currentGameLabel.Location = new System.Drawing.Point(646, 378);
      this.currentGameLabel.Name = "currentGameLabel";
      this.currentGameLabel.Size = new System.Drawing.Size(150, 13);
      this.currentGameLabel.TabIndex = 11;
      this.currentGameLabel.Text = "Game 0/0";
      this.currentGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // championSearch
      // 
      this.championSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.championSearch.Location = new System.Drawing.Point(594, 6);
      this.championSearch.Name = "championSearch";
      this.championSearch.Size = new System.Drawing.Size(109, 20);
      this.championSearch.TabIndex = 10;
      this.championSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldKeyDown);
      // 
      // label3
      // 
      this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(522, 9);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(66, 13);
      this.label3.TabIndex = 9;
      this.label3.Text = "or Champion";
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(279, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(111, 13);
      this.label2.TabIndex = 8;
      this.label2.Text = "Search by: Summoner";
      // 
      // summonerSearch
      // 
      this.summonerSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.summonerSearch.Location = new System.Drawing.Point(396, 6);
      this.summonerSearch.Name = "summonerSearch";
      this.summonerSearch.Size = new System.Drawing.Size(120, 20);
      this.summonerSearch.TabIndex = 7;
      this.summonerSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FieldKeyDown);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(6, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(31, 13);
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
            "Crystal Scar",
            "Other"});
      this.mapComboBox.Location = new System.Drawing.Point(43, 6);
      this.mapComboBox.Name = "mapComboBox";
      this.mapComboBox.Size = new System.Drawing.Size(121, 21);
      this.mapComboBox.TabIndex = 5;
      this.mapComboBox.SelectedIndexChanged += new System.EventHandler(this.mapComboBox_SelectedIndexChanged);
      // 
      // gameTable
      // 
      this.gameTable.AllowUserToAddRows = false;
      this.gameTable.AllowUserToDeleteRows = false;
      this.gameTable.AllowUserToResizeRows = false;
      dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.gameTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
      this.gameTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gameTable.BackgroundColor = System.Drawing.Color.White;
      this.gameTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.gameTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gameTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
      this.gameTable.ColumnHeadersHeight = 20;
      this.gameTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.gameTable.DefaultCellStyle = dataGridViewCellStyle11;
      this.gameTable.Location = new System.Drawing.Point(6, 33);
      this.gameTable.MultiSelect = false;
      this.gameTable.Name = "gameTable";
      this.gameTable.ReadOnly = true;
      dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gameTable.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
      this.gameTable.RowHeadersVisible = false;
      this.gameTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gameTable.Size = new System.Drawing.Size(790, 338);
      this.gameTable.TabIndex = 4;
      this.gameTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.gameTableCellFormatting);
      this.gameTable.CurrentCellChanged += new System.EventHandler(this.gameTableCellChange);
      this.gameTable.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataBindingComplete);
      // 
      // Main
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(834, 462);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.menuStrip1);
      this.DoubleBuffered = true;
      this.MainMenuStrip = this.menuStrip1;
      this.MinimumSize = new System.Drawing.Size(850, 500);
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

