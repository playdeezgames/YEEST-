Public Interface IWorld
    ReadOnly Property SerializedData As String
    Function CreateLocation() As ILocation
End Interface
