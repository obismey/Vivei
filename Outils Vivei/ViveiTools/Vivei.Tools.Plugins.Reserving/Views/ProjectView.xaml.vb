Public Class ProjectView

    Private Sub ContentControl_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        Dim item = CType(CType(sender, ContentControl).DataContext, ViewModel.ProjectTreeItem)

        If item.OnDoubleClick Is Nothing Then
            item.OnDoubleClick.Invoke()
        End If
    End Sub
End Class
