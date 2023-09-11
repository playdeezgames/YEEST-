Module Program
    Sub Main(args As String())
        Console.Title = "YEEST!!"
        Dim host As IHost = New Host(AddressOf AnsiConsole.MarkupLine, AddressOf AnsiConsole.Ask)
        host.Run()
    End Sub
End Module
