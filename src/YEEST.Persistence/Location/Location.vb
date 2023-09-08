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
End Class
