using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLStats
{
  public class Util
  {
    public static string Sanitize(string s) {
      return new string(s.Where(Char.IsLetter).ToArray()).ToLower();
    }

    /// <summary>
    /// Remove the column header border in the Aero theme in Vista,
    /// but keep it for other themes such as standard and classic.
    /// </summary>
    public static DataGridViewHeaderBorderStyle ProperColumnHeadersBorderStyle {
      get {
        return (SystemFonts.MessageBoxFont.Name == "Segoe UI") ?
          DataGridViewHeaderBorderStyle.None :
          DataGridViewHeaderBorderStyle.Raised;
      }
    }
  }
}
