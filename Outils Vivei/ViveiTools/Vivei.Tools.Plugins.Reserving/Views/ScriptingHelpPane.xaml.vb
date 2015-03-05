Public Class ScriptingHelpPane

    Property ScriptingModule As Core.Scripting.ScriptingModule

    Private Sub InsererNomColonneButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles InsererNomColonneButton.Click
        Try
            Me.ScriptingModule.InsertCode("Project.GetSource(""" & NameSourcesComboBox.SelectedValue & """).GetColumnByName(""" & NameColumnsComboBox.SelectedValue & """)")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub InsererUsageColonneButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Me.ScriptingModule.InsertCode("Project.GetSource(""" & UsageSourcesComboBox.SelectedValue & """).GetColumnByUsage(""" & UsageColumnsComboBox.SelectedValue & """)")
        Catch ex As Exception

        End Try
    End Sub
End Class
