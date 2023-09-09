Public Interface IFlagHolder
    Sub SetFlag(flagName As String, flagState As Boolean)
    Function GetFlag(flagName As String) As Boolean
End Interface
