Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter

    Public Sub New(data As Data.WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub

    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return "character-type"
        End Get
    End Property
End Class
