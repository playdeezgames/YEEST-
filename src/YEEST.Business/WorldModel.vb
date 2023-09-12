Public Class WorldModel
    Implements IWorldModel
    Public ReadOnly Property Exists As Boolean Implements IWorldModel.Exists
        Get
            Return False
        End Get
    End Property
End Class
