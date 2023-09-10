Friend Class Character
    Inherits CharacterDataClient
    Implements ICharacter

    Friend Const CharacterTypeKey As String = "CharacterType"
    Private Const LocationIdKey As String = "LocationId"

    Public Sub New(data As Data.WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub

    Public ReadOnly Property CharacterType As String Implements ICharacter.CharacterType
        Get
            Return GetMetadata(CharacterTypeKey)
        End Get
    End Property

    Public Property Location As ILocation Implements ICharacter.Location
        Get
            If Not HasStatistic(LocationIdKey) Then
                Return Nothing
            End If
            Return New Location(WorldData, GetStatistic(LocationIdKey))
        End Get
        Set(value As ILocation)
            If Location IsNot Nothing Then
                Location.RemoveCharacter(Me)
            End If
            If value Is Nothing Then
                RemoveStatistic(LocationIdKey)
                Return
            End If
            SetStatistic(LocationIdKey, value.Id)
            value.AddCharacter(Me)
        End Set
    End Property
End Class
