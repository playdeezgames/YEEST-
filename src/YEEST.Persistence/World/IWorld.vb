Public Interface IWorld
    Inherits IHolder
    ReadOnly Property SerializedData As String
    Function CreateLocation() As ILocation
    Function CreateCharacter() As ICharacter
End Interface
