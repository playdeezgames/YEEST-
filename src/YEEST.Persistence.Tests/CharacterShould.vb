Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class CharacterShould
    Inherits InstancedHolderShould(Of ICharacter)

    Protected Overrides Sub ValidateSetMetadata(key As String, value As String, data As Data.WorldData, subject As ICharacter)
        'do nothing
    End Sub

    Protected Overrides Sub ValidateRemoveMetadata(key As String, value As String, data As Data.WorldData, subject As ICharacter)
        'do nothing
    End Sub

    Protected Overrides Sub ValidateSetFlag(name As String, value As Boolean, data As WorldData, subject As ICharacter)
        If value Then
            data.Characters(0).Flags.ShouldContain(name)
        Else
            data.Characters(0).Flags.ShouldNotContain(name)
        End If
    End Sub

    Protected Overrides Sub ValidateSetStatistic(statisticName As String, statisticValue As Integer, data As WorldData, subject As ICharacter)
        data.Characters(0).Statistics(statisticName).ShouldBe(statisticValue)
    End Sub

    Protected Overrides Function CreateSubject(data As Data.WorldData) As ICharacter
        Return World.Create(data).CreateCharacter("character-type")
    End Function
    <Fact>
    Sub have_a_character_id()
        Dim subject = CreateSubject(New Data.WorldData)

        Dim actual = subject.Id

        actual.ShouldBe(0)
    End Sub
    <Fact>
    Sub have_initial_location_of_nothing()
        Dim subject = CreateSubject(New Data.WorldData)

        Dim actual = subject.Location

        actual.ShouldBeNull
    End Sub
    <Fact>
    Sub set_location_with_location_property()
        Dim subject = CreateSubject(New Data.WorldData)
        Dim location = subject.World.CreateLocation("location-type")

        subject.Location = location

        subject.Location.ShouldNotBeNull
    End Sub
    <Fact>
    Sub clear_location_with_location_property()
        Dim subject = CreateSubject(New Data.WorldData)
        Dim location = subject.World.CreateLocation("location-type")
        subject.Location = location

        subject.Location = Nothing

        subject.Location.ShouldBeNull
    End Sub
End Class
