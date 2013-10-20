namespace LoLStats
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
      this.linkLabel1 = new System.Windows.Forms.LinkLabel();
      this.button1 = new System.Windows.Forms.Button();
      this.linkLabel2 = new System.Windows.Forms.LinkLabel();
      this.SuspendLayout();
      // 
      // versionLabel
      // 
      this.versionLabel.AutoSize = true;
      this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.versionLabel.Location = new System.Drawing.Point(9, 9);
      this.versionLabel.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.versionLabel.Name = "versionLabel";
      this.versionLabel.Size = new System.Drawing.Size(158, 32);
      this.versionLabel.TabIndex = 0;
      this.versionLabel.Text = "LoLStats 1.0.0";
      // 
      // linkLabel1
      // 
      this.linkLabel1.AutoSize = true;
      this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(8, 34);
      this.linkLabel1.Location = new System.Drawing.Point(15, 51);
      this.linkLabel1.Margin = new System.Windows.Forms.Padding(0, 10, 3, 0);
      this.linkLabel1.Name = "linkLabel1";
      this.linkLabel1.Size = new System.Drawing.Size(248, 21);
      this.linkLabel1.TabIndex = 1;
      this.linkLabel1.TabStop = true;
      this.linkLabel1.Text = "Github: http://github.com/hansonw/LoLStats";
      this.linkLabel1.UseCompatibleTextRendering = true;
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
      // linkLabel2
      // 
      this.linkLabel2.AutoSize = true;
      this.linkLabel2.LinkArea = new System.Windows.Forms.LinkArea(7, 20);
      this.linkLabel2.Location = new System.Drawing.Point(15, 72);
      this.linkLabel2.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
      this.linkLabel2.Name = "linkLabel2";
      this.linkLabel2.Size = new System.Drawing.Size(174, 21);
      this.linkLabel2.TabIndex = 3;
      this.linkLabel2.TabStop = true;
      this.linkLabel2.Text = "Email: hanson.wng@gmail.com";
      this.linkLabel2.UseCompatibleTextRendering = true;
      // 
      // AboutDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(305, 143);
      this.Controls.Add(this.linkLabel2);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.linkLabel1);
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
    private System.Windows.Forms.LinkLabel linkLabel1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.LinkLabel linkLabel2;
  }
}