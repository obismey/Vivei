Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition
Imports AvalonDock
Imports Xceed.Wpf.AvalonDock.Layout


Public Class UIService
    Implements Core.UI.IUIService




    Private _CoreMenuItems() As Core.UI.MenuItem = New Core.UI.MenuItem() { _
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem("", AddressOf UndoRedoService.Instance.Undo),
        New Core.UI.MenuItem("", AddressOf UndoRedoService.Instance.Redo),
        New Core.UI.MenuItem("", AddressOf ShowWindowList),
        New Core.UI.MenuItem(),
        New Core.UI.MenuItem("", AddressOf ShowHelpWindow)
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

    'Public Property Windows As New ObjectModel.ObservableCollection(Of DockableContent)
    'Public Property Documents As New ObjectModel.ObservableCollection(Of DocumentContent)
    Public Property Documents As New ObjectModel.ObservableCollection(Of Object)
    Public Property Tools As New ObjectModel.ObservableCollection(Of Object)

    Public Function OpenDocument(ByVal caption As String, ByVal icon As String, ByVal view As Object) As Core.UI.IDocumentWindow Implements Core.UI.IUIService.OpenDocument
        'Dim ImageSourceConverter = New ImageSourceConverter()
        'Dim dc = New DocumentContent() With {.Title = caption, .Icon = Nothing, .Content = view}
        ' Dim dc = New LayoutDocument() With {.Title = caption, .Description = caption, .Content = view}
        Dim adw = New AvalonDockDocumentWindow(view)
        adw.Caption = caption
        'Dim bt As New HeaderedContentControl
        'bt.Content = view
        'bt.Header = caption
        Documents.Add(adw)

        'Dim mw As MainWindow = Application.Current.MainWindow
        'mw.DockingManager.GetLayoutItemFromModel(dc).Title = caption
        'Return New AvalonDockDocumentWindow(dc)

        'Try
        '    MainWindow.DocumentContainer.Children.Add(New LayoutDocument() With {.Title = Date.Now.ToString(), .Content = view})
        'Catch ex As Exception

        'End Try
        Return adw
    End Function

    'Private _windowlist As New ObjectModel.ObservableCollection(Of AvalonDockToolWindow)
    Public Function RegisterWindow(ByVal id As String, ByVal caption As String, ByVal icon As String, ByVal view As Object) As Core.UI.IToolWindow Implements Core.UI.IUIService.RegisterWindow
        'Dim ImageSourceConverter = New ImageSourceConverter()
        'Dim dc = New DockableContent() With {.Title = caption, .Icon = Nothing, .Content = view, .Name = id}
        'Windows.Add(dc)

        'Dim result = New AvalonDockToolWindow(dc)
        '_windowlist.Add(result)
        'Return result

        Dim adw = New AvalonDockToolWindow(view, id)
        adw.Caption = caption

        'Dim bt As New HeaderedContentControl
        'bt.Content = view
        'bt.Header = caption
        Tools.Add(adw)

        Return adw
    End Function

    Private _HelpWindow As HelpWindow
    Private Sub ShowHelpWindow()
        If _HelpWindow Is Nothing Then
            _HelpWindow = New HelpWindow
            Dim f = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "gpl.rtf")
            _HelpWindow.RichTextBox.Selection.Load(IO.File.OpenRead(f), DataFormats.Rtf)
        End If


        _HelpWindow.ShowDialog()
    End Sub

    Private _WindowListWindow As WindowListWindow
    Private Sub ShowWindowList()
        If _WindowListWindow Is Nothing Then

            _WindowListWindow = New WindowListWindow()
            _WindowListWindow.DataGrid.ItemsSource = Tools
        End If
        _WindowListWindow.ShowDialog()
    End Sub

    Public ReadOnly Property Windows As Core.UI.IWindowCollection Implements Core.UI.IUIService.Windows
        Get

        End Get
    End Property
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

'Public Class AvalonDockDocumentWindow
'    'Implements Core.UI.IDocumentWindow


'    'Private _DocumentContent As DocumentContent
'    'Private _Icon As String

'    'Sub New(ByVal DocumentContent As DocumentContent)
'    '    _DocumentContent = DocumentContent
'    'End Sub


'    'Public Sub Close() Implements Core.UI.IDocumentWindow.Close
'    '    _DocumentContent.Close()
'    'End Sub

'    'Public ReadOnly Property IsClosed As Boolean Implements Core.UI.IDocumentWindow.IsClosed
'    '    Get
'    '        Return Not _DocumentContent.IsLoaded
'    '    End Get
'    'End Property

'    'Public Property Caption As String Implements Core.UI.IWindow.Caption
'    '    Get
'    '        Return _DocumentContent.Title
'    '    End Get
'    '    Set(ByVal value As String)
'    '        _DocumentContent.Title = value
'    '    End Set
'    'End Property

'    'Public Property Icon As String Implements Core.UI.IWindow.Icon
'    '    Get
'    '        Return _Icon
'    '    End Get
'    '    Set(ByVal value As String)
'    '        _Icon = value
'    '    End Set
'    'End Property

'    'Public Property IsActive As Boolean Implements Core.UI.IWindow.IsActive
'    '    Get
'    '        Return _DocumentContent.IsActiveDocument
'    '    End Get
'    '    Set(ByVal value As Boolean)
'    '        If value = _DocumentContent.IsActiveDocument Then Return
'    '        If value Then _DocumentContent.Activate()
'    '    End Set
'    'End Property

'    'Public Property IsVisible As Boolean Implements Core.UI.IWindow.IsVisible
'    '    Get
'    '        Return _DocumentContent.IsVisible
'    '    End Get
'    '    Set(ByVal value As Boolean)
'    '        If _DocumentContent.IsVisible = value Then Return
'    '        If value Then _DocumentContent.Show()
'    '    End Set
'    'End Property

'    'Public ReadOnly Property View As Object Implements Core.UI.IWindow.View
'    '    Get
'    '        Return _DocumentContent.Content
'    '    End Get
'    'End Property

'    'Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
'    'Public Event PropertyChanging(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangingEventArgs) Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
'End Class

'Public Class AvalonDockToolWindow
'    'Implements Core.UI.IToolWindow



'    'Private _DockableContent As DockableContent
'    'Private _Icon As String

'    'Sub New(ByVal DockableContent As DockableContent)
'    '    _DockableContent = DockableContent
'    'End Sub

'    'Public Property Caption As String Implements Core.UI.IWindow.Caption
'    '    Get
'    '        Return _DockableContent.Title
'    '    End Get
'    '    Set(ByVal value As String)
'    '        _DockableContent.Title = value
'    '    End Set
'    'End Property

'    'Public Property Icon As String Implements Core.UI.IWindow.Icon
'    '    Get
'    '        Return _Icon
'    '    End Get
'    '    Set(ByVal value As String)
'    '        _Icon = value
'    '    End Set
'    'End Property

'    'Public Property IsActive As Boolean Implements Core.UI.IWindow.IsActive
'    '    Get
'    '        Return _DockableContent.IsActiveContent
'    '    End Get
'    '    Set(ByVal value As Boolean)
'    '        If value = _DockableContent.IsActiveContent Then Return
'    '        If value Then _DockableContent.Activate()
'    '    End Set
'    'End Property

'    'Public Property IsVisible As Boolean Implements Core.UI.IWindow.IsVisible
'    '    Get
'    '        Return _DockableContent.IsVisible
'    '    End Get
'    '    Set(ByVal value As Boolean)
'    '        If _DockableContent.IsVisible = value Then Return
'    '        Try
'    '            If value Then _DockableContent.Show()
'    '        Catch ex As Exception
'    '            Try
'    '                If value Then _DockableContent.Activate()
'    '            Catch ex1 As Exception
'    '                MessageBox.Show(ex1.ToString())
'    '            End Try
'    '        End Try


'    '        RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("IsVisible"))
'    '    End Set
'    'End Property

'    'Public ReadOnly Property View As Object Implements Core.UI.IWindow.View
'    '    Get
'    '        Return _DockableContent.Content
'    '    End Get
'    'End Property

'    'Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
'    'Public Event PropertyChanging(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangingEventArgs) Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging

'    'Public Sub Hide() Implements Core.UI.IToolWindow.Hide
'    '    _DockableContent.Hide()
'    'End Sub

'    'Public ReadOnly Property IsHidden As Boolean Implements Core.UI.IToolWindow.IsHidden
'    '    Get
'    '        Return Not _DockableContent.IsVisible
'    '    End Get
'    'End Property

'    'Public ReadOnly Property State As Object Implements Core.UI.IToolWindow.State
'    '    Get
'    '        Return _DockableContent.State.ToString()
'    '    End Get
'    'End Property

'    'Public ReadOnly Property Name As String Implements Core.UI.IToolWindow.Name
'    '    Get
'    '        Return _DockableContent.Name
'    '    End Get
'    'End Property
'End Class

Public Class AvalonDockDocumentWindow
    Implements Core.UI.IDocumentWindow

    Dim _Caption As String
    Dim _View As Object

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Public Event PropertyChanging(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangingEventArgs) Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging

    Sub New(ByVal View As Object)
        Me._View = View
    End Sub

    Public Sub Close() Implements Core.UI.IDocumentWindow.Close

    End Sub

    Public ReadOnly Property IsClosed As Boolean Implements Core.UI.IDocumentWindow.IsClosed
        Get

        End Get
    End Property

    Public Property Caption As String Implements Core.UI.IWindow.Caption
        Get
            Return _Caption
        End Get
        Set(ByVal value As String)
            _Caption = value
            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("Caption"))
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

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public Property IsVisible As Boolean Implements Core.UI.IWindow.IsVisible
        Get

        End Get
        Set(ByVal value As Boolean)

        End Set
    End Property

    Public ReadOnly Property View As Object Implements Core.UI.IWindow.View
        Get
            Return _View
        End Get
    End Property
End Class

Public Class AvalonDockToolWindow
    Implements Core.UI.IToolWindow
    Implements ICommand

    Dim _Caption As String
    Dim _View As Object
    Private _id As String
    Dim _IsActive As Boolean = True
    Dim _IsVisible As Boolean = True
    Dim _visibility As Visibility = Visibility.Visible

    Sub New(ByVal view As Object, ByVal id As String)
        ' TODO: Complete member initialization 
        _View = view
        _id = id
        CloseCommand = Me
    End Sub

    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
    Public Event PropertyChanging(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangingEventArgs) Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging

    Sub New(ByVal View As Object)
        Me._View = View
        CloseCommand = Me
    End Sub


    Public Sub Hide() Implements Core.UI.IToolWindow.Hide

    End Sub

    Public ReadOnly Property IsHidden As Boolean Implements Core.UI.IToolWindow.IsHidden
        Get

        End Get
    End Property

    Public ReadOnly Property Name As String Implements Core.UI.IToolWindow.Name
        Get
            Return _id
        End Get
    End Property

    Public ReadOnly Property State As Object Implements Core.UI.IToolWindow.State
        Get

        End Get
    End Property

    Public Property Caption As String Implements Core.UI.IWindow.Caption
        Get
            Return _Caption
        End Get
        Set(ByVal value As String)
            _Caption = value
            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("Caption"))
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
            Return _IsActive
        End Get
        Set(ByVal value As Boolean)

            Me._IsActive = value

            If Not IsVisible Then
                IsVisible = True
            End If

            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("IsActive"))

        End Set
    End Property

    Public Property CloseCommand As ICommand


    Public Property IsVisible As Boolean Implements Core.UI.IWindow.IsVisible
        Get
            '           Return _IsVisible
            Return _visibility = Visibility.Visible
        End Get
        Set(ByVal value As Boolean)
            ' Me._IsVisible =If( value
            Me._visibility = If(value, Visibility.Visible, Visibility.Hidden)
            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("IsVisible"))
            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("Visibility"))

        End Set
    End Property

    Public Property Visibility As Visibility
        Get
            Return _visibility
        End Get
        Set(ByVal value As Visibility)
            _visibility = value
            _IsVisible = (value = Windows.Visibility.Visible)
            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("IsVisible"))
            RaiseEvent PropertyChanged(Me, New ComponentModel.PropertyChangedEventArgs("Visibility"))

        End Set
    End Property

    Public ReadOnly Property View As Object Implements Core.UI.IWindow.View
        Get
            Return _View
        End Get
    End Property

    Public Function CanExecute(ByVal parameter As Object) As Boolean Implements System.Windows.Input.ICommand.CanExecute
        Return True
    End Function

    Public Event CanExecuteChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements System.Windows.Input.ICommand.CanExecuteChanged

    Public Sub Execute(ByVal parameter As Object) Implements System.Windows.Input.ICommand.Execute

    End Sub
End Class