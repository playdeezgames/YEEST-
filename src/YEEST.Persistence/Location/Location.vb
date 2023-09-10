Imports YEEST.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation

    Friend Const LocationTypeKey As String = "LocationType"

    Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, locationId)
    End Sub

    Public ReadOnly Property LocationType As String Implements ILocation.LocationType
        Get
            Return GetMetadata(LocationTypeKey)
        End Get
    End Property

    Public ReadOnly Property Characters As IEnumerable(Of ICharacter) Implements ILocation.Characters
        Get
            Return LocationData.Characters.Select(Function(characterId) New Character(WorldData, characterId))
        End Get
    End Property

    Public Sub AddCharacter(character As ICharacter) Implements ILocation.AddCharacter
        LocationData.Characters.Add(character.Id)
    End Sub

    Public Sub RemoveCharacter(character As ICharacter) Implements ILocation.RemoveCharacter
        LocationData.Characters.Remove(character.Id)
    End Sub
End Class
