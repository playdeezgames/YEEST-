﻿Imports YEEST.Data

Friend Class LocationDataClient
    Inherits InstancedWorldDataClient
    Protected Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, locationId)
    End Sub

    Protected ReadOnly Property LocationData As LocationData
        Get
            Return WorldData.Locations(Id)
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
