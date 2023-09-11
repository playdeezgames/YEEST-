Module Program
    Sub Main(args As String())
        Dim host As IHost = New Host(AddressOf AnsiConsole.MarkupLine, AddressOf AnsiConsole.Ask)
        host.Run()
    End Sub
End Module
