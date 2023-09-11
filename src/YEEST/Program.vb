Imports System.Net

Module Program
    Sub Main(args As String())
        Dim host As IHost = New Host(AddressOf Console.WriteLine, AddressOf Console.ReadLine)
        host.Run()
    End Sub
End Module
