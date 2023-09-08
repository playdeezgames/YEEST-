Imports YEEST.Data

Public Class WorldDataClient
    Protected ReadOnly WorldData As WorldData
    Protected Sub New(data As WorldData)
        Me.WorldData = data
    End Sub
End Class
