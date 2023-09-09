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

        actual.ShouldBe("{""Locations"":[],""Metadatas"":{}}")
    End Sub
    <Fact>
    Sub create_location_when_calling_CreateLocation()
        Dim data = New WorldData
        Dim subject As IWorld = World.Create(data)

        Dim actual = subject.CreateLocation()

        actual.ShouldNotBeNull()
        data.Locations.ShouldHaveSingleItem()
        subject.SerializedData.ShouldBe("{""Locations"":[{""Metadatas"":{}}],""Metadatas"":{}}")
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

    Protected Overrides Function CreateSubject(data As WorldData) As IWorld
        Return World.Create(data)
    End Function
End Class

