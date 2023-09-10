Imports Shouldly
Imports Xunit

Public MustInherit Class InstancedHolderShould(Of THolder As IInstancedHolder)
    Inherits HolderShould(Of THolder)
    <Fact>
    Sub retrieve_world_when_calling_World_property()
        Dim data As New Data.WorldData
        Dim subject = CreateSubject(data)

        Dim actual = subject.World

        actual.ShouldNotBeNull
    End Sub
End Class
