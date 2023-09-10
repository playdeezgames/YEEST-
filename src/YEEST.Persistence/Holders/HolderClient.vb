Public MustInherit Class HolderClient
    Implements IHolder
    Protected MustOverride ReadOnly Property MetadataSource As Dictionary(Of String, String)
    Protected MustOverride ReadOnly Property FlagSource As HashSet(Of String)
    Protected MustOverride ReadOnly Property StatisticSource As Dictionary(Of String, Integer)

    Public Sub SetMetadata(key As String, value As String) Implements IMetadataHolder.SetMetadata
        MetadataSource(key) = value
    End Sub

    Public Sub RemoveMetadata(key As String) Implements IMetadataHolder.RemoveMetadata
        MetadataSource.Remove(key)
    End Sub

    Public Sub SetFlag(flagName As String, flagState As Boolean) Implements IFlagHolder.SetFlag
        If flagState Then
            FlagSource.Add(flagName)
        Else
            FlagSource.Remove(flagName)
        End If
    End Sub

    Public Sub SetStatistic(statisticName As String, statisticValue As Integer) Implements IStatisticHolder.SetStatistic
        StatisticSource(statisticName) = statisticValue
    End Sub

    Public Function GetMetadata(key As String) As String Implements IMetadataHolder.GetMetadata
        Return MetadataSource(key)
    End Function

    Public Function HasMetadata(key As String) As Boolean Implements IMetadataHolder.HasMetadata
        Return MetadataSource.ContainsKey(key)
    End Function

    Public Function GetFlag(flagName As String) As Boolean Implements IFlagHolder.GetFlag
        Return FlagSource.Contains(flagName)
    End Function

    Public Function GetStatistic(statisticName As String, Optional defaultValue As Integer = 0) As Integer Implements IStatisticHolder.GetStatistic
        Return If(HasStatistic(statisticName), StatisticSource(statisticName), defaultValue)
    End Function

    Public Function HasStatistic(statisticName As String) As Boolean Implements IStatisticHolder.HasStatistic
        Return StatisticSource.ContainsKey(statisticName)
    End Function
End Class
