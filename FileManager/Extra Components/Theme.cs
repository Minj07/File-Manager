using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace FileManager
{
    public class Theme
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
            text = (contrast(Color.White, main) > contrast(Color.Black, main) ? Color.White : Color.Black);
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

        public double luminance(Color color)
        {
            double r = color.R / 255d;
            double g = color.G / 255d;
            double b = color.B / 255d;
            Func<double, double> calc = v => (v <= 0.03928
            ? v / 12.92
            : Math.Pow((v + 0.055) / 1.055, 2.4));
            return calc(r) * 0.2126 + calc(g) * 0.7152 + calc(b) * 0.0722;
        }

        public double contrast(Color a, Color b)
        {
            double lum1 = luminance(a);
            double lum2 = luminance(b);
            double brightest = (lum1 > lum2 ? lum1 : lum2);
            double darkest = (lum1 < lum2 ? lum1 : lum2);
            return (brightest + 0.05) / (darkest + 0.05);
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
        
        static public Bitmap Recolor(Bitmap input, Color color)
        {
            for (int i =0 ; i < input.Width; i++)
            {
                for (int j =0 ; j < input.Height; j++)
                {
                    if (input.GetPixel(i,j).A > 0)
                    {
                        input.SetPixel(i, j, Color.FromArgb(input.GetPixel(i, j).A,color));
                    }
                }
            }
            return input;
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        public enum icon
        {
            left_arrow = 1,
            right_arrow = 2,
            expand_down_arrow = 3,
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
                case icon.expand_down_arrow: temp = Properties.Resources.expand_down_arrow;
                    break;
                case icon.up_arrow: temp = Properties.Resources.up_arrow;
                    break;
                case icon.new_file: temp = Properties.Resources.new_file;
                    break;
                case icon.reboot: temp = Properties.Resources.reboot;
                    break;
                default: temp = Properties.Resources.reboot; break;
            }
            return Recolor(temp,text);
        }

        public void test(Control c)
        {
            MessageBox.Show(c.GetType().ToString());
        }
    }
}
