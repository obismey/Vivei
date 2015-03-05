Imports Vivei.Tools.Core

Public Class ReservingPlugin
    Implements IPlugin

    Private _Application As IApplication
    Private _UIService As UI.IUIService
    Private _ScriptingService As Scripting.IScriptingService

    Private _RootProjectItem As ViewModel.ProjectTreeItem


    Private Shared _Instance As ReservingPlugin
    Dim _CurrentProject As Model.Project
    Dim _WorkflowService As Workflow.IWorkflowService

    Public Shared ReadOnly Property Instance As ReservingPlugin
        Get
            Return _Instance
        End Get
    End Property

    Public ReadOnly Property RootProjectItem As ViewModel.ProjectTreeItem
        Get
            Return _RootProjectItem
        End Get
    End Property

    Public ReadOnly Property CurrentProject As Model.Project
        Get
            Return _CurrentProject
        End Get
    End Property

    Sub New()
        If _Instance Is Nothing Then
            _Instance = Me
            Me._CurrentProject = New Model.Project
        End If
    End Sub

    Public Function GetServices() As System.Collections.Generic.IEnumerable(Of Core.IService) Implements Core.IPlugin.GetServices
        Return Nothing
    End Function

    Public Sub Reset(ByVal Application As Core.IApplication) Implements Core.IPlugin.Reset
        If _Instance IsNot Me Then Return

        Me._Application = Application
        For Each Service In Application.GetServices()
            If Me._UIService Is Nothing Then
                Me._UIService = TryCast(Service, UI.IUIService)
            End If
            If Me._ScriptingService Is Nothing Then
                Me._ScriptingService = TryCast(Service, Scripting.IScriptingService)
            End If
            If Me._WorkflowService Is Nothing Then
                Me._WorkflowService = TryCast(Service, Workflow.IWorkflowService)
            End If
        Next

        If _UIService Is Nothing Then Return

        SetupDefaultProjectTree("Nouveau Projet")

        Me._UIService.RegisterWindow("LogView", "Liste des erreurs", "", New LogView())
        Me._UIService.RegisterWindow("ProjectView", "Explorateur de projets", "", New ProjectView())
        'Me._UIService.OpenDocument("DataImportView", "Liste des erreurs", New DataImportView())


    End Sub

    Private Sub SetupDefaultProjectTree(ByVal rootheader As String)
        _RootProjectItem = New ViewModel.ProjectTreeItem()
        _RootProjectItem.Caption = rootheader

        Dim importsProjectTreeItem = New ViewModel.ProjectTreeItem()
        importsProjectTreeItem.Caption = "Imports"
        importsProjectTreeItem.ContextMenu = New ObjectModel.ObservableCollection(Of Core.UI.MenuItem)()

        Dim scriptProjectTreeItem = New ViewModel.ProjectTreeItem()
        scriptProjectTreeItem.Caption = "Scripts"
        scriptProjectTreeItem.ContextMenu = New ObjectModel.ObservableCollection(Of Core.UI.MenuItem)()

        Dim analysisProjectTreeItem = New ViewModel.ProjectTreeItem()
        analysisProjectTreeItem.Caption = "Analyses"
        analysisProjectTreeItem.ContextMenu = New ObjectModel.ObservableCollection(Of Core.UI.MenuItem)()

        Dim batchsProjectTreeItem = New ViewModel.ProjectTreeItem()
        batchsProjectTreeItem.Caption = "Batchs"
        batchsProjectTreeItem.ContextMenu = New ObjectModel.ObservableCollection(Of Core.UI.MenuItem)()

        _RootProjectItem.Children.Add(importsProjectTreeItem)
        _RootProjectItem.Children.Add(scriptProjectTreeItem)
        _RootProjectItem.Children.Add(analysisProjectTreeItem)
        _RootProjectItem.Children.Add(batchsProjectTreeItem)

        Dim importDataMenuItem = _
            New Core.UI.MenuItem( _
            "Importer des données", _
            Sub()

                Dim dataSourceName = Microsoft.VisualBasic.InputBox( _
                    "Nom de la source de données",
                    DefaultResponse:="Data-" & Now.ToShortDateString() & "-" & Now.ToLongTimeString())

                Dim dsrc = New Model.DataSource
                dsrc.Name = dataSourceName
                Dim view = New DataImportView()
                view.DataSource = dsrc

                Dim datasrc = Me._UIService.OpenDocument(dataSourceName, "", view)

                Dim dataSourceProjectTreeItem = New ViewModel.ProjectTreeItem()
                dataSourceProjectTreeItem.Caption = dataSourceName

                dataSourceProjectTreeItem.OnDoubleClick = Sub()
                                                              If Not datasrc.IsClosed Then
                                                                  'Me._UIService.OpenDocument(dataSourceName, "", New DataImportView())
                                                              Else
                                                                  datasrc.IsActive = True
                                                              End If
                                                          End Sub


                importsProjectTreeItem.Children.Add(dataSourceProjectTreeItem)
            End Sub)

        importsProjectTreeItem.ContextMenu.Add(importDataMenuItem)

        Dim scriptStandardMenuItem = _
           New Core.UI.MenuItem( _
           "Ajouter un script", _
           Sub()

               'Me._UIService.OpenDocument("Triangle Standard", "", New TriangleView())
               Dim modname = "Script-" & Now.ToShortDateString() & "-" & Now.ToLongTimeString()
               Dim helppane = New ScriptingHelpPane()
               Dim scp = Me._ScriptingService.CreateProject("")
               scp.AddAssemblyReference(Me.GetType().Assembly)

               Dim modl = scp.AddModule(modname)
               modl.ImportedNamespaces.Add("Vivei.Tools.Plugins.Reserving.Model")
               helppane.ScriptingModule = modl

               Me._ScriptingService.OpenModule(modl, helppane)

               Dim dataSourceProjectTreeItem = New ViewModel.ProjectTreeItem()
               dataSourceProjectTreeItem.Caption = "Script"

               dataSourceProjectTreeItem.OnDoubleClick = Sub()

                                                         End Sub

               scriptProjectTreeItem.Children.Add(dataSourceProjectTreeItem)
           End Sub)


        scriptProjectTreeItem.ContextMenu.Add(scriptStandardMenuItem)

        Dim triangleStandardMenuItem = _
           New Core.UI.MenuItem( _
           "Creer une analyse", _
           Sub()

               ''Me._UIService.OpenDocument("Triangle Standard", "", New TriangleView())
               Dim modname = "Analyse-" & Now.ToShortDateString() & "-" & Now.ToLongTimeString()
               'Dim helppane = New ScriptingHelpPane()
               'Dim scp = Me._ScriptingService.CreateProject("")
               'scp.AddAssemblyReference(Me.GetType().Assembly)

               'Dim modl = scp.AddModule(modname)
               'modl.ImportedNamespaces.Add("Vivei.Tools.Plugins.Reserving.Model")
               'helppane.ScriptingModule = modl

               Me._WorkflowService.OpenWorflow(modname, New Workflow.WorkflowDocument())

               Dim dataSourceProjectTreeItem = New ViewModel.ProjectTreeItem()
               dataSourceProjectTreeItem.Caption = "Analyse"

               'dataSourceProjectTreeItem.OnDoubleClick = Sub() Me._UIService.OpenDocument(dataSourceName, "", New DataImportView())

               analysisProjectTreeItem.Children.Add(dataSourceProjectTreeItem)
           End Sub)


        analysisProjectTreeItem.ContextMenu.Add(triangleStandardMenuItem)
    End Sub
End Class
