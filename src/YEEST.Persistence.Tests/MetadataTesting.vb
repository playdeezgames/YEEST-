Friend Module MetadataTesting
    Friend Sub DoSetMetadataTest(Of THolder As IHolder)(MetadataKey As String, MetadataValue As String, subject As THolder, Optional validator As Action(Of THolder) = Nothing)
        subject.SetMetadata(MetadataKey, MetadataValue)
        If validator IsNot Nothing Then
            validator(subject)
        End If
    End Sub
End Module
