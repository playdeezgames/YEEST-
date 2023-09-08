Imports Shouldly
Imports Xunit
Public Class WorldShould
    <Fact>
    Sub be_instantiable()
        Dim subject As IWorld = World.Create()

        subject.ShouldNotBeNull
    End Sub
    <Fact>
    Sub serialize()
        Dim subject As IWorld = World.Create()

        subject.SerializedData.ShouldBe("{}")
    End Sub
    <Fact>
    Sub create_location()
        Dim subject As IWorld = World.Create()

        Dim actual = subject.CreateLocation()

        actual.ShouldNotBeNull()
    End Sub
End Class

