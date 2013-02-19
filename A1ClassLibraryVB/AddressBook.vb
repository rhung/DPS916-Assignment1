Imports A1ClassLibraryCS
Imports Newtonsoft.Json
Imports System.Linq

Public Class AddressBook
    Implements IJSONSerializer

    Dim recordsList As New List(Of RecordA1)

    Public Event createSuccessEvent()
    Public Event updateSuccessEvent()
    Public Event deleteSuccessEvent()
    Public Event getSuccessEvent()

    Public ReadOnly Property Records() As List(Of RecordA1)
        Get
            Return recordsList
        End Get
    End Property

    Public Sub createRecord(ByVal record As RecordA1)
        recordsList.Add(record)
        recordsList = recordsList.OrderBy(Function(x) x.UserName).ToList()
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

    Public Function getAllUserNames() As List(Of String)
        Dim userNameList As New List(Of String)
        For Each record As RecordA1 In recordsList
            userNameList.Add(record.UserName)
        Next
        RaiseEvent getSuccessEvent()
        Return userNameList
    End Function

    Public Function readFromJSON(ByVal file As String) As Boolean Implements IJSONSerializer.readFromJSON
        Dim result As Boolean = True
        Using readFile As New IO.StreamReader(file)
            Try
                Dim jsonString As String = readFile.ReadToEnd
                Dim records As List(Of RecordA1) = JsonConvert.DeserializeObject(Of List(Of RecordA1))(jsonString)
                Me.recordsList = records
            Catch ex As Exception
                result = False
            End Try
        End Using
        Return result
    End Function

    Public Function writeToJSON(file As String) As Boolean Implements IJSONSerializer.writeToJSON
        Dim result As Boolean = True
        Using writeFile As New IO.StreamWriter(file)
            Try
                Dim jsonString = JsonConvert.SerializeObject(Me.recordsList, Formatting.Indented)
                writeFile.Write(jsonString)
            Catch ex As Exception
                result = False
            End Try
        End Using
        Return result
    End Function

    Private Shared Function CompareRecordsByUserName(ByVal record1 As RecordA1, ByVal record2 As RecordA1)
        If record1.UserName Is Nothing Then
            If record2.UserName Is Nothing Then
                ' If both user names nothing then equal
                Return 0
            Else
                ' If record1's userName is nothing and record2's userName not nothing, then record2 is greater
                Return -1
            End If

        Else
            ' If record2's userName is not nothing and record2's userName is nothing, then record1 is greater
            If record2.UserName Is Nothing Then
                Return 1
            Else
                ' If both are not nothing, compare them and return result
                Return record1.UserName.CompareTo(record2.UserName)
            End If
        End If
    End Function
End Class
