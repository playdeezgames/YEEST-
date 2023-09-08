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

    Public Shared Function Create(data As WorldData) As IWorld
        Return New World(data)
    End Function

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Return New Location()
    End Function
End Class
