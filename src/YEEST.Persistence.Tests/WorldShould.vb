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

        subject.SerializedData.ShouldBe("{""Locations"":[]}")
    End Sub
    <Fact>
    Sub create_location()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Dim actual = subject.CreateLocation()

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
        subject.SerializedData.ShouldBe("{""Locations"":[{}]}")
    End Sub
End Class

