Imports System.Security.Cryptography.X509Certificates
Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public Class LocationShould
    <Fact>
    Sub have_a_location_id()
        Dim w = World.Create(New Data.WorldData)

        Dim subject = w.CreateLocation()

        subject.ShouldNotBeNull
        subject.Id.ShouldBe(0)
    End Sub
    <Fact>
    Sub store_metadata_when_calling_SetMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim w As IWorld = World.Create(data)
        Dim subject = w.CreateLocation

        subject.SetMetadata(MetadataKey, MetadataValue)

        data.Locations(0).Metadatas.ShouldContainKeyAndValue(MetadataKey, MetadataValue)
    End Sub
End Class
