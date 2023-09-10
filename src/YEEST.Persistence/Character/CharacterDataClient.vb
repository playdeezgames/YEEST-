Imports YEEST.Data

Friend Class CharacterDataClient
    Inherits InstancedWorldDataClient
    Protected Sub New(data As WorldData, characterId As Integer)
        MyBase.New(data, characterId)
    End Sub

    Protected ReadOnly Property CharacterData As CharacterData
        Get
            Return WorldData.Characters(Id)
        End Get
    End Property

    Protected Overrides ReadOnly Property MetadataSource As Dictionary(Of String, String)
        Get
            Return CharacterData.Metadatas
        End Get
    End Property
    Protected Overrides ReadOnly Property FlagSource As HashSet(Of String)
        Get
            Return CharacterData.Flags
        End Get
    End Property
    Protected Overrides ReadOnly Property StatisticSource As Dictionary(Of String, Integer)
        Get
            Return CharacterData.Statistics
        End Get
    End Property
End Class
