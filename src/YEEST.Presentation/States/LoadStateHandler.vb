Friend Class LoadStateHandler
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
        AddMessage(String.Empty)
        AddMessage("[green]Load From?[/]")
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        PopState()
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Dim filename = String.Join(" "c, tokens)
        Try
            model.Deserialize(System.IO.File.ReadAllText(filename))
            AddMessage("[green]Game loaded successfully![/]")
        Catch ex As Exception
            AddMessage("[red]Game failed to load![/]")
        End Try
        PopState()
    End Sub
End Class
