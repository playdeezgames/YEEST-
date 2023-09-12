Public Class WorldModelShould
    <Fact>
    Sub be_instantiable()
        Dim subject As IWorldModel

        subject = New WorldModel

        subject.ShouldNotBeNull
        subject.Exists.ShouldBeFalse
    End Sub
    <Fact>
    Sub be_startable()
        Dim subject As IWorldModel = New WorldModel

        subject.Start()

        subject.Exists.ShouldBeTrue
    End Sub
    <Fact>
    Sub be_abandonable()
        Dim subject As IWorldModel = New WorldModel
        subject.Start()

        subject.Abandon()

        subject.Exists.ShouldBeFalse
    End Sub
    <Fact>
    Sub be_serializable()
        Dim subject As IWorldModel = New WorldModel
        subject.Start()

        Dim actual = subject.Serialize()

        actual.ShouldBe("{""Locations"":[],""Characters"":[],""Metadatas"":{},""Flags"":[],""Statistics"":{}}")
    End Sub
    <Fact>
    Sub be_deserializeable()
        Dim subject As IWorldModel = New WorldModel
        subject.Start()

        subject.Deserialize("{""Locations"":[],""Characters"":[],""Metadatas"":{},""Flags"":[],""Statistics"":{}}")

        subject.Exists.ShouldBeTrue
    End Sub
    <Fact>
    Sub have_avatar_model()
        Dim subject As IWorldModel = New WorldModel
        subject.Start()

        Dim actual = subject.Avatar

        actual.ShouldNotBeNull
    End Sub
End Class


