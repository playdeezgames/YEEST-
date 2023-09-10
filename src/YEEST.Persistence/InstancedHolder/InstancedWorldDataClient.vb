Imports YEEST.Data

Friend MustInherit Class InstancedWorldDataClient
    Inherits WorldDataClient
    Implements IInstancedHolder

    Friend Const IsRecycledFlag As String = "IsRecycled"

    Protected Sub New(data As WorldData, id As Integer)
        MyBase.New(data)
        Me.Id = id
    End Sub

    Public ReadOnly Property Id As Integer Implements IInstancedHolder.Id

    Public ReadOnly Property World As IWorld Implements IInstancedHolder.World
        Get
            Return Persistence.World.Create(WorldData)
        End Get
    End Property

    Public Overridable Sub Recycle() Implements IInstancedHolder.Recycle
        SetFlag(IsRecycledFlag, True)
    End Sub
End Class
