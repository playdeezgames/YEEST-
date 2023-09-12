Imports System
Imports Xunit
Public Class ModelShould
    <Fact>
    Sub be_instantiable()
        Dim subject As IWorldModel

        subject = New WorldModel

        subject.ShouldNotBeNull
    End Sub
End Class


