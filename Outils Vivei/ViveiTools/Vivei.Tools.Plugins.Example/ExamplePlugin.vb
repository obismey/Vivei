Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports System.Windows.Xps.Packaging


Public Class ExamplePlugin
    Implements IPlugin

    Private _Application As IApplication
    Dim _UIService As UI.IUIService

  

    Public Sub New()

    End Sub

    Public Function GetServices() As System.Collections.Generic.IEnumerable(Of Core.IService) Implements Core.IPlugin.GetServices
        Return Nothing
    End Function

    Public Sub Reset(ByVal Application As Core.IApplication) Implements Core.IPlugin.Reset
        Me._Application = Application
        For Each Service In Application.GetServices()
            If Me._UIService Is Nothing Then
                Me._UIService = TryCast(Service, UI.IUIService)
                Exit For
            End If
        Next
        ActiveFolder.Instance = New ActiveFolder()
        '   Me._UIService.RegisterWindow("time", "", New TimeView())
        Me._UIService.RegisterWindow("FolderBrowser", "Folder Browser", "", New Browser())
        Dim lst = New ListBox()
        'Dim factoryPanel = New FrameworkElementFactory(GetType(WrapPanel))
        'factoryPanel.SetValue(WrapPanel.IsItemsHostProperty, True)
        'Dim template = New ItemsPanelTemplate()
        'template.VisualTree = factoryPanel
        'lst.ItemsPanel = template
        lst.DataContext = ActiveFolder.Instance
        BindingOperations.SetBinding(lst, ListBox.ItemsSourceProperty, New Binding("Value.Files"))
        Dim s = New Style(GetType(ListBoxItem))
        s.Setters.Add(New EventSetter(Control.MouseDoubleClickEvent, New MouseButtonEventHandler(AddressOf OpenDocument)))
        lst.ItemContainerStyle = s
        Me._UIService.RegisterWindow("FileList", "File List", "", lst)


        Me._UIService.HomeMenuItem.OnClick = Sub() Me._UIService.OpenDocument("ttttt", "", New FsWpfControls.FsRichTextBox.FsRichTextBox())
    End Sub

    Private ExcelInitialized As Boolean = False
    Private ExcelApplication As Microsoft.Office.Interop.Excel.Application
    Private Sub OpenDocument(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
        Dim finfo As IO.FileInfo = sender.DataContext
        If finfo.Extension = ".xps" Or finfo.Extension = ".docx" Then
            'Dim editor = New FsWpfControls.FsRichTextBox.FsRichTextBox()
            Dim xps = New XpsDocument(finfo.FullName, IO.FileAccess.Read)
            'Dim writer = XpsDocument.CreateXpsDocumentWriter(xps)
            'Dim doc = New FlowDocument()
            'writer.Write(doc.DocumentPaginator)
            Dim v = New DocumentViewer()
            v.Document = xps.GetFixedDocumentSequence()
            _UIService.OpenDocument(finfo.Name, "", v)
        End If
        If finfo.Extension.Contains(".xls") Then
            'If Not ExcelInitialized Then
            '    ExcelApplication = New Microsoft.Office.Interop.Excel.Application()
            '    ExcelApplication.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlNormal
            '    ExcelApplication.Visible = True
            '    ExcelInitialized = True
            'End If
            'ExcelApplication.Workbooks.Open(finfo.FullName)
            Dim wfh = New Forms.Integration.WindowsFormsHost()
            Dim ev = New ExcelViewer.ExcelViewer()
            ev.OpenFile(finfo.FullName)
            ev.Dock = System.Windows.Forms.DockStyle.Fill
            wfh.Child = ev
            _UIService.OpenDocument(finfo.Name, "", wfh)
        End If
    End Sub
End Class

Public Class Time
    Inherits DependencyObject

    Public Shared Property Instance As Time = New Time()

    Private WithEvents Timer As DispatcherTimer
    Sub New()
        Timer = New DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Background, Sub() Me.Value = Now, Application.Current.Dispatcher)
        Timer.Start()
    End Sub



    Public Property Value As String
        Get
            Return GetValue(ValueProperty)
        End Get

        Set(ByVal value As String)
            SetValue(ValueProperty, value)
        End Set
    End Property

    Public Shared ReadOnly ValueProperty As DependencyProperty = _
                           DependencyProperty.Register("Value", _
                           GetType(String), GetType(Time), _
                           New FrameworkPropertyMetadata(""))



End Class

Public Class BrowserItem
    Inherits Core.UI.UIObject

    Dim _DirectoryInfo As IO.DirectoryInfo

    Public Sub New(ByVal directoryInfo As System.IO.DirectoryInfo)
        Me._DirectoryInfo = directoryInfo
        Me.Name = Me._DirectoryInfo.Name
        Me.FullPath = Me._DirectoryInfo.FullName
    End Sub
    Public Sub New(ByVal p As String)

    End Sub
    Private _Directories As IEnumerable(Of BrowserItem)

    Public Property Name As String
    Public Property IsExpanded As Boolean
    Public ReadOnly Property Directories As IEnumerable(Of BrowserItem)
        Get
            If _Directories Is Nothing Then
                Try
                    _Directories = From d In _DirectoryInfo.EnumerateDirectories() Select New BrowserItem(d)
                Catch ex As Exception

                End Try
            End If
            Return _Directories
        End Get
    End Property
    Public ReadOnly Property Files As IEnumerable(Of IO.FileInfo)
        Get
            Return _DirectoryInfo.EnumerateFiles()
        End Get
    End Property
    Public Shared ReadOnly Property RootItems As IEnumerable(Of BrowserItem)
        Get
            Return IO.Directory.GetLogicalDrives().Select(Function(d) New BrowserItem(New IO.DirectoryInfo(d)))
        End Get
    End Property

    Public Property FullPath As String

    Private _IsSelected As Boolean
    Public Property IsSelected As Boolean
        Get
            Return _IsSelected
        End Get
        Set(ByVal value As Boolean)
            _IsSelected = value
            If value Then
                ActiveFolder.Instance.Value = Me
            End If
            OnPropertyChanged("IsSelected")
        End Set
    End Property


End Class
Public Class ActiveFolder
    Inherits Core.UI.UIObject

    Private _Value As BrowserItem
    Public Property Value As BrowserItem
        Get
            Return _Value
        End Get
        Set(ByVal value As BrowserItem)
            _Value = value
            OnPropertyChanged("Value")
        End Set
    End Property

    Public Shared Property Instance As ActiveFolder
End Class

Public Module ExtensionModule
    <System.Runtime.CompilerServices.Extension()> _
    Public Function ToImageSource(ByVal icon As System.Drawing.Icon) As ImageSource
        Dim imageSource As ImageSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHIcon(icon.Handle, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions())

        Return imageSource
    End Function
End Module