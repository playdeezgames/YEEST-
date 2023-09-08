Imports YEEST.Data

Friend Class Location
    Implements ILocation
    Private ReadOnly data As WorldData
    Private ReadOnly locationId As Integer
    Sub New(data As WorldData, locationId As Integer)
        Me.data = data
        Me.locationId = locationId
    End Sub

    Public ReadOnly Property Id As Integer Implements ILocation.Id
        Get
            Return locationId
        End Get
    End Property
End Class
