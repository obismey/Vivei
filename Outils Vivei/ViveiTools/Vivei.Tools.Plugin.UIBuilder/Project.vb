Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports Vivei.Tools.Core.UI
Imports System.Collections.ObjectModel


Public Class Project
    Inherits UIObject

    Public Shared Property Current As Project = New Project()

    Sub New()
        Children.Add(New ProjectItem("References", GetCommand("addref", "Ajouter une reference")))
        Children.Add(New ProjectItem("Configurations", GetCommand("importconfig", "Importer une configuration")))
        Children.Add(New ProjectItem("Ressources"))
        Children.Add(New ProjectItem("Donnees"))
        Children.Add(New ProjectItem("Documents", GetCommand("newdoc", "Nouveau document")))
    End Sub

    Private Function GetCommand(ByVal type As String, ByVal caption As String) As MenuItem
        Return New MenuItem(caption, Sub() ExecuteCommand(type))
    End Function
    Private Sub ExecuteCommand(ByVal type As String)
        If type = "newdoc" Then
            Dim dpi As DocumentProjectItem = New DocumentProjectItem()
            dpi.DocumentWindow = UIBuilderPlugin._UIService.OpenDocument(dpi.Caption, "", New ContentControl())
            Children(4).Children.Add(dpi)
        End If
    End Sub
    Public Property Children As New ObservableCollection(Of ProjectItem)

    Private _ActiveDocument As DocumentProjectItem
    Public Property ActiveDocument As DocumentProjectItem
        Get
            Return _ActiveDocument
        End Get
        Set(ByVal value As DocumentProjectItem)
            _ActiveDocument = value
            UIBuilderPlugin._UndoRedoService.ActiveContext = value
            If _ActiveDocument.DocumentWindow.IsClosed Then
                _ActiveDocument.DocumentWindow = UIBuilderPlugin._UIService.OpenDocument(_ActiveDocument.Caption, "", New ContentControl())
            Else
                _ActiveDocument.DocumentWindow.IsActive = True
            End If
            OnPropertyChanged("ActiveDocument")
        End Set
    End Property
End Class
