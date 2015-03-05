Imports System.Data

Public Class SimpleCsvReader

    Public Shared Function Read(ByVal file As String) As DataTable
        Dim lines = IO.File.ReadLines(file).GetEnumerator()
        Dim result As DataTable = New DataTable()
        result.BeginLoadData()
        lines.MoveNext()
        Dim separator = ";"c
        Dim firstline = lines.Current.Split(separator)
        If firstline.Length = 1 Then
            If firstline(0).Contains(",") Then
                separator = ","c
                firstline = lines.Current.Split(separator)
            End If
        End If
        For Each s In firstline
            result.Columns.Add(s, GetType(String))
        Next

        While lines.MoveNext()
            result.Rows.Add(lines.Current.Split(separator))
        End While

        result.EndLoadData()
        Return result
    End Function

    Public Shared Function Read(ByVal file As String, _
                                ByVal separator As String, _
                                ByVal decimalCharacter As Char, _
                                ByVal colonneNames As String(), _
                                ByVal colonneTypes As String(), _
                                ByVal colonneFormats As String()) As DataTable
        Dim lines = IO.File.ReadLines(file).GetEnumerator()
        Dim result As DataTable = New DataTable()
        If decimalCharacter = "."c Then
            result.Locale = Globalization.CultureInfo.InvariantCulture
        ElseIf decimalCharacter = ","c Then
            result.Locale = Globalization.CultureInfo.GetCultureInfo("fr-FR")
        End If


        For i = 0 To colonneNames.Length - 1
            If colonneTypes(i) = "Texte" Then
                result.Columns.Add(colonneNames(i), GetType(String))
            ElseIf colonneTypes(i) = "Nombre" Then
                result.Columns.Add(colonneNames(i), GetType(Double))
            ElseIf colonneTypes(i) = "Date" Then
                result.Columns.Add(colonneNames(i), GetType(DateTime))
            End If
        Next

        lines.MoveNext()
        Dim firstline = lines.Current.Split(separator).ToList()
        Dim colonneIndexes(colonneNames.Length) As Integer
        For i = 0 To colonneNames.Length - 1
            Dim colname = colonneNames(i)
            If colname.StartsWith("""") And colname.Trim().EndsWith("""") Then
                colname = colname.Trim().Substring(1, colname.Trim().Length - 2)
            End If
            colonneIndexes(i) = firstline.IndexOf(colname)

            If colonneIndexes(i) = -1 Then
                colonneIndexes(i) = firstline.IndexOf("""" & colname & """")
            End If

        Next

        result.BeginLoadData()
        While lines.MoveNext()
            Dim line = lines.Current.Split(separator)
            Dim nr = result.NewRow()
            For i = 0 To colonneNames.Length - 1
                If colonneTypes(i) = "Texte" Then
                    Dim colvalue = line(colonneIndexes(i))

                    If colvalue.StartsWith("""") And colvalue.Trim().EndsWith("""") Then
                        colvalue = colvalue.Trim().Substring(1, colvalue.Trim().Length - 2)
                    End If

                    nr(i) = colvalue
                ElseIf colonneTypes(i) = "Nombre" Then
                    Dim colvalue = line(colonneIndexes(i))

                    If colvalue.StartsWith("""") And colvalue.Trim().EndsWith("""") Then
                        colvalue = colvalue.Trim().Substring(1, colvalue.Trim().Length - 2)
                    End If

                    If colvalue <> "" Then
                        If decimalCharacter = "."c Then
                            Dim doublevalue As Double

                            If Double.TryParse(colvalue, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, doublevalue) Then
                                nr(i) = doublevalue
                            Else
                                If Double.TryParse(colvalue, Globalization.NumberStyles.Any, Globalization.CultureInfo.GetCultureInfo("fr-FR"), doublevalue) Then
                                    nr(i) = doublevalue
                                Else
                                    nr(i) = DBNull.Value
                                End If
                            End If
                          
                        ElseIf decimalCharacter = ","c Then
                            Dim doublevalue As Double

                            If Double.TryParse(colvalue, Globalization.NumberStyles.Any, Globalization.CultureInfo.GetCultureInfo("fr-FR"), doublevalue) Then
                                nr(i) = doublevalue
                            Else
                                If Double.TryParse(colvalue, Globalization.NumberStyles.Any, Globalization.CultureInfo.InvariantCulture, doublevalue) Then
                                    nr(i) = doublevalue
                                Else
                                    nr(i) = DBNull.Value
                                End If
                            End If
                         
                        End If
                    Else
                        nr(i) = DBNull.Value ' 0.0
                    End If
                ElseIf colonneTypes(i) = "Date" Then
                    'result.Columns.Add(colonneNames(i), GetType(DateTime))
                End If
            Next
            result.Rows.Add(nr)
        End While
        result.EndLoadData()

        Return result
    End Function

    Public Shared Sub ReadToDB(ByVal file As String, _
                                    ByVal separator As String, _
                                    ByVal decimalCharacter As Char, _
                                    ByVal colonneNames As String(), _
                                    ByVal colonneTypes As String(), _
                                    ByVal colonneFormats As String(), _
                                    ByVal tablename As String, _
                                    ByVal connectionstring As String)

        'Dim lines = IO.File.ReadLines(file).GetEnumerator()

        'lines.MoveNext()
        'Dim firstline = lines.Current.Split(separator).ToList()
        'Dim colonneIndexes(colonneNames.Length) As Integer
        'For i = 0 To colonneNames.Length - 1
        '    colonneIndexes(i) = firstline.IndexOf(colonneNames(i))
        'Next

        'Dim con = New SQLite.SQLiteConnection(connectionstring)
        'Dim inserttextbase = "INSERT INTO " & tablename.ToUpper() & "(" & String.Join(",", colonneNames) & ") VALUES("
        'Dim cmd = New SQLite.SQLiteCommand()
        'cmd.Connection = con
        'con.Open()
        'Dim trans = con.BeginTransaction()
        'While lines.MoveNext()
        '    Dim line = lines.Current.Split(separator)
        '    Dim inserttext = inserttextbase
        '    For i = 0 To colonneNames.Length - 1
        '        If colonneTypes(i) = "Texte" Then
        '            inserttext = inserttext & "'" & line(colonneIndexes(i)) & "'"
        '        ElseIf colonneTypes(i) = "Nombre" Then
        '            If line(colonneIndexes(i)) <> "" Then
        '                If decimalCharacter = "."c Then
        '                    '  nr(i) = Double.Parse(line(colonneIndexes(i)), Globalization.CultureInfo.InvariantCulture)
        '                    inserttext = inserttext & line(colonneIndexes(i))
        '                ElseIf decimalCharacter = ","c Then
        '                    inserttext = inserttext & Double.Parse(line(colonneIndexes(i)), Globalization.CultureInfo.GetCultureInfo("fr-FR")).ToString(Globalization.CultureInfo.InvariantCulture)
        '                End If
        '            Else
        '                inserttext = inserttext & "0.0"
        '            End If
        '        ElseIf colonneTypes(i) = "Date" Then
        '            'Date.Parse(,,'result.Columns.Add(colonneNames(i), GetType(DateTime))
        '        End If
        '        If i = colonneNames.Length - 1 Then
        '            inserttext = inserttext & ")"
        '        Else
        '            inserttext = inserttext & ","
        '        End If
        '    Next
        '    cmd.CommandText = inserttext
        '    cmd.ExecuteNonQuery()
        'End While
        'trans.Commit()
        'con.Close()
        'con.Dispose()
    End Sub

    Public Shared Function ReadFirstLine(ByVal file As String) As List(Of String)
        Dim lines = IO.File.ReadLines(file).GetEnumerator()
        lines.MoveNext()
        Dim separator = ";"c
        Dim linesCurrent = lines.Current
        Dim firstline = lines.Current.Split(separator)
        If firstline.Length = 1 Then
            If firstline(0).Contains(",") Then
                separator = ","c
                firstline = lines.Current.Split(separator)
            End If
        End If
        lines.Dispose()
        lines = Nothing
        Dim result = New List(Of String)()
        result.Add(separator)
        result.Add(linesCurrent)
        For Each l In firstline

            If l.Trim().StartsWith("""") And l.Trim().EndsWith("""") Then
                result.Add(l.Trim().Substring(1, l.Trim().Length - 2))
            Else
                result.Add(l.Trim())
            End If

        Next

        Return result
    End Function

    'Public Shared Function ReadLineCount(ByVal file As String) As Integer
    '    ' Return IO.File.ReadLines(file).Count()
    'End Function
End Class
