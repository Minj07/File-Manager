using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;

namespace FileManager
{
    internal class Theme
    {
        public Color main;
        public Color lighterMain;
        public Color darkerMain;
        public Color text;
        public Color Unused;
        public Theme(Color main)
        {
            this.main = main;
            lighterMain = Color.FromArgb(increase(main.R),increase(main.G),increase(main.B));
            darkerMain = Color.FromArgb(decrease(main.R),decrease(main.G),decrease(main.B));
            text = Color.FromArgb(255 - main.R, 255 - main.G, 255 - main.B);
            Random random = new Random();
            do
            {
                //Unused = Color.FromArgb(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
                Unused = Color.Azure;
            } while ((new Color[] { main, lighterMain, darkerMain, text }).Contains(Unused));
        }
        public Theme(Theme theme)
        {
            main = theme.main;
            lighterMain = theme.darkerMain;
            darkerMain = theme.darkerMain;
            text = theme.text;
        }

        public static Color HexColor(string h)
        {
            Exception InvalidHexadecimal = new Exception("Invalid Hexadecimal");
            Exception InvalidHexColor = new Exception("Invalid Hex Color");
            CultureInfo ci = new CultureInfo("en-US");
            if (h[0] == '#'&&h.Length==7) h = h.Substring(1, 6);
            if (h.Length!=6) throw InvalidHexColor;
            foreach (char c in h)
            {
                if (!"0123456789ABCDEF".Contains(c))
                {
                    throw InvalidHexadecimal;
                }
            }
            if (h.Length != 6)
            {
                throw InvalidHexadecimal;
            }
            return Color.FromArgb(int.Parse(h.Substring(0,2),NumberStyles.HexNumber), int.Parse(h.Substring(2, 2), NumberStyles.HexNumber), int.Parse(h.Substring(4, 2), NumberStyles.HexNumber));
        }

        private int increase(int i)
        {
            return (255 - i) / 10 + i;
        }

        private int decrease(int i)
        {
            return i - (i / 10);
        }
        
        private Bitmap Recolor(Bitmap input)
        {
            for (int i =0 ; i < input.Width; i++)
            {
                for (int j =0 ; j < input.Height; j++)
                {
                    if (input.GetPixel(i,j).A > 0)
                    {
                        input.SetPixel(i, j, Color.FromArgb(text.R,text.G,text.B, input.GetPixel(i, j).A));
                    }
                }
            }
            return input;
        }

        public enum icon
        {
            left_arrow = 1,
            right_arrow = 2,
            expand_arrow = 3,
            up_arrow = 4,
            new_file = 5,
            reboot = 6,
        }

        public Bitmap getIcon(icon input)
        {
            Bitmap temp;
            switch (input)
            {
                case icon.left_arrow: temp = Properties.Resources.left_arrow;
                    break;
                case icon.right_arrow: temp = Properties.Resources.right_arrow;
                    break;
                case icon.expand_arrow: temp = Properties.Resources.expand_arrow;
                    break;
                case icon.up_arrow: temp = Properties.Resources.up_arrow;
                    break;
                case icon.new_file: temp = Properties.Resources.new_file;
                    break;
                case icon.reboot: temp = Properties.Resources.reboot;
                    break;
                default: temp = Properties.Resources.reboot; break;
            }
            return Recolor(temp);
        }

        public void test(Control c)
        {
            MessageBox.Show(c.GetType().ToString());
        }
    }
}
