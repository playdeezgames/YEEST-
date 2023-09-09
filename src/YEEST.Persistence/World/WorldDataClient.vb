Imports YEEST.Data

Public Class WorldDataClient
    Inherits HolderClient
    Protected ReadOnly WorldData As WorldData
    Protected Sub New(data As WorldData)
        Me.WorldData = data
    End Sub
    Protected Overrides ReadOnly Property MetadataSource As Dictionary(Of String, String)
        Get
            Return WorldData.Metadatas
        End Get
    End Property

    Protected Overrides ReadOnly Property FlagSource As HashSet(Of String)
        Get
            Return WorldData.Flags
        End Get
    End Property
End Class
