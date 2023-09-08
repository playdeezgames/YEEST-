Imports YEEST.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Private ReadOnly locationId As Integer
    Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data)
        Me.locationId = locationId
    End Sub

    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return locationId
        End Get
    End Property

    Public Sub SetMetadata(key As String, value As String) Implements ILocation.SetMetadata
        LocationData.Metadatas(key) = value
    End Sub

    Private ReadOnly Property LocationData As LocationData
        Get
            Return data.Locations(locationId)
        End Get
    End Property

    Public Function GetMetadata(key As String) As String Implements ILocation.GetMetadata
        Return LocationData.Metadatas(key)
    End Function
End Class
