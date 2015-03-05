

Public Class ScriptView

    'Private _Evaluator As Mono.CSharp.Evaluator
    Private _Evaluator As Object
    Private _Parser As ICSharpCode.NRefactory.CSharp.CSharpParser
    Dim _EvaluatorLogger As IO.StringWriter

    Property ScriptingModule As Core.Scripting.ScriptingModule

    Property ScriptingProject As Core.Scripting.ScriptingProject


    Shared _codeProvider As Microsoft.CSharp.CSharpCodeProvider

    Private Sub ScriptView_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        If _Evaluator Is Nothing And _Parser Is Nothing Then
            Dim completion = New ICSharpCode.CodeCompletion.CSharpCompletion(New ScriptProvider(ScriptingModule))

            Me.AvalonEditCodeTextEditor.FontFamily = New FontFamily("Calibri")
            Me.AvalonEditCodeTextEditor.FontSize = CDbl(14)

            completion.AddAssembly(Me.GetType().Assembly.Location)
            completion.AddAssembly(GetType(System.Data.DataTable).Assembly.Location)


            For Each ass In CType(Me.ScriptingProject, ScriptingProjectImpl).AssemblyReferences
                completion.AddAssembly(ass.Location)
            Next


            Me.AvalonEditCodeTextEditor.Completion = completion

            Me.AvalonEditCodeTextEditor.OpenFile(IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DefaultScript.csx"))

            FormatHeader()

            Me.AvalonEditCodeTextEditor.SyntaxHighlighting = ICSharpCode.AvalonEdit.Highlighting.HighlightingManager.Instance.GetDefinition("C#")

            Me._Parser = New ICSharpCode.NRefactory.CSharp.CSharpParser()

            'Dim cc = New Mono.CSharp.CompilerContext(New Mono.CSharp.CompilerSettings(), New Mono.CSharp.ConsoleReportPrinter())
            '_Evaluator = New Mono.CSharp.Evaluator(cc)
            Dim evaldata = Core.MonoCsharpEvaluator.Create()
            Me._Evaluator = evaldata.Item1
            Me._EvaluatorLogger = evaldata.Item2

            ''_Evaluator.ReferenceAssembly(GetType(Int32).Assembly)
            _Evaluator.ReferenceAssembly(Me.GetType().Assembly)
            _Evaluator.ReferenceAssembly(GetType(System.Data.DataColumn).Assembly)
            _Evaluator.ReferenceAssembly(GetType(NameScope).Assembly)
            _Evaluator.ReferenceAssembly(GetType(Xaml.XamlServices).Assembly)
            _Evaluator.ReferenceAssembly(GetType(UIElement).Assembly)
            _Evaluator.ReferenceAssembly(GetType(Control).Assembly)

            For Each ass In CType(Me.ScriptingProject, ScriptingProjectImpl).AssemblyReferences
                Me._Evaluator.ReferenceAssembly(ass)
            Next

            _Evaluator.Run("using System;")
            _Evaluator.Run("using System.Collections.Generic;")
            _Evaluator.Run("using System.Linq;")
            _Evaluator.Run("using System.Text;")
            _Evaluator.Run("using Vivei.Tools.Application.Scripting;")
            _Evaluator.Run("using System.Data;")


            For Each ns In Me.ScriptingModule.ImportedNamespaces
                Me._Evaluator.Run("using " & ns & " ;")
            Next

            CSScriptLibrary.CSScript.Evaluator.Reset(True)

            CSScriptLibrary.CSScript.Evaluator.ReferenceAssembly(GetType(System.Data.DataColumn).Assembly)

            CSScriptLibrary.CSScript.Evaluator.Run("using System;")
            CSScriptLibrary.CSScript.Evaluator.Run("using System.Collections.Generic;")
            CSScriptLibrary.CSScript.Evaluator.Run("using System.Linq;")
            CSScriptLibrary.CSScript.Evaluator.Run("using System.Text;")
            CSScriptLibrary.CSScript.Evaluator.Run("using Vivei.Tools.Application.Scripting;")
            CSScriptLibrary.CSScript.Evaluator.Run("using System.Data;")

            _codeProvider = New Microsoft.CSharp.CSharpCodeProvider()
            '_codeCompiler = _codeProvider.CreateCompiler()
        End If


        ' Dim eval As Mono.CSharp.Ev
    End Sub

    Private Sub FormatHeader()


        Me.AvalonEditCodeTextEditor.Text = Me.AvalonEditCodeTextEditor.Text.Replace("${PLUGIN}", System.Reflection.Assembly.GetCallingAssembly().GetName().Name)
        Me.AvalonEditCodeTextEditor.Text = Me.AvalonEditCodeTextEditor.Text.Replace("${USER}", " " & Environment.UserDomainName & "\" & Environment.UserName & " ")
        Me.AvalonEditCodeTextEditor.Text = Me.AvalonEditCodeTextEditor.Text.Replace("${DATE}", Now.ToShortDateString())
        Me.AvalonEditCodeTextEditor.Text = Me.AvalonEditCodeTextEditor.Text.Replace("${TIME}", Now.ToShortTimeString())
        Me.AvalonEditCodeTextEditor.Text = Me.AvalonEditCodeTextEditor.Text.Replace("${PROJECT}", "DefaultProject")
    End Sub

    Private Sub ExecuteButton_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim stmts = Me._Parser.ParseStatements(Me.AvalonEditCodeTextEditor.Text)

        If Me._Parser.HasErrors Then
            Dim q = From err In Me._Parser.ErrorsAndWarnings
                    Select "(" & err.Region.BeginLine & "," & err.Region.BeginColumn & "," & err.ErrorType.ToString() & ") : " & err.Message
            MessageBox.Show(String.Join(Environment.NewLine, q.ToArray()))

        Else
            Try
                'For Each ass In CType(Me.ScriptingProject, ScriptingProjectImpl).AssemblyReferences
                '    Me._Evaluator.ReferenceAssembly(ass)
                'Next
                'For Each ns In Me.ScriptingModule.ImportedNamespaces
                '    Me._Evaluator.Run("using " & ns & " ;")
                'Next

                'Dim result = Nothing
                'Me._Evaluator.Compile(Me.AvalonEditCodeTextEditor.Text).Invoke(result)
                'Return
                'Dim scriptResult = CSScriptLibrary.CSScript.Evaluator.Evaluate(Me.AvalonEditCodeTextEditor.Text)
                'Dim scriptDelegate = CSScriptLibrary.CSScript.LoadDelegate(Of Func(Of Object))(Me.AvalonEditCodeTextEditor.Text)
                'Dim scriptResult = scriptDelegate()
                'MessageBox.Show(scriptResult.ToString())
                'MessageBox.Show(Me._Evaluator.Evaluate(Me.AvalonEditCodeTextEditor.Text).ToString())
                Dim cpm As New CodeDom.Compiler.CompilerParameters()
                cpm.GenerateExecutable = False
                cpm.GenerateInMemory = True
                For Each ass In AppDomain.CurrentDomain.GetAssemblies
                    Try
                        cpm.ReferencedAssemblies.Add(ass.Location)
                    Catch ex As Exception

                    End Try

                Next

                Dim cpmResult = _codeProvider.CompileAssemblyFromSource(cpm, GetCode(Me.AvalonEditCodeTextEditor.Text, "void"))

                If Not cpmResult.Errors.HasErrors Then
                    '    Dim scriptResult = cpmResult.CompiledAssembly.GetType("Script").GetMethod("Execute").Invoke(Nothing, Nothing)
                    'MessageBox.Show(scriptResult.ToString())
                    cpmResult.CompiledAssembly.GetType("Script").GetMethod("Execute").Invoke(Nothing, Nothing)

                Else

                    MessageBox.Show(String.Join(vbCrLf, cpmResult.Errors.Cast(Of CodeDom.Compiler.CompilerError).Select(Function(err) err.ToString()).ToArray()))
                End If

                Dim o = 1
            Catch ex As Exception
                'MessageBox.Show("Une erreur s'est produite:" & vbCrLf & Me._EvaluatorLogger.ToString())
                'Me._EvaluatorLogger.Flush()
                MessageBox.Show(ex.ToString())
                Dim o = 1
            End Try
        End If
    End Sub

    Public Function GetCode(ByVal methodbody As String, ByVal returnType As String) As String
        Dim q = From ns In CType(Me._ScriptingModule, ScriptingModuleImpl).ImportedNamespaces Select "using " & ns & " ;"


        Dim usings = "" & "using System; " & "using System.Data; " & "using System.Collections.Generic; " & "using System.Linq; " _
            & "using System.Text; " & "using Vivei.Tools.Application.Scripting;" & String.Join(" ", q.ToArray()) & Environment.NewLine

        Return usings & vbCrLf & _
            "public static class Script {" & vbCrLf & _
            "public static " & returnType & " Execute() {" & vbCrLf & _
             methodbody & vbCrLf & "}" & vbCrLf & "}"
    End Function
End Class

Public Class ScriptProvider
    Implements ICSharpCode.CodeCompletion.ICSharpScriptProvider


    'Public Function GetUsing(ByVal fileExtension As String) As String Implements ICSharpCode.CodeCompletion.ICSharpScriptProvider.GetUsing
    '    'If Not fileExtension.StartsWith(".cs") Then
    '    '    Return "" & "using System; " & "using System.Collections.Generic; " & "using System.Linq; " & "using System.Text; "
    '    'End If

    '    'If Not fileExtension.StartsWith(".vb") Then
    '    Return "" & _
    '        "Imports System " & Environment.NewLine & _
    '        "Imports System.Collections.Generic " & Environment.NewLine & _
    '        "using System.Linq " & Environment.NewLine & _
    '        "using System.Text "
    '    'End If


    '    Return Nothing
    'End Function

    Private _scriptingModule As Core.Scripting.ScriptingModule

    Sub New(ByVal scriptingModule As Core.Scripting.ScriptingModule)
        ' TODO: Complete member initialization 
        _scriptingModule = scriptingModule
    End Sub


    Public Function GetVars() As String Implements ICSharpCode.CodeCompletion.ICSharpScriptProvider.GetVars
        Return Nothing
    End Function


    Public Function GetUsing() As String Implements ICSharpCode.CodeCompletion.ICSharpScriptProvider.GetUsing
        Dim q = From ns In CType(Me._scriptingModule, ScriptingModuleImpl).ImportedNamespaces Select "using " & ns & " ;"


        Return "" & "using System; " & "using System.Data; " & "using System.Collections.Generic; " & "using System.Linq; " _
            & "using System.Text; " & "using Vivei.Tools.Application.Scripting;" & String.Join(" ", q.ToArray()) & Environment.NewLine
    End Function


End Class