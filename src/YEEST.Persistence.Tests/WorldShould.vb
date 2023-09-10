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
    End Sub
    <Fact>
    Sub serialize_when_calling_SerializedData()
        Dim subject As IWorld = World.Create(New WorldData)

        Dim actual = subject.SerializedData

        actual.ShouldBe("{""Locations"":[],""Characters"":[],""Metadatas"":{},""Flags"":[],""Statistics"":{}}")
    End Sub
    <Fact>
    Sub create_location_when_calling_CreateLocation()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)
        Const locationType = "location-type"

        Dim actual = subject.CreateLocation(locationType)

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
        subject.SerializedData.ShouldBe("{""Locations"":[{""Characters"":[],""Metadatas"":{""LocationType"":""location-type""},""Flags"":[],""Statistics"":{}}],""Characters"":[],""Metadatas"":{},""Flags"":[],""Statistics"":{}}")
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
        subject.SerializedData.ShouldBe("{""Locations"":[],""Characters"":[{""Metadatas"":{""CharacterType"":""character-type""},""Flags"":[],""Statistics"":{}}],""Metadatas"":{},""Flags"":[],""Statistics"":{}}")
    End Sub
    Protected Overrides Sub ValidateSetMetadata(key As String, value As String, data As WorldData, subject As IWorld)
        subject.SerializedData.ShouldContain(key)
        subject.SerializedData.ShouldContain(value)
        data.Metadatas.ShouldHaveSingleItem
        data.Metadatas.ShouldContainKeyAndValue(key, value)
    End Sub

    Protected Overrides Sub ValidateRemoveMetadata(key As String, value As String, data As WorldData, subject As IWorld)
        subject.SerializedData.ShouldNotContain(key)
        subject.SerializedData.ShouldNotContain(value)
    End Sub

    Protected Overrides Sub ValidateSetFlag(name As String, value As Boolean, data As WorldData, subject As IWorld)
        If value Then
            data.Flags.ShouldContain(name)
            subject.SerializedData.ShouldContain(name)
        Else
            data.Flags.ShouldNotContain(name)
            subject.SerializedData.ShouldNotContain(name)
        End If
    End Sub

    Protected Overrides Sub ValidateSetStatistic(statisticName As String, statisticValue As Integer, data As WorldData, subject As IWorld)
        data.Statistics(statisticName).ShouldBe(statisticValue)
        subject.SerializedData.ShouldContain(statisticName)
        subject.SerializedData.ShouldContain(statisticValue.ToString())
    End Sub

    Protected Overrides Function CreateSubject(data As WorldData) As IWorld
        Return World.Create(data)
    End Function
End Class

