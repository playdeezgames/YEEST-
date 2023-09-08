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

    Protected Overrides ReadOnly Property MetadataSource As Dictionary(Of String, String)
        Get
            Return WorldData.Metadatas
        End Get
    End Property

    Public Shared Function Create(data As WorldData) As IWorld
        Return New World(data)
    End Function

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData())
        Return New Location(WorldData, locationId)
    End Function
End Class
