Imports Vivei.Tools.Core
Imports System.Windows.Threading
Imports Vivei.Tools.Core.UI
Imports System.Collections.ObjectModel


Public Class UIBuilderPlugin
    Implements IPlugin

    Private _Application As IApplication
    Friend Shared _UIService As UI.IUIService
    Friend Shared _UndoRedoService As UndoRedo.IUndoRedoService
    Friend Shared _MainResourceDictionary As MainResourceDictionary
    Public Sub New()

    End Sub

    Public Function GetServices() As System.Collections.Generic.IEnumerable(Of Core.IService) Implements Core.IPlugin.GetServices
        Return Nothing
    End Function

    Public Sub Reset(ByVal Application As Core.IApplication) Implements Core.IPlugin.Reset
        Me._Application = Application
        For Each Service In Application.GetServices()
            If _UIService Is Nothing Then
                _UIService = TryCast(Service, UI.IUIService)
            End If
            If _UndoRedoService Is Nothing Then
                _UndoRedoService = TryCast(Service, UndoRedo.IUndoRedoService)
            End If
        Next
        'ActiveFolder.Instance = New ActiveFolder()
        ''   Me._UIService.RegisterWindow("time", "", New TimeView())
        'Me._UIService.RegisterWindow("FolderBrowser", "Folder Browser", "", New Browser())
        'Dim lst = New ListBox()
        ''Dim factoryPanel = New FrameworkElementFactory(GetType(WrapPanel))
        ''factoryPanel.SetValue(WrapPanel.IsItemsHostProperty, True)
        ''Dim template = New ItemsPanelTemplate()
        ''template.VisualTree = factoryPanel
        ''lst.ItemsPanel = template
        'lst.DataContext = ActiveFolder.Instance
        'BindingOperations.SetBinding(lst, ListBox.ItemsSourceProperty, New Binding("Value.Files"))
        'Dim s = New Style(GetType(ListBoxItem))
        's.Setters.Add(New EventSetter(Control.MouseDoubleClickEvent, New MouseButtonEventHandler(AddressOf OpenDocument)))
        'lst.ItemContainerStyle = s
        _UIService.RegisterWindow("UIBuilderProjectBrowser", "Project Browser", "", New ProjectBrowser())
        _UIService.RegisterWindow("UIBuilderDocumentStructure", "Document Structure", "", New DocumentStructure())
        _UIService.RegisterWindow("UIBuilderNodeStyle", "Style du Noeud", "", New NodeStyle())

        _MainResourceDictionary = New MainResourceDictionary()
        _MainResourceDictionary.InitializeComponent()
        'Me._UIService.HomeMenuItem.OnClick = Sub() Me._UIService.OpenDocument("ttttt", "", New FsWpfControls.FsRichTextBox.FsRichTextBox())
    End Sub

    'Private ExcelInitialized As Boolean = False
    ''Private ExcelApplication As Microsoft.Office.Interop.Excel.Application
    'Private Sub OpenDocument(ByVal sender As Object, ByVal args As MouseButtonEventArgs)
    '    Dim finfo As IO.FileInfo = sender.DataContext
    '    If finfo.Extension = ".xps" Or finfo.Extension = ".docx" Then
    '        'Dim editor = New FsWpfControls.FsRichTextBox.FsRichTextBox()
    '        Dim xps = New XpsDocument(finfo.FullName, IO.FileAccess.Read)
    '        'Dim writer = XpsDocument.CreateXpsDocumentWriter(xps)
    '        'Dim doc = New FlowDocument()
    '        'writer.Write(doc.DocumentPaginator)
    '        Dim v = New DocumentViewer()
    '        v.Document = xps.GetFixedDocumentSequence()
    '        _UIService.OpenDocument(finfo.Name, "", v)
    '    End If
    '    If finfo.Extension.Contains(".xls") Then
    '        'If Not ExcelInitialized Then
    '        '    ExcelApplication = New Microsoft.Office.Interop.Excel.Application()
    '        '    ExcelApplication.WindowState = Microsoft.Office.Interop.Excel.XlWindowState.xlNormal
    '        '    ExcelApplication.Visible = True
    '        '    ExcelInitialized = True
    '        'End If
    '        'ExcelApplication.Workbooks.Open(finfo.FullName)
    '        Dim wfh = New Forms.Integration.WindowsFormsHost()
    '        Dim ev = New ExcelViewer.ExcelViewer()
    '        ev.OpenFile(finfo.FullName)
    '        ev.Dock = System.Windows.Forms.DockStyle.Fill
    '        wfh.Child = ev
    '        _UIService.OpenDocument(finfo.Name, "", wfh)
    '    End If
    'End Sub
End Class