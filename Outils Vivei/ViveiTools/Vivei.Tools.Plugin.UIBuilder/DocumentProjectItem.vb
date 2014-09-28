Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports Vivei.Tools.Core.UI
Imports System.Collections.ObjectModel

Public Class DocumentProjectItem
    Inherits ProjectItem
    Implements UndoRedo.IUndoRedoContext

    Private Shared Counter As Integer
    Dim _DocumentWindow As IDocumentWindow

    Sub New()
        Counter += 1
        Commands.Add(New MenuItem("Renommer", Sub() ExecuteCommand("rename")))
        Commands.Add(New MenuItem("Supprimer", Sub() ExecuteCommand("delete")))
        Commands.Add(New MenuItem("Exporter", Sub() ExecuteCommand("export")))
        Caption = "Document " & Counter
        'View.Title = Caption
        RootNodes.Add(New ContainerDocumentNode(Me, GetType(Grid)))
        'CType(RootNodes(0).Visual, Grid).Background = System.Windows.Media.Brushes.White
        'CType(RootNodes(0).Visual, Grid).Margin = New Thickness(2)
    End Sub

    Public Property DocumentWindow As IDocumentWindow
        Get
            Return _DocumentWindow
        End Get
        Set(ByVal value As IDocumentWindow)
            _DocumentWindow = value
            _DocumentWindow.View.Content = RootNodes(0).VisualContainer
        End Set
    End Property
    Private Sub ExecuteCommand(ByVal type As String)

    End Sub

    Friend Overrides Sub DoubleClick()
        Project.Current.ActiveDocument = Me
    End Sub

    Private _ActiveNode As DocumentNode
    Public Property ActiveNode As DocumentNode
        Get
            Return _ActiveNode
        End Get
        Set(ByVal value As DocumentNode)
            _ActiveNode = value
            OnPropertyChanged("ActiveNode")
        End Set
    End Property
    Public Property RootNodes As New ObservableCollection(Of DocumentNode)

    Public Property IsActive As Boolean Implements Core.UndoRedo.IUndoRedoContext.IsActive
       
End Class
