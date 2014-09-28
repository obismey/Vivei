Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition

Class Application
    Implements Core.IApplication

    Private _container As CompositionContainer

    <ImportMany(GetType(Core.IPlugin))> _
    Private _plugins As List(Of System.Lazy(Of Core.IPlugin, Object))

    Private _services As New List(Of Core.IService)

    Public Function GetPlugins() As System.Collections.Generic.IEnumerable(Of Core.IPlugin) Implements Core.IApplication.GetPlugins
        Return _plugins.Select(Function(lazy) lazy.Value)
    End Function

    Public Function GetServices() As System.Collections.Generic.IEnumerable(Of Core.IService) Implements Core.IApplication.GetServices
        Return _services
    End Function

    Private Sub Application_Exit(ByVal sender As Object, ByVal e As System.Windows.ExitEventArgs) Handles Me.Exit
        _container.Dispose()
        'Dim vconfig = XElement.Load("VisualConfig.xml")
        'Dim manager = UIService.Instance.Windows(0).Manager
        ''For Each elt In UIService.Instance.Windows
        ''    Dim x = <Window id=<%= elt.Tag %> DockableStyle=<%= elt.DockableStyle %> Stat=<%= elt.State %>/>

        ''    vconfig.Add(x)
        ''Next
        'Dim x = <Windows/>
        'manager.SaveLayout(x.CreateWriter())
        'vconfig.Add(x)
        'vconfig.Save("VisualConfig.xml")
    End Sub

    Private Sub Application_Startup(ByVal sender As Object, ByVal e As System.Windows.StartupEventArgs) Handles Me.Startup
        _services.Add(UIService.Instance)
        _services.Add(UndoRedoService.Instance)

        Dim catalog = New AggregateCatalog()

        catalog.Catalogs.Add(New AssemblyCatalog(Me.GetType().Assembly))

        For Each directory In IO.Directory.EnumerateDirectories( _
            IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules"))

            catalog.Catalogs.Add(New DirectoryCatalog(directory))
        Next

        _container = New CompositionContainer(catalog)

        Dim batch = New CompositionBatch()

        batch.AddPart(Me)

        Try
            _container.Compose(batch)
        Catch ex As Exception
            _container.Dispose()
        End Try

        For Each p In _plugins
            p.Value.Reset(Me)
        Next

    End Sub
End Class
