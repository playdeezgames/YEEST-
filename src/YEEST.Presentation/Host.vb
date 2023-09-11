Public Class Host
    Implements IHost
    Private ReadOnly outputter As Action(Of String)
    Private ReadOnly inputter As Func(Of String)
    Private ReadOnly handlerStack As New Stack(Of String)
    Private ReadOnly commandHandlers As New Dictionary(Of String, ICommandHandler)
    Private messages As New Queue(Of String)
    Sub New(outputter As Action(Of String), inputter As Func(Of String))
        Me.outputter = If(outputter, AddressOf Console.WriteLine)
        Me.inputter = If(inputter, AddressOf Console.ReadLine)
        commandHandlers.Add(TitleState, New TitleStateHandler(messages, handlerStack))
        commandHandlers.Add(ConfirmQuitState, New ConfirmQuitStateHandler(messages, handlerStack))
        handlerStack.Push(TitleState)
    End Sub
    Public Sub Run() Implements IHost.Run
        Do
            commandHandlers(handlerStack.Peek()).Update()
            OutputMessages()
            commandHandlers(handlerStack.Peek()).HandleCommand(ReadInput())
        Loop While handlerStack.Any
        OutputMessages()
    End Sub
    Private Function ReadInput() As IEnumerable(Of String)
        Return inputter().ToLower().Split(" "c, StringSplitOptions.RemoveEmptyEntries)
    End Function
    Private Sub OutputMessages()
        While messages.Any
            outputter(messages.Dequeue)
        End While
    End Sub
End Class
