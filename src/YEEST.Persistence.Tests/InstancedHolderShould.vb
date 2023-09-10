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
    <Fact>
    Sub set_IsRecycled_flag_when_calling_Recycle()
        Dim data As New Data.WorldData
        Dim subject = CreateSubject(data)

        subject.Recycle()

        subject.GetFlag("IsRecycled").ShouldBeTrue
    End Sub
End Class
