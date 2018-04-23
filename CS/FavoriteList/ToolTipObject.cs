using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteList
{
    public class ToolTipObject
    {
        public string AddToolTip;
        public BarSubItem ToolTipItem;
        public string RemoveToolTip;
        public ToolTipObject(BarSubItem _toolTipItem)
        {
            ToolTipItem = _toolTipItem;
            AddToolTip = "Add to Favorites";
            RemoveToolTip = "Remove from Favorites";
        }
    }
}
