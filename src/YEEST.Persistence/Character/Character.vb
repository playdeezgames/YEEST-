Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter

    Public Sub New(data As Data.WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub
End Class
