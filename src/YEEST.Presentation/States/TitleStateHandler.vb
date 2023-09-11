﻿Friend Class TitleStateHandler
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
            Return HelpText
        End Get
    End Property
    Public Overrides Sub Update()
        AddMessage("[fuchsia]YEEST!![/] Main Menu")
        AddMessage("Commands: quit, *help")
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        AddMessage(InvalidCommandMessage)
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Select Case tokens.First
            Case HelpText
                PushState(HelpState)
            Case QuitText
                PushState(ConfirmQuitState)
            Case Else
                OnInvalidCommand()
        End Select
    End Sub
End Class
