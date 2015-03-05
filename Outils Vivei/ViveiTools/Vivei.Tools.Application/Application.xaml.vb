Imports System.ComponentModel.Composition.Hosting
Imports System.ComponentModel.Composition
Imports System.Activities.Presentation.Toolbox

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
        _services.Add(ScriptingService.Instance)
        _services.Add(New WorkflowService())

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

Public Class WorkflowService
    Implements Core.Workflow.IWorkflowService


    Sub New()
        Reset()
    End Sub


    Public Sub Reset() Implements Core.IService.Reset


        Dim md = New System.Activities.Core.Presentation.DesignerMetadata()
        md.Register()

        Dim toolboxControl = New System.Activities.Presentation.Toolbox.ToolboxControl()

        toolboxControl.Categories.Add(New ToolboxCategory("Control Flow") From { _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.DoWhile)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.ForEach(Of ))), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.[If])), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Parallel)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.ParallelForEach(Of ))), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Pick)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.PickBranch)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Sequence)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Switch(Of ))), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.[While])) _
        })

        toolboxControl.Categories.Add(New ToolboxCategory("Primitives") From { _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Assign)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Delay)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.InvokeMethod)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.WriteLine)), _
         New ToolboxItemWrapper(GetType(CustomActivity))
        })

        toolboxControl.Categories.Add(New ToolboxCategory("Error Handling") From { _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.Rethrow)), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.[Throw])), _
         New ToolboxItemWrapper(GetType(System.Activities.Statements.TryCatch)) _
        })

        UIService.Instance.RegisterWindow("WorkflowToolBox", "Boites à outils du workflow", "", toolboxControl)

    

    End Sub

    Public Function OpenWorflow(ByVal name As String, ByVal document As Core.Workflow.WorkflowDocument) As Core.UI.IDocumentWindow Implements Core.Workflow.IWorkflowService.OpenWorflow
        Return UIService.Instance.OpenDocument(name, "", New WorkflowDesigner())
    End Function
End Class

Public NotInheritable Class CustomActivity
    Inherits System.Activities.CodeActivity

    'Définir un argument d'entrée d'activité de type String
    Property Code() As System.Activities.InArgument(Of String)

    ' Si votre activité retourne une valeur, dérivez de CodeActivity(Of TResult)
    ' et retournez la valeur à partir de la méthode Execute.
    Protected Overrides Sub Execute(ByVal context As System.Activities.CodeActivityContext)
        'Obtenir la valeur runtime de l'argument d'entrée Text
        Dim Code As String
        Code = context.GetValue(Me.Code)
    End Sub
End Class
