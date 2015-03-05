Imports Vivei.Tools.Core.UI

Public Class DataImportView

    Sub New()

        ' Cet appel est requis par le concepteur.
        InitializeComponent()

        ' Ajoutez une initialisation quelconque après l'appel InitializeComponent().

        Me.UsageDataGridComboBoxColumn.ItemsSource = DataModel.KnownUsages
        Me.TypeDataGridComboBoxColumn.ItemsSource = DataModel.KnownTypes
        Me.ConvertisseurDataGridComboBoxColumn.ItemsSource = DataModel.KnownConverters


    End Sub

    Property DataSource As Model.DataSource

    Private Sub ImporterButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles ImporterButton.Click
        If SASRadioButton.IsChecked Then
            LoadSAS()
        End If

        If CSVRadioButton.IsChecked Then
            LoadCSV()
        End If
    End Sub

    Private Sub LoadSAS()
        'ImporterButton.Visibility = Windows.Visibility.Collapsed
        Dim opd = New Microsoft.Win32.OpenFileDialog()
        opd.Filter = "Fichiers SAS|*.sas7bdat"
        If opd.ShowDialog() Then
            Dim conbuilder As New System.Data.OleDb.OleDbConnectionStringBuilder()
            conbuilder.Provider = "sas.LocalProvider"
            conbuilder.DataSource = IO.Path.GetDirectoryName(opd.FileName)

            Dim cmd As New System.Data.OleDb.OleDbCommand( _
             IO.Path.GetFileNameWithoutExtension(opd.FileName), _
             New System.Data.OleDb.OleDbConnection(conbuilder.ConnectionString))

            cmd.CommandType = System.Data.CommandType.TableDirect
            Dim dataTable As New System.Data.DataTable
            Dim adp As New System.Data.OleDb.OleDbDataAdapter(cmd)
            adp.Fill(dataTable)
           

            EXCELRadioButton.IsEnabled = False
            SQLRadioButton.IsEnabled = False
            CSVRadioButton.IsEnabled = False

            _PageCount = CInt(dataTable.Rows.Count / _RowPerPage) + 1
            _CurrentPage = 0
            _CurrentTable = dataTable
            _CurrentTableView = New System.Data.DataView(dataTable)
            _CurrentModel = New DataModel(dataTable)

            For Each c As System.Data.DataColumn In dataTable.Columns
                Dim dmp = New DataModelProperty()
                dmp.Name = c.ColumnName
                dmp.SourceColumn = c
                If c.DataType Is GetType(String) Then
                    dmp.Type = "Texte"
                ElseIf c.DataType Is GetType(Double) Then
                    dmp.Type = "Nombre"
                End If
                _CurrentModel.Add(dmp)
            Next
            DataModelEditingDataGrid.ItemsSource = _CurrentModel

            ColonneSourceDataGridComboBoxColumn.ItemsSource = _CurrentModel.SourceColumns
            PageComboBox.ItemsSource = Enumerable.Range(0, _PageCount + 1).ToArray()

            FileTextBlock.Text = opd.FileName

            'PreviewDataGrid.ItemsSource = Nothing
            'PreviewDataGrid.Columns.Clear()
            'PreviewDataGrid.AutoGenerateColumns = False

            PreviewListView.ItemsSource = Nothing
            CType(PreviewListView.View, GridView).Columns.Clear()

            For Each col As System.Data.DataColumn In dataTable.Columns

                Dim dgcol As New DataGridTextColumn
                dgcol.Header = col.ColumnName
                dgcol.Binding = New Binding("[" & col.ColumnName & "]")

                'PreviewDataGrid.Columns.Add(dgcol)

                Dim lstcol As New GridViewColumn()
                lstcol.DisplayMemberBinding = New Binding("[" & col.ColumnName & "]")
                lstcol.Header = col.ColumnName

                CType(PreviewListView.View, GridView).Columns.Add(lstcol)
                lstcol.Width = 150

            Next

            PageComboBox.SelectedIndex = 0

            Me.DataSource.Model = Me._CurrentModel

            Me.DataSource.Table = _CurrentTable

            If Not ReservingPlugin.Instance.CurrentProject.DataSources.Contains(Me.DataSource) Then

                ReservingPlugin.Instance.CurrentProject.DataSources.Add(Me.DataSource)
            End If
        End If
    End Sub

    Private _CurrentPage As Integer
    Private _RowPerPage As Integer = 50
    Private _PageCount As Integer
    Private _CurrentTable As System.Data.DataTable
    Private _CurrentTableView As System.Data.DataView
    Private _CurrentModel As DataModel

    Private Sub LoadCSV()
        'ImporterButton.Visibility = Windows.Visibility.Collapsed
        Dim opd = New Microsoft.Win32.OpenFileDialog()
        opd.Filter = "Fichiers Texte|*.txt;*.csv"
        If opd.ShowDialog() Then
            Dim cow = New CsvOptionsWindow()
            Dim fl = SimpleCsvReader.ReadFirstLine(opd.FileName)
            cow.FirstLine = fl(1)
            cow.CsvSeparateurTextBox.Text = fl(0)
            cow.CsvSeparateurTextBox_TextChanged(Nothing, Nothing)
            'cow.LineCountTextBlock.Text = SimpleCsvReader.ReadLineCount(opd.FileName)
            cow.ShowDialog()
            Dim conf = CType(cow.CsvDatagrid.ItemsSource, IEnumerable(Of CsvOptionsWindow.ColumnOption))
            Dim dataTable = SimpleCsvReader.Read( _
                opd.FileName, _
                cow.CsvSeparateurTextBox.Text, _
                If(cow.DecimalComboBox.SelectedIndex = 0, "."c, ","c), _
                conf.Select(Function(c) c.Name).ToArray(), _
                conf.Select(Function(c) c.Type).ToArray(), _
                conf.Select(Function(c) c.Format).ToArray())

            EXCELRadioButton.IsEnabled = False
            SQLRadioButton.IsEnabled = False
            SASRadioButton.IsEnabled = False

            _PageCount = CInt(dataTable.Rows.Count / _RowPerPage) + 1
            _CurrentPage = 0
            _CurrentTable = dataTable
            _CurrentTableView = New System.Data.DataView(dataTable)
            _CurrentModel = New DataModel(dataTable)

            For Each c As System.Data.DataColumn In dataTable.Columns
                Dim dmp = New DataModelProperty()
                dmp.Name = c.ColumnName
                dmp.SourceColumn = c
                If c.DataType Is GetType(String) Then
                    dmp.Type = "Texte"
                ElseIf c.DataType Is GetType(Double) Then
                    dmp.Type = "Nombre"
                End If
                _CurrentModel.Add(dmp)
            Next
            DataModelEditingDataGrid.ItemsSource = _CurrentModel

            ColonneSourceDataGridComboBoxColumn.ItemsSource = _CurrentModel.SourceColumns
            PageComboBox.ItemsSource = Enumerable.Range(0, _PageCount + 1).ToArray()

            FileTextBlock.Text = opd.FileName

            'PreviewDataGrid.ItemsSource = Nothing
            'PreviewDataGrid.Columns.Clear()
            'PreviewDataGrid.AutoGenerateColumns = False

            PreviewListView.ItemsSource = Nothing
            CType(PreviewListView.View, GridView).Columns.Clear()

            For Each col As System.Data.DataColumn In dataTable.Columns

                Dim dgcol As New DataGridTextColumn
                dgcol.Header = col.ColumnName
                dgcol.Binding = New Binding("[" & col.ColumnName & "]")

                'PreviewDataGrid.Columns.Add(dgcol)

                Dim lstcol As New GridViewColumn()
                lstcol.DisplayMemberBinding = New Binding("[" & col.ColumnName & "]")
                lstcol.Header = col.ColumnName

                CType(PreviewListView.View, GridView).Columns.Add(lstcol)
                lstcol.Width = 150

            Next

            PageComboBox.SelectedIndex = 0

            Me.DataSource.Model = Me._CurrentModel

            Me.DataSource.Table = _CurrentTable

            If Not ReservingPlugin.Instance.CurrentProject.DataSources.Contains(Me.DataSource) Then

                ReservingPlugin.Instance.CurrentProject.DataSources.Add(Me.DataSource)
            End If
        End If

    End Sub

    Private Sub SourceTypeRadioButton_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        'If ImporterButton.Visibility = Windows.Visibility.Collapsed Then
        '    MessageBox.Show("Cett action va reinitialiser la source de données. Voulez vous continuer")
        'End If
    End Sub
    Private Sub SourceTypeRadioButton_Unchecked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub



    Private Sub PageComboBox_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles PageComboBox.SelectionChanged
        Dim rows As New List(Of System.Data.DataRowView)(_RowPerPage)

        _CurrentPage = PageComboBox.SelectedIndex

        For i = _CurrentPage * _RowPerPage To Math.Min(_CurrentTableView.Count - 1, (_CurrentPage + 1) * _RowPerPage - 1)
            rows.Add(_CurrentTableView(i))
        Next

        'If PreviewDataGrid.Columns.Count = 0 Then
        '    PreviewDataGrid.AutoGenerateColumns = True
        '    PreviewDataGrid.ItemsSource = _CurrentTable.DefaultView
        '    PreviewDataGrid.AutoGenerateColumns = False
        'End If

        ' PreviewDataGrid.ItemsSource = rows
        PreviewListView.ItemsSource = rows
        'PreviewDataGrid.AutoGenerateColumns = False
    End Sub

    Private Sub NextButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles NextButton.Click
        Try
            PageComboBox.SelectedIndex += 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PreviousButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles PreviousButton.Click
        Try
            PageComboBox.SelectedIndex -= 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub EndButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles EndButton.Click
        Try
            PageComboBox.SelectedIndex = _PageCount - 1
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BeginButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles BeginButton.Click
        Try
            PageComboBox.SelectedIndex = 0
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PreviewListViewColumnHeaderClick(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub

    Private Sub SaveMappingModelButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim spd = New Microsoft.Win32.SaveFileDialog()
        spd.Filter = "Fichiers de modele de donnes|*.mdl"
        spd.AddExtension = True
        spd.DefaultExt = "mdl"
        spd.InitialDirectory = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules\ReservingPlugin\Data")

        If _CurrentModel Is Nothing Then Return

        If spd.ShowDialog() Then

            Dim fun = Function(p As DataModelProperty)
                          Dim x = <Property
                                      SourceColumn=<%= If(p.SourceColumn Is Nothing, Nothing, p.SourceColumn.ColumnName) %>
                                      Name=<%= p.Name %>
                                      Type=<%= p.Type %>
                                      Formula=<%= p.Formula %>
                                      ConverterType=<%= p.ConverterType %>
                                      Usage=<%= p.Usage %>
                                      Priority=<%= p.Priority %>/>
                          Return x
                      End Function


            Dim xmodel = <Model>
                             <%= From p In Me._CurrentModel Select fun(p) %>
                         </Model>

            xmodel.Save(spd.FileName)
        End If
    End Sub

    Private Sub LoadMappingModelButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim opd = New Microsoft.Win32.OpenFileDialog()
        opd.Filter = "Fichiers de modele de donnes|*.mdl"
        opd.InitialDirectory = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Modules\ReservingPlugin\Data")

        If _CurrentTable Is Nothing Then Return
        If _CurrentModel Is Nothing Then Return

        If opd.ShowDialog() Then
            Dim xmodel = XElement.Load(opd.FileName)

            Dim fun = Function(x As XElement)
                          Dim p = New DataModelProperty()
                          p.Name = x.@Name
                          p.Type = x.@Type
                          p.Formula = x.@Formula
                          p.ConverterType = x.@ConverterType
                          p.Usage = x.@Usage
                          p.Priority = x.@Priority
                          If _CurrentTable IsNot Nothing Then
                              If _CurrentTable.Columns.Contains(x.@SourceColumn) Then
                                  p.SourceColumn = _CurrentTable.Columns(x.@SourceColumn)
                              End If
                          End If
                          Return p
                      End Function


            For Each x In xmodel.<Property>
                _CurrentModel.Add(fun(x))
            Next
        End If
    End Sub

    Private Sub ValidateChangesMappingModelButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

    End Sub
End Class

Public Class DataModel
    Inherits ObjectModel.ObservableCollection(Of DataModelProperty)
    Implements ICloneable

    Private _data As System.Data.DataTable

    Sub New(ByVal data As System.Data.DataTable)
        _data = data
    End Sub

    Public ReadOnly Property SourceColumns As IEnumerable(Of System.Data.DataColumn)
        Get
            'If ProvisionnementModule._ActiveProject.ExternalData Is Nothing Then Return Nothing
            'Dim data = ProvisionnementModule._ActiveProject.ExternalData.Columns.Cast(Of DataColumn).ToList()
            'data.Insert(0, New DataColumn("(Aucun)", GetType(String)))
            Return _data.Columns.Cast(Of System.Data.DataColumn).ToList()
        End Get
    End Property

    Public Shared ReadOnly Property KnownTypes As String()
        Get
            Return New String() {"Nombre", "Texte", "Date"}
        End Get
    End Property

    Public Shared ReadOnly Property KnownConverters As String()
        Get
            Return New String() {"(Aucun)", "TextToNumber", "TexteToDate"}
        End Get
    End Property

    Public Shared ReadOnly Property KnownUsages As String()
        Get
            Return New String() {"(Aucun)", "Segmentation", "Line Of Business", "Categorie Ministerielle", "Garantie", "Survenance", "Declaration", "Deroulement", "Reglement", "Prime", "Sinistre", "Provision"}
        End Get
    End Property

    Friend Sub NotifySourceColumnsChange()
        Me.OnPropertyChanged(New ComponentModel.PropertyChangedEventArgs("SourceColumns"))
    End Sub

    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim result = New DataModel(_data)

        For Each c In Me
            result.Add(c.Clone())
        Next

        Return result
    End Function
End Class

Public Class DataModelProperty
    Inherits UIObject
    Implements ICloneable


    Private Shared inc = 0

    Private _ConverterType As String
    Private _Usage As String
    Private _Priority As Integer
    Private _Formula As String
    Private _Type As String
    Private _Name As String
    Private _SourceColumn As System.Data.DataColumn

    Sub New()
        inc += 1
        _Name = "Colonne " & inc
        _Type = "Texte"
        _ConverterType = "(Aucun)"
        _Usage = "(Aucun)"
    End Sub


    Public Property SourceColumn As System.Data.DataColumn
        Get
            Return _SourceColumn
        End Get
        Set(ByVal value As System.Data.DataColumn)
            _SourceColumn = value
            OnPropertyChanged("SourceColumn")
        End Set
    End Property
  
    Public Property Name As String
        Get
            Return _Name
        End Get
        Set(ByVal value As String)
            _Name = value
            OnPropertyChanged("Name")
        End Set
    End Property
 
    Public Property Type As String
        Get
            Return _Type
        End Get
        Set(ByVal value As String)
            _Type = value
            OnPropertyChanged("Type")
        End Set
    End Property
  
    Public Property Formula As String
        Get
            Return _Formula
        End Get
        Set(ByVal value As String)
            _Formula = value
            OnPropertyChanged("Formula")
        End Set
    End Property

    Public Property ConverterType As String
        Get
            Return _ConverterType
        End Get
        Set(ByVal value As String)
            _ConverterType = value
            OnPropertyChanged("Converter")
        End Set
    End Property


    Public Property Usage As String
        Get
            Return _Usage
        End Get
        Set(ByVal value As String)
            _Usage = value
            OnPropertyChanged("Usage")
        End Set
    End Property

    Public Property Priority As Integer
        Get
            Return _Priority
        End Get
        Set(ByVal value As Integer)
            _Priority = value
            OnPropertyChanged("Priority")
        End Set
    End Property


    Public Function Clone() As Object Implements System.ICloneable.Clone
        Dim result As New DataModelProperty

        result._ConverterType = _ConverterType
        result._Usage = _Usage
        result._Priority = _Priority
        result._Formula = _Formula
        result._Type = _Type
        result._Name = _Name
        result._SourceColumn = _SourceColumn

        Return result
    End Function
End Class

