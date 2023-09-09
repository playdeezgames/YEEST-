Friend Module MetadataTesting
    Friend Sub DoSetMetadataTest(Of THolder As IHolder)(
                                                       instantiator As Func(Of Data.WorldData, THolder),
                                                       Optional validator As Action(Of String, String, Data.WorldData, THolder) = Nothing)
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New Data.WorldData
        Dim subject = instantiator(Data)
        subject.SetMetadata(MetadataKey, MetadataValue)
        If validator IsNot Nothing Then
            validator(MetadataKey, MetadataValue, data, subject)
        End If
    End Sub
End Module
