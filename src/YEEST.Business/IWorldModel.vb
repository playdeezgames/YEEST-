Public Interface IWorldModel
    ReadOnly Property Exists As Boolean
    Sub Start()
    Sub Abandon()
    Sub Deserialize(serialized As String)
    Function Serialize() As String
End Interface
