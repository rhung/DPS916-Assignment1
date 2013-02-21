' DPS916 - Visual Basic Course
' Coded By: Raymond Hung and Stanley Tsang
' Assignment 1
' AddressBook.vb
' Last Modified February 20 2013

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

End Class
