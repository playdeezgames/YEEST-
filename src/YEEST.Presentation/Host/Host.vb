Public Class Host
    Implements IHost
    Private ReadOnly outputter As Action(Of String)
    Private ReadOnly inputter As Func(Of String, String, String)
    Private ReadOnly handlerStack As New Stack(Of String)
    Private ReadOnly commandHandlers As New Dictionary(Of String, ICommandHandler)
    Private messages As New Queue(Of String)
    Private ReadOnly model As IWorldModel
    Sub New(outputter As Action(Of String), inputter As Func(Of String, String, String))
        Me.outputter = outputter
        Me.inputter = inputter
        Me.model = New WorldModel
        commandHandlers.Add(TitleState, New TitleStateHandler(model, messages, handlerStack))
        commandHandlers.Add(ConfirmQuitState, New ConfirmQuitStateHandler(model, messages, handlerStack))
        commandHandlers.Add(HelpState, New HelpStateHandler(model, messages, handlerStack))
        handlerStack.Push(TitleState)
    End Sub
    Private ReadOnly Property CurrentCommandHandler As ICommandHandler
        Get
            Return commandHandlers(handlerStack.Peek())
        End Get
    End Property
    Public Sub Run() Implements IHost.Run
        Do
            CurrentCommandHandler.Update()
            OutputMessages()
            CurrentCommandHandler.HandleCommand(ReadInput())
        Loop While handlerStack.Any
        OutputMessages()
    End Sub
    Private Function ReadInput() As IEnumerable(Of String)
        Return inputter(CurrentCommandHandler.Prompt, CurrentCommandHandler.DefaultCommand).ToLower().Split(" "c, StringSplitOptions.RemoveEmptyEntries)
    End Function
    Private Sub OutputMessages()
        While messages.Any
            outputter(messages.Dequeue)
        End While
    End Sub
End Class
