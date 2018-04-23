using DevExpress.XtraBars;
using DevExpress.XtraBars.Controls;
using DevExpress.XtraBars.ViewInfo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FavoriteList
{
    public class ExampleHelper
    {
        readonly static string filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
        public static Image GetImage(bool inFavorites)
        {
            Image img = Image.FromFile(filePath + @"\star_off.png");
            if (inFavorites)
                img = Image.FromFile(filePath + @"\star.png");
            return img;
        }

        private static CustomControl GetBarControl(BarSubItemLink link)
        {
            PropertyInfo property = link.GetType().GetProperty("BarControl", BindingFlags.Instance | BindingFlags.NonPublic);
            CustomControl barControl = (CustomControl)property.GetValue(link, null);
            return barControl;
        }

        public static Point GetPoint(BarSubItemLink link, Point pt, bool PointToClient)
        {
            CustomControl barControl = GetBarControl(link);
            if (PointToClient)
                return barControl.PointToClient(pt);
            return barControl.PointToScreen(pt);
        }

        public static Point GetToolTipLocation(BarSubItemLink link)
        {
            Rectangle rect = GetGlyphRect(link);
            return GetPoint(link, new Point(rect.Right, rect.Bottom), false);
        }

        public static bool GlyphContainsCursor(BarSubItemLink link)
        {
            Rectangle rect = GetGlyphRect(link);
            if (rect == Rectangle.Empty)
                return false;
            Point local = GetPoint(link, Cursor.Position, true);
            return rect.Contains(local);
        }

        public static Rectangle GetGlyphRect(BarSubItemLink link)
        {
            BarSubItemLinkViewInfo vi = GetSubItemLinkViewInfo(link);
            if (vi == null)
                return Rectangle.Empty;
            return vi.Rects[BarLinkParts.Glyph];
        }

        private static BarSubItemLinkViewInfo GetSubItemLinkViewInfo(BarSubItemLink link)
        {
            PropertyInfo property = link.GetType().GetProperty("LinkViewInfo", BindingFlags.Instance | BindingFlags.NonPublic);
            return (BarSubItemLinkViewInfo)property.GetValue(link, null);
        }
    }
}
