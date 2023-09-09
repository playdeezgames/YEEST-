Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class WorldShould
    <Fact>
    Sub be_instantiable_when_calling_World__Create()
        Dim data As New WorldData

        Dim subject As IWorld = World.Create(data)

        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub serialize_when_calling_SerializedData()
        Dim subject As IWorld = World.Create(New WorldData)

        Dim actual = subject.SerializedData

        actual.ShouldBe("{""Locations"":[],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub create_location_when_calling_CreateLocation()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Dim actual = subject.CreateLocation()

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
        subject.SerializedData.ShouldBe("{""Locations"":[{""Metadatas"":{}}],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub store_metadata_when_calling_SetMetadata()
        DoSetMetadataTest(AddressOf World.Create,
                          Sub(k, v, d, s)
                              s.SerializedData.ShouldContain(k)
                              s.SerializedData.ShouldContain(v)
                              d.Metadatas.ShouldHaveSingleItem
                              d.Metadatas.ShouldContainKeyAndValue(k, v)
                          End Sub)
    End Sub
    <Fact>
    Sub retrieve_metadata_when_calling_GetMetadata()
        DoGetMetadataTest(AddressOf World.Create)
    End Sub
    <Fact>
    Sub throw_exception_when_metadata_key_not_found_when_calling_GetMetadata()
        DoGetMetadataNotFoundTest(AddressOf World.Create)
    End Sub
    <Fact>
    Sub return_false_when_metadata_key_not_found_when_calling_HasMetadata()
        DoHasMetadataNotFoundTest(AddressOf World.Create)
    End Sub
    <Fact>
    Sub return_true_when_metadata_key_id_found_when_calling_HasMetadata()
        DoHasMetadataTest(AddressOf World.Create)
    End Sub
    <Fact>
    Sub remove_metadata_after_adding_it_when_calling_RemoveMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        subject.RemoveMetadata(MetadataKey)

        subject.HasMetadata(MetadataKey).ShouldBeFalse
        subject.SerializedData.ShouldNotContain(MetadataKey)
        subject.SerializedData.ShouldNotContain(MetadataValue)
    End Sub
End Class

