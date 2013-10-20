namespace LoLGears
{
  partial class GameDetails
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameDetails));
      this.headerLabel = new System.Windows.Forms.Label();
      this.dateLabel = new System.Windows.Forms.Label();
      this.lengthLabel = new System.Windows.Forms.Label();
      this.blueTeamFlow = new System.Windows.Forms.FlowLayoutPanel();
      this.purpleTeamFlow = new System.Windows.Forms.FlowLayoutPanel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.resultLabel = new System.Windows.Forms.Label();
      this.resultDisclaimer = new System.Windows.Forms.ToolTip(this.components);
      this.closeButton = new System.Windows.Forms.Button();
      this.deathsLabel = new System.Windows.Forms.LinkLabel();
      this.viewGameLogButton = new System.Windows.Forms.Button();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // headerLabel
      // 
      this.headerLabel.AutoSize = true;
      this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.headerLabel.Location = new System.Drawing.Point(7, 9);
      this.headerLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.headerLabel.Name = "headerLabel";
      this.headerLabel.Size = new System.Drawing.Size(305, 25);
      this.headerLabel.TabIndex = 0;
      this.headerLabel.Text = "Summoner\'s Rift, 5v5 (Co-op. vs AI)";
      // 
      // dateLabel
      // 
      this.dateLabel.AutoSize = true;
      this.dateLabel.Location = new System.Drawing.Point(9, 37);
      this.dateLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.dateLabel.Name = "dateLabel";
      this.dateLabel.Size = new System.Drawing.Size(324, 15);
      this.dateLabel.TabIndex = 1;
      this.dateLabel.Text = "Played on MM, dd, YYYY HH:mm XM on NA (version 3.1.23)";
      // 
      // lengthLabel
      // 
      this.lengthLabel.AutoSize = true;
      this.lengthLabel.Location = new System.Drawing.Point(9, 55);
      this.lengthLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.lengthLabel.Name = "lengthLabel";
      this.lengthLabel.Size = new System.Drawing.Size(116, 15);
      this.lengthLabel.TabIndex = 2;
      this.lengthLabel.Text = "Game length: mm:ss";
      // 
      // blueTeamFlow
      // 
      this.blueTeamFlow.Location = new System.Drawing.Point(9, 80);
      this.blueTeamFlow.Margin = new System.Windows.Forms.Padding(0, 10, 3, 3);
      this.blueTeamFlow.Name = "blueTeamFlow";
      this.blueTeamFlow.Size = new System.Drawing.Size(240, 110);
      this.blueTeamFlow.TabIndex = 3;
      // 
      // purpleTeamFlow
      // 
      this.purpleTeamFlow.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
      this.purpleTeamFlow.Location = new System.Drawing.Point(285, 80);
      this.purpleTeamFlow.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
      this.purpleTeamFlow.Name = "purpleTeamFlow";
      this.purpleTeamFlow.Size = new System.Drawing.Size(240, 110);
      this.purpleTeamFlow.TabIndex = 4;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.resultLabel);
      this.panel1.Location = new System.Drawing.Point(359, 9);
      this.panel1.Margin = new System.Windows.Forms.Padding(0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(166, 47);
      this.panel1.TabIndex = 6;
      // 
      // resultLabel
      // 
      this.resultLabel.AutoSize = true;
      this.resultLabel.BackColor = System.Drawing.Color.Silver;
      this.resultLabel.Dock = System.Windows.Forms.DockStyle.Right;
      this.resultLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.resultLabel.ForeColor = System.Drawing.SystemColors.ControlText;
      this.resultLabel.Location = new System.Drawing.Point(46, 0);
      this.resultLabel.Margin = new System.Windows.Forms.Padding(0);
      this.resultLabel.Name = "resultLabel";
      this.resultLabel.Padding = new System.Windows.Forms.Padding(5);
      this.resultLabel.Size = new System.Drawing.Size(120, 35);
      this.resultLabel.TabIndex = 7;
      this.resultLabel.Text = "UNKNOWN";
      // 
      // resultDisclaimer
      // 
      this.resultDisclaimer.AutomaticDelay = 100;
      // 
      // closeButton
      // 
      this.closeButton.Location = new System.Drawing.Point(450, 230);
      this.closeButton.Margin = new System.Windows.Forms.Padding(0);
      this.closeButton.Name = "closeButton";
      this.closeButton.Size = new System.Drawing.Size(75, 23);
      this.closeButton.TabIndex = 7;
      this.closeButton.Text = "&Close";
      this.closeButton.UseVisualStyleBackColor = true;
      this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
      // 
      // deathsLabel
      // 
      this.deathsLabel.AutoSize = true;
      this.deathsLabel.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
      this.deathsLabel.Location = new System.Drawing.Point(9, 203);
      this.deathsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.deathsLabel.Name = "deathsLabel";
      this.deathsLabel.Size = new System.Drawing.Size(157, 15);
      this.deathsLabel.TabIndex = 8;
      this.deathsLabel.Text = "You had X deaths this game.";
      this.deathsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.showDeaths);
      // 
      // viewGameLogButton
      // 
      this.viewGameLogButton.Location = new System.Drawing.Point(10, 230);
      this.viewGameLogButton.Name = "viewGameLogButton";
      this.viewGameLogButton.Size = new System.Drawing.Size(113, 23);
      this.viewGameLogButton.TabIndex = 9;
      this.viewGameLogButton.Text = "&View game log...";
      this.viewGameLogButton.UseVisualStyleBackColor = true;
      this.viewGameLogButton.Click += new System.EventHandler(this.viewGameLog_Click);
      // 
      // GameDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(534, 262);
      this.Controls.Add(this.viewGameLogButton);
      this.Controls.Add(this.deathsLabel);
      this.Controls.Add(this.closeButton);
      this.Controls.Add(this.purpleTeamFlow);
      this.Controls.Add(this.blueTeamFlow);
      this.Controls.Add(this.lengthLabel);
      this.Controls.Add(this.dateLabel);
      this.Controls.Add(this.headerLabel);
      this.Controls.Add(this.panel1);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "GameDetails";
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.Text = "Game Details";
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label headerLabel;
    private System.Windows.Forms.Label dateLabel;
    private System.Windows.Forms.Label lengthLabel;
    private System.Windows.Forms.FlowLayoutPanel blueTeamFlow;
    private System.Windows.Forms.FlowLayoutPanel purpleTeamFlow;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Label resultLabel;
    private System.Windows.Forms.ToolTip resultDisclaimer;
    private System.Windows.Forms.Button closeButton;
    private System.Windows.Forms.LinkLabel deathsLabel;
    private System.Windows.Forms.Button viewGameLogButton;
  }
}