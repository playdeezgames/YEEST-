Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class WorldShould
    <Fact>
    Sub be_instantiable()
        Dim subject As IWorld = World.Create(New WorldData)

        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub serialize()
        Dim subject As IWorld = World.Create(New WorldData)

        subject.SerializedData.ShouldBe("{""Locations"":[],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub create_location()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Dim actual = subject.CreateLocation()

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
        subject.SerializedData.ShouldBe("{""Locations"":[{}],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub store_metadata()
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
    Sub retrieve_metadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        subject.SetMetadata(MetadataKey, MetadataValue)
        Dim actual = subject.GetMetadata(MetadataKey)

        actual.ShouldBe(MetadataValue)
    End Sub
    <Fact>
    Sub throw_exception_when_metadata_key_not_found()
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Should.Throw(Of KeyNotFoundException)(
            Sub()
                subject.GetMetadata(MetadataKey)
            End Sub)
    End Sub
End Class

