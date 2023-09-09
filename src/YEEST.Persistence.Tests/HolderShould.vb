Imports Xunit

Public MustInherit Class HolderShould(Of THolder As IHolder)
    Protected MustOverride Function CreateSubject(data As Data.WorldData) As THolder
    Protected MustOverride Sub ValidateSetMetadata(key As String, value As String, data As Data.WorldData, subject As THolder)
    Protected MustOverride Sub ValidateRemoveMetadata(key As String, value As String, data As Data.WorldData, subject As THolder)
    <Fact>
    Public Sub retrieve_metadata_when_calling_GetMetadata()
        DoGetMetadataTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Public Sub throw_exception_when_metadata_key_not_found_when_calling_GetMetadata()
        DoGetMetadataNotFoundTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Public Sub return_false_when_metadata_key_not_found_when_calling_HasMetadata()
        DoHasMetadataNotFoundTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Public Sub return_true_when_metadata_key_id_found_when_calling_HasMetadata()
        DoHasMetadataTest(AddressOf CreateSubject)
    End Sub
    <Fact>
    Public Sub store_metadata_when_calling_SetMetadata()
        DoSetMetadataTest(AddressOf CreateSubject,
                          AddressOf ValidateSetMetadata)
    End Sub
    <Fact>
    Public Sub remove_metadata_after_adding_it_when_calling_RemoveMetadata()
        DoRemoveMetadataTest(AddressOf CreateSubject,
                             AddressOf ValidateRemoveMetadata)
    End Sub
End Class
