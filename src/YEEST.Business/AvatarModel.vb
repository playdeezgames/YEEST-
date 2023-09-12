Friend Class AvatarModel
    Implements IAvatarModel

    Private world As IWorld

    Public Sub New(world As IWorld)
        Me.world = world
    End Sub

    Public ReadOnly Property Name As String Implements IAvatarModel.Name
        Get
            Return "Tagon"
        End Get
    End Property
End Class
