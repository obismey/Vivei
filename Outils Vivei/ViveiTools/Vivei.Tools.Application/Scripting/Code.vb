Public Class ScriptingService
    Implements Core.Scripting.IScriptingService



    Private Shared _Instance As ScriptingService


    Public Shared ReadOnly Property Instance As ScriptingService
        Get
            If _Instance Is Nothing Then
                _Instance = New ScriptingService()
            End If
            Return _Instance
        End Get
    End Property

    Public Function CreateProject(ByVal name As String) As Core.Scripting.ScriptingProject Implements Core.Scripting.IScriptingService.CreateProject
        Return New ScriptingProjectImpl()
    End Function

    Public Function LoadProject(ByVal name As String) As Core.Scripting.ScriptingProject Implements Core.Scripting.IScriptingService.LoadProject

    End Function
    
    Public ReadOnly Property Projects As System.Collections.Generic.ICollection(Of Core.Scripting.ScriptingProject) Implements Core.Scripting.IScriptingService.Projects
        Get

        End Get
    End Property

    Public Sub Reset() Implements Core.IService.Reset

    End Sub

    Public Function OpenModule(ByVal [Module] As Core.Scripting.ScriptingModule, Optional ByVal BottomView As Object = Nothing) As Core.UI.IDocumentWindow Implements Core.Scripting.IScriptingService.OpenModule
        Dim view = New ScriptView()
        view.ScriptingModule = [Module]
        view.ScriptingProject = [Module].ScriptingProject
        view.BottomViewContentControl.Content = BottomView
        AddHandler CType([Module], ScriptingModuleImpl).CodeInserted, Sub(sender As Object, code As String) view.AvalonEditCodeTextEditor.Document.Insert(view.AvalonEditCodeTextEditor.CaretOffset, code)
        Return UIService.Instance.OpenDocument([Module].Name, "", view)
    End Function
End Class

Public Class ScriptingProjectImpl
    Inherits Core.Scripting.ScriptingProject

    Public Property AssemblyReferences As New List(Of Reflection.Assembly)

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function AddModule(ByVal Name As String) As Core.Scripting.ScriptingModule
        Return New ScriptingModuleImpl() With {.Name = Name, .ScriptingProject = Me}
    End Function

    Public Overrides Function AddAssemblyReference(ByVal Assembly As System.Reflection.Assembly) As Core.Scripting.ScriptingReference
        AssemblyReferences.Add(Assembly)
        RaiseEvent AssemblyReferenceAdded(Me, Assembly)
        Return Nothing
    End Function

    Public Event AssemblyReferenceAdded(ByVal sender As Object, ByVal Assembly As System.Reflection.Assembly)
End Class

Public Class ScriptingReferenceImpl
    Inherits Core.Scripting.ScriptingReference

    Public Sub New()
        MyBase.New()
    End Sub



End Class

Public Class ScriptingModuleImpl
    Inherits Core.Scripting.ScriptingModule

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Sub InsertCode(ByVal code As String)
        RaiseEvent CodeInserted(Me, code)
    End Sub

    Public Event CodeInserted(ByVal sender As Object, ByVal code As String)

End Class