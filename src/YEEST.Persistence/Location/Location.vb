Imports YEEST.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, locationId)
    End Sub

    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return LocationId
        End Get
    End Property

    Public Sub SetMetadata(key As String, value As String) Implements ILocation.SetMetadata
        LocationData.Metadatas(key) = value
    End Sub

    Public Function GetMetadata(key As String) As String Implements ILocation.GetMetadata
        Return LocationData.Metadatas(key)
    End Function

    Public Function HasMetadata(key As String) As Boolean Implements ILocation.HasMetadata
        Return False
    End Function
End Class
