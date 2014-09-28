Imports System.Windows.Controls.Primitives


Public Class NumberEditor
    Inherits System.Windows.Controls.Control

    Shared Sub New()
        DefaultStyleKeyProperty.OverrideMetadata(GetType(NumberEditor), New FrameworkPropertyMetadata(GetType(NumberEditor)))
    End Sub

    Public Property Increment As Double
        Get
            Return GetValue(IncrementProperty)
        End Get

        Set(ByVal value As Double)
            SetValue(IncrementProperty, value)
        End Set
    End Property

    Public Shared ReadOnly IncrementProperty As DependencyProperty = _
                           DependencyProperty.Register("Increment", _
                           GetType(Double), GetType(NumberEditor), _
                           New FrameworkPropertyMetadata(1.0))

    Public Property Value As Double
        Get
            Return GetValue(ValueProperty)
        End Get

        Set(ByVal value As Double)
            SetValue(ValueProperty, value)
        End Set
    End Property

    Public Shared ReadOnly ValueProperty As DependencyProperty = _
                           DependencyProperty.Register("Value", _
                           GetType(Double), GetType(NumberEditor), _
                           New FrameworkPropertyMetadata(0.0))

    Public Property Format As String
        Get
            Return GetValue(FormatProperty)
        End Get

        Set(ByVal value As String)
            SetValue(FormatProperty, value)
        End Set
    End Property

    Public Shared ReadOnly FormatProperty As DependencyProperty = _
                           DependencyProperty.Register("Format", _
                           GetType(String), GetType(NumberEditor), _
                           New FrameworkPropertyMetadata("N0", AddressOf FormatChanged))


    Public Overrides Sub OnApplyTemplate()
        ValueTextBox = Me.Template.FindName("PART_ValueTextBox", Me)
        AddRepeatButton = Me.Template.FindName("PART_AddRepeatButton", Me)
        SubtractRepeatButton = Me.Template.FindName("PART_SubtractRepeatButton", Me)

        BindingOperations.SetBinding( _
            ValueTextBox, _
            TextBox.TextProperty, _
            New Binding("Value") With {.Source = Me, .StringFormat = Format, .UpdateSourceTrigger = UpdateSourceTrigger.Default})
    End Sub

    Private WithEvents ValueTextBox As TextBox
    Private WithEvents AddRepeatButton As RepeatButton
    Private WithEvents SubtractRepeatButton As RepeatButton

    Private Sub AddRepeatButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles AddRepeatButton.Click
        Try
            '     ValueTextBox.Text = CDbl(ValueTextBox.Text) + Increment
            Value += Increment
        Catch ex As Exception

        End Try

    End Sub

    Private Sub SubtractRepeatButton_Click(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles SubtractRepeatButton.Click
        Try
            'ValueTextBox.Text = CDbl(ValueTextBox.Text) - Increment
            Value -= Increment

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ValueTextBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ValueTextBox.KeyUp
        If e.Key = Key.Enter Then

        End If
    End Sub

    Private Sub ValueTextBox_TextChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles ValueTextBox.TextChanged
    End Sub


    Private Shared Sub FormatChanged(ByVal d As System.Windows.DependencyObject, ByVal e As System.Windows.DependencyPropertyChangedEventArgs)
        Dim f As String = e.NewValue
        Dim editor As NumberEditor = d

        If editor.ValueTextBox Is Nothing Then Return

        Dim b = BindingOperations.GetBinding(editor.ValueTextBox, TextBox.TextProperty)

        If b IsNot Nothing Then
            '    b.StringFormat = f


            BindingOperations.SetBinding( _
            editor.ValueTextBox, _
                TextBox.TextProperty, _
                New Binding("Value") With {.Source = editor, .StringFormat = f, .UpdateSourceTrigger = UpdateSourceTrigger.Default})

        End If
    End Sub

End Class
