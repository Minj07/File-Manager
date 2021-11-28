using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager.Extra_Components
{
    internal class CustomListView : ListView
    {
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);
            using (Brush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
                

        }
    }
}
