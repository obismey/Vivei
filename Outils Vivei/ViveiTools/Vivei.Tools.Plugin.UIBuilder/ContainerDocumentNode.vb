Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports Vivei.Tools.Core.UI
Imports System.Collections.ObjectModel

Public Class ContainerDocumentNode
    Inherits DocumentNode

    Sub New(ByVal DocumentProjectItem As DocumentProjectItem)
        MyBase.New(DocumentProjectItem)
        IsContainer = True
    End Sub
    Sub New(ByVal DocumentProjectItem As DocumentProjectItem, ByVal type As Type)
        MyBase.New(DocumentProjectItem, type)
        ContainerType = type
        For Each t As Type In ContainerTypeList
            Dim tempt = t
            Commands.Add(New MenuItem("Add " & t.Name, Sub() ExecuteCommand("addcontainer", tempt)))
        Next
        IsContainer = True
        UpdateIsProperties()
        RowList.Add(New GridSize(Me, RowList))
        ColumnList.Add(New GridSize(Me, ColumnList))
    End Sub
    Private Sub ExecuteCommand(ByVal type As String, ByVal detail As Object)
        Dim cdn As ContainerDocumentNode = New ContainerDocumentNode(Me.DocumentProjectItem, detail)
        Children.Add(cdn)
        Dim p = TryCast(Me.VisualContainer.Content, Panel)
        If p Is Nothing Then
            'hcc = TryCast(Me.Visual, HeaderedContentControl)
            'If hcc IsNot Nothing Then
            '    p = TryCast(hcc.Content, Panel)
            '    If p IsNot Nothing Then
            '        p.Children.Add(cdn.Visual)
            '    End If
            'End If
        Else
            Dim undo = Sub(obj)
                           Children.Remove(cdn)
                           p.Children.Remove(cdn.VisualContainer)
                       End Sub
            Dim redo = Sub(obj)
                           Children.Add(cdn)
                           p.Children.Add(cdn.VisualContainer)
                       End Sub
            UIBuilderPlugin._UndoRedoService.ActiveContext = Me.DocumentProjectItem
            UIBuilderPlugin._UndoRedoService.Push(New UndoRedo.DefaultUndoRedoToken(undo, redo, "Ajout de " & detail.Name))
            p.Children.Add(cdn.VisualContainer)
        End If
    End Sub

    Private _ContainerType As Type
    Public Property ContainerType As Type
        Get
            Return _ContainerType
        End Get
        Set(ByVal value As Type)
            _ContainerType = value
            OnPropertyChanged("ContainerType")
            UpdateIsProperties()
        End Set
    End Property

    Public Property IsUniformGrid As Boolean
    Public Property IsWrapOrStack As Boolean
    Public Property IsGrid As Boolean

    Private Sub UpdateIsProperties()
        If _ContainerType Is GetType(Grid) Then
            IsUniformGrid = False
            IsWrapOrStack = False
            IsGrid = True
        End If
        If _ContainerType Is GetType(StackPanel) Then
            IsUniformGrid = False
            IsWrapOrStack = True
            IsGrid = False
        End If
        If _ContainerType Is GetType(WrapPanel) Then
            IsUniformGrid = False
            IsWrapOrStack = True
            IsGrid = False
        End If
        If _ContainerType Is GetType(DockPanel) Then
            IsUniformGrid = False
            IsWrapOrStack = False
            IsGrid = False
        End If
        If _ContainerType Is GetType(Primitives.UniformGrid) Then
            IsUniformGrid = True
            IsWrapOrStack = False
            IsGrid = False
        End If

        OnPropertyChanged("IsUniformGrid")
        OnPropertyChanged("IsWrapOrStack")
        OnPropertyChanged("IsGrid")

    End Sub

    Private _RowCount As Integer
    Public Property RowCount As Integer
        Get
            Return _RowCount
        End Get
        Set(ByVal value As Integer)
            _RowCount = value
            If IsUniformGrid Then
                CType(Me.VisualContainer.Content, Primitives.UniformGrid).Rows = value
            End If
        End Set
    End Property

    Private _ColumnCount As Integer
    Public Property ColumnCount As Integer
        Get
            Return _ColumnCount
        End Get
        Set(ByVal value As Integer)
            _ColumnCount = value
            If IsUniformGrid Then
                CType(Me.VisualContainer.Content, Primitives.UniformGrid).Columns = value
            End If
        End Set
    End Property

    Private _Orientation As Orientation
    Public Property Orientation As Orientation
        Get
            Return _Orientation
        End Get
        Set(ByVal value As Orientation)
            _Orientation = value
            If IsWrapOrStack Then
                Me.VisualContainer.Content.Orientation = value
            End If
        End Set
    End Property

    Public Property RowList As New ObservableCollection(Of GridSize)
    Public Property ColumnList As New ObservableCollection(Of GridSize)

    Public Shared Property ContainerTypeList As Type() = New Type() {GetType(Grid), GetType(StackPanel), GetType(DockPanel), GetType(Primitives.UniformGrid), GetType(WrapPanel)}
End Class
Public Class SetPropertyCommand
    Public Shared Sub Push(ByVal context As UndoRedo.IUndoRedoContext, ByVal propertydescriptor As ComponentModel.PropertyDescriptor, ByVal target As Object, ByVal value As Object)
        propertydescriptor.SetValue(target, value)
    End Sub
   
    Private Shared Sub Undo(ByVal obj As Object)

    End Sub
    Private Shared Sub Redo(ByVal obj As Object)

    End Sub
End Class
'Public Interface ISupportSetPropertyCommand
'    Property DisableSetPropertyCommand
'End Interface