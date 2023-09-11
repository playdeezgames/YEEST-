Public Class Host
    Implements IHost

    Private Const TitleState As String = "title"
    Private Const ConfirmQuitState As String = "ConfirmQuit"
    Private Const QuitToken = "quit"
    Private Const InvalidCommandMessage As String = "[red]Invalid Command![/]"
    Private Const YesText = "yes"
    Private Const NoText = "no"

    Private ReadOnly outputter As Action(Of String)
    Private ReadOnly inputter As Func(Of String)
    Private ReadOnly handlerStack As New Stack(Of String)
    Private ReadOnly commandHandlers As New Dictionary(Of String, Action(Of Queue(Of String), Stack(Of String), IEnumerable(Of String))) From
        {
            {TitleState, AddressOf HandleTitleCommand},
            {ConfirmQuitState, AddressOf HandleConfirmQuitCommand}
        }

    Private Sub HandleConfirmQuitCommand(queue As Queue(Of String), stack As Stack(Of String), tokens As IEnumerable(Of String))
        If Not tokens.Any Then
            messages.Enqueue("(please type 'yes' or 'no')")
        End If
        Select Case tokens.First
            Case YesText
                messages.Enqueue("[green]Thank you for playing![]")
                While (stack.Any)
                    stack.Pop()
                End While
            Case NoText
                stack.Pop()
        End Select
    End Sub

    Private messages As New Queue(Of String)(New List(Of String) From
        {
            "[fuchsia]YEEST!![/]"
        })
    Sub New(outputter As Action(Of String), inputter As Func(Of String))
        Me.outputter = If(outputter, AddressOf Console.WriteLine)
        Me.inputter = If(inputter, AddressOf Console.ReadLine)
        handlerStack.Push(TitleState)
    End Sub


    Public Sub Run() Implements IHost.Run
        Do
            OutputMessages()
            commandHandlers(handlerStack.Peek()).Invoke(messages, handlerStack, ReadInput())
        Loop While handlerStack.Any
    End Sub

    Private Shared Sub HandleTitleCommand(messages As Queue(Of String), stateStack As Stack(Of String), tokens As IEnumerable(Of String))
        If Not tokens.Any Then
            messages.Enqueue(InvalidCommandMessage)
        End If
        Select Case tokens.First
            Case QuitToken
                messages.Enqueue("[red]Are you sure you want to quit?[/]")
                stateStack.Push(ConfirmQuitState)
        End Select
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
