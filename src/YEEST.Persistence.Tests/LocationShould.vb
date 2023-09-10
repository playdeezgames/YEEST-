Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class LocationShould
    Inherits InstancedHolderShould(Of ILocation)
    <Fact>
    Sub have_a_location_id()
        Dim subject = CreateSubject(New Data.WorldData)

        Dim actual = subject.Id

        actual.ShouldBe(0)
    End Sub
    <Fact>
    Sub initially_have_location_type()
        Dim subject = CreateSubject(New Data.WorldData)

        Dim actual = subject.LocationType

        actual.ShouldBe("location-type")
    End Sub
    <Fact>
    Sub initially_have_no_characters()
        Dim subject = CreateSubject(New Data.WorldData)

        Dim actual = subject.Characters

        actual.ShouldBeEmpty
    End Sub
    <Fact>
    Sub add_a_character()
        Dim subject = CreateSubject(New Data.WorldData)
        Dim character = subject.World.CreateCharacter("character-type")

        subject.AddCharacter(character)

        subject.Characters.ShouldHaveSingleItem
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

    Protected Overrides Sub ValidateSetStatistic(statisticName As String, statisticValue As Integer, data As WorldData, subject As ILocation)
        data.Locations(0).Statistics(statisticName).ShouldBe(statisticValue)
    End Sub

    Protected Overrides Function CreateSubject(data As WorldData) As ILocation
        Const locationType = "location-type"
        Return World.Create(data).CreateLocation(locationType)
    End Function
End Class
