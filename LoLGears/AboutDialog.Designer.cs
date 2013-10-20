namespace LoLGears
{
  partial class AboutDialog
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
      this.versionLabel = new System.Windows.Forms.Label();
      this.githubLink = new System.Windows.Forms.LinkLabel();
      this.button1 = new System.Windows.Forms.Button();
      this.emailLink = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // versionLabel
      // 
      this.versionLabel.AutoSize = true;
      this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.versionLabel.Location = new System.Drawing.Point(9, 9);
      this.versionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(129, 32);
      this.versionLabel.TabIndex = 0;
      this.versionLabel.Text = "LoLGears v";
      // 
      // githubLink
      // 
      this.githubLink.AutoSize = true;
      this.githubLink.LinkArea = new System.Windows.Forms.LinkArea(8, 34);
      this.githubLink.Location = new System.Drawing.Point(15, 51);
      this.githubLink.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
      this.githubLink.Name = "githubLink";
      this.githubLink.Size = new System.Drawing.Size(252, 21);
      this.githubLink.TabIndex = 1;
      this.githubLink.TabStop = true;
      this.githubLink.Text = "Github: http://github.com/hansonw/LoLGears";
      this.githubLink.UseCompatibleTextRendering = true;
      this.githubLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(218, 108);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(75, 23);
      this.button1.TabIndex = 2;
      this.button1.Text = "&OK";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // emailLink
      // 
      this.emailLink.AutoSize = true;
      this.emailLink.LinkArea = new System.Windows.Forms.LinkArea(23, 20);
      this.emailLink.Location = new System.Drawing.Point(15, 72);
      this.emailLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.emailLink.Name = "emailLink";
      this.emailLink.Size = new System.Drawing.Size(271, 21);
      this.emailLink.TabIndex = 3;
      this.emailLink.TabStop = true;
      this.emailLink.Text = "Send feedback/bugs to: hanson.wng@gmail.com";
      this.emailLink.UseCompatibleTextRendering = true;
      this.emailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
      // 
      // AboutDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(305, 143);
      this.Controls.Add(this.emailLink);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.githubLink);
      this.Controls.Add(this.versionLabel);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.Name = "AboutDialog";
      this.Text = "About";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label versionLabel;
    private System.Windows.Forms.LinkLabel githubLink;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.LinkLabel emailLink;
  }
}