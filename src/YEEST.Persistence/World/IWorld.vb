Public Interface IWorld
    Inherits IMetadataHolder
    ReadOnly Property SerializedData As String
    Function CreateLocation() As ILocation
End Interface
