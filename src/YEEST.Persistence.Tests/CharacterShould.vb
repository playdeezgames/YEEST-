Public Class CharacterShould
    Inherits HolderShould(Of ICharacter)

    Protected Overrides Sub ValidateSetMetadata(key As String, value As String, data As Data.WorldData, subject As ICharacter)
        'do nothing
    End Sub

    Protected Overrides Sub ValidateRemoveMetadata(key As String, value As String, data As Data.WorldData, subject As ICharacter)
        'do nothing
    End Sub

    Protected Overrides Function CreateSubject(data As Data.WorldData) As ICharacter
        Return World.Create(data).CreateCharacter()
    End Function
End Class
