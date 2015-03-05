Namespace Model

    Public Class Project

        Public Property DataSources As New ObjectModel.ObservableCollection(Of DataSource)

        Public Function GetDataSource(ByVal name As String) As DataSource
            Try
                Return (From prop In DataSources Where prop.Name = name Select prop Take 1).FirstOrDefault()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class

    Public Class DataSource

        Public Property Name As String

        Friend Property ConnectionString As String

        Friend Property Type As String

        Public Property Model As DataModel

        Friend Property Table As System.Data.DataTable

        Public ReadOnly Property Data As System.Collections.Generic.IEnumerable(Of System.Data.DataRow)
            Get
                Return Me.Table.Rows.Cast(Of System.Data.DataRow)()
            End Get
        End Property

        Public Function GetColumnBySourceName(ByVal name As String) As System.Data.DataColumn
            Try
                Return Table.Columns(name)
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function GetColumnByName(ByVal name As String) As System.Data.DataColumn
            Try
                Return (From prop In Model Where prop.Name = name Select prop.SourceColumn Take 1).FirstOrDefault()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        Public Function GetColumnByUsage(ByVal usage As String) As System.Data.DataColumn
            Try
                Return (From prop In Model Where prop.Usage = usage Select prop.SourceColumn Take 1).FirstOrDefault()
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
    End Class

    'Public Class Table

    '    Public Function GetColumnByName()
    'End Class
End Namespace