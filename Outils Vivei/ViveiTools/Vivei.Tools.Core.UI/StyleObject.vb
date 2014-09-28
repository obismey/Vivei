Imports System.Windows.Controls
Imports System.Windows.Input
Imports System.Windows
Imports System.Windows.Media
Imports System.ComponentModel

Public Class StyleObject
    Inherits UIObject



    'Friend Shared valideproperties As SortedList(Of String, Type)

    'Private _Properties As New ObjectModel.ObservableCollection(Of DashboardZoneProperty)

    '<Browsable(False)> _
    '<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    'Public ReadOnly Property Properties As ObjectModel.ObservableCollection(Of DashboardZoneProperty)
    '    Get
    '        Return _Properties
    '    End Get
    'End Property

    '<Browsable(False)> _
    'Public Property InlcudedProperties As String()
    '    Get
    '        Return (From p In _Properties Where p.Include Select p.Name).ToArray()
    '    End Get
    '    Set(value As String())
    '        For Each p In value
    '            Dim q = (From prop In _Properties Where p = prop.Name Select prop Take 1).FirstOrDefault()

    '            If q IsNot Nothing Then
    '                q.Include = True
    '            End If
    '        Next
    '    End Set
    'End Property

    'Friend Shared Sub SetupValideProperties()
    '    If valideproperties Is Nothing Then

    '        valideproperties = New SortedList(Of String, Type)()

    '        valideproperties.Add("Format", GetType(String))

    '        valideproperties.Add("FontFamily", GetType(FontFamily))
    '        valideproperties.Add("FontStyle", GetType(FontStyle))
    '        valideproperties.Add("FontWeight", GetType(FontWeight))
    '        valideproperties.Add("FontStretch", GetType(FontStretch))
    '        valideproperties.Add("FontSize", GetType(Double))
    '        valideproperties.Add("Foreground", GetType(Brush))
    '        valideproperties.Add("TextDecorations", GetType(TextDecorationCollection))
    '        valideproperties.Add("TextAlignment", GetType(TextAlignment))
    '        valideproperties.Add("TextTrimming", GetType(TextTrimming))
    '        valideproperties.Add("TextWrapping", GetType(TextWrapping))

    '        valideproperties.Add("Background", GetType(Brush))
    '        valideproperties.Add("BorderThickness", GetType(Thickness))
    '        valideproperties.Add("CornerRadius", GetType(CornerRadius))
    '        valideproperties.Add("BorderBrush", GetType(Brush))

    '        valideproperties.Add("Padding", GetType(Thickness))
    '        valideproperties.Add("Width", GetType(Double))
    '        valideproperties.Add("MinWidth", GetType(Double))
    '        valideproperties.Add("MaxWidth", GetType(Double))
    '        valideproperties.Add("Height", GetType(Double))
    '        valideproperties.Add("MinHeight", GetType(Double))
    '        valideproperties.Add("MaxHeight", GetType(Double))
    '        valideproperties.Add("Margin", GetType(Thickness))
    '        valideproperties.Add("HorizontalAlignment", GetType(HorizontalAlignment))
    '        valideproperties.Add("VerticalAlignment", GetType(VerticalAlignment))
    '        valideproperties.Add("HorizontalContentAlignment", GetType(HorizontalAlignment))
    '        valideproperties.Add("VerticalContentAlignment", GetType(VerticalAlignment))

    '        valideproperties.Add("RenderTransform", GetType(RotateTransform))
    '        valideproperties.Add("RenderTransformOrigin", GetType(Point))
    '        valideproperties.Add("LayoutTransform", GetType(RotateTransform))

    '        valideproperties.Add("Focusable", GetType(Boolean))

    '        valideproperties.Add("Visibility", GetType(Visibility))
    '    End If
    'End Sub

    'Sub New()

    '    SetupValideProperties()

    '    SetupProperties()
    'End Sub

    'Private Sub SetupProperties()
    '    _Properties = New ObjectModel.ObservableCollection(Of DashboardZoneProperty)( _
    '        (From prop As ComponentModel.PropertyDescriptor In _
    '        ComponentModel.TypeDescriptor.GetProperties(Me) _
    '        Where Not prop.IsReadOnly And prop.IsBrowsable _
    '        Select New DashboardZoneProperty(Nothing, Me, prop, prop.Category) With {.Include = False}).AsEnumerable())

    '    For Each p In Me._Properties
    '        AddHandler p.IncludeChanged, Sub() Me.OnPropertyChanged("Include")
    '    Next
    'End Sub

    Private _Background As Brush = Brushes.Red

    <Category("Mise en forme")> _
    Public Property Background As Brush
        Get
            Return _Background
        End Get
        Set(ByVal value As Brush)
            _Background = value
            OnPropertyChanged("Background")
        End Set
    End Property

    Private _BorderBrush As Brush = Brushes.Yellow

    <Category("Mise en forme")> _
    Public Property BorderBrush As Brush
        Get
            Return _BorderBrush
        End Get
        Set(ByVal value As Brush)
            _BorderBrush = value
            OnPropertyChanged("BorderBrush")
        End Set
    End Property

    Private _BorderThickness As Thickness

    <Category("Mise en forme")> _
    Public Property BorderThickness As Thickness
        Get
            Return _BorderThickness
        End Get
        Set(ByVal value As Thickness)
            _BorderThickness = value
            OnPropertyChanged("BorderThickness")
        End Set
    End Property

    Private _CornerRadius As CornerRadius

    <Category("Mise en forme")> _
    Public Property CornerRadius As CornerRadius
        Get
            Return _CornerRadius
        End Get
        Set(ByVal value As CornerRadius)
            _CornerRadius = value
            OnPropertyChanged("CornerRadius")
        End Set
    End Property

    Private _Focusable As Boolean

    <Category("Autres")> _
    Public Property Focusable As Boolean
        Get
            Return _Focusable
        End Get
        Set(ByVal value As Boolean)
            _Focusable = value
            OnPropertyChanged("Focusable")
        End Set
    End Property

    Private _FontFamily As FontFamily

    <Category("Texte")> _
    Public Property FontFamily As FontFamily
        Get
            Return _FontFamily
        End Get
        Set(ByVal value As FontFamily)
            _FontFamily = value
            OnPropertyChanged("FontFamily")
        End Set
    End Property

    Private _FontSize As Double

    <Category("Texte")> _
    Public Property FontSize As Double
        Get
            Return _FontSize
        End Get
        Set(ByVal value As Double)
            _FontSize = value
            OnPropertyChanged("FontSize")
        End Set
    End Property

    Private _FontStretch As FontStretch

    <Category("Texte")> _
    Public Property FontStretch As FontStretch
        Get
            Return _FontStretch
        End Get
        Set(ByVal value As FontStretch)
            _FontStretch = value
            OnPropertyChanged("FontStretch")
        End Set
    End Property

    Private _FontStyle As FontStyle

    <Category("Texte")> _
    Public Property FontStyle As FontStyle
        Get
            Return _FontStyle
        End Get
        Set(ByVal value As FontStyle)
            _FontStyle = value
            OnPropertyChanged("FontStyle")
        End Set
    End Property

    Private _FontWeight As FontWeight

    <Category("Texte")> _
    Public Property FontWeight As FontWeight
        Get
            Return _FontWeight
        End Get
        Set(ByVal value As FontWeight)
            _FontWeight = value
            OnPropertyChanged("FontWeight")
        End Set
    End Property

    Private _Foreground As Brush

    <Category("Texte")> _
    Public Property Foreground As Brush
        Get
            Return _Foreground
        End Get
        Set(ByVal value As Brush)
            _Foreground = value
            OnPropertyChanged("Foreground")
        End Set
    End Property

    Private _Format As String

    <Category("Texte")> _
    Public Property Format As String
        Get
            Return _Format
        End Get
        Set(ByVal value As String)
            _Format = value
            OnPropertyChanged("Format")
        End Set
    End Property

    Private _Height As Double

    <Category("Positionnement")> _
    Public Property Height As Double
        Get
            Return _Height
        End Get
        Set(ByVal value As Double)
            _Height = value
            OnPropertyChanged("Height")
        End Set
    End Property

    Private _HorizontalAlignment As HorizontalAlignment

    <Category("Positionnement")> _
    Public Property HorizontalAlignment As HorizontalAlignment
        Get
            Return _HorizontalAlignment
        End Get
        Set(ByVal value As HorizontalAlignment)
            _HorizontalAlignment = value
            OnPropertyChanged("HorizontalAlignment")
        End Set
    End Property

    Private _HorizontalContentAlignment As HorizontalAlignment

    <Category("Positionnement")> _
    Public Property HorizontalContentAlignment As HorizontalAlignment
        Get
            Return _HorizontalContentAlignment
        End Get
        Set(ByVal value As HorizontalAlignment)
            _HorizontalContentAlignment = value
            OnPropertyChanged("HorizontalContentAlignment")
        End Set
    End Property

    Private _LayoutTransform As Transform

    <Category("Transformation")> _
    Public Property LayoutTransform As Transform
        Get
            Return _LayoutTransform
        End Get
        Set(ByVal value As Transform)
            _LayoutTransform = value
            OnPropertyChanged("LayoutTransform")
        End Set
    End Property

    Private _Margin As Thickness

    <Category("Positionnement")> _
    Public Property Margin As Thickness
        Get
            Return _Margin
        End Get
        Set(ByVal value As Thickness)
            _Margin = value
            OnPropertyChanged("Margin")
        End Set
    End Property

    Private _MaxHeight As Double

    <Category("Positionnement")> _
    Public Property MaxHeight As Double
        Get
            Return _MaxHeight
        End Get
        Set(ByVal value As Double)
            _MaxHeight = value
            OnPropertyChanged("MaxHeight")
        End Set
    End Property

    Private _MaxWidth As Double

    <Category("Positionnement")> _
    Public Property MaxWidth As Double
        Get
            Return _MaxWidth
        End Get
        Set(ByVal value As Double)
            _MaxWidth = value
            OnPropertyChanged("MaxWidth")
        End Set
    End Property

    Private _MinHeight As Double

    <Category("Positionnement")> _
    Public Property MinHeight As Double
        Get
            Return _MinHeight
        End Get
        Set(ByVal value As Double)
            _MinHeight = value
            OnPropertyChanged("MinHeight")
        End Set
    End Property

    Private _MinWidth As Double

    <Category("Positionnement")> _
    Public Property MinWidth As Double
        Get
            Return _MinWidth
        End Get
        Set(ByVal value As Double)
            _MinWidth = value
            OnPropertyChanged("MinWidth")
        End Set
    End Property

    Private _Padding As Thickness

    <Category("Positionnement")> _
    Public Property Padding As Thickness
        Get
            Return _Padding
        End Get
        Set(ByVal value As Thickness)
            _Padding = value
            OnPropertyChanged("Padding")
        End Set
    End Property

    Private _RenderTransform As Transform

    <Category("Transformation")> _
    Public Property RenderTransform As Transform
        Get
            Return _RenderTransform
        End Get
        Set(ByVal value As Transform)
            _RenderTransform = value
            OnPropertyChanged("RenderTransform")
        End Set
    End Property

    Private _RenderTransformOrigin As Point

    <Category("Transformation")> _
    Public Property RenderTransformOrigin As Point
        Get
            Return _RenderTransformOrigin
        End Get
        Set(ByVal value As Point)
            _RenderTransformOrigin = value
            OnPropertyChanged("RenderTransformOrigin")
        End Set
    End Property

    Private _TextAlignment As TextAlignment

    <Category("Texte")> _
    Public Property TextAlignment As TextAlignment
        Get
            Return _TextAlignment
        End Get
        Set(ByVal value As TextAlignment)
            _TextAlignment = value
            OnPropertyChanged("TextAlignment")
        End Set
    End Property

    Private _TextDecorations As TextDecorationCollection

    <Category("Texte")> _
    Public Property TextDecorations As TextDecorationCollection
        Get
            Return _TextDecorations
        End Get
        Set(ByVal value As TextDecorationCollection)
            _TextDecorations = value
            OnPropertyChanged("TextDecorations")
        End Set
    End Property

    Private _TextTrimming As TextTrimming

    <Category("Texte")> _
    Public Property TextTrimming As TextTrimming
        Get
            Return _TextTrimming
        End Get
        Set(ByVal value As TextTrimming)
            _TextTrimming = value
            OnPropertyChanged("TextTrimming")
        End Set
    End Property

    Private _TextWrapping As TextWrapping

    <Category("Texte")> _
    Public Property TextWrapping As TextWrapping
        Get
            Return _TextWrapping
        End Get
        Set(ByVal value As TextWrapping)
            _TextWrapping = value
            OnPropertyChanged("TextWrapping")
        End Set
    End Property

    Private _VerticalAlignment As VerticalAlignment

    <Category("Positionnement")> _
    Public Property VerticalAlignment As VerticalAlignment
        Get
            Return _VerticalAlignment
        End Get
        Set(ByVal value As VerticalAlignment)
            _VerticalAlignment = value
            OnPropertyChanged("VerticalAlignment")
        End Set
    End Property

    Private _VerticalContentAlignment As VerticalAlignment

    <Category("Positionnement")> _
    Public Property VerticalContentAlignment As VerticalAlignment
        Get
            Return _VerticalContentAlignment
        End Get
        Set(ByVal value As VerticalAlignment)
            _VerticalContentAlignment = value
            OnPropertyChanged("VerticalContentAlignment")
        End Set
    End Property

    Private _Width As Double

    <Category("Positionnement")> _
    Public Property Width As Double
        Get
            Return _Width
        End Get
        Set(ByVal value As Double)
            _Width = value
            OnPropertyChanged("Width")
        End Set
    End Property

    Private _Visibility As Windows.Visibility
    <Category("Positionnement")> _
    Public Property Visibility As Windows.Visibility
        Get
            Return _Visibility
        End Get
        Set(ByVal value As Windows.Visibility)
            _Visibility = value
            OnPropertyChanged("Visibility")
        End Set
    End Property

    'Public Function Clone(linked As Boolean) As StyleObject

    'End Function

    'Shared Function FromUIElement(element As FrameworkElement) As StyleObject

    '    SetupValideProperties()

    '    Dim result = New StyleObject()

    '    For Each prop In valideproperties.Keys
    '        Try
    '            TypeDescriptor.GetProperties(result)(prop) _
    '                .SetValue(result, _
    '                TypeDescriptor.GetProperties(element)(prop).GetValue(element))
    '        Catch ex As Exception
    '            Debug.Print("erreur=" & prop)
    '        End Try
    '    Next

    '    If element.Style IsNot Nothing Then
    '        For Each setter As Setter In element.Style.Setters
    '            Try
    '                Dim q = (From p In result._Properties Where p.Name = setter.Property.Name Select p Take 1).FirstOrDefault()

    '                If q IsNot Nothing Then
    '                    q.Include = True
    '                End If
    '            Catch ex As Exception

    '            End Try
    '        Next
    '    End If

    '    Return result
    'End Function

    'Public Sub Apply(uielement As UIElement)
    '    For Each prop In Properties
    '        If prop.Include Then
    '            Try
    '                TypeDescriptor.GetProperties(uielement)(prop.Name).SetValue(uielement, prop.Value)
    '            Catch ex As Exception
    '                Try
    '                    TypeDescriptor.GetProperties(uielement)("Extender." & prop.Name).SetValue(uielement, prop.Value)
    '                Catch ex1 As Exception

    '                End Try
    '            End Try
    '        End If
    '    Next
    'End Sub
    'Public Sub Apply(uielement As UIElement, propertymap As Func(Of String, PropertyDescriptor))
    '    For Each prop In Properties
    '        If prop.Include Then
    '            Try
    '                propertymap(prop.Name).SetValue(uielement, prop.Value)
    '            Catch ex As Exception

    '            End Try
    '        End If
    '    Next
    'End Sub
    'Shared Function FromStyle(style As Style) As StyleObject
    '    Dim so As New StyleObject

    '    For Each setter As Setter In style.Setters
    '        Dim q = (From p In so._Properties Where p.Name = setter.Property.Name Select p Take 1).FirstOrDefault()

    '        If q IsNot Nothing Then
    '            q.Value = setter.Value
    '            q.Include = True
    '        End If
    '    Next

    '    Return so
    'End Function
    'Shared Function ToStyle(so As StyleObject) As Style
    '    If so Is Nothing Then Return Nothing
    '    If so.InlcudedProperties().Length = 0 Then Return Nothing

    '    Dim s As New Style
    '    For Each prop In so.Properties
    '        If prop.Include Then
    '            Try
    '                s.Setters.Add(New Setter(
    '                    DependencyPropertyDescriptor.FromProperty( _
    '                    TypeDescriptor.GetProperties(GetType(BaseControl))(prop.Name)).DependencyProperty, prop.Value))
    '            Catch ex As Exception
    '                Try
    '                    s.Setters.Add(New Setter(
    '                        DependencyPropertyDescriptor.FromProperty( _
    '                        TypeDescriptor.GetProperties(GetType(Control))(prop.Name)).DependencyProperty, prop.Value))
    '                Catch ex0 As Exception
    '                    Try
    '                        s.Setters.Add(New Setter(
    '                            DependencyPropertyDescriptor.FromProperty( _
    '                            TypeDescriptor.GetProperties(GetType(TextBlock))(prop.Name)).DependencyProperty, prop.Value))
    '                    Catch ex1 As Exception
    '                        Try
    '                            s.Setters.Add(New Setter(
    '                                DependencyPropertyDescriptor.FromProperty( _
    '                                TypeDescriptor.GetProperties(GetType(Border))(prop.Name)).DependencyProperty, prop.Value))
    '                        Catch ex2 As Exception

    '                        End Try
    '                    End Try
    '                End Try
    '            End Try
    '        End If
    '    Next
    '    Return s
    'End Function
    'Shared Function ToStyle(so As StyleObject, target As UIElement) As Style
    '    Dim s As New Style
    '    s.TargetType = target.GetType()
    '    For Each prop In so.Properties
    '        If prop.Include Then
    '            Try
    '                s.Setters.Add(New Setter(
    '                    DependencyPropertyDescriptor.FromProperty( _
    '                    TypeDescriptor.GetProperties(target)(prop.Name)).DependencyProperty, prop.Value))
    '            Catch ex As Exception
    '                Try
    '                    s.Setters.Add(New Setter(
    '                        DependencyPropertyDescriptor.FromProperty( _
    '                        TypeDescriptor.GetProperties(target)("Extender." & prop.Name)).DependencyProperty, prop.Value))
    '                Catch ex1 As Exception
    '                    Try
    '                        s.Setters.Add(New Setter(
    '                            DependencyPropertyDescriptor.FromProperty( _
    '                            TypeDescriptor.GetProperties(GetType(Control))(prop.Name)).DependencyProperty, prop.Value))
    '                    Catch ex2 As Exception
    '                        Try
    '                            s.Setters.Add(New Setter(
    '                                DependencyPropertyDescriptor.FromProperty( _
    '                                TypeDescriptor.GetProperties(GetType(TextBlock))(prop.Name)).DependencyProperty, prop.Value))
    '                        Catch ex3 As Exception
    '                            Try
    '                                s.Setters.Add(New Setter(
    '                                    DependencyPropertyDescriptor.FromProperty( _
    '                                    TypeDescriptor.GetProperties(GetType(Border))(prop.Name)).DependencyProperty, prop.Value))
    '                            Catch ex4 As Exception

    '                            End Try
    '                        End Try
    '                    End Try
    '                End Try
    '            End Try
    '        End If
    '    Next
    '    Return s
    'End Function
    'Public Shared Function ToStyle(ByVal so As StyleObject, ByVal target As Type) As Style
    '    Dim s As New Style
    '    For Each prop In so.Properties
    '        If prop.Include Then
    '            Try
    '                s.Setters.Add(New Setter(
    '                    DependencyPropertyDescriptor.FromProperty( _
    '                    TypeDescriptor.GetProperties(target)(prop.Name)).DependencyProperty, prop.Value))
    '            Catch ex As Exception
    '                's.Setters.Add(New Setter(DependencyPropertyDescriptor.FromName(prop.Name, GetType(Extender), target).DependencyProperty, prop.Value))
    '            End Try
    '        End If
    '    Next
    '    Return s
    'End Function

    Private _Properties As New Dictionary(Of String, Boolean)
    <Browsable(False)> _
    Default Public Property Item(ByVal name As String) As Boolean
        Get
            Dim result As Boolean = False
            If _Properties.TryGetValue(name, result) Then
                Return result
            End If
            Return result
        End Get
        Set(ByVal value As Boolean)
            Dim result As Boolean = False
            If _Properties.TryGetValue(name, result) Then
                If result = value Then Return
                _Properties(name) = value
            Else
                _Properties.Add(name, value)
            End If
            OnPropertyChanged("Item[]")
        End Set
    End Property

    Public Sub Reset()
        _Properties.Clear()
        OnPropertyChanged("Item[]")
    End Sub
    Public Sub Enable(ByVal name As String)
        Me(name) = True
    End Sub
    Public Sub Disable(ByVal name As String)
        Me(name) = False
    End Sub
    Public Sub Toggle(ByVal name As String)
        Me(name) = Not Me(name)
    End Sub
    Shared Function FromObject(ByVal element As DependencyObject) As StyleObject
        Dim result = New StyleObject()

        For Each prop As PropertyDescriptor In TypeDescriptor.GetProperties(GetType(StyleObject))
            If prop.IsBrowsable And Not prop.IsReadOnly Then
                Try
                    prop.SetValue(result, TypeDescriptor.GetProperties(element)(prop.Name).GetValue(element))
                Catch ex As Exception

                End Try
            End If
        Next
        Return result
    End Function
    Public Shared Function ToStyle(ByVal so As StyleObject, ByVal target As Type) As Style
        Dim s As New Style
        For Each prop In so._Properties
            If prop.Value Then
                Try
                    s.Setters.Add(New Setter(
                        DependencyPropertyDescriptor.FromProperty( _
                        TypeDescriptor.GetProperties(target)(prop.Key)).DependencyProperty, TypeDescriptor.GetProperties(GetType(StyleObject))(prop.Key).GetValue(so)))
                Catch ex As Exception
                    's.Setters.Add(New Setter(DependencyPropertyDescriptor.FromName(prop.Name, GetType(Extender), target).DependencyProperty, prop.Value))
                End Try
            End If
        Next
        Return s
    End Function


    
End Class

Public Class StyleObjectCollection
    Implements Specialized.INotifyCollectionChanged
    Implements ComponentModel.INotifyPropertyChanged
    Implements IList(Of StyleObject)

    Public Event CollectionChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs) Implements System.Collections.Specialized.INotifyCollectionChanged.CollectionChanged
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged

    Public Sub Add(ByVal item As StyleObject) Implements System.Collections.Generic.ICollection(Of StyleObject).Add

    End Sub

    Public Sub Clear() Implements System.Collections.Generic.ICollection(Of StyleObject).Clear

    End Sub

    Public Function Contains(ByVal item As StyleObject) As Boolean Implements System.Collections.Generic.ICollection(Of StyleObject).Contains

    End Function

    Public Sub CopyTo(ByVal array() As StyleObject, ByVal arrayIndex As Integer) Implements System.Collections.Generic.ICollection(Of StyleObject).CopyTo

    End Sub

    Public ReadOnly Property Count As Integer Implements System.Collections.Generic.ICollection(Of StyleObject).Count
        Get

        End Get
    End Property

    Public ReadOnly Property IsReadOnly As Boolean Implements System.Collections.Generic.ICollection(Of StyleObject).IsReadOnly
        Get

        End Get
    End Property

    Public Function Remove(ByVal item As StyleObject) As Boolean Implements System.Collections.Generic.ICollection(Of StyleObject).Remove

    End Function

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of StyleObject) Implements System.Collections.Generic.IEnumerable(Of StyleObject).GetEnumerator

    End Function

    Public Function IndexOf(ByVal item As StyleObject) As Integer Implements System.Collections.Generic.IList(Of StyleObject).IndexOf

    End Function

    Public Sub Insert(ByVal index As Integer, ByVal item As StyleObject) Implements System.Collections.Generic.IList(Of StyleObject).Insert

    End Sub

    Default Public Property Item(ByVal index As Integer) As StyleObject Implements System.Collections.Generic.IList(Of StyleObject).Item
        Get

        End Get
        Set(ByVal value As StyleObject)

        End Set
    End Property

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.Generic.IList(Of StyleObject).RemoveAt

    End Sub

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator

    End Function
End Class