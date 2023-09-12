Imports YEEST.Data

Public Class WorldModel
    Implements IWorldModel
    Private worldData As WorldData = Nothing
    Public ReadOnly Property Exists As Boolean Implements IWorldModel.Exists
        Get
            Return worldData IsNot Nothing
        End Get
    End Property
    Public Sub Start() Implements IWorldModel.Start
        worldData = New WorldData
    End Sub
    Public Sub Abandon() Implements IWorldModel.Abandon
        worldData = Nothing
    End Sub
End Class
