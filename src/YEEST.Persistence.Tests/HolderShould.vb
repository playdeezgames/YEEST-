Imports Shouldly
Imports Xunit
Imports YEEST.Data

Public MustInherit Class HolderShould(Of THolder As IHolder)
    Protected MustOverride Function CreateSubject(data As Data.WorldData) As THolder
    Protected MustOverride Sub ValidateSetMetadata(key As String, value As String, data As Data.WorldData, subject As THolder)
    Protected MustOverride Sub ValidateRemoveMetadata(key As String, value As String, data As Data.WorldData, subject As THolder)
    Protected MustOverride Sub ValidateSetFlag(name As String, value As Boolean, data As WorldData, subject As THolder)
    Protected MustOverride Sub ValidateSetStatistic(statisticName As String, statisticValue As Integer, data As WorldData, subject As THolder)
    <Fact>
    Public Sub retrieve_metadata_when_calling_GetMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject As IHolder = CreateSubject(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        Dim actual As String = subject.GetMetadata(MetadataKey)

        actual.ShouldBe(MetadataValue)
    End Sub
    <Fact>
    Public Sub throw_exception_when_metadata_key_not_found_when_calling_GetMetadata()
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject = CreateSubject(data)

        Dim action = Sub() subject.GetMetadata(MetadataKey)

        Should.Throw(Of KeyNotFoundException)(action)
    End Sub
    <Fact>
    Public Sub return_false_when_metadata_key_not_found_when_calling_HasMetadata()
        Const MetadataKey = "key"
        Dim data = New WorldData
        Dim subject = CreateSubject(data)

        Dim actual = subject.HasMetadata(MetadataKey)

        actual.ShouldBeFalse
    End Sub
    <Fact>
    Public Sub return_true_when_metadata_key_id_found_when_calling_HasMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject = CreateSubject(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        Dim actual = subject.HasMetadata(MetadataKey)

        actual.ShouldBeTrue
    End Sub
    <Fact>
    Public Sub store_metadata_when_calling_SetMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New Data.WorldData
        Dim subject = CreateSubject(data)
        subject.SetMetadata(MetadataKey, MetadataValue)
        ValidateSetMetadata(MetadataKey, MetadataValue, data, subject)
    End Sub
    <Fact>
    Public Sub remove_metadata_after_adding_it_when_calling_RemoveMetadata()
        Const MetadataKey = "key"
        Const MetadataValue = "value"
        Dim data = New WorldData
        Dim subject = CreateSubject(data)
        subject.SetMetadata(MetadataKey, MetadataValue)

        subject.RemoveMetadata(MetadataKey)

        subject.HasMetadata(MetadataKey).ShouldBeFalse
        ValidateRemoveMetadata(MetadataKey, MetadataValue, data, subject)
    End Sub
    <Theory>
    <InlineData("flag-name", True)>
    <InlineData("flag-name", False)>
    Public Sub set_flag_when_calling_SetFlag(flagName As String, flagValue As Boolean)
        Dim data = New WorldData
        Dim subject = CreateSubject(data)

        subject.SetFlag(flagName, flagValue)

        ValidateSetFlag(flagName, flagValue, data, subject)
    End Sub

    <Theory>
    <InlineData("flag-name", True)>
    <InlineData("flag-name", False)>
    Public Sub get_flag_when_calling_GetFlag(flagName As String, flagValue As Boolean)
        Dim data = New WorldData
        Dim subject = CreateSubject(data)
        subject.SetFlag(flagName, flagValue)

        Dim actual As Boolean = subject.GetFlag(flagName)

        actual.shouldbe(flagValue)
    End Sub
    <Fact>
    Public Sub set_statistic_when_calling_SetStatistic()
        Const StatisticName = "statistic-name"
        Const StatisticValue = 69
        Dim data = New WorldData
        Dim subject = CreateSubject(data)

        subject.SetStatistic(StatisticName, StatisticValue)

        ValidateSetStatistic(StatisticName, StatisticValue, data, subject)
    End Sub
    <Fact>
    Public Sub get_default_value_when_calling_GetStatistic()
        Const StatisticName = "statistic-name"
        Const DefaultValue = 999
        Dim data = New WorldData
        Dim subject = CreateSubject(data)

        Dim actual = subject.GetStatistic(StatisticName, DefaultValue)

        actual.ShouldBe(DefaultValue)
    End Sub
    <Fact>
    Public Sub get_stored_value_when_calling_GetStatistic()
        Const StatisticName = "statistic-name"
        Const StatisticValue = 69
        Const DefaultValue = 999
        Dim data = New WorldData
        Dim subject = CreateSubject(data)
        subject.SetStatistic(StatisticName, StatisticValue)

        Dim actual = subject.GetStatistic(StatisticName, DefaultValue)

        actual.ShouldBe(StatisticValue)
    End Sub
    <Fact>
    Public Sub determine_absent_statistic_not_present_when_calling_HasStatistic()
        Const StatisticName = "statistic-name"
        Dim data = New WorldData
        Dim subject = CreateSubject(data)

        Dim actual = subject.HasStatistic(StatisticName)

        actual.ShouldBeFalse
    End Sub
    <Fact>
    Public Sub determine_present_statistic_is_present_when_calling_HasStatistic()
        Const StatisticName = "statistic-name"
        Const StatisticValue = 69
        Dim data = New WorldData
        Dim subject = CreateSubject(data)
        subject.SetStatistic(StatisticName, StatisticValue)

        Dim actual = subject.HasStatistic(StatisticName)

        actual.ShouldBeTrue
    End Sub
End Class
