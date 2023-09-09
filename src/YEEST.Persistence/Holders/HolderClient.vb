Public MustInherit Class HolderClient
    Implements IHolder
    Protected MustOverride ReadOnly Property MetadataSource As Dictionary(Of String, String)
    Protected MustOverride ReadOnly Property FlagSource As HashSet(Of String)

    Public Sub SetMetadata(key As String, value As String) Implements IMetadataHolder.SetMetadata
        MetadataSource(key) = value
    End Sub

    Public Sub RemoveMetadata(key As String) Implements IMetadataHolder.RemoveMetadata
        MetadataSource.Remove(key)
    End Sub

    Public Sub SetFlag(flagName As String, flagState As Boolean) Implements IFlagHolder.SetFlag
        If flagState Then
            FlagSource.Add(flagName)
        Else
            FlagSource.Remove(flagName)
        End If
    End Sub

    Public Function GetMetadata(key As String) As String Implements IMetadataHolder.GetMetadata
        Return MetadataSource(key)
    End Function

    Public Function HasMetadata(key As String) As Boolean Implements IMetadataHolder.HasMetadata
        Return MetadataSource.ContainsKey(key)
    End Function
End Class
