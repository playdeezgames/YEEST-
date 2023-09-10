Public Interface IStatisticHolder
    Sub SetStatistic(statisticName As String, statisticValue As Integer)
    Function GetStatistic(statisticName As String, Optional defaultValue As Integer = 0) As Integer
    'HasStatistic
    'RemoveStatistic
End Interface
