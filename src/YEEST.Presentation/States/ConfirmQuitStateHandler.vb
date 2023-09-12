Friend Class ConfirmQuitStateHandler
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
            Return NoText
        End Get
    End Property

    Public Overrides Sub Update()
        AddMessage("[red]Are you sure you want to quit?[/]")
        AddMessage("Commands: yes, *no")
    End Sub
    Protected Overrides Sub OnInvalidCommand()
        AddMessage("Please enter 'yes' or 'no'!")
    End Sub
    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Select Case tokens.First
            Case YesText
                PopAllStates()
            Case NoText
                PopState()
        End Select
    End Sub
End Class
