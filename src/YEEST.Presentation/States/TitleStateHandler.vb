Friend Class TitleStateHandler
    Inherits CommandHandler
    Public Sub New(model As IWorldModel, messages As Queue(Of String), stateStack As Stack(Of String))
        MyBase.New(model, messages, stateStack)
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
        AddMessage(String.Empty)
        AddMessage("[fuchsia]YEEST!![/] Main Menu")
        If model.Exists Then
            AddMessage("(there is a game in session)")
        End If
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        AddMessage(InvalidCommandMessage)
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Select Case tokens.First
            Case ContinueText
                If model.Exists Then
                    PushState(InPlayState)
                Else
                    AddMessage($"No game in session! Try '{StartText}' to start one!")
                End If
            Case SaveText
                If model.Exists Then
                    PushState(SaveState)
                Else
                    AddMessage("You cannot save at this time!")
                End If
            Case StartText
                If model.Exists Then
                    AddMessage($"Game is already in session! Try '{ContinueText}' to return to it!")
                Else
                    model.Start()
                    PushState(InPlayState)
                End If
            Case HelpText
                PushState(HelpState)
            Case QuitText
                If model.Exists Then
                    AddMessage($"Game is in session. You have to '{AbandonText}' first.")
                Else
                    PushState(ConfirmQuitState)
                End If
            Case AbandonText
                If model.Exists Then
                    PushState(ConfirmAbandonstate)
                Else
                    AddMessage("There is no game in session.")
                End If
            Case LoadText
                If model.Exists Then
                    AddMessage($"Game is in session. You have to '{AbandonText}' first.")
                Else
                    PushState(LoadState)
                End If
            Case Else
                OnInvalidCommand()
        End Select
    End Sub
End Class
