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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
      this.nameLabel = new System.Windows.Forms.Label();
      this.githubLink = new System.Windows.Forms.LinkLabel();
      this.button1 = new System.Windows.Forms.Button();
      this.emailLink = new System.Windows.Forms.LinkLabel();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.versionLabel = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // nameLabel
      // 
      this.nameLabel.AutoSize = true;
      this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.nameLabel.Location = new System.Drawing.Point(66, 9);
      this.nameLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.nameLabel.Name = "nameLabel";
      this.nameLabel.Size = new System.Drawing.Size(110, 32);
      this.nameLabel.TabIndex = 0;
      this.nameLabel.Text = "LoLGears";
      // 
      // githubLink
      // 
      this.githubLink.AutoSize = true;
      this.githubLink.LinkArea = new System.Windows.Forms.LinkArea(8, 34);
      this.githubLink.Location = new System.Drawing.Point(15, 72);
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
      this.button1.Location = new System.Drawing.Point(218, 127);
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
      this.emailLink.Location = new System.Drawing.Point(15, 93);
      this.emailLink.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.emailLink.Name = "emailLink";
      this.emailLink.Size = new System.Drawing.Size(271, 21);
      this.emailLink.TabIndex = 3;
      this.emailLink.TabStop = true;
      this.emailLink.Text = "Send feedback/bugs to: hanson.wng@gmail.com";
      this.emailLink.UseCompatibleTextRendering = true;
      this.emailLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkClicked);
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(15, 12);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.TabIndex = 4;
      this.pictureBox1.TabStop = false;
      // 
      // versionLabel
      // 
      this.versionLabel.AutoSize = true;
      this.versionLabel.Location = new System.Drawing.Point(69, 45);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(60, 15);
      this.versionLabel.TabIndex = 5;
      this.versionLabel.Text = "version ....";
      // 
      // AboutDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(305, 162);
      this.Controls.Add(this.versionLabel);
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.emailLink);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.githubLink);
      this.Controls.Add(this.nameLabel);
      this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.Name = "AboutDialog";
      this.Text = "About";
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.LinkLabel githubLink;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.LinkLabel emailLink;
    private System.Windows.Forms.Label nameLabel;
    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Label versionLabel;
  }
}