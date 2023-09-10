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
            Return Array.Empty(Of ICharacter)
        End Get
    End Property
End Class
