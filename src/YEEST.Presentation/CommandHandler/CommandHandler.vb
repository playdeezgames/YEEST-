Friend MustInherit Class CommandHandler
    Implements ICommandHandler
    Private messages As Queue(Of String)
    Private stateStack As Stack(Of String)
    Protected ReadOnly Property model As IWorldModel
    Public MustOverride ReadOnly Property Prompt As String Implements ICommandHandler.Prompt
    Public MustOverride ReadOnly Property DefaultCommand As String Implements ICommandHandler.DefaultCommand

    Sub New(model As IWorldModel, messages As Queue(Of String), stateStack As Stack(Of String))
        Me.messages = messages
        Me.stateStack = stateStack
    End Sub

    Protected Sub AddMessage(message As String)
        messages.Enqueue(message)
    End Sub

    Public MustOverride Sub Update() Implements ICommandHandler.Update
    Protected MustOverride Sub OnInvalidCommand()
    Protected MustOverride Sub ParseCommand(tokens As IEnumerable(Of String))

    Public Sub HandleCommand(tokens As IEnumerable(Of String)) Implements ICommandHandler.HandleCommand
        If Not tokens.Any Then
            OnInvalidCommand()
            Return
        End If
        ParseCommand(tokens)
    End Sub
    Protected Sub PushState(state As String)
        stateStack.Push(state)
    End Sub
    Protected Sub PopState()
        stateStack.Pop()
    End Sub
    Protected Sub PopAllStates()
        While stateStack.Any
            stateStack.Pop()
        End While
    End Sub
    Protected Sub GoToState(state As String)
        PopState()
        PushState(state)
    End Sub
End Class
