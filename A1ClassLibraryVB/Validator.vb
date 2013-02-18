Imports System.Text.RegularExpressions

Public Class Validator

    Dim userNameExpression As New System.Text.RegularExpressions.Regex("[^a-zA-z0-9]+")
    Dim emailFormatExpression1 As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]+@myseneca.ca)$")
    Dim emailFormatExpression2 As New System.Text.RegularExpressions.Regex("^([0-9a-zA-Z]([.]{0,1}[0-9a-zA-Z])*@senecacollege.on.ca)$")
    Dim phoneExpression
    Dim addressExpression

    Public Function validateUserName(ByVal value As String) As Boolean
        Return Not userNameExpression.IsMatch(value)
    End Function

    Public Function validateEmail(ByVal value As String) As Boolean
        Return emailFormatExpression1.IsMatch(value) Or emailFormatExpression2.IsMatch(value)
    End Function

    Public Function validatePhone(ByVal value As String) As Boolean
        Return True
    End Function

    Public Function validateAddress(ByVal value As String) As Boolean
        Return True
    End Function

End Class

