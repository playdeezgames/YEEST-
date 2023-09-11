Imports Xunit
Imports Shouldly

Namespace YEEST.Presentation.Tests
    Public Class HostShould
        <Fact>
        Sub run()
            Dim subject As IHost = New Host()

            Dim action = Sub() subject.Run()

            Should.NotThrow(action)
        End Sub
    End Class
End Namespace

