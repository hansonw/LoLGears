namespace LoLStats
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
      this.headerLabel = new System.Windows.Forms.Label();
      this.gamesPlayedLabel = new System.Windows.Forms.Label();
      this.recordLabel = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.gamesLink = new System.Windows.Forms.LinkLabel();
      this.lolkingLink = new System.Windows.Forms.LinkLabel();
      this.flowLayoutPanel1.SuspendLayout();
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
      // gamesPlayedLabel
      // 
      this.gamesPlayedLabel.AutoSize = true;
      this.gamesPlayedLabel.Location = new System.Drawing.Point(12, 45);
      this.gamesPlayedLabel.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
      this.gamesPlayedLabel.Name = "gamesPlayedLabel";
      this.gamesPlayedLabel.Size = new System.Drawing.Size(234, 15);
      this.gamesPlayedLabel.TabIndex = 2;
      this.gamesPlayedLabel.Text = "Games: 123 (as: 123, with: 234, against: 234)";
      // 
      // recordLabel
      // 
      this.recordLabel.AutoSize = true;
      this.recordLabel.Location = new System.Drawing.Point(12, 63);
      this.recordLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
      this.recordLabel.Name = "recordLabel";
      this.recordLabel.Size = new System.Drawing.Size(270, 15);
      this.recordLabel.TabIndex = 3;
      this.recordLabel.Text = "Known record: 123-23 (with: 123-23, against: 12-2)";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.Location = new System.Drawing.Point(9, 91);
      this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(139, 21);
      this.label2.TabIndex = 5;
      this.label2.Text = "Champions Played";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.AutoSize = true;
      this.flowLayoutPanel1.Controls.Add(this.headerLabel);
      this.flowLayoutPanel1.Controls.Add(this.gamesLink);
      this.flowLayoutPanel1.Controls.Add(this.lolkingLink);
      this.flowLayoutPanel1.Location = new System.Drawing.Point(9, 9);
      this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size(247, 25);
      this.flowLayoutPanel1.TabIndex = 7;
      // 
      // gamesLink
      // 
      this.gamesLink.AutoSize = true;
      this.gamesLink.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.gamesLink.Location = new System.Drawing.Point(162, 7);
      this.gamesLink.Margin = new System.Windows.Forms.Padding(0);
      this.gamesLink.Name = "gamesLink";
      this.gamesLink.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
      this.gamesLink.Size = new System.Drawing.Size(42, 18);
      this.gamesLink.TabIndex = 6;
      this.gamesLink.TabStop = true;
      this.gamesLink.Text = "games";
      this.gamesLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.gamesLink_LinkClicked);
      // 
      // lolkingLink
      // 
      this.lolkingLink.AutoSize = true;
      this.lolkingLink.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.lolkingLink.Location = new System.Drawing.Point(204, 7);
      this.lolkingLink.Margin = new System.Windows.Forms.Padding(0);
      this.lolkingLink.Name = "lolkingLink";
      this.lolkingLink.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
      this.lolkingLink.Size = new System.Drawing.Size(43, 18);
      this.lolkingLink.TabIndex = 7;
      this.lolkingLink.TabStop = true;
      this.lolkingLink.Text = "lolking";
      this.lolkingLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lolkingLink_LinkClicked);
      // 
      // SummonerDetails
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size(334, 362);
      this.Controls.Add(this.flowLayoutPanel1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.recordLabel);
      this.Controls.Add(this.gamesPlayedLabel);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "SummonerDetails";
      this.Text = "SummonerDetails";
      this.flowLayoutPanel1.ResumeLayout(false);
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label headerLabel;
    private System.Windows.Forms.Label gamesPlayedLabel;
    private System.Windows.Forms.Label recordLabel;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.LinkLabel gamesLink;
    private System.Windows.Forms.LinkLabel lolkingLink;
  }
}