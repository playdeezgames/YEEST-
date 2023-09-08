Imports YEEST.Data

Friend Class LocationDataClient
    Inherits WorldDataClient
    Protected ReadOnly LocationId As Integer
    Protected Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data)
        Me.LocationId = locationId
    End Sub
    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(LocationId)
        End Get
    End Property

    Protected Overrides ReadOnly Property MetadataSource As Dictionary(Of String, String)
        Get
            Return LocationData.Metadatas
        End Get
    End Property
End Class
