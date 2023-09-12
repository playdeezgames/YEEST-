Friend Class SaveStateHandler
    Inherits CommandHandler

    Public Sub New(model As IWorldModel, messages As Queue(Of String), stateStack As Stack(Of String))
        MyBase.New(model, messages, stateStack)
    End Sub

    Public Overrides ReadOnly Property Prompt As String
        Get
            Return "[white]filename: [/]"
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultCommand As String
        Get
            Return String.Empty
        End Get
    End Property

    Public Overrides Sub Update()
        AddMessage("[green]Save As?[/]")
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        AddMessage("(save game canceled)")
        PopState()
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Dim filename = String.Join(" "c, tokens)
        System.IO.File.WriteAllText(filename, model.Serialize())
        PopState()
    End Sub
End Class
