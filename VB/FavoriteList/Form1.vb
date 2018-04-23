Imports DevExpress.Utils
Imports DevExpress.XtraBars

Namespace FavoriteList
	Partial Public Class Form1
		Inherits DevExpress.XtraBars.Ribbon.RibbonForm
		Implements IMessageFilter

		Public Sub New()
			InitializeComponent()
			InitToolTipList()
			InitContacts()
			InitTimer()

			Application.AddMessageFilter(Me)
			barManger = ribbonControl1.Manager
		End Sub

		#Region "InitializeComponent"
		Private Sub InitToolTipList()
			ToolTipList.Add(New ToolTipObject(barSubItem3))
			ToolTipList.Add(New ToolTipObject(barSubItem4))
			ToolTipList.Add(New ToolTipObject(barSubItem5))
			ToolTipList.Add(New ToolTipObject(barSubItem6))
		End Sub
		Private Sub InitContacts()
			Dim img As Image = ExampleHelper.GetImage(False)
			barSubItem3.Glyph = img
			barSubItem4.Glyph = img
			barSubItem5.Glyph = img
			barSubItem6.Glyph = img
		End Sub
		Private Sub InitTimer()
			timer = New Timer() With {.Interval = 400}
			AddHandler timer.Tick, AddressOf Tick
		End Sub
		#End Region
		#Region "Fields"
		Private timer As Timer
		Private ReadOnly ToolTipList As New List(Of ToolTipObject)()
		Private ReadOnly barManger As BarManager
		Private ReadOnly itemsAndLinks As New Dictionary(Of BarItem, BarItemLink)()
		Public Const WM_MouseMove As Integer = &H200
		Private isToolTipShown As Boolean = False
		Private link As BarSubItemLink = Nothing
		#End Region
		#Region "Event Handlers"
		Private Sub barSubItem3_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barSubItem3.ItemClick
			AddToFavorites(e)
		End Sub
		Private Sub barSubItem4_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barSubItem4.ItemClick
			AddToFavorites(e)
		End Sub

		Private Sub barSubItem5_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barSubItem5.ItemClick
			AddToFavorites(e)
		End Sub

		Private Sub barSubItem6_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs) Handles barSubItem6.ItemClick
			AddToFavorites(e)
		End Sub

		Private Sub Tick(ByVal sender As Object, ByVal e As EventArgs)
			ShowToolTip()
		End Sub
		#End Region

		Private Sub ShowToolTip()
			Dim index As Integer = -1
			Dim item As BarSubItem = Nothing
			For i As Integer = 0 To ToolTipList.Count - 1
				item = ToolTipList(i).ToolTipItem
				link = TryCast(item.Links(0), BarSubItemLink)
				If ExampleHelper.GlyphContainsCursor(link) Then
					index = i
					Exit For
				End If
			Next i

			If index <> -1 Then
				Dim args As New ToolTipControllerShowEventArgs() With {
					.ToolTipLocation = ToolTipLocation.Fixed,
					.SuperTip = New SuperToolTip()
				}
				args.SuperTip.Items.Add(If(itemsAndLinks.ContainsKey(item), ToolTipList(index).RemoveToolTip, ToolTipList(index).AddToolTip))
				Dim linkPoint As Point = ExampleHelper.GetToolTipLocation(link)
				barManger.GetToolTipController().ShowHint(args, linkPoint)
				isToolTipShown = True
			End If
		End Sub

		Private Sub HideToolTip()
			barManger.GetToolTipController().HideHint()
			isToolTipShown = False
		End Sub

		Private Sub HideToolTipIfRequired()
			If isToolTipShown AndAlso Not ExampleHelper.GlyphContainsCursor(link) Then
				HideToolTip()
			End If
		End Sub

		Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
			If m.Msg = WM_MouseMove Then
				HideToolTipIfRequired()
				timer.Stop()
				timer.Start()
			End If
			Return False
		End Function

		Private Sub AddToFavorites(ByVal e As ItemClickEventArgs)
			If ExampleHelper.GlyphContainsCursor(TryCast(e.Link, BarSubItemLink)) Then
				Dim inFavorites As Boolean = True
				If barSubItem2.ContainsItem(e.Item) Then
					inFavorites = False
					barSubItem2.ItemLinks.Remove(itemsAndLinks(e.Item))
					itemsAndLinks.Remove(e.Item)
				Else
					itemsAndLinks(e.Item) = barSubItem2.ItemLinks.Add(e.Item)
				End If
				e.Item.Glyph = ExampleHelper.GetImage(inFavorites)
			End If
		End Sub

	End Class
End Namespace
