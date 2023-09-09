Imports Shouldly
Imports YEEST.Data

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
    Friend Sub DoGetMetadataTest(Of THolder As IHolder)(instantiator As Func(Of Data.WorldData, THolder))
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject As IHolder = instantiator(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        Dim actual As String = subject.GetMetadata(MetadataKey)

        actual.ShouldBe(MetadataValue)
    End Sub
    Friend Sub DoGetMetadataNotFoundTest(Of THolder As IHolder)(instantiator As Func(Of Data.WorldData, THolder))
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject = instantiator(data)

        Dim action = Sub() subject.GetMetadata(MetadataKey)

        Should.Throw(Of KeyNotFoundException)(action)
    End Sub
    Friend Sub DoHasMetadataNotFoundTest(Of THolder As IHolder)(instantiator As Func(Of Data.WorldData, THolder))
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject = instantiator(data)

        Dim actual = subject.HasMetadata(MetadataKey)

        actual.ShouldBeFalse
    End Sub
    Friend Sub DoHasMetadataTest(Of THolder As IHolder)(instantiator As Func(Of Data.WorldData, THolder))
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject = instantiator(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        Dim actual = subject.HasMetadata(MetadataKey)

        actual.ShouldBeTrue
    End Sub
    Friend Sub DoRemoveMetadataTest(Of THolder As IHolder)(
                                                          instantiator As Func(Of Data.WorldData, THolder),
                                                          Optional validator As Action(Of String, String, Data.WorldData, THolder) = Nothing)
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject = instantiator(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        subject.RemoveMetadata(MetadataKey)

        subject.HasMetadata(MetadataKey).ShouldBeFalse
        If validator IsNot Nothing Then
            validator(MetadataKey, MetadataValue, data, subject)
        End If
    End Sub
End Module
