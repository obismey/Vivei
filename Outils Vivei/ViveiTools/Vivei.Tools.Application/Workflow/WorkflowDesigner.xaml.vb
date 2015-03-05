Public Class WorkflowDesigner

    Public Property WfDesigner As System.Activities.Presentation.WorkflowDesigner

    Private Sub WorkflowDesigner_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        If WfDesigner Is Nothing Then

            WfDesigner = New System.Activities.Presentation.WorkflowDesigner()

            WfDesigner.Load(New System.Activities.Statements.Sequence())

            'UIService.Instance.RegisterWindow("WorkflowView", "Vue du workflow", "", WfDesigner.View)

            'UIService.Instance.RegisterWindow("WorkflowPropertyGrid", "Proprietes du workflow", "", WfDesigner.PropertyInspectorView)

            'Me.WfDesigner.Context.Services.Publish(Of View.IExpressionEditorService)(New ExpressionEditorService())

            Grid.SetColumn(WfDesigner.PropertyInspectorView, 2)
            Grid.SetRow(WfDesigner.PropertyInspectorView, 1)
            Grid.SetColumn(WfDesigner.View, 0)
            Grid.SetRow(WfDesigner.View, 1)

            Me.RootGrid.Children.Add(WfDesigner.View)

            Me.RootGrid.Children.Add(WfDesigner.PropertyInspectorView)
        End If

    End Sub

    Private Sub ExecuteButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub
End Class
