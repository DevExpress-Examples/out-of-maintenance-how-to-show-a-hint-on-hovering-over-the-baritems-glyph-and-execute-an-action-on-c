Namespace FavoriteList
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing Then
				If components IsNot Nothing Then
					components.Dispose()
				End If
				If barManger IsNot Nothing Then
					barManger.Dispose()
				End If
				If timer IsNot Nothing Then
					timer.Dispose()
				End If
				If link IsNot Nothing Then
					link.Dispose()
					link = Nothing
				End If
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form1))
			Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
			Me.barSubItem1 = New DevExpress.XtraBars.BarSubItem()
			Me.barSubItem2 = New DevExpress.XtraBars.BarSubItem()
			Me.barSubItem3 = New DevExpress.XtraBars.BarSubItem()
			Me.barSubItem4 = New DevExpress.XtraBars.BarSubItem()
			Me.barSubItem5 = New DevExpress.XtraBars.BarSubItem()
			Me.barSubItem6 = New DevExpress.XtraBars.BarSubItem()
			Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
			Me.ribbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
			Me.defaultLookAndFeel1 = New DevExpress.LookAndFeel.DefaultLookAndFeel(Me.components)
			DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' ribbonControl1
			' 
			Me.ribbonControl1.ExpandCollapseItem.Id = 0
			Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.ribbonControl1.ExpandCollapseItem, Me.barSubItem1, Me.barSubItem2, Me.barSubItem3, Me.barSubItem4, Me.barSubItem5, Me.barSubItem6})
			Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
			Me.ribbonControl1.MaxItemId = 14
			Me.ribbonControl1.Name = "ribbonControl1"
			Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() { Me.ribbonPage1})
			Me.ribbonControl1.Size = New System.Drawing.Size(649, 147)
			' 
			' barSubItem1
			' 
			Me.barSubItem1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False
			Me.barSubItem1.Caption = "Contacts"
			Me.barSubItem1.Glyph = (DirectCast(resources.GetObject("barSubItem1.Glyph"), System.Drawing.Image))
			Me.barSubItem1.Id = 1
			Me.barSubItem1.LargeGlyph = (DirectCast(resources.GetObject("barSubItem1.LargeGlyph"), System.Drawing.Image))
			Me.barSubItem1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {
				New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barSubItem2, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
				New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItem3),
				New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItem4),
				New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItem5),
				New DevExpress.XtraBars.LinkPersistInfo(Me.barSubItem6)
			})
			Me.barSubItem1.Name = "barSubItem1"
			' 
			' barSubItem2
			' 
			Me.barSubItem2.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False
			Me.barSubItem2.Caption = "Favorites"
			Me.barSubItem2.Glyph = (DirectCast(resources.GetObject("barSubItem2.Glyph"), System.Drawing.Image))
			Me.barSubItem2.Id = 2
			Me.barSubItem2.LargeGlyph = (DirectCast(resources.GetObject("barSubItem2.LargeGlyph"), System.Drawing.Image))
			Me.barSubItem2.Name = "barSubItem2"
			' 
			' barSubItem3
			' 
			Me.barSubItem3.Caption = "Contact1"
			Me.barSubItem3.Id = 5
			Me.barSubItem3.Name = "barSubItem3"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.barSubItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItem3_ItemClick);
			' 
			' barSubItem4
			' 
			Me.barSubItem4.Caption = "Contact2"
			Me.barSubItem4.Id = 6
			Me.barSubItem4.Name = "barSubItem4"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.barSubItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItem4_ItemClick);
			' 
			' barSubItem5
			' 
			Me.barSubItem5.Caption = "Contact3"
			Me.barSubItem5.Id = 7
			Me.barSubItem5.Name = "barSubItem5"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.barSubItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItem5_ItemClick);
			' 
			' barSubItem6
			' 
			Me.barSubItem6.Caption = "contact4"
			Me.barSubItem6.Id = 8
			Me.barSubItem6.Name = "barSubItem6"
'INSTANT VB NOTE: The following InitializeComponent event wireup was converted to a 'Handles' clause:
'ORIGINAL LINE: this.barSubItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSubItem6_ItemClick);
			' 
			' ribbonPage1
			' 
			Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() { Me.ribbonPageGroup1})
			Me.ribbonPage1.Name = "ribbonPage1"
			Me.ribbonPage1.Text = "Contacts Page"
			' 
			' ribbonPageGroup1
			' 
			Me.ribbonPageGroup1.AllowTextClipping = False
			Me.ribbonPageGroup1.ItemLinks.Add(Me.barSubItem1)
			Me.ribbonPageGroup1.Name = "ribbonPageGroup1"
			Me.ribbonPageGroup1.Text = "Contacts Page Group"
			' 
			' defaultLookAndFeel1
			' 
			Me.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013"
			' 
			' Form1
			' 
			Me.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(649, 399)
			Me.Controls.Add(Me.ribbonControl1)
			Me.Name = "Form1"
			Me.Ribbon = Me.ribbonControl1
			Me.Text = "Form1"
			DirectCast(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
		Private ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
		Private ribbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
		Private barSubItem1 As DevExpress.XtraBars.BarSubItem
		Private barSubItem2 As DevExpress.XtraBars.BarSubItem
		Private WithEvents barSubItem3 As DevExpress.XtraBars.BarSubItem
		Private WithEvents barSubItem4 As DevExpress.XtraBars.BarSubItem
		Private WithEvents barSubItem5 As DevExpress.XtraBars.BarSubItem
		Private WithEvents barSubItem6 As DevExpress.XtraBars.BarSubItem
		Private defaultLookAndFeel1 As DevExpress.LookAndFeel.DefaultLookAndFeel
	End Class
End Namespace

