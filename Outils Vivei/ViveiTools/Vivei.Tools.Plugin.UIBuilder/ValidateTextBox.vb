'
' Created by SharpDevelop.
' User: zwickertvi
' Date: 08/09/2014
' Time: 16:30
' 
' To change this template use Tools | Options | Coding | Edit Standard Headers.
'
Imports System
Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.Data
Imports System.Windows
Imports System.Windows.Controls
Imports System.Xml


Public Class ValidateTextBox
	Inherits TextBox 
	
	Protected Overrides Sub OnKeyUp(e As System.Windows.Input.KeyEventArgs)		
		MyBase.OnKeyUp(e)
		
		If e.Key= System.Windows.Input.Key.Enter Then
			Try
				System.Windows.Data.BindingOperations.GetBindingExpression(Me, TextBox.TextProperty).UpdateSource()
				e.Handled=True 
			Catch 
				
			End Try
			
		End If
	End Sub 
End Class
