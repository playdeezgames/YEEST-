Imports YEEST.Data

Public Class CharacterDataClient
    Inherits WorldDataClient
    Protected ReadOnly CharacterId As Integer
    Protected Sub New(data As WorldData, characterId As Integer)
        MyBase.New(data)
        Me.CharacterId = characterId
    End Sub
    Protected ReadOnly Property CharacterData As CharacterData
        Get
            Return WorldData.Characters(CharacterId)
        End Get
    End Property

    Protected Overrides ReadOnly Property MetadataSource As Dictionary(Of String, String)
        Get
            Return CharacterData.Metadatas
        End Get
    End Property
End Class
