Imports YEEST.Data

Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Friend Const AvatarIdStatistic = "AvatarId"
    Private Sub New(data As WorldData)
        MyBase.New(data)
    End Sub

    Public Property Avatar As ICharacter Implements IWorld.Avatar
        Get
            Return If(
                HasStatistic(AvatarIdStatistic),
                New Character(WorldData, GetStatistic(AvatarIdStatistic)),
                Nothing)
        End Get
        Set(value As ICharacter)
            If value Is Nothing Then
                RemoveStatistic(AvatarIdStatistic)
                Return
            End If
            SetStatistic(AvatarIdStatistic, value.Id)
        End Set
    End Property

    Public Shared Function Create(data As WorldData) As IWorld
        Return New World(data)
    End Function

    Public Function CreateLocation(locationType As String) As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.FindIndex(Function(x) x.Flags.Contains(InstancedWorldDataClient.IsRecycledFlag))
        If locationId < 0 Then
            locationId = WorldData.Locations.Count
            WorldData.Locations.Add(New LocationData())
        Else
            WorldData.Locations(locationId) = New LocationData
        End If
        Dim result = New Location(WorldData, locationId)
        result.SetMetadata(Location.LocationTypeKey, locationType)
        Return result
    End Function

    Public Function CreateCharacter(characterType As String) As ICharacter Implements IWorld.CreateCharacter
        Dim characterId = WorldData.Characters.FindIndex(Function(x) x.Flags.Contains(InstancedWorldDataClient.IsRecycledFlag))
        If characterId < 0 Then
            characterId = WorldData.Characters.Count
            WorldData.Characters.Add(New CharacterData())
        Else
            WorldData.Characters(characterId) = New CharacterData
        End If
        Dim result As New Character(WorldData, characterId)
        result.SetMetadata(Character.CharacterTypeKey, characterType)
        Return result
    End Function
End Class
