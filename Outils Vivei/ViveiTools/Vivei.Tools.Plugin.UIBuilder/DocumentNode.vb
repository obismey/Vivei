Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports Vivei.Tools.Core.UI
Imports System.Collections.ObjectModel

Public Class DocumentNode
    Inherits UIObject

    Public Property DocumentProjectItem As DocumentProjectItem
    Sub New(ByVal DocumentProjectItem As DocumentProjectItem)
        Me.DocumentProjectItem = DocumentProjectItem
    End Sub
    Sub New(ByVal DocumentProjectItem As DocumentProjectItem, ByVal type As Type)
        Me.DocumentProjectItem = DocumentProjectItem
        Dim v = New BaseControl()
        v.Content = Activator.CreateInstance(type)
        VisualContainer = v
        SetupLayoutProperties()
    End Sub

    Sub SetupLayoutProperties()
        'LayoutProperties.Add(New LayoutProperty("Alignement Horizontal", True, False, GetType(HorizontalAlignment)))
        'LayoutProperties.Add(New LayoutProperty("Alignement Vertical", True, False, GetType(VerticalAlignment)))

        'LayoutProperties.Add(New LayoutProperty("Longueur", False, True, Nothing))
        'LayoutProperties.Add(New LayoutProperty("Hauteur", False, True, Nothing))

        'LayoutProperties.Add(New LayoutProperty("Gauche", False, True, Nothing))
        'LayoutProperties.Add(New LayoutProperty("Haut", False, True, Nothing))
        'LayoutProperties.Add(New LayoutProperty("Droite", False, True, Nothing))
        'LayoutProperties.Add(New LayoutProperty("Bas", False, True, Nothing))


        'For Each lp As LayoutProperty In Me.LayoutProperties
        '    lp.Owner = Me
        'Next
    End Sub

    Public Property Commands As New ObservableCollection(Of MenuItem)

    'Public Property LayoutProperties As New ObservableCollection(Of LayoutProperty)


    Private _Name As String
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
            OnPropertyChanged("Name")
            OnPropertyChanged("Caption")
        End Set
    End Property

    Public Property VisualContainer As BaseControl

    Public Property DataPath As String

    Public Property Children As New ObservableCollection(Of DocumentNode)
    Private _IsExpanded As Boolean
    Public Property IsExpanded As Boolean
        Get
            Return _IsExpanded
        End Get
        Set(ByVal value As Boolean)
            _IsExpanded = value
            OnPropertyChanged("IsExpanded")
        End Set
    End Property
    Public Property Caption As String
        Get
            Return If(String.IsNullOrEmpty(Me.Name), VisualContainer.Content.GetType().Name, Me.Name & "(" & VisualContainer.Content.GetType().Name & ")")
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Private _IsSelected As Boolean
    Private _DesignAdorner As DesignAdorner
    Public Property IsSelected As Boolean
        Get
            Return _IsSelected
        End Get
        Set(ByVal value As Boolean)
            If _IsSelected = value Then Return
            _IsSelected = value
            If _DesignAdorner Is Nothing Then
                Try
                    Dim myAdornerLayer = AdornerLayer.GetAdornerLayer(Me.VisualContainer)
                    _DesignAdorner = New DesignAdorner(Me.VisualContainer)
                    myAdornerLayer.Add(_DesignAdorner)
                Catch ex As Exception

                End Try

            Else
                If Not _DesignAdorner.IsLoaded Then
                    Try
                        Dim myAdornerLayer = AdornerLayer.GetAdornerLayer(Me.VisualContainer)
                        myAdornerLayer.Remove(_DesignAdorner)
                        _DesignAdorner = New DesignAdorner(Me.VisualContainer)
                        myAdornerLayer.Add(_DesignAdorner)
                    Catch ex As Exception

                    End Try

                End If
            End If
            If value Then
                'If Project.Current.ActiveDocument.ActiveNode IsNot Nothing Then
                '    Project.Current.ActiveDocument.ActiveNode._IsSelected = False
                '    Project.Current.ActiveDocument.ActiveNode.OnPropertyChanged("IsSelected")
                'End If
                Project.Current.ActiveDocument.ActiveNode = Me
                _DesignAdorner.Visibility = Visibility.Visible
            Else
                Project.Current.ActiveDocument.ActiveNode = Nothing
                _DesignAdorner.Visibility = Visibility.Collapsed

            End If

            OnPropertyChanged("IsSelected")
        End Set

    End Property

    Private _Docking As Dock
    Public Property Docking As Dock
        Get
            Return _Docking
        End Get
        Set(ByVal value As Dock)
            _Docking = value
            DockPanel.SetDock(VisualContainer, value)
        End Set
    End Property

    Public ReadOnly Property ContentBorder As Border
        Get
            Return VisualContainer.Template.FindName("ContentCtrl", VisualContainer)
        End Get
    End Property
    Public ReadOnly Property HeadBorder As Border
        Get
            Return VisualContainer.Template.FindName("HeaderCtrl", VisualContainer)
        End Get
    End Property

    Private WithEvents _HeadStyle As New StyleObject
    Public ReadOnly Property HeadStyle As StyleObject
        Get
            Return _HeadStyle
        End Get
    End Property
    Private WithEvents _ContentStyle As New StyleObject
    Public ReadOnly Property ContentStyle As StyleObject
        Get
            Return _ContentStyle
        End Get
    End Property
    Public Property GridRow As Integer
    Public Property GridColumn As Integer
    Public Property GridRowSpan As Integer = 1
    Public Property GridColumnSpan As Integer = 1



    'Private _BackColor As NamedColor
    'Public Property BackColor As NamedColor
    '    Get
    '        Return _BackColor
    '    End Get
    '    Set(ByVal value As NamedColor)
    '        _BackColor = value
    '        Dim p As Panel = TryCast(Visual, Panel)

    '        If p IsNot Nothing Then
    '            p.Background = New SolidColorBrush(value.Value)
    '        End If

    '    End Set
    'End Property
    Public Property IsContainer As Boolean

    Private Sub _HeadStyle_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles _HeadStyle.PropertyChanged
        If e.PropertyName = "Item[]" Then Return
        _HeadStyle.Enable(e.PropertyName)

        VisualContainer.HeaderContainerStyle = StyleObject.ToStyle(_HeadStyle, GetType(Border))
    End Sub

    Private Sub _ContentStyle_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles _ContentStyle.PropertyChanged
        If e.PropertyName = "Item[]" Then Return
        _ContentStyle.Enable(e.PropertyName)
        VisualContainer.ContentContainerStyle = StyleObject.ToStyle(_ContentStyle, GetType(Border))
    End Sub
End Class
