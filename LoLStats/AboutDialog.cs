using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLStats
{
  public partial class AboutDialog : Form
  {
    public AboutDialog() {
      InitializeComponent();

      versionLabel.Text = "LoLStats " + Application.ProductVersion;
    }

    private void button1_Click(object sender, EventArgs e) {
      Close();
    }
  }
}
