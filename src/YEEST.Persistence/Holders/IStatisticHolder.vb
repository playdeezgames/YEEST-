Public Interface IStatisticHolder
    Sub SetStatistic(statisticName As String, statisticValue As Integer)
    Function GetStatistic(statisticName As String, Optional defaultValue As Integer = 0) As Integer
    Function HasStatistic(statisticName As String) As Boolean
    Sub RemoveStatistic(statisticName As String)
End Interface
