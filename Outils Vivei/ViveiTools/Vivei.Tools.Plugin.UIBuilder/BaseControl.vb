Imports System.Windows.Controls.Primitives

Public Class BaseControl
    Inherits System.Windows.Controls.HeaderedContentControl

    Shared Sub New()
        'Cet appel OverrideMetadata indique au système que cet élément souhaite apporter un style différent de celui de sa classe de base.
        'Ce style est défini dans themes\generic.xaml
        DefaultStyleKeyProperty.OverrideMetadata(GetType(BaseControl), New FrameworkPropertyMetadata(GetType(BaseControl)))
    End Sub

    Public Property HeaderContainerStyle As Style
        Get
            Return GetValue(HeaderContainerStyleProperty)
        End Get
        Set(ByVal value As Style)
            SetValue(HeaderContainerStyleProperty, value)
        End Set
    End Property

    Public Shared ReadOnly HeaderContainerStyleProperty As DependencyProperty = _
                           DependencyProperty.Register("HeaderContainerStyle", _
                           GetType(Style), GetType(BaseControl), _
                           New FrameworkPropertyMetadata(Nothing))


    Public Property ContentContainerStyle As Style
        Get
            Return GetValue(ContentContainerStyleProperty)
        End Get

        Set(ByVal value As Style)
            SetValue(ContentContainerStyleProperty, value)
        End Set
    End Property

    Public Shared ReadOnly ContentContainerStyleProperty As DependencyProperty = _
                           DependencyProperty.Register("ContentContainerStyle", _
                           GetType(Style), GetType(BaseControl), _
                           New FrameworkPropertyMetadata(Nothing))

    Public Property HeaderPosition As HeaderPosition
        Get
            Return GetValue(HeaderPositionProperty)
        End Get

        Set(ByVal value As HeaderPosition)
            SetValue(HeaderPositionProperty, value)
        End Set
    End Property

    Public Shared ReadOnly HeaderPositionProperty As DependencyProperty = _
                            DependencyProperty.Register("HeaderPosition", _
                            GetType(HeaderPosition), GetType(BaseControl), _
                            New PropertyMetadata(HeaderPosition.Top))

    Public Property Dock As Dock
        Get
            Return DockPanel.GetDock(Me)
        End Get
        Set(ByVal value As Dock)
            DockPanel.SetDock(Me, value)
        End Set
    End Property
End Class
Public Enum HeaderPosition
    Top
    Left
    Bottom
    Right
    Free
End Enum