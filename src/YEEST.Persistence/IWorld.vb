Public Interface IWorld
    ReadOnly Property SerializedData As String
    Function CreateLocation() As ILocation
    Sub SetMetadata(key As String, value As String)
    Function GetMetadata(metadataKey As String) As String
End Interface
