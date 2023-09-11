Imports Xunit
Imports Shouldly

Namespace YEEST.Presentation.Tests
    Public Class HostShould
        <Theory>
        <InlineData(2, "quit", "yes")>
        <InlineData(4, "quit", "no", "quit", "yes")>
        Sub run(outputCount As Integer, ParamArray commands() As String)
            Dim output As New List(Of String)
            Dim input As New Queue(Of String)
            For Each cmd In commands
                input.Enqueue(cmd)
            Next
            Dim subject As IHost = New Host(AddressOf output.Add, Function(p, d) input.Dequeue)

            Dim action = Sub() subject.Run()

            Should.NotThrow(action)
            output.Count.ShouldBe(outputCount)
            input.ShouldBeEmpty
        End Sub
    End Class
End Namespace

