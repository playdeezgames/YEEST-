Public Interface IWorldModel
    ReadOnly Property Exists As Boolean
    Sub Start()
    Sub Abandon()
    Function Serialize() As String
End Interface
