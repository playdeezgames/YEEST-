Imports YEEST.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, locationId)
    End Sub

    Public ReadOnly Property LocationType As String Implements ILocation.LocationType
        Get
            Return Nothing
        End Get
    End Property
End Class
