Public Interface ILocation
    Inherits IInstancedHolder
    ReadOnly Property LocationType As String
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
End Interface
