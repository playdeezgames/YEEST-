Friend Class HelpStateHandler
    Inherits CommandHandler

    Public Sub New(model As IWorldModel, messages As Queue(Of String), stateStack As Stack(Of String))
        MyBase.New(model, messages, stateStack)
    End Sub

    Public Overrides ReadOnly Property Prompt As String
        Get
            Throw New NotImplementedException
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultCommand As String
        Get
            Throw New NotImplementedException
        End Get
    End Property

    Private Shared commandDescriptions As IReadOnlyDictionary(Of String, String) =
        New Dictionary(Of String, String) From
        {
            {
                AbandonText,
                "Abandons the current session."
            },
            {
                ContinueText,
                "Resumes the current session."
            },
            {
                StartText,
                "Starts a new session."
            },
            {
                HelpText,
                "Provides context sensitive help."
            },
            {
                QuitText,
                "Quits the game."
            },
            {
                SaveText,
                "Save the current session."
            },
            {
                GameText,
                "Brings up the game menu."
            },
            {
                StatusText,
                "Shows the current in-game status."
            }
        }

    Private Shared stateCommands As IReadOnlyDictionary(Of String, IReadOnlyList(Of String)) =
        New Dictionary(Of String, IReadOnlyList(Of String)) From
        {
            {
                TitleState,
                New List(Of String) From
                {
                    AbandonText,
                    ContinueText,
                    StartText,
                    HelpText,
                    QuitText,
                    SaveText
                }
            },
            {
                InPlayState,
                New List(Of String) From
                {
                    GameText,
                    HelpText,
                    StatusText
                }
            }
        }

    Public Overrides Sub Update()
        AddMessage("[blue]Help Menu:[/]")
        For Each cmd In stateCommands(PreviousState)
            AddMessage($"[teal]{cmd}[/] - {commandDescriptions(cmd)}")
        Next
        PopState()
    End Sub

    Protected Overrides Sub OnInvalidCommand()
        Throw New NotImplementedException
    End Sub

    Protected Overrides Sub ParseCommand(tokens As IEnumerable(Of String))
        Throw New NotImplementedException
    End Sub
End Class
