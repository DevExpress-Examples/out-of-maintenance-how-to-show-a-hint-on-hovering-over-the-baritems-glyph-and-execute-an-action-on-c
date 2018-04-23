Imports DevExpress.XtraBars
Imports DevExpress.XtraBars.Controls
Imports DevExpress.XtraBars.ViewInfo
Imports System.IO
Imports System.Reflection

Namespace FavoriteList
	Public Class ExampleHelper
		Private ReadOnly Shared filePath As String = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
		Public Shared Function GetImage(ByVal inFavorites As Boolean) As Image
			Dim img As Image = Image.FromFile(filePath & "\star_off.png")
			If inFavorites Then
				img = Image.FromFile(filePath & "\star.png")
			End If
			Return img
		End Function

		Private Shared Function GetBarControl(ByVal link As BarSubItemLink) As CustomControl
			Dim [property] As PropertyInfo = link.GetType().GetProperty("BarControl", BindingFlags.Instance Or BindingFlags.NonPublic)
			Dim barControl As CustomControl = DirectCast([property].GetValue(link, Nothing), CustomControl)
			Return barControl
		End Function

		Public Shared Function GetPoint(ByVal link As BarSubItemLink, ByVal pt As Point, ByVal PointToClient As Boolean) As Point
			Dim barControl As CustomControl = GetBarControl(link)
			If PointToClient Then
				Return barControl.PointToClient(pt)
			End If
			Return barControl.PointToScreen(pt)
		End Function

		Public Shared Function GetToolTipLocation(ByVal link As BarSubItemLink) As Point
			Dim rect As Rectangle = GetGlyphRect(link)
			Return GetPoint(link, New Point(rect.Right, rect.Bottom), False)
		End Function

		Public Shared Function GlyphContainsCursor(ByVal link As BarSubItemLink) As Boolean
			Dim rect As Rectangle = GetGlyphRect(link)
			If rect = Rectangle.Empty Then
				Return False
			End If
			Dim local As Point = GetPoint(link, Cursor.Position, True)
			Return rect.Contains(local)
		End Function

		Public Shared Function GetGlyphRect(ByVal link As BarSubItemLink) As Rectangle
			Dim vi As BarSubItemLinkViewInfo = GetSubItemLinkViewInfo(link)
			If vi Is Nothing Then
				Return Rectangle.Empty
			End If
			Return vi.Rects(BarLinkParts.Glyph)
		End Function

		Private Shared Function GetSubItemLinkViewInfo(ByVal link As BarSubItemLink) As BarSubItemLinkViewInfo
			Dim [property] As PropertyInfo = link.GetType().GetProperty("LinkViewInfo", BindingFlags.Instance Or BindingFlags.NonPublic)
			Return DirectCast([property].GetValue(link, Nothing), BarSubItemLinkViewInfo)
		End Function
	End Class
End Namespace
