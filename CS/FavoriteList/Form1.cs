using DevExpress.Utils;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FavoriteList
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm, IMessageFilter
    {
        public Form1()
        {
            InitializeComponent();
            InitToolTipList();
            InitContacts();
            InitTimer();

            Application.AddMessageFilter(this);
            barManger = ribbonControl1.Manager;
        }

        #region InitializeComponent
        private void InitToolTipList()
        {
            ToolTipList.Add(new ToolTipObject(barSubItem3));
            ToolTipList.Add(new ToolTipObject(barSubItem4));
            ToolTipList.Add(new ToolTipObject(barSubItem5));
            ToolTipList.Add(new ToolTipObject(barSubItem6));
        }
        private void InitContacts()
        {
            Image img = ExampleHelper.GetImage(false);
            barSubItem3.Glyph = img;
            barSubItem4.Glyph = img;
            barSubItem5.Glyph = img;
            barSubItem6.Glyph = img;
        }
        private void InitTimer()
        {
            timer = new Timer() { Interval = 400 };
            timer.Tick += Tick;
        }
        #endregion
        #region Fields
        Timer timer;
        readonly List<ToolTipObject> ToolTipList = new List<ToolTipObject>();
        readonly BarManager barManger;
        readonly Dictionary<BarItem, BarItemLink> itemsAndLinks = new Dictionary<BarItem, BarItemLink>();
        public const int WM_MouseMove = 0x0200;
        bool isToolTipShown = false;
        BarSubItemLink link = null;
        #endregion
        #region Event Handlers
        private void barSubItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddToFavorites(e);
        }
        private void barSubItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddToFavorites(e);
        }

        private void barSubItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddToFavorites(e);
        }

        private void barSubItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddToFavorites(e);
        }

        void Tick(object sender, EventArgs e)
        {
            ShowToolTip();
        }
        #endregion

        private void ShowToolTip()
        {
            int index = -1;
            BarSubItem item = null;
            for (int i = 0; i < ToolTipList.Count; i++)
            {
                item = ToolTipList[i].ToolTipItem;
                link = item.Links[0] as BarSubItemLink;
                if (ExampleHelper.GlyphContainsCursor(link))
                {
                    index = i;
                    break;
                }
            }

            if (index != -1)
            {
                ToolTipControllerShowEventArgs args = new ToolTipControllerShowEventArgs() { ToolTipLocation = ToolTipLocation.Fixed, SuperTip = new SuperToolTip() };
                args.SuperTip.Items.Add(itemsAndLinks.ContainsKey(item) ? ToolTipList[index].RemoveToolTip : ToolTipList[index].AddToolTip);
                Point linkPoint = ExampleHelper.GetToolTipLocation(link);
                barManger.GetToolTipController().ShowHint(args, linkPoint);
                isToolTipShown = true;
            }
        }

        private void HideToolTip()
        {
            barManger.GetToolTipController().HideHint();
            isToolTipShown = false;
        }

        private void HideToolTipIfRequired()
        {
            if (isToolTipShown && !ExampleHelper.GlyphContainsCursor(link))
                HideToolTip();
        }

        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == WM_MouseMove)
            {
                HideToolTipIfRequired();
                timer.Stop();
                timer.Start();
            }
            return false;
        }

        private void AddToFavorites(ItemClickEventArgs e)
        {
            if (ExampleHelper.GlyphContainsCursor(e.Link as BarSubItemLink))
            {
                bool inFavorites = true;
                if (barSubItem2.ContainsItem(e.Item))
                {
                    inFavorites = false;
                    barSubItem2.ItemLinks.Remove(itemsAndLinks[e.Item]);
                    itemsAndLinks.Remove(e.Item);
                }
                else
                    itemsAndLinks[e.Item] = barSubItem2.ItemLinks.Add(e.Item);
                e.Item.Glyph = ExampleHelper.GetImage(inFavorites);
            }
        }

    }
}
