Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter

    Friend Const CharacterTypeKey As String = "CharacterType"

    Public Sub New(data As Data.WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub

    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return GetMetadata(CharacterTypeKey)
        End Get
    End Property

    Public ReadOnly Property Location As ILocation Implements ICharacter.Location
        Get
            Return Nothing
        End Get
    End Property
End Class
