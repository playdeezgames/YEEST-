Public Class ModelShould
    <Fact>
    Sub be_instantiable()
        Dim subject As IWorldModel

        subject = New WorldModel

        subject.ShouldNotBeNull
        subject.Exists.ShouldBeFalse
    End Sub
End Class


