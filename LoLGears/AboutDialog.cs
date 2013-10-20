using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLGears
{
  public partial class AboutDialog : Form
  {
    public AboutDialog() {
      InitializeComponent();

      versionLabel.Text = "LoLGears v" + Application.ProductVersion;
    }

    private void button1_Click(object sender, EventArgs e) {
      Close();
    }

    private void linkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
      var label = (LinkLabel) sender;
      string link = label.Text.Substring(e.Link.Start, e.Link.Length);
      if (link.Contains('@')) {
        link = "mailto:" + link;
      }
      Process.Start(link);
    }
  }
}
