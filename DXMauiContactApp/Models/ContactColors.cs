using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXMauiContactApp.Models
{
    public class ContactColors
    {
        public static Color GetRandomColor()
        {
            return GetColor(new Random().Next(10));
        }
        public static Color GetColor(int colorNumber)
        {
            switch (colorNumber)
            {
                case 1: return Color.FromArgb("#f15558");
                case 2: return Color.FromArgb("#ff7c11");
                case 3: return Color.FromArgb("#ffbf22");
                case 4: return Color.FromArgb("#ff6e86");
                case 5: return Color.FromArgb("#9865b0");
                case 6: return Color.FromArgb("#756cfd");
                case 7: return Color.FromArgb("#0055d8");
                case 8: return Color.FromArgb("#01b0ee");
                case 9: return Color.FromArgb("#0097ad");
                case 0: return Color.FromArgb("#00c831");
                default: return Color.FromArgb("#949494");
            }
        }
    }
}
