using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoLGears
{
  public class Util
  {
    public static string Sanitize(string s) {
      return new string(s.Where(Char.IsLetter).ToArray()).ToLower();
    }

    public static string FormatTime(int seconds) {
      if (seconds == 0) return "0 seconds";

      string[] unitNames = {"sec", "min", "hr", "day"};
      int[] units = {60, 60, 24, int.MaxValue};
      var ret = new List<String>();
      for (int i = 0; i < units.Length && seconds > 0; i++) {
        int x = seconds % units[i];
        if (x > 0) {
          ret.Insert(0, (x + " " + unitNames[i] + (x == 1 ? "" : "s")));
        }
        seconds /= units[i];
      }

      return String.Join(", ", ret.ToArray());
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
