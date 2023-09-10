Public Interface IWorld
    Inherits IHolder
    ReadOnly Property SerializedData As String
    Function CreateLocation(locationType As String) As ILocation
    Function CreateCharacter(characterType As String) As ICharacter
End Interface
