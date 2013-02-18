Imports System.Text.RegularExpressions

Public Class Validator

    Dim userNameExpression
    Dim emailExpression
    Dim phoneExpression
    Dim addressExpression

    Public Function validateUserName(ByVal value As String) As Boolean
        Return True
    End Function

    Public Function validateEmail(ByVal value As String) As Boolean
        Return True
    End Function

    Public Function validatePhone(ByVal value As String) As Boolean
        Return True
    End Function

    Public Function validateAddress(ByVal value As String) As Boolean
        Return True
    End Function

End Class

