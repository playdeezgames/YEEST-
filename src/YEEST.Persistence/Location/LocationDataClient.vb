Imports YEEST.Data

Friend Class LocationDataClient
    Inherits InstancedWorldDataClient
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
    Protected Overrides ReadOnly Property FlagSource As HashSet(Of String)
        Get
            Return LocationData.Flags
        End Get
    End Property
    Protected Overrides ReadOnly Property StatisticSource As Dictionary(Of String, Integer)
        Get
            Return LocationData.Statistics
        End Get
    End Property
End Class
