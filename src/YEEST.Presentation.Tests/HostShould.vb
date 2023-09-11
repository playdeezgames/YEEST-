Imports Xunit
Imports Shouldly

Namespace YEEST.Presentation.Tests
    Public Class HostShould
        <Fact>
        Sub run()
            Dim output As New List(Of String)
            Dim input As New Queue(Of String)
            input.Enqueue(String.Empty)
            Dim subject As IHost = New Host(AddressOf output.Add, AddressOf input.Dequeue)

            Dim action = Sub() subject.Run()

            Should.NotThrow(action)
            output.Count.ShouldBe(1)
            input.ShouldBeEmpty
        End Sub
    End Class
End Namespace

