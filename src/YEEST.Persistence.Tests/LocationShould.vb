Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class LocationShould
    Inherits HolderShould(Of ILocation)
    <Fact>
    Sub have_a_location_id()
        Dim w = World.Create(New Data.WorldData)

        Dim subject = w.CreateLocation()

        subject.ShouldNotBeNull
        subject.Id.ShouldBe(0)
    End Sub

    Protected Overrides Sub ValidateSetMetadata(key As String, value As String, data As WorldData, subject As ILocation)
        'do nothing
    End Sub

    Protected Overrides Sub ValidateRemoveMetadata(key As String, value As String, data As WorldData, subject As ILocation)
        'do nothing
    End Sub

    Protected Overrides Sub ValidateSetFlag(name As String, value As Boolean, data As WorldData, subject As ILocation)
        If value Then
            data.Locations(0).Flags.ShouldContain(name)
        Else
            data.Locations(0).Flags.ShouldNotContain(name)
        End If
    End Sub

    Protected Overrides Function CreateSubject(data As WorldData) As ILocation
        Return World.Create(data).CreateLocation
    End Function
End Class
