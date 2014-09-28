Public Class UndoRedoService
    Inherits Core.UI.UIObject
    Implements Core.UndoRedo.IUndoRedoService

    Dim _ActiveContext As Core.UndoRedo.IUndoRedoContext
    Private Shared _Instance As UndoRedoService
    Public Shared ReadOnly Property Instance As UndoRedoService
        Get
            If _Instance Is Nothing Then
                _Instance = New UndoRedoService()
            End If
            Return _Instance
        End Get
    End Property


    Private Sub New()

    End Sub
    Public Sub Reset() Implements Core.IService.Reset

    End Sub

    Public Property ActiveContext As Core.UndoRedo.IUndoRedoContext Implements Core.UndoRedo.IUndoRedoService.ActiveContext
        Get
            Return _ActiveContext
        End Get
        Set(ByVal value As Core.UndoRedo.IUndoRedoContext)
            If value Is _ActiveContext Then Return

            If _ActiveContext IsNot Nothing Then
                _ActiveContext.IsActive = False
            End If
            _ActiveContext = value
            _ActiveContext.IsActive = True


            OnPropertyChanged("ActiveContext")
            OnPropertyChanged("LastToken")
            OnPropertyChanged("LastUndoToken")

        End Set
    End Property

    Private _TokenStack As New Dictionary(Of Core.UndoRedo.IUndoRedoContext, Stack(Of Core.UndoRedo.IUndoRedoToken))
    Private _TokenUndoStack As New Dictionary(Of Core.UndoRedo.IUndoRedoContext, Stack(Of Core.UndoRedo.IUndoRedoToken))

    Public Sub Push(ByVal Token As Core.UndoRedo.IUndoRedoToken) Implements Core.UndoRedo.IUndoRedoService.Push
        If _ActiveContext Is Nothing Then Return

        If Not _TokenStack.ContainsKey(_ActiveContext) Then
            _TokenStack.Add(_ActiveContext, New Stack(Of Core.UndoRedo.IUndoRedoToken)())
        End If

        _TokenStack(_ActiveContext).Push(Token)

        If _TokenUndoStack.ContainsKey(_ActiveContext) Then
            _TokenUndoStack(_ActiveContext).Clear()
        End If

        OnPropertyChanged("LastToken")
        OnPropertyChanged("LastUndoToken")
    End Sub

    Public Sub Undo()
        If _ActiveContext Is Nothing Then Return
        If Not _TokenStack.ContainsKey(ActiveContext) Then Return
        If _TokenStack(_ActiveContext).Count = 0 Then Return

        If Not _TokenUndoStack.ContainsKey(ActiveContext) Then
            _TokenUndoStack.Add(ActiveContext, New Stack(Of Core.UndoRedo.IUndoRedoToken)())
        End If

        _TokenUndoStack(_ActiveContext).Push(_TokenStack(_ActiveContext).Pop())

        _TokenUndoStack(_ActiveContext).Peek().Undo()

        OnPropertyChanged("LastToken")
        OnPropertyChanged("LastUndoToken")
    End Sub
    Public Sub Redo()
        If _ActiveContext Is Nothing Then Return
        If Not _TokenUndoStack.ContainsKey(ActiveContext) Then Return
        If Not _TokenStack.ContainsKey(ActiveContext) Then Return
        If _TokenUndoStack(_ActiveContext).Count = 0 Then Return

        _TokenStack(_ActiveContext).Push(_TokenUndoStack(_ActiveContext).Pop())

        _TokenStack(_ActiveContext).Peek().Redo()

        OnPropertyChanged("LastToken")
        OnPropertyChanged("LastUndoToken")
    End Sub

    Public ReadOnly Property LastToken As Core.UndoRedo.IUndoRedoToken
        Get
            If _ActiveContext Is Nothing Then Return Nothing
            If Not _TokenStack.ContainsKey(ActiveContext) Then Return Nothing
            If _TokenStack(_ActiveContext).Count = 0 Then Return Nothing

            Return _TokenStack(_ActiveContext).Peek()
        End Get
    End Property
    Public ReadOnly Property LastUndoToken As Core.UndoRedo.IUndoRedoToken
        Get
            If _ActiveContext Is Nothing Then Return Nothing
            If Not _TokenUndoStack.ContainsKey(ActiveContext) Then Return Nothing
            If Not _TokenStack.ContainsKey(ActiveContext) Then Return Nothing
            If _TokenUndoStack(_ActiveContext).Count = 0 Then Return Nothing

            Return _TokenUndoStack(_ActiveContext).Peek()
        End Get
    End Property
End Class
