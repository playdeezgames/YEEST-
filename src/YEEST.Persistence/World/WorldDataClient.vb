Imports YEEST.Data

Public Class WorldDataClient
    Protected ReadOnly WorldData As WorldData
    Protected Sub New(data As WorldData, metadataSource As Func(Of Dictionary(Of String, String)))
        Me.WorldData = data
    End Sub
End Class
