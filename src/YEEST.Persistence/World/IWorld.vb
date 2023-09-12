Public Interface IWorld
    Inherits IHolder
    Function CreateLocation(locationType As String) As ILocation
    Function CreateCharacter(characterType As String) As ICharacter
    ReadOnly Property Avatar As ICharacter
End Interface
