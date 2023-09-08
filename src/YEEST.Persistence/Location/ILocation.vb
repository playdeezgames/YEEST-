Public Interface ILocation
    ReadOnly Property Id As Integer
    Sub SetMetadata(key As String, value As String)
    Function GetMetadata(key As String) As String
End Interface
