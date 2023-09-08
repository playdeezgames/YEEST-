Imports YEEST.Data

Friend Class LocationDataClient
    Inherits WorldDataClient
    Protected ReadOnly locationId As Integer
    Protected Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data)
        Me.locationId = locationId
    End Sub
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(locationId)
        End Get
    End Property
End Class
