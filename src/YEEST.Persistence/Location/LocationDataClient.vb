Imports YEEST.Data

Friend Class LocationDataClient
    Inherits WorldDataClient
    Protected ReadOnly LocationId As Integer
    Protected Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, Function() data.Locations([locationId]).Metadatas)
        Me.LocationId = locationId
    End Sub
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(LocationId)
        End Get
    End Property
End Class
