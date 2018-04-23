Imports DevExpress.XtraBars
Imports System
Imports System.Collections.Generic
Imports System.Linq

Namespace FavoriteList
	Public Class ToolTipObject
		Public AddToolTip As String
		Public ToolTipItem As BarSubItem
		Public RemoveToolTip As String
		Public Sub New(ByVal _toolTipItem As BarSubItem)
			ToolTipItem = _toolTipItem
			AddToolTip = "Add to Favorites"
			RemoveToolTip = "Remove from Favorites"
		End Sub
	End Class
End Namespace
