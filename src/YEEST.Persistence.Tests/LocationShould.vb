Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class LocationShould

    <Fact>
    Sub have_a_location_id()
        Dim w = World.Create(New Data.WorldData)

        Dim subject = w.CreateLocation()

        subject.ShouldNotBeNull
        subject.Id.ShouldBe(0)
    End Sub
    Private Shared Function CreateSubject(data As Data.WorldData) As ILocation
        Return World.Create(data).CreateLocation
    End Function
    <Fact>
    Sub store_metadata_when_calling_SetMetadata()
        DoSetMetadataTest(AddressOf CreateSubject,
            Sub(k, v, d, s)
                d.Locations(0).Metadatas.ShouldContainKeyAndValue(k, v)
            End Sub)
    End Sub
    <Fact>
    Sub retrieve_metadata_when_calling_GetMetadata()
        DoGetMetadataTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Sub throw_exception_when_metadata_key_not_found_when_calling_GetMetadata()
        DoGetMetadataNotFoundTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Sub return_false_when_metadata_key_not_found_when_calling_HasMetadata()
        DoHasMetadataNotFoundTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Sub return_true_when_metadata_key_id_found_when_calling_HasMetadata()
        Const MetadataKey = "key"
        Const MetadataValue As String = "value"
        Dim data = New WorldData
        Dim w As IWorld = World.Create(data)
        Dim subject = w.CreateLocation
        subject.SetMetadata(MetadataKey, MetadataValue)

        Dim actual As Boolean = subject.HasMetadata(MetadataKey)

        actual.ShouldBeTrue
    End Sub
    <Fact>
    Sub remove_metadata_after_adding_it_when_calling_RemoveMetadata()
        Const MetadataKey = "key"
        Const MetadataValue As String = "value"
        Dim data = New WorldData
        Dim w As IWorld = World.Create(data)
        Dim subject = w.CreateLocation
        subject.SetMetadata(MetadataKey, MetadataValue)

        subject.RemoveMetadata(MetadataKey)

        Dim actual As Boolean = subject.HasMetadata(MetadataKey)
        actual.ShouldBeFalse
    End Sub
End Class
