Public Class ModelShould
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
End Class


