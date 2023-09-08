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

    Public Sub SetMetadata(key As String, value As String) Implements IWorld.SetMetadata
        WorldData.Metadatas(key) = value
    End Sub

    Public Sub RemoveMetadata(key As String) Implements IWorld.RemoveMetadata
        WorldData.Metadatas.Remove(key)
    End Sub

    Public Shared Function Create(data As WorldData) As IWorld
        Return New World(data)
    End Function

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Dim locationId = WorldData.Locations.Count
        WorldData.Locations.Add(New LocationData())
        Return New Location(WorldData, locationId)
    End Function

    Public Function GetMetadata(metadataKey As String) As String Implements IWorld.GetMetadata
        Return WorldData.Metadatas(metadataKey)
    End Function

    Public Function HasMetadata(metadataKey As String) As Boolean Implements IWorld.HasMetadata
        Return WorldData.Metadatas.ContainsKey(metadataKey)
    End Function
End Class
