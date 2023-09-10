Imports YEEST.Data

Friend MustInherit Class InstancedWorldDataClient
    Inherits WorldDataClient
    Implements IInstancedHolder

    Protected Sub New(data As WorldData)
        MyBase.New(data)
    End Sub

    Public MustOverride ReadOnly Property Id As Integer Implements IInstancedHolder.Id
End Class
