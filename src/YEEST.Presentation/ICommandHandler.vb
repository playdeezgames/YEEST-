Friend Interface ICommandHandler
    Sub Update()
    Sub HandleCommand(tokens As IEnumerable(Of String))
    ReadOnly Property Prompt As String
    ReadOnly Property DefaultCommand As String
End Interface
