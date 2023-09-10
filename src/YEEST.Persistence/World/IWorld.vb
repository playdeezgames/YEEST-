Public Interface IWorld
    Inherits IHolder
    ReadOnly Property SerializedData As String
    Function CreateLocation(locationType As String) As ILocation
    Function CreateCharacter() As ICharacter
End Interface
