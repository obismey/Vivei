'<DockingManager version="1.3.0">
'   <DocumentPane IsMain="true" ResizeWidth="*" ResizeHeight="*" EffectiveSize="0,0" />
'   <Hidden />
'   <Windows />
' </DockingManager>



Class MainWindow

   

    'Private Sub MainWindow_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated

    'End Sub

    'Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
    '    Dim vconfig = XElement.Load("VisualConfig.xml")
    '    Dim x = vconfig.<DockingManager>.FirstOrDefault()
    '    If x IsNot Nothing Then
    '        x.Remove()
    '    End If

    '    'Dim manager = UIService.Instance.Windows(0).Manager
    '    ''For Each elt In UIService.Instance.Windows
    '    ''    Dim x = <Window id=<%= elt.Tag %> DockableStyle=<%= elt.DockableStyle %> Stat=<%= elt.State %>/>

    '    ''    vconfig.Add(x)
    '    ''Next
    '    '  Dim x = <Windows/>
    '    Dim str = New IO.StringWriter()
    '    Try
    '        DockingManager.SaveLayout(str)
    '        x = XElement.Parse(str.ToString())
    '        vconfig.Add(x)
    '    Catch ex As Exception

    '    End Try

    '    'For Each w In UIService.Instance.Windows
    '    '    If w.ContainerPane IsNot Nothing Then
    '    '        vconfig.Add(<WindowAssociation id=<%= w.ContainerPane.Tag %> name=<%= w.Tag %>/>)
    '    '    End If

    '    'Next
    '    'vconfig.Save("VisualConfig.xml")
    'End Sub


    'Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded


    'End Sub

    ''Private Sub UIServiceInstanceWindowsCollectionChanged(ByVal sender As Object, ByVal e As Specialized.NotifyCollectionChangedEventArgs)

    ''End Sub


    'Private Sub DockingManager_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles DockingManager.Loaded
    '    'For Each w In UIService.Instance.Windows

    '    '    'DefaultDockablePane.Items.Add(w)
    '    'Next
    '    'AddHandler UIService.Instance.Windows.CollectionChanged, AddressOf UIServiceInstanceWindowsCollectionChanged
    '    'DefaultDockablePane.ItemsSource=UIService.Instance.
    '    Try


    '        'Dim vconfig = XElement.Load("VisualConfig.xml")
    '        ''Dim x = vconfig.<DockingManager>.First()
    '        DockingManager.DeserializationCallback = Sub(s As Object, args As AvalonDock.DeserializationCallbackEventArgs)
    '                                                     Dim w = (From elt In UIService.Instance.Windows Where elt.Name = args.Name).FirstOrDefault()
    '                                                     Dim wc = w.Content
    '                                                     w.Content = Nothing
    '                                                     args.Content = w
    '                                                 End Sub

    '        'DockingManager.RestoreLayout(New IO.StringReader(x.ToString()))

    '        Dim DockingManagerContent = TryCast(DockingManager.Content, AvalonDock.DocumentPane)

    '        If DockingManagerContent IsNot Nothing Then
    '            'DockingManager.Content = Nothing
    '            'Dim rp = New AvalonDock.ResizingPanel()
    '            'DockingManager.Content = rp
    '            'Dim DefaultDockablePane = New AvalonDock.DockablePane()

    '            ''DefaultDockablePane.ItemsSource = UIService.Instance.Windows

    '            'rp.Children.Add(DockingManagerContent)
    '            ''DockingManager.MainDocumentPane = New AvalonDock.DocumentPane()
    '            ''rp.Children.Add(DockingManager.MainDocumentPane)
    '            'rp.Children.Add(DefaultDockablePane)
    '            'Dim firstpane As AvalonDock.DockablePane = DefaultDockablePane
    '            'For Each w In UIService.Instance.Windows
    '            '    If w.ContainerPane IsNot Nothing And firstpane Is Nothing Then
    '            '        firstpane = w.ContainerPane
    '            '    End If
    '            'Next

    '            'For Each w In UIService.Instance.Windows
    '            '    If w.ContainerPane Is Nothing And firstpane IsNot Nothing Then
    '            '        firstpane.Items.Add(w)
    '            '    End If
    '            'Next

    '            'For Each w In UIService.Instance.Windows

    '            'Next
    '        End If

    '        'If DockingManager.MainDocumentPane Is Nothing Then
    '        '    DockingManager.MainDocumentPane = New AvalonDock.DocumentPane()
    '        'End If

    '        'If DockingManager.Content Is Nothing Then
    '        '    DockingManager.Content = New AvalonDock.ResizingPanel()
    '        'End If
    '        ''Dim rp = TryCast(DockingManager.Content, AvalonDock.ResizingPanel)
    '        ''Dim drp = TryCast(DockingManager.Content, AvalonDock.DocumentPaneResizingPanel)

    '        '' ''Dim p = New AvalonDock.DockablePane()
    '        ''If rp Is Nothing Or drp IsNot Nothing Then
    '        ''    DockingManager.Content = New AvalonDock.ResizingPanel()
    '        ''    rp = DockingManager.Content
    '        ''End If
    '        '' ''rp.Children.Add(p)
    '        ''Dim rp = New AvalonDock.ResizingPanel()
    '        ''Dim p = New AvalonDock.DockablePane()
    '        ''Dim dp = New AvalonDock.DocumentPane()
    '        'Dim firstpane As AvalonDock.DockablePane = Nothing
    '        'For Each w In UIService.Instance.Windows
    '        '    If w.ContainerPane IsNot Nothing And firstpane Is Nothing Then
    '        '        firstpane = w.ContainerPane
    '        '    End If
    '        'Next
    '        'For Each w In UIService.Instance.Windows
    '        '    If w.ContainerPane Is Nothing And firstpane IsNot Nothing Then
    '        '        firstpane.Items.Add(w)
    '        '    End If
    '        'Next
    '        ''rp.Children.Add(p)
    '        ''rp.Children.Add(dp)
    '        ''DockingManager.Content = rp
    '        ''DockingManager.MainDocumentPane = dp

    '    Catch ex As Exception

    '    End Try
    'End Sub
End Class

Public Class PanesStyleSelector
    Inherits StyleSelector

    Public Property ToolStyle As Style
    Public Property FileStyle As Style


    Public Overrides Function SelectStyle(ByVal item As Object, ByVal container As System.Windows.DependencyObject) As System.Windows.Style
        CType(container, Xceed.Wpf.AvalonDock.Controls.LayoutDocumentItem).Title = "dddddddddddddddddd"
        Return ToolStyle
    End Function
End Class