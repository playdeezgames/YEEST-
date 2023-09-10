Imports YEEST.Data

Friend Class Location
    Inherits LocationDataClient
    Implements ILocation
    Sub New(data As WorldData, locationId As Integer)
        MyBase.New(data, locationId)
    End Sub
End Class
