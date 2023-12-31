Imports System.ComponentModel.DataAnnotations
Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class WorldShould
    Inherits HolderShould(Of IWorld)
    <Fact>
    Sub be_instantiable_when_calling_World__Create()
        Dim data As New WorldData

        Dim subject As IWorld = World.Create(data)

        subject.ShouldNotBeNull
        subject.Avatar.ShouldBeNull
    End Sub
    <Fact>
    Sub create_location_when_calling_CreateLocation()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)
        Const locationType = "location-type"

        Dim actual = subject.CreateLocation(locationType)

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
    End Sub
    <Fact>
    Sub use_recycled_locations_when_available()
        Const oldLocationType = "old-location-type"
        Const metadataKey = "metadata-key"
        Const metadataValue = "metadata-value"
        Const statisticKey = "statistic-key"
        Const statisticValue = 69
        Const flagName = "flag-name"
        Const newLocationType = "new-location-type"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)
        Dim oldLocation = subject.CreateLocation(oldLocationType)
        oldLocation.SetMetadata(metadataKey, metadataValue)
        oldLocation.SetStatistic(statisticKey, statisticValue)
        oldLocation.SetFlag(flagName, True)
        oldLocation.Recycle()

        Dim actual = subject.CreateLocation(newLocationType)

        data.Locations.ShouldHaveSingleItem
        actual.LocationType.ShouldBe(newLocationType)
        actual.HasStatistic(statisticKey).ShouldBeFalse
        actual.HasMetadata(metadataKey).ShouldBeFalse
        actual.GetFlag(flagName).ShouldBeFalse
        actual.GetFlag("IsRecycled").ShouldBeFalse
        actual.Id.ShouldBe(0)
    End Sub
    <Fact>
    Sub use_recycled_characters_when_available()
        Const oldCharacterType = "old-character-type"
        Const metadataKey = "metadata-key"
        Const metadataValue = "metadata-value"
        Const statisticKey = "statistic-key"
        Const statisticValue = 69
        Const flagName = "flag-name"
        Const newCharacterType = "new-location-type"
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)
        Dim oldLocation = subject.CreateCharacter(oldCharacterType)
        oldLocation.SetMetadata(metadataKey, metadataValue)
        oldLocation.SetStatistic(statisticKey, statisticValue)
        oldLocation.SetFlag(flagName, True)
        oldLocation.Recycle()

        Dim actual = subject.CreateCharacter(newCharacterType)

        data.Characters.ShouldHaveSingleItem
        actual.CharacterType.ShouldBe(newCharacterType)
        actual.HasStatistic(statisticKey).ShouldBeFalse
        actual.HasMetadata(metadataKey).ShouldBeFalse
        actual.GetFlag(flagName).ShouldBeFalse
        actual.GetFlag("IsRecycled").ShouldBeFalse
        actual.Id.ShouldBe(0)
    End Sub
    <Fact>
    Sub create_character_when_calling_CreateCharacter()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)
        Const characterType = "character-type"

        Dim actual As ICharacter = subject.CreateCharacter(characterType)

        actual.ShouldNotBeNull()
        actual.CharacterType.ShouldBe("character-type")
        data.Characters.ShouldHaveSingleItem()
    End Sub
    <Fact>
    Public Sub assign_an_avatar()
        Dim subject = CreateSubject(New WorldData)
        Dim character = subject.CreateCharacter("character-type")

        subject.Avatar = character

        subject.Avatar.ShouldNotBeNull
        subject.Avatar.Id.ShouldBe(character.Id)
    End Sub
    <Fact>
    Public Sub remove_avatar()
        Dim subject = CreateSubject(New WorldData)
        subject.Avatar = subject.CreateCharacter("character-type")

        subject.Avatar = Nothing

        subject.Avatar.ShouldBeNull
    End Sub
    Protected Overrides Sub ValidateSetMetadata(key As String, value As String, data As WorldData, subject As IWorld)
        data.Metadatas.ShouldHaveSingleItem
        data.Metadatas.ShouldContainKeyAndValue(key, value)
    End Sub

    Protected Overrides Sub ValidateRemoveMetadata(key As String, value As String, data As WorldData, subject As IWorld)
        data.Metadatas.ShouldBeEmpty
    End Sub

    Protected Overrides Sub ValidateSetFlag(name As String, value As Boolean, data As WorldData, subject As IWorld)
        If value Then
            data.Flags.ShouldContain(name)
        Else
            data.Flags.ShouldNotContain(name)
        End If
    End Sub

    Protected Overrides Sub ValidateSetStatistic(statisticName As String, statisticValue As Integer, data As WorldData, subject As IWorld)
        data.Statistics(statisticName).ShouldBe(statisticValue)
    End Sub

    Protected Overrides Function CreateSubject(data As WorldData) As IWorld
        Return World.Create(data)
    End Function
End Class

