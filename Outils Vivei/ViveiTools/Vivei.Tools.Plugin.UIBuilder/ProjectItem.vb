Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports Vivei.Tools.Core.UI
Imports System.Collections.ObjectModel

Public Class ProjectItem
    Inherits UIObject

    Friend Overridable Sub DoubleClick()

    End Sub

    Public Property Children As New ObservableCollection(Of ProjectItem)

    Public Property Commands As New ObservableCollection(Of MenuItem)

    Public Property Caption As String

    Public Property IsExpanded As Boolean

    Sub New()

    End Sub

    Sub New(ByVal Caption As String)
        Me.Caption = Caption
    End Sub

    Sub New(ByVal Caption As String, ByVal ParamArray Commands() As MenuItem)
        Me.Caption = Caption
        For Each c As MenuItem In Commands
            Me.Commands.Add(c)
        Next
    End Sub
End Class
