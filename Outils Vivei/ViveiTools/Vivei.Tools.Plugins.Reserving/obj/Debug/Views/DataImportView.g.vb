﻿#ExternalChecksum("..\..\..\Views\DataImportView.xaml","{406ea660-64cf-4c82-b6f0-42d48172a799}","02FD443916A038E16143186511973705")
'------------------------------------------------------------------------------
' <auto-generated>
'     Ce code a été généré par un outil.
'     Version du runtime :4.0.30319.34209
'
'     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
'     le code est régénéré.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Automation
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Ink
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Media.Effects
Imports System.Windows.Media.Imaging
Imports System.Windows.Media.Media3D
Imports System.Windows.Media.TextFormatting
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Shell
Imports Vivei.Tools.Plugins.Reserving
Imports Vivei.Tools.Plugins.Reserving.Model


'''<summary>
'''DataImportView
'''</summary>
<Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>  _
Partial Public Class DataImportView
    Inherits System.Windows.Controls.UserControl
    Implements System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",58)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents CSVRadioButton As System.Windows.Controls.RadioButton
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",59)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents EXCELRadioButton As System.Windows.Controls.RadioButton
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",60)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents SASRadioButton As System.Windows.Controls.RadioButton
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",61)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents SQLRadioButton As System.Windows.Controls.RadioButton
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",69)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents FileTextBlock As System.Windows.Controls.TextBlock
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",71)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ImporterButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",78)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents DataPreviewRadioButton As System.Windows.Controls.RadioButton
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",79)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents DataMappingRadioButton As System.Windows.Controls.RadioButton
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",92)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents PreviewListView As System.Windows.Controls.ListView
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",105)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents BeginButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",106)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents PreviousButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",107)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents PageComboBox As System.Windows.Controls.ComboBox
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",108)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents NextButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",109)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents EndButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",122)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents SaveMappingModelButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",123)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents LoadMappingModelButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",124)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ValidateChangesMappingModelButton As System.Windows.Controls.Button
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",127)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents DataModelEditingDataGrid As System.Windows.Controls.DataGrid
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",140)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents UsageDataGridComboBoxColumn As System.Windows.Controls.DataGridComboBoxColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",141)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ColonneSourceDataGridComboBoxColumn As System.Windows.Controls.DataGridComboBoxColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",143)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents TypeDataGridComboBoxColumn As System.Windows.Controls.DataGridComboBoxColumn
    
    #End ExternalSource
    
    
    #ExternalSource("..\..\..\Views\DataImportView.xaml",144)
    <System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")>  _
    Friend WithEvents ConvertisseurDataGridComboBoxColumn As System.Windows.Controls.DataGridComboBoxColumn
    
    #End ExternalSource
    
    Private _contentLoaded As Boolean
    
    '''<summary>
    '''InitializeComponent
    '''</summary>
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")>  _
    Public Sub InitializeComponent() Implements System.Windows.Markup.IComponentConnector.InitializeComponent
        If _contentLoaded Then
            Return
        End If
        _contentLoaded = true
        Dim resourceLocater As System.Uri = New System.Uri("/Vivei.Tools.Plugins.Reserving;component/views/dataimportview.xaml", System.UriKind.Relative)
        
        #ExternalSource("..\..\..\Views\DataImportView.xaml",1)
        System.Windows.Application.LoadComponent(Me, resourceLocater)
        
        #End ExternalSource
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")>  _
    Sub System_Windows_Markup_IComponentConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IComponentConnector.Connect
        If (connectionId = 1) Then
            Me.CSVRadioButton = CType(target,System.Windows.Controls.RadioButton)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",58)
            AddHandler Me.CSVRadioButton.Unchecked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Unchecked)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",58)
            AddHandler Me.CSVRadioButton.Checked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Checked)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 2) Then
            Me.EXCELRadioButton = CType(target,System.Windows.Controls.RadioButton)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",59)
            AddHandler Me.EXCELRadioButton.Unchecked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Unchecked)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",59)
            AddHandler Me.EXCELRadioButton.Checked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Checked)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 3) Then
            Me.SASRadioButton = CType(target,System.Windows.Controls.RadioButton)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",60)
            AddHandler Me.SASRadioButton.Unchecked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Unchecked)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",60)
            AddHandler Me.SASRadioButton.Checked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Checked)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 4) Then
            Me.SQLRadioButton = CType(target,System.Windows.Controls.RadioButton)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",61)
            AddHandler Me.SQLRadioButton.Unchecked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Unchecked)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",61)
            AddHandler Me.SQLRadioButton.Checked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Checked)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 5) Then
            Me.FileTextBlock = CType(target,System.Windows.Controls.TextBlock)
            Return
        End If
        If (connectionId = 6) Then
            Me.ImporterButton = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 7) Then
            Me.DataPreviewRadioButton = CType(target,System.Windows.Controls.RadioButton)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",78)
            AddHandler Me.DataPreviewRadioButton.Unchecked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Unchecked)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",78)
            AddHandler Me.DataPreviewRadioButton.Checked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Checked)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 8) Then
            Me.DataMappingRadioButton = CType(target,System.Windows.Controls.RadioButton)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",79)
            AddHandler Me.DataMappingRadioButton.Unchecked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Unchecked)
            
            #End ExternalSource
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",79)
            AddHandler Me.DataMappingRadioButton.Checked, New System.Windows.RoutedEventHandler(AddressOf Me.SourceTypeRadioButton_Checked)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 9) Then
            Me.PreviewListView = CType(target,System.Windows.Controls.ListView)
            Return
        End If
        If (connectionId = 11) Then
            Me.BeginButton = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 12) Then
            Me.PreviousButton = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 13) Then
            Me.PageComboBox = CType(target,System.Windows.Controls.ComboBox)
            Return
        End If
        If (connectionId = 14) Then
            Me.NextButton = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 15) Then
            Me.EndButton = CType(target,System.Windows.Controls.Button)
            Return
        End If
        If (connectionId = 16) Then
            Me.SaveMappingModelButton = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",122)
            AddHandler Me.SaveMappingModelButton.Click, New System.Windows.RoutedEventHandler(AddressOf Me.SaveMappingModelButton_Click)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 17) Then
            Me.LoadMappingModelButton = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",123)
            AddHandler Me.LoadMappingModelButton.Click, New System.Windows.RoutedEventHandler(AddressOf Me.LoadMappingModelButton_Click)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 18) Then
            Me.ValidateChangesMappingModelButton = CType(target,System.Windows.Controls.Button)
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",124)
            AddHandler Me.ValidateChangesMappingModelButton.Click, New System.Windows.RoutedEventHandler(AddressOf Me.ValidateChangesMappingModelButton_Click)
            
            #End ExternalSource
            Return
        End If
        If (connectionId = 19) Then
            Me.DataModelEditingDataGrid = CType(target,System.Windows.Controls.DataGrid)
            Return
        End If
        If (connectionId = 20) Then
            Me.UsageDataGridComboBoxColumn = CType(target,System.Windows.Controls.DataGridComboBoxColumn)
            Return
        End If
        If (connectionId = 21) Then
            Me.ColonneSourceDataGridComboBoxColumn = CType(target,System.Windows.Controls.DataGridComboBoxColumn)
            Return
        End If
        If (connectionId = 22) Then
            Me.TypeDataGridComboBoxColumn = CType(target,System.Windows.Controls.DataGridComboBoxColumn)
            Return
        End If
        If (connectionId = 23) Then
            Me.ConvertisseurDataGridComboBoxColumn = CType(target,System.Windows.Controls.DataGridComboBoxColumn)
            Return
        End If
        Me._contentLoaded = true
    End Sub
    
    <System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily"),  _
     System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")>  _
    Sub System_Windows_Markup_IStyleConnector_Connect(ByVal connectionId As Integer, ByVal target As Object) Implements System.Windows.Markup.IStyleConnector.Connect
        Dim eventSetter As System.Windows.EventSetter
        If (connectionId = 10) Then
            eventSetter = New System.Windows.EventSetter()
            eventSetter.Event = System.Windows.Controls.Primitives.ButtonBase.ClickEvent
            
            #ExternalSource("..\..\..\Views\DataImportView.xaml",97)
            eventSetter.Handler = New System.Windows.RoutedEventHandler(AddressOf Me.PreviewListViewColumnHeaderClick)
            
            #End ExternalSource
            CType(target,System.Windows.Style).Setters.Add(eventSetter)
        End If
    End Sub
End Class

