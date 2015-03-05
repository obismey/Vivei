Namespace ViewModel

    Public Class ProjectTreeItem
        Inherits Core.UI.UIObject

        Private _OnDoubleClick As action
        Private _Caption As String
        Private _Icon As String
        Private _ContextMenu As ObjectModel.ObservableCollection(Of Core.UI.MenuItem)
        Private _Children As New ObjectModel.ObservableCollection(Of ProjectTreeItem)

        Public Property Caption As String
            Get
                Return _Caption
            End Get
            Set(ByVal value As String)
                _Caption = value
                OnPropertyChanged("Caption")
            End Set
        End Property

        Public Property Icon As String
            Get
                Return _Icon
            End Get
            Set(ByVal value As String)
                _Icon = value
                OnPropertyChanged("Icon")
            End Set
        End Property

        Public Property ContextMenu As ObjectModel.ObservableCollection(Of Core.UI.MenuItem)
            Get
                Return _ContextMenu
            End Get
            Set(ByVal value As ObjectModel.ObservableCollection(Of Core.UI.MenuItem))
                _ContextMenu = value
                OnPropertyChanged("ContextMenu")
            End Set
        End Property

        Public ReadOnly Property Children As ObjectModel.ObservableCollection(Of ProjectTreeItem)
            Get
                Return _Children
            End Get
        End Property

        Public Property OnDoubleClick As action
            Get
                Return _OnDoubleClick
            End Get
            Set(ByVal value As action)
                _OnDoubleClick = value
                OnPropertyChanged("OnDoubleClick")
            End Set
        End Property


    End Class

End Namespace