Imports YEEST.Data

Friend MustInherit Class InstancedWorldDataClient
    Inherits WorldDataClient
    Implements IInstancedHolder

    Protected Sub New(data As WorldData, id As Integer)
        MyBase.New(data)
        Me.Id = id
    End Sub

    Public ReadOnly Property Id As Integer Implements IInstancedHolder.Id

    Public ReadOnly Property World As IWorld Implements IInstancedHolder.World
        Get
            Throw New NotImplementedException()
        End Get
    End Property
End Class
