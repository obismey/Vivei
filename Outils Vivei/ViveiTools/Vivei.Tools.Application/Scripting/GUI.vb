Namespace Scripting
    Public Module GUI
        Public Sub ShowMessage(ByVal message As Object)
            Try
                MessageBox.Show(message)
            Catch ex As Exception
                MessageBox.Show(message.ToString())
            End Try
        End Sub
    End Module

    Public Module ENV
        Public ReadOnly Property DomainName As String
            Get
                Return Environment.UserDomainName
            End Get
        End Property

        Public ReadOnly Property UserName As String
            Get
                Return Environment.UserName
            End Get
        End Property

        Public ReadOnly Property MachineName As String
            Get
                Return Environment.MachineName
            End Get
        End Property
    End Module
End Namespace