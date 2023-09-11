Module Program
    Sub Main(args As String())
        Dim host As IHost = New Host(AddressOf AnsiConsole.MarkupLine, Function()
                                                                           Return AnsiConsole.Ask(Of String)("[olive]Now What?[/]")
                                                                       End Function)
        host.Run()
    End Sub
End Module
