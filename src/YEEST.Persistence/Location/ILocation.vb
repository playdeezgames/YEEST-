﻿Public Interface ILocation
    Inherits IInstancedHolder
    ReadOnly Property LocationType As String
    ReadOnly Property Characters As IEnumerable(Of ICharacter)
    Sub AddCharacter(character As ICharacter)
End Interface
