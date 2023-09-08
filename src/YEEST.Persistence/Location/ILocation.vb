Public Interface ILocation
    ReadOnly Property Id As Integer
    Sub SetMetadata(key As String, value As String)
    Function GetMetadata(key As String) As String
    Function HasMetadata(key As String) As Boolean
End Interface
