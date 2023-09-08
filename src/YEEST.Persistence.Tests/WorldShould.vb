Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class WorldShould
    <Fact>
    Sub be_instantiable_when_calling_World__Create()
        Dim subject As IWorld = World.Create(New WorldData)

        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub serialize_when_calling_SerializedData()
        Dim subject As IWorld = World.Create(New WorldData)

        subject.SerializedData.ShouldBe("{""Locations"":[],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub create_location_when_calling_CreateLocation()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Dim actual = subject.CreateLocation()

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
        subject.SerializedData.ShouldBe("{""Locations"":[{}],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub store_metadata_when_calling_SetMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        subject.SetMetadata(MetadataKey, MetadataValue)

        data.Metadatas.ShouldHaveSingleItem
        data.Metadatas.ShouldContainKeyAndValue(MetadataKey, MetadataValue)
        subject.SerializedData.ShouldContain(MetadataKey)
        subject.SerializedData.ShouldContain(MetadataValue)
    End Sub
    <Fact>
    Sub retrieve_metadata_when_calling_GetMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        subject.SetMetadata(MetadataKey, MetadataValue)
        Dim actual = subject.GetMetadata(MetadataKey)

        actual.ShouldBe(MetadataValue)
    End Sub
    <Fact>
    Sub throw_exception_when_metadata_key_not_found_when_calling_GetMetadata()
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Should.Throw(Of KeyNotFoundException)(
            Sub()
                subject.GetMetadata(MetadataKey)
            End Sub)
    End Sub
    <Fact>
    Sub return_false_when_metadata_key_not_found_when_calling_HasMetadata()
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        subject.HasMetadata(MetadataKey).ShouldBeFalse
    End Sub
End Class

