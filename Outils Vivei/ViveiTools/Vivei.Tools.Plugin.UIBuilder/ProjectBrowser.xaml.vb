Public Class ProjectBrowser

  
    Private Sub ProjectItem_ContentControl_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs)
        Dim pi As ProjectItem = sender.DataContext
        pi.DoubleClick()
    End Sub
End Class
