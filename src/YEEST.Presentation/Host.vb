Public Class Host
    Implements IHost
    Private ReadOnly outputter As Action(Of String)
    Private ReadOnly inputter As Func(Of String)
    Sub New(outputter As Action(Of String), inputter As Func(Of String))
        Me.outputter = If(outputter, AddressOf Console.WriteLine)
        Me.inputter = If(inputter, AddressOf Console.ReadLine)
    End Sub

    Public Sub Run() Implements IHost.Run
        outputter("YEEST!!")
        inputter()
    End Sub
End Class
