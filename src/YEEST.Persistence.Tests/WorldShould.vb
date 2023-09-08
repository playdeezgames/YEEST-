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
End Class

