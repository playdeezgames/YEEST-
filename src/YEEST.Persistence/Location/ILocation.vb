Public Interface ILocation
    Inherits IInstancedHolder
    ReadOnly Property LocationType As String
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    Sub AddCharacter(character As ICharacter)
    Sub RemoveCharacter(character As ICharacter)
    Function HasCharacter(character As ICharacter) As Boolean
End Interface
