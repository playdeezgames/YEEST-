Friend Class InPlayStateHandler
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
            Return GameText
        End Get
    End Property

    Public Overrides Sub Update()
        AddMessage("Yer playing the game!")
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        AddMessage(InvalidCommandMessage)
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Select Case tokens.First
            Case GameText
                PopState()
            Case Else
                OnInvalidCommand()
        End Select
    End Sub
End Class
