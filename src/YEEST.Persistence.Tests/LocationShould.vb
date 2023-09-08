Imports Shouldly
Imports Xunit

Public Class LocationShould
    <Fact>
    Sub have_a_location_id()
        Dim w = World.Create(New Data.WorldData)

        Dim subject = w.CreateLocation()

        subject.ShouldNotBeNull
        subject.Id.ShouldBe(0)
    End Sub
End Class
