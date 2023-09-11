﻿Friend Class HelpStateHandler
    Inherits CommandHandler

    Public Sub New(messages As Queue(Of String), stateStack As Stack(Of String))
        MyBase.New(messages, stateStack)
    End Sub

    Public Overrides ReadOnly Property Prompt As String
        Get
            Return DefaultPrompt
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultCommand As String
        Get
            Return ExitText
        End Get
    End Property

    Public Overrides Sub Update()
        AddMessage("[blue]Help Menu:[/]")
        AddMessage("Commands: *exit")
        AddMessage("[teal]help[/]: brings up help(you are here)")
        AddMessage("[teal]quit[/]: quits the game")
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        AddMessage(InvalidCommandMessage)
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Select Case tokens.First
            Case ExitText
                PopState()
            Case Else
                OnInvalidCommand()
        End Select
    End Sub
End Class