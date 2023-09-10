Imports System.Text.Json
Imports YEEST.Data

Public Class World
    Inherits WorldDataClient
    Implements IWorld
    Private Sub New(data As WorldData)
        MyBase.New(data)
    End Sub

    Public ReadOnly Property SerializedData As String Implements IWorld.SerializedData
        Get
            Return JsonSerializer.Serialize(WorldData)
        End Get
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
        Dim characterId = WorldData.Characters.Count
        WorldData.Characters.Add(New CharacterData())
        Dim result As New Character(WorldData, characterId)
        result.SetMetadata(Character.CharacterTypeKey, characterType)
        Return result
    End Function
End Class
