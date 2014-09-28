'Imports System
Imports System.Collections.ObjectModel
'Imports System.Configuration
'Imports System.Data
'Imports System.Windows
'Imports System.Windows.Controls
'Imports System.Xml
Imports Vivei.Tools.Core.UI



Public Class GridSize
    Inherits UIObject

    Private _Container As ObservableCollection(Of GridSize)
    Private _Owner As ContainerDocumentNode
    Sub New(ByVal owner As ContainerDocumentNode, ByVal container As ObservableCollection(Of GridSize))
        Me._Container = container
        Me._Owner = owner
        Me._Value = "100%"
        InsertCommand = New MenuItem("", AddressOf Insert)
        RemoveCommand = New MenuItem("", AddressOf Remove)
    End Sub

    Public Property InsertCommand As MenuItem
    Public Property RemoveCommand As MenuItem

    Private _Value As String
    Public Property Value As String
        Get
            Return _Value
        End Get
        Set(ByVal value As String)
            _Value = value
            OnPropertyChanged("Value")
        End Set
    End Property

    Private Sub Insert()
        Me._Container.Insert(Me._Container.IndexOf(Me), New GridSize(Me._Owner, Me._Container))
    End Sub
    Private Sub Remove()
        If Me._Container.Count <= 1 Then Return
        Me._Container.Remove(Me)
    End Sub
End Class