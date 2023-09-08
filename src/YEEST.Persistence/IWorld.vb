Public Interface IWorld
    ReadOnly Property SerializedData As String
    Function CreateLocation() As ILocation
    Sub SetMetadata(key As String, value As String)
    Function GetMetadata(key As String) As String
    Function HasMetadata(key As String) As Boolean
    Sub RemoveMetadata(key As String)
End Interface
