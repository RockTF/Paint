using System;
using System.Drawing;

namespace NewPaitnt.Implementation
{
    public static class HexColorConverter
    {
        public static Color HexToColor(string hexColor)
        {
            Color color;
            if (hexColor.Length == 9)
            {
                int A = Convert.ToInt32(hexColor.Substring(1, 2), 16);
                int R = Convert.ToInt32(hexColor.Substring(3, 2), 16);
                int G = Convert.ToInt32(hexColor.Substring(5, 2), 16);
                int B = Convert.ToInt32(hexColor.Substring(7, 2), 16);
                color = Color.FromArgb(A, R, G, B);
            }
            else if (hexColor.Length == 7)
            {
                int R = Convert.ToInt32(hexColor.Substring(1, 2), 16);
                int G = Convert.ToInt32(hexColor.Substring(3, 2), 16);
                int B = Convert.ToInt32(hexColor.Substring(5, 2), 16);
                color = Color.FromArgb(R, G, B);
            }
            else
            {
                throw new ArgumentException("Invalid hex color");
            }
            return color;
        }
        public static string ColorToHex(Color color)
        {
            string hexColor = "#";
            hexColor += color.A.ToString("X2");
            hexColor += color.R.ToString("X2");
            hexColor += color.G.ToString("X2");
            hexColor += color.B.ToString("X2");
            return hexColor;
        }
    }
}
