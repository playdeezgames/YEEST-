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
End Class
