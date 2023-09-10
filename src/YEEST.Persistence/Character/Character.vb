Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter

    Public Sub New(data As Data.WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub

    Public Overrides ReadOnly Property Id As Integer Implements ICharacter.Id
        Get
            Return CharacterId
        End Get
    End Property
End Class
