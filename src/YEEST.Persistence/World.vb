Imports System.Text.Json
Imports YEEST.Data

Public Class World
    Implements IWorld
    Private ReadOnly data As WorldData
    Private Sub New(data As WorldData)
        Me.data = data
    End Sub

    Public ReadOnly Property SerializedData As String Implements IWorld.SerializedData
        Get
            Return JsonSerializer.Serialize(data)
        End Get
    End Property

    Public Sub SetMetadata(key As String, value As String) Implements IWorld.SetMetadata
        data.Metadatas(key) = value
    End Sub

    Public Shared Function Create(data As WorldData) As IWorld
        Return New World(data)
    End Function

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Dim locationId = data.Locations.Count
        data.Locations.Add(New LocationData())
        Return New Location(data, locationId)
    End Function
End Class
