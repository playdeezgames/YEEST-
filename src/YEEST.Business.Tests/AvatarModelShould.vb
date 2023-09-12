Public Class AvatarModelShould
    <Fact>
    Sub have_name()
        Dim model As IWorldModel = New WorldModel()
        Dim subject As IAvatarModel = model.Avatar

        Dim actual = subject.Name

        actual.ShouldNotBeNull
    End Sub
End Class
