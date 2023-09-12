Imports System.Text.Json
Imports YEEST.Data

Public Class WorldModel
    Implements IWorldModel
    Private worldData As WorldData = Nothing
    Public ReadOnly Property Exists As Boolean Implements IWorldModel.Exists
        Get
            Return worldData IsNot Nothing
        End Get
    End Property

    Public ReadOnly Property Avatar As IAvatarModel Implements IWorldModel.Avatar
        Get
            Return New AvatarModel(World.Create(worldData))
        End Get
    End Property

    Public Sub Start() Implements IWorldModel.Start
        worldData = New WorldData
    End Sub
    Public Sub Abandon() Implements IWorldModel.Abandon
        worldData = Nothing
    End Sub

    Public Sub Deserialize(serialized As String) Implements IWorldModel.Deserialize
        worldData = JsonSerializer.Deserialize(Of WorldData)(serialized)
    End Sub

    Public Function Serialize() As String Implements IWorldModel.Serialize
        Return JsonSerializer.Serialize(worldData)
    End Function
End Class
