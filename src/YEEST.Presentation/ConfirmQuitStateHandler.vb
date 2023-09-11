Friend Class ConfirmQuitStateHandler
    Inherits CommandHandler
    Public Sub New(messages As Queue(Of String), stateStack As Stack(Of String))
        MyBase.New(messages, stateStack)
    End Sub
    Public Overrides Sub Update()
        AddMessage("[red]Are you sure you want to quit?[/]")
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
