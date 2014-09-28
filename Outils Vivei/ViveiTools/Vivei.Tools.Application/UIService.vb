Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition
Imports AvalonDock


Public Class UIService
    Implements Core.UI.IUIService



    Private _CoreMenuItems() As Core.UI.MenuItem = New Core.UI.MenuItem() { _
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem("", AddressOf UndoRedoService.Instance.Undo),
        New Core.UI.MenuItem("", AddressOf UndoRedoService.Instance.Redo),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem()
    }

    Private Shared _Instance As UIService


    Private Sub New()

    End Sub

    Public Shared ReadOnly Property Instance As UIService
        Get
            If _Instance Is Nothing Then
                _Instance = New UIService()
            End If
            Return _Instance
        End Get
    End Property

    Public Sub Reset() Implements Core.IService.Reset

    End Sub

    Public ReadOnly Property BackMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.BackMenuItem
        Get
            Return _CoreMenuItems(1)
        End Get
    End Property

    Public ReadOnly Property ForwardMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.ForwardMenuItem
        Get
            Return _CoreMenuItems(2)
        End Get
    End Property

    Public ReadOnly Property HelpMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.HelpMenuItem
        Get
            Return _CoreMenuItems(7)
        End Get
    End Property

    Public ReadOnly Property HomeMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.HomeMenuItem
        Get
            Return _CoreMenuItems(0)
        End Get
    End Property

    Public ReadOnly Property MainMenu As Core.UI.MenuItemCollection Implements Core.UI.IUIService.MainMenu
        Get

        End Get
    End Property
 
    Public ReadOnly Property OptionsMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.OptionsMenuItem
        Get
            Return _CoreMenuItems(6)
        End Get
    End Property

    Public ReadOnly Property RedoMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.RedoMenuItem
        Get
            Return _CoreMenuItems(4)
        End Get
    End Property

    Public ReadOnly Property UndoMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.UndoMenuItem
        Get
            Return _CoreMenuItems(3)
        End Get
    End Property

    Public ReadOnly Property WindowsMenuItem As Core.UI.MenuItem Implements Core.UI.IUIService.WindowsMenuItem
        Get
            Return _CoreMenuItems(5)
        End Get
    End Property

    Public Property Windows As New ObjectModel.ObservableCollection(Of DockableContent)

    Public Property Documents As New ObjectModel.ObservableCollection(Of DocumentContent)

    Public Function OpenDocument(ByVal caption As String, ByVal icon As String, ByVal view As Object) As Core.UI.IDocumentWindow Implements Core.UI.IUIService.OpenDocument
        Dim ImageSourceConverter = New ImageSourceConverter()
        Dim dc = New DocumentContent() With {.Title = caption, .Icon = Nothing, .Content = view}
        Documents.Add(dc)
        Return New AvalonDockDocumentWindow(dc)
    End Function

    Public Function RegisterWindow(ByVal id As String, ByVal caption As String, ByVal icon As String, ByVal view As Object) As Core.UI.IToolWindow Implements Core.UI.IUIService.RegisterWindow
        Dim ImageSourceConverter = New ImageSourceConverter()
        Windows.Add(New DockableContent() With {.Title = caption, .Icon = Nothing, .Content = view, .Name = id})

    End Function

End Class


Public Class DynamicSettings

    Private Shared _Instance As Dynamic.ExpandoObject

    Public Shared ReadOnly Property Instance As Object
        Get
            If _Instance Is Nothing Then
                _Instance = New Dynamic.ExpandoObject()

                If IO.File.Exists("VisualConfig.xml") Then
                    For Each xelt In XElement.Load("VisualConfig.xml").<Property>
                        If xelt.@Type = "GridLength" Then
                            CType(_Instance, IDictionary(Of String, Object)).Add(xelt.@Name, (New GridLengthConverter()).ConvertFromInvariantString(xelt.@Value))
                        End If
                    Next
                End If


                AddHandler CType(_Instance, ComponentModel.INotifyPropertyChanged).PropertyChanged, AddressOf InstancePropertyChanged
            End If
            Return _Instance
        End Get
    End Property

    Private Shared Sub InstancePropertyChanged(ByVal sender As Object, ByVal e As ComponentModel.PropertyChangedEventArgs)
        Dim q = From elt In _Instance Select <Property Name=<%= elt.Key %> Value=<%= elt.Value %> Type=<%= elt.Value.GetType().Name %>/>

        Dim x = <Data><%= q %></Data>

        x.Save("VisualConfig.xml")
    End Sub

End Class

Public Class AvalonDockDocumentWindow
    Implements Core.UI.IDocumentWindow


    Private _DocumentContent As DocumentContent

    Sub New(ByVal DocumentContent As DocumentContent)
        _DocumentContent = DocumentContent
    End Sub


    Public Sub Close() Implements Core.UI.IDocumentWindow.Close
        _DocumentContent.Close()
    End Sub

    Public ReadOnly Property IsClosed As Boolean Implements Core.UI.IDocumentWindow.IsClosed
        Get
            Return Not _DocumentContent.IsLoaded
        End Get
    End Property

    Public Property Caption As String Implements Core.UI.IWindow.Caption
        Get
            Return _DocumentContent.Title
        End Get
        Set(ByVal value As String)
            _DocumentContent.Title = value
        End Set
    End Property

    Public Property Icon As String Implements Core.UI.IWindow.Icon
        Get

        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Property IsActive As Boolean Implements Core.UI.IWindow.IsActive
        Get
            Return _DocumentContent.IsActiveDocument
        End Get
        Set(ByVal value As Boolean)
            If value = _DocumentContent.IsActiveDocument Then Return
            If value Then _DocumentContent.Activate()
        End Set
    End Property

    Public Property IsVisible As Boolean Implements Core.UI.IWindow.IsVisible
        Get
            Return _DocumentContent.IsVisible
        End Get
        Set(ByVal value As Boolean)
            If _DocumentContent.IsVisible = value Then Return
            _DocumentContent.Show()
        End Set
    End Property

    Public ReadOnly Property View As Object Implements Core.UI.IWindow.View
        Get
            Return _DocumentContent.Content
        End Get
    End Property

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Public Event PropertyChanging(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangingEventArgs) Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
End Class