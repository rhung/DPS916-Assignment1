Imports A1ClassLibraryCS

Public Class AddressBook
    Implements IJSONSerializer

    Dim fileName As String
    Dim recordsList As New ArrayList()

    Public Event createSuccessEvent()
    Public Event updateSuccessEvent()
    Public Event deleteSuccessEvent()
    Public Event getSuccessEvent()

    Public ReadOnly Property Records() As ArrayList
        Get
            Return recordsList
        End Get
    End Property

    Public Sub createRecord(ByVal record As RecordA1)
        recordsList.Add(record)
        recordsList.Sort()
        RaiseEvent createSuccessEvent()
    End Sub

    Public Sub updateRecord(ByVal index As Integer, ByVal record As RecordA1)
        recordsList.Item(index) = record
        RaiseEvent updateSuccessEvent()
    End Sub

    Public Sub deleteRecord(ByVal index As Integer)
        recordsList.RemoveAt(index)
        RaiseEvent deleteSuccessEvent()
    End Sub

    Public Function getAllUserNames() As ArrayList
        Dim userNameList As New ArrayList
        For Each record As RecordA1 In recordsList
            userNameList.Add(record.UserName)
        Next
        Return userNameList
    End Function

    Public Function readFromJSON(ByVal file As String) As Boolean Implements IJSONSerializer.readFromJSON
        Dim result As Boolean = True
        ' Insert code here
        Return result
    End Function

    Public Function writeToJSON(file As String) As Boolean Implements IJSONSerializer.writeToJSON
        Dim result As Boolean = True
        ' Insert code here
        Return result
    End Function
End Class
