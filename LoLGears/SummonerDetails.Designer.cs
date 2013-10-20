namespace LoLGears
{
  partial class SummonerDetails
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
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      this.headerLabel = new System.Windows.Forms.Label();
      this.recordLabel = new System.Windows.Forms.Label();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.lolkingLink = new System.Windows.Forms.LinkLabel();
      this.closeButton = new System.Windows.Forms.Button();
      this.gamesPlayedLabel = new System.Windows.Forms.LinkLabel();
      this.timeLabel = new System.Windows.Forms.Label();
      this.tabControl = new System.Windows.Forms.TabControl();
      this.championStatsPage = new System.Windows.Forms.TabPage();
      this.championTable = new System.Windows.Forms.DataGridView();
      this.deathStatsPage = new System.Windows.Forms.TabPage();
      this.deathTable = new System.Windows.Forms.DataGridView();
      this.flowLayoutPanel1.SuspendLayout();
      this.tabControl.SuspendLayout();
      this.championStatsPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.championTable)).BeginInit();
      this.deathStatsPage.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.deathTable)).BeginInit();
      this.SuspendLayout();
      // 
      // headerLabel
      // 
      this.headerLabel.AutoSize = true;
      this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.headerLabel.Location = new System.Drawing.Point(0, 0);
      this.headerLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.headerLabel.Name = "headerLabel";
      this.headerLabel.Size = new System.Drawing.Size(159, 25);
      this.headerLabel.TabIndex = 1;
      this.headerLabel.Text = "Summoner Name";
      // 
      // recordLabel
      // 
      this.recordLabel.AutoSize = true;
      this.recordLabel.Location = new System.Drawing.Point(11, 62);
      this.recordLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.recordLabel.Name = "recordLabel";
      this.recordLabel.Size = new System.Drawing.Size(270, 15);
      this.recordLabel.TabIndex = 3;
      this.recordLabel.Text = "Known record: 123-23 (with: 123-23, against: 12-2)";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.headerLabel);
      this.flowLayoutPanel1.Controls.Add(this.lolkingLink);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 9);
      this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 25);
      this.flowLayoutPanel1.TabIndex = 7;
      // 
      // lolkingLink
      // 
      this.lolkingLink.AutoSize = true;
      this.lolkingLink.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lolkingLink.Location = new System.Drawing.Point(162, 7);
      this.lolkingLink.Margin = new System.Windows.Forms.Padding(0);
      this.lolkingLink.Name = "lolkingLink";
      this.lolkingLink.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
      this.lolkingLink.Size = new System.Drawing.Size(43, 18);
      this.lolkingLink.TabIndex = 7;
      this.lolkingLink.TabStop = true;
      this.lolkingLink.Text = "lolking";
      this.lolkingLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lolkingLink_LinkClicked);
      // 
      // closeButton
      // 
      this.closeButton.Location = new System.Drawing.Point(257, 349);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 9;
      this.closeButton.Text = "Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // gamesPlayedLabel
      // 
      this.gamesPlayedLabel.AutoSize = true;
      this.gamesPlayedLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
      this.gamesPlayedLabel.Location = new System.Drawing.Point(11, 44);
      this.gamesPlayedLabel.Margin = new System.Windows.Forms.Padding(0);
      this.gamesPlayedLabel.Name = "gamesPlayedLabel";
      this.gamesPlayedLabel.Size = new System.Drawing.Size(196, 15);
      this.gamesPlayedLabel.TabIndex = 13;
      this.gamesPlayedLabel.Text = "Games: 123 (as: x, with: y, against: z)";
      this.gamesPlayedLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gamesLinkClicked);
      // 
      // timeLabel
      // 
      this.timeLabel.AutoSize = true;
      this.timeLabel.Location = new System.Drawing.Point(11, 80);
      this.timeLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.timeLabel.Name = "timeLabel";
      this.timeLabel.Size = new System.Drawing.Size(156, 15);
      this.timeLabel.TabIndex = 14;
      this.timeLabel.Text = "Total time logged: 1d 2h 3m";
      // 
      // tabControl
      // 
      this.tabControl.Controls.Add(this.championStatsPage);
      this.tabControl.Controls.Add(this.deathStatsPage);
      this.tabControl.Location = new System.Drawing.Point(14, 110);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(318, 233);
      this.tabControl.TabIndex = 15;
      // 
      // championStatsPage
      // 
      this.championStatsPage.BackColor = System.Drawing.SystemColors.ControlLight;
      this.championStatsPage.Controls.Add(this.championTable);
      this.championStatsPage.Location = new System.Drawing.Point(4, 24);
      this.championStatsPage.Name = "championStatsPage";
      this.championStatsPage.Padding = new System.Windows.Forms.Padding(3);
      this.championStatsPage.Size = new System.Drawing.Size(310, 205);
      this.championStatsPage.TabIndex = 0;
      this.championStatsPage.Text = "Champion Stats";
      this.championStatsPage.UseVisualStyleBackColor = true;
      // 
      // championTable
      // 
      this.championTable.AllowUserToAddRows = false;
      this.championTable.AllowUserToDeleteRows = false;
      this.championTable.AllowUserToResizeRows = false;
      dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.championTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
      this.championTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.championTable.BackgroundColor = System.Drawing.Color.White;
      this.championTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.championTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.championTable.ColumnHeadersHeight = 20;
      this.championTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.championTable.Location = new System.Drawing.Point(3, 3);
      this.championTable.Margin = new System.Windows.Forms.Padding(0);
      this.championTable.MultiSelect = false;
      this.championTable.Name = "championTable";
      this.championTable.ReadOnly = true;
      this.championTable.RowHeadersVisible = false;
      this.championTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.championTable.Size = new System.Drawing.Size(304, 199);
      this.championTable.TabIndex = 12;
      this.championTable.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.showChampionGames);
      this.championTable.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.championTableCellFormatting);
      // 
      // deathStatsPage
      // 
      this.deathStatsPage.BackColor = System.Drawing.SystemColors.ControlLight;
      this.deathStatsPage.Controls.Add(this.deathTable);
      this.deathStatsPage.Location = new System.Drawing.Point(4, 24);
      this.deathStatsPage.Name = "deathStatsPage";
      this.deathStatsPage.Padding = new System.Windows.Forms.Padding(3);
      this.deathStatsPage.Size = new System.Drawing.Size(310, 205);
      this.deathStatsPage.TabIndex = 1;
      this.deathStatsPage.Text = "Death Stats";
      this.deathStatsPage.UseVisualStyleBackColor = true;
      // 
      // deathTable
      // 
      this.deathTable.AllowUserToAddRows = false;
      this.deathTable.AllowUserToDeleteRows = false;
      this.deathTable.AllowUserToResizeRows = false;
      dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.deathTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
      this.deathTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.deathTable.BackgroundColor = System.Drawing.Color.White;
      this.deathTable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.deathTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      this.deathTable.ColumnHeadersHeight = 20;
      this.deathTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.deathTable.Location = new System.Drawing.Point(3, 3);
      this.deathTable.Margin = new System.Windows.Forms.Padding(0);
      this.deathTable.MultiSelect = false;
      this.deathTable.Name = "deathTable";
      this.deathTable.ReadOnly = true;
      this.deathTable.RowHeadersVisible = false;
      this.deathTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.deathTable.Size = new System.Drawing.Size(304, 199);
      this.deathTable.TabIndex = 13;
      // 
      // SummonerDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(344, 384);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.timeLabel);
      this.Controls.Add(this.gamesPlayedLabel);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Controls.Add(this.recordLabel);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "SummonerDetails";
      this.Text = "Summoner Details";
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.tabControl.ResumeLayout(false);
      this.championStatsPage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.championTable)).EndInit();
      this.deathStatsPage.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.deathTable)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label headerLabel;
    private System.Windows.Forms.Label recordLabel;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.LinkLabel lolkingLink;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.LinkLabel gamesPlayedLabel;
    private System.Windows.Forms.Label timeLabel;
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage championStatsPage;
    private System.Windows.Forms.DataGridView championTable;
    private System.Windows.Forms.TabPage deathStatsPage;
    private System.Windows.Forms.DataGridView deathTable;
  }
}