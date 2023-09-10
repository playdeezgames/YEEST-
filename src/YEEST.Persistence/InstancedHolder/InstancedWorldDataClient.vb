Imports YEEST.Data

Friend MustInherit Class InstancedWorldDataClient
    Inherits WorldDataClient
    Implements IInstancedHolder

    Protected Sub New(data As WorldData, id As Integer)
        MyBase.New(data)
        Me.Id = id
    End Sub

    Public ReadOnly Property Id As Integer Implements IInstancedHolder.Id
End Class
