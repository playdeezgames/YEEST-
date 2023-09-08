Imports YEEST.Data

Public MustInherit Class WorldDataClient
    Implements IMetadataHolder
    Protected ReadOnly WorldData As WorldData
    Protected MustOverride ReadOnly Property MetadataSource As Dictionary(Of String, String)
    Protected Sub New(data As WorldData)
        Me.WorldData = data
    End Sub

    Public Sub SetMetadata(key As String, value As String) Implements IMetadataHolder.SetMetadata
        MetadataSource(key) = value
    End Sub

    Public Sub RemoveMetadata(key As String) Implements IMetadataHolder.RemoveMetadata
        MetadataSource.Remove(key)
    End Sub

    Public Function GetMetadata(key As String) As String Implements IMetadataHolder.GetMetadata
        Return MetadataSource(key)
    End Function

    Public Function HasMetadata(key As String) As Boolean Implements IMetadataHolder.HasMetadata
        Return MetadataSource.ContainsKey(key)
    End Function
End Class
