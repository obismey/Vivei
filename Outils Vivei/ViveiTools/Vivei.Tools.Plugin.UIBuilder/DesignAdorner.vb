Public Class DesignAdorner
    Inherits Adorner

    Dim rulers(9) As Controls.Primitives.Thumb
    Dim txts(6) As TextBlock
    Dim txtpaths() As String = New String() {"Width", "Height", "Margin.Left", "Margin.Top", "Margin.Right", "Margin.Bottom"}

    Dim aligncbx As ComboBox
    Dim alignhvalues(16) As HorizontalAlignment
    Dim alignvvalues(16) As VerticalAlignment

    Dim children As VisualCollection

    Private Shared rulercursors() As Cursor = New Cursor() {
        Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE, _
        Cursors.SizeNWSE, Cursors.SizeNS, Cursors.SizeNESW, Cursors.SizeWE, _
        Cursors.ScrollAll}

    Private Shared rulerhalign() As Windows.HorizontalAlignment = _
        New Windows.HorizontalAlignment() {
        Windows.HorizontalAlignment.Left,
        Windows.HorizontalAlignment.Center,
        Windows.HorizontalAlignment.Right,
        Windows.HorizontalAlignment.Right,
        Windows.HorizontalAlignment.Right,
        Windows.HorizontalAlignment.Center,
        Windows.HorizontalAlignment.Left,
        Windows.HorizontalAlignment.Left,
        Windows.HorizontalAlignment.Center}


    Private Shared rulervalign() As Windows.VerticalAlignment = _
        New Windows.VerticalAlignment() {
        Windows.VerticalAlignment.Top,
        Windows.VerticalAlignment.Top,
        Windows.VerticalAlignment.Top,
        Windows.VerticalAlignment.Center,
        Windows.VerticalAlignment.Bottom,
        Windows.VerticalAlignment.Bottom,
        Windows.VerticalAlignment.Bottom,
        Windows.VerticalAlignment.Center,
        Windows.VerticalAlignment.Center}

    Sub New(ByVal adornedElement As UIElement)
        MyBase.New(adornedElement)

        children = New VisualCollection(Me)

        For i = 0 To 8

            Dim th = New Controls.Primitives.Thumb()
            th.Style = UIBuilderPlugin._MainResourceDictionary("RulerThumbStyle")
            th.Background = Brushes.Green
            th.Width = 10
            th.Height = 10
            th.Cursor = rulercursors(i)
            th.BorderBrush = Nothing
            th.Margin = New Thickness( _
                5 * (rulerhalign(i) = Windows.HorizontalAlignment.Left), _
                5 * (rulervalign(i) = Windows.VerticalAlignment.Top), _
                5 * (rulerhalign(i) = Windows.HorizontalAlignment.Right), _
                5 * (rulervalign(i) = Windows.VerticalAlignment.Bottom))
            th.HorizontalAlignment = rulerhalign(i)
            th.VerticalAlignment = rulervalign(i)

            AddHandler th.DragDelta, AddressOf RulerDragDelta
            AddHandler th.DragStarted, AddressOf RulerDragStarted
            AddHandler th.DragCompleted, AddressOf RulerDragCompleted

            rulers(i) = th
            children.Add(th)
        Next
        For i = 0 To 8

            '            Dim th = New TextBlock ()
            '           ' th.Style = ModuleDashboarding._resdic("RulerThumbStyle")
            '           th.Background = Brushes.Green
            '           th.Foreground=Brushes.White
            '           th.IsHitTestVisible=False 
            ' th.Width = 10
            '  th.Height = 10
            ' th.Cursor = rulercursors(i)
            ' th.BorderBrush = Nothing
            '            th.Margin = New Thickness( _
            '                5 * (rulerhalign(i) = Windows.HorizontalAlignment.Left), _
            '                5 * (rulervalign(i) = Windows.VerticalAlignment.Top), _
            '                5 * (rulerhalign(i) = Windows.HorizontalAlignment.Right), _
            '                5 * (rulervalign(i) = Windows.VerticalAlignment.Bottom))
            '            th.HorizontalAlignment = rulerhalign(i)
            '            th.VerticalAlignment = rulervalign(i)

            '    AddHandler th.DragDelta, AddressOf RulerDragDelta

            '            txts(i) = th
            '            children.Add(th)
        Next

        aligncbx = New ComboBox()
        aligncbx.Background = Brushes.White
        aligncbx.Focusable = False
        Dim cc = -1
        Dim cbxitems = New List(Of String)
        For Each elth In [Enum].GetValues(GetType(HorizontalAlignment))
            For Each eltv In [Enum].GetValues(GetType(VerticalAlignment))
                cbxitems.Add("H=" & elth.ToString() & ";V=" & eltv.ToString())
                cc += 1
                alignhvalues(cc) = elth
                alignvvalues(cc) = eltv
            Next
        Next
        aligncbx.Visibility = Windows.Visibility.Collapsed
        aligncbx.HorizontalAlignment = Windows.HorizontalAlignment.Center
        aligncbx.VerticalAlignment = Windows.VerticalAlignment.Center
        aligncbx.ItemsSource = cbxitems
        children.Add(aligncbx)

        AddHandler aligncbx.SelectionChanged, AddressOf aligncbxSelectionChanged

        Me.Visibility = Visibility.Collapsed

    End Sub

    Private Sub RulerDragDelta(ByVal sender As Object, ByVal e As Controls.Primitives.DragDeltaEventArgs)
        Dim cas = Array.IndexOf(rulers, sender)

        Dim ctrl As Control = AdornedElement

        If cas = 0 Then
            ctthumbdrag(e.HorizontalChange, e.VerticalChange)
            lcthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 1 Then
            ctthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 2 Then
            ctthumbdrag(e.HorizontalChange, e.VerticalChange)
            rcthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 3 Then
            rcthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 4 Then
            cbthumbdrag(e.HorizontalChange, e.VerticalChange)
            rcthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 5 Then
            cbthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 6 Then
            cbthumbdrag(e.HorizontalChange, e.VerticalChange)
            lcthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 7 Then
            lcthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If

        If cas = 8 Then
            ccthumbdrag(e.HorizontalChange, e.VerticalChange)
        End If
    End Sub

    Protected Overrides ReadOnly Property VisualChildrenCount As Integer
        Get
            Return children.Count
        End Get
    End Property

    Protected Overrides Function GetVisualChild(ByVal index As Integer) As System.Windows.Media.Visual
        Return children(index)
    End Function

    Protected Overrides Function ArrangeOverride(ByVal finalSize As System.Windows.Size) As System.Windows.Size

        For i = 0 To 8
            rulers(i).Arrange(New Rect(finalSize))
        Next
        aligncbx.Arrange(New Rect(finalSize))

        Return finalSize
    End Function

    Protected Overrides Sub OnRender(ByVal drawingContext As System.Windows.Media.DrawingContext)
        MyBase.OnRender(drawingContext)

        Try

            Dim Ctrl As FrameworkElement = AdornedElement
            Dim parentCtrl As FrameworkElement = Ctrl.Parent
            Dim renderPen As New Pen(New SolidColorBrush(Colors.Green), 2)

            If Ctrl.HorizontalAlignment = Windows.HorizontalAlignment.Stretch Or _
               Ctrl.HorizontalAlignment = Windows.HorizontalAlignment.Left Then

                drawingContext.DrawLine( _
                  renderPen, _
                  New Point(0, Ctrl.RenderSize.Height / 2.0), _
                  New Point(parentCtrl.TranslatePoint(New Point(0, 0), Ctrl).X, Ctrl.RenderSize.Height / 2.0))

            End If

            If Ctrl.HorizontalAlignment = Windows.HorizontalAlignment.Stretch Or _
               Ctrl.HorizontalAlignment = Windows.HorizontalAlignment.Right Then

                drawingContext.DrawLine( _
                          renderPen, _
                          New Point(Ctrl.RenderSize.Width, Ctrl.RenderSize.Height / 2.0), _
                          New Point(parentCtrl.TranslatePoint(New Point(parentCtrl.RenderSize.Width, 0), Ctrl).X, Ctrl.RenderSize.Height / 2.0))

            End If

            If Ctrl.VerticalAlignment = Windows.VerticalAlignment.Stretch Or _
               Ctrl.VerticalAlignment = Windows.VerticalAlignment.Top Then

                drawingContext.DrawLine( _
                    renderPen, _
                    New Point(Ctrl.RenderSize.Width / 2.0, 0), _
                    New Point(Ctrl.RenderSize.Width / 2.0, parentCtrl.TranslatePoint(New Point(0, 0), Ctrl).Y))

            End If

            If Ctrl.VerticalAlignment = Windows.VerticalAlignment.Stretch Or _
              Ctrl.VerticalAlignment = Windows.VerticalAlignment.Bottom Then

                drawingContext.DrawLine( _
                  renderPen, _
                  New Point(Ctrl.RenderSize.Width / 2.0, Ctrl.RenderSize.Height), _
                  New Point(Ctrl.RenderSize.Width / 2.0, parentCtrl.TranslatePoint(New Point(0, parentCtrl.RenderSize.Height), Ctrl).Y))


            End If
            drawingContext.DrawRectangle(Nothing, renderPen, New Rect(AdornedElement.RenderSize))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cbthumbdrag(ByVal HorizontalChange As Double, ByVal VerticalChange As Double)

        Dim ctrl As Control = AdornedElement
        Select Case ctrl.VerticalAlignment
            Case Windows.VerticalAlignment.Center
                If Double.IsNaN(ctrl.Height) Then
                    ctrl.Height = ctrl.ActualHeight
                End If
                ctrl.Height += VerticalChange

            Case Windows.VerticalAlignment.Top
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right, 0.0)
                If Double.IsNaN(ctrl.Height) Then
                    ctrl.Height = ctrl.ActualHeight
                End If
                ctrl.Height += VerticalChange

            Case Windows.VerticalAlignment.Bottom
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom - VerticalChange)
                If Double.IsNaN(ctrl.Height) Then
                    ctrl.Height = ctrl.ActualHeight
                End If
                ctrl.Height += VerticalChange

            Case Windows.VerticalAlignment.Stretch
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom - VerticalChange)

        End Select
    End Sub

    Private Sub ctthumbdrag(ByVal HorizontalChange As Double, ByVal VerticalChange As Double)

        Dim ctrl As Control = AdornedElement
        Select Case ctrl.VerticalAlignment
            Case Windows.VerticalAlignment.Center
                If Double.IsNaN(ctrl.Height) Then
                    ctrl.Height = ctrl.ActualHeight
                End If
                ctrl.Height -= VerticalChange

            Case Windows.VerticalAlignment.Top
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top + VerticalChange, ctrl.Margin.Right, ctrl.Margin.Bottom)
                If Double.IsNaN(ctrl.Height) Then
                    ctrl.Height = ctrl.ActualHeight
                End If
                ctrl.Height -= VerticalChange

            Case Windows.VerticalAlignment.Bottom
                ctrl.Margin = New Thickness(ctrl.Margin.Left, 0.0, ctrl.Margin.Right, ctrl.Margin.Bottom)
                If Double.IsNaN(ctrl.Height) Then
                    ctrl.Height = ctrl.ActualHeight
                End If
                ctrl.Height -= VerticalChange

            Case Windows.VerticalAlignment.Stretch
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top + VerticalChange, ctrl.Margin.Right, ctrl.Margin.Bottom)

        End Select
    End Sub

    Private Sub lcthumbdrag(ByVal HorizontalChange As Double, ByVal VerticalChange As Double)

        Dim ctrl As Control = AdornedElement
        Select Case ctrl.HorizontalAlignment
            Case Windows.HorizontalAlignment.Center
                If Double.IsNaN(ctrl.Width) Then
                    ctrl.Width = ctrl.ActualWidth
                End If
                ctrl.Width -= HorizontalChange

            Case Windows.HorizontalAlignment.Left
                ctrl.Margin = New Thickness(ctrl.Margin.Left + HorizontalChange, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom)
                If Double.IsNaN(ctrl.Width) Then
                    ctrl.Width = ctrl.ActualWidth
                End If
                ctrl.Width -= HorizontalChange

            Case Windows.HorizontalAlignment.Right
                ctrl.Margin = New Thickness(0.0, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom)
                If Double.IsNaN(ctrl.Width) Then
                    ctrl.Width = ctrl.ActualWidth
                End If
                ctrl.Width -= HorizontalChange

            Case Windows.HorizontalAlignment.Stretch
                ctrl.Margin = New Thickness(ctrl.Margin.Left + HorizontalChange, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom)

        End Select
    End Sub

    Private Sub rcthumbdrag(ByVal HorizontalChange As Double, ByVal VerticalChange As Double)

        Dim ctrl As Control = AdornedElement
        Select Case ctrl.HorizontalAlignment
            Case Windows.HorizontalAlignment.Center
                If Double.IsNaN(ctrl.Width) Then
                    ctrl.Width = ctrl.ActualWidth
                End If
                ctrl.Width += HorizontalChange

            Case Windows.HorizontalAlignment.Left
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, 0.0, ctrl.Margin.Bottom)
                If Double.IsNaN(ctrl.Width) Then
                    ctrl.Width = ctrl.ActualWidth
                End If
                ctrl.Width += HorizontalChange

            Case Windows.HorizontalAlignment.Right
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right - HorizontalChange, ctrl.Margin.Bottom)
                If Double.IsNaN(ctrl.Width) Then
                    ctrl.Width = ctrl.ActualWidth
                End If
                ctrl.Width += HorizontalChange

            Case Windows.HorizontalAlignment.Stretch
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right - HorizontalChange, ctrl.Margin.Bottom)

        End Select
    End Sub

    Private Sub ccthumbdrag(ByVal HorizontalChange As Double, ByVal VerticalChange As Double)
        Dim ctrl As Control = AdornedElement
        Select Case ctrl.HorizontalAlignment
            Case Windows.HorizontalAlignment.Center
                ctrl.Margin = New Thickness(ctrl.Margin.Left + HorizontalChange / 2.0, ctrl.Margin.Top, ctrl.Margin.Right - HorizontalChange / 2.0, ctrl.Margin.Bottom)

            Case Windows.HorizontalAlignment.Left
                ctrl.Margin = New Thickness(ctrl.Margin.Left + HorizontalChange, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom)

            Case Windows.HorizontalAlignment.Right
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right - HorizontalChange, ctrl.Margin.Bottom)

            Case Windows.HorizontalAlignment.Stretch
                ctrl.Margin = New Thickness(ctrl.Margin.Left + HorizontalChange, ctrl.Margin.Top, ctrl.Margin.Right - HorizontalChange, ctrl.Margin.Bottom)

        End Select


        Select Case ctrl.VerticalAlignment
            Case Windows.VerticalAlignment.Center
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top + VerticalChange / 2.0, ctrl.Margin.Right, ctrl.Margin.Bottom - VerticalChange / 2.0)

            Case Windows.VerticalAlignment.Top
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top + VerticalChange, ctrl.Margin.Right, ctrl.Margin.Bottom)

            Case Windows.VerticalAlignment.Bottom
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top, ctrl.Margin.Right, ctrl.Margin.Bottom - VerticalChange)

            Case Windows.VerticalAlignment.Stretch
                ctrl.Margin = New Thickness(ctrl.Margin.Left, ctrl.Margin.Top + VerticalChange, ctrl.Margin.Right, ctrl.Margin.Bottom - VerticalChange)

        End Select


    End Sub

    Private Sub aligncbxSelectionChanged(sender As Object, e As SelectionChangedEventArgs)
        CType(AdornedElement, FrameworkElement).HorizontalAlignment = Me.alignhvalues(aligncbx.SelectedIndex)
        CType(AdornedElement, FrameworkElement).VerticalAlignment = Me.alignvvalues(aligncbx.SelectedIndex)
    End Sub

    Private startwidth As Double
    Private startheight As Double
    Private startmargin As Thickness
    Private Sub RulerDragStarted(ByVal sender As Object, ByVal e As Primitives.DragStartedEventArgs)
        Dim ctrl As Control = AdornedElement
        startwidth = ctrl.Width
        startheight = ctrl.Height
        startmargin = ctrl.Margin
       
    End Sub

    Private Sub RulerDragCompleted(ByVal sender As Object, ByVal e As Primitives.DragCompletedEventArgs)
        Dim ctrl As Control = AdornedElement
        Dim data = New Object() {ctrl, startwidth, startheight, startmargin, ctrl.Width, ctrl.Height, ctrl.Margin}
        UIBuilderPlugin._UndoRedoService.ActiveContext = Project.Current.ActiveDocument
        UIBuilderPlugin._UndoRedoService.Push(New Core.UndoRedo.DefaultUndoRedoToken(AddressOf UndoDesignAction, AddressOf RedoDesignAction, "Deplacement de " & AdornedElement.GetType().Name, data))
    End Sub

    Private Shared Sub UndoDesignAction(ByVal obj)
        Dim data As Object() = obj
        Dim ctrl As Control = data(0)
        ctrl.Width = data(1)
        ctrl.Height = data(2)
        ctrl.Margin = data(3)
    End Sub
    Private Shared Sub RedoDesignAction(ByVal obj)
        Dim data As Object() = obj
        Dim ctrl As Control = data(0)
        ctrl.Width = data(4)
        ctrl.Height = data(5)
        ctrl.Margin = data(6)
    End Sub
End Class