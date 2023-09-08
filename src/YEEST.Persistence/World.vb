Public Class World
    Implements IWorld
    Private Sub New()

    End Sub

    Public ReadOnly Property SerializedData As String Implements IWorld.SerializedData
        Get
            Return "{}"
        End Get
    End Property

    Public Shared Function Create() As IWorld
        Return New World()
    End Function

    Public Function CreateLocation() As ILocation Implements IWorld.CreateLocation
        Return New Location()
    End Function
End Class
