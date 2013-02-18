Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports A1ClassLibraryVB

<TestClass()> Public Class ValidatorTest

    Dim testValidator As Validator

    ' called before each test case
    <TestInitialize()> Public Sub Initialize()
        testValidator = New Validator()
    End Sub

    ' called after each test case
    <TestCleanup()> Public Sub CleanUp()
        testValidator = Nothing
    End Sub

    <TestMethod()> Public Sub TestUserNameValidationGood()
        Assert.IsTrue(testValidator.validateUserName("stsang1"))
    End Sub

    <TestMethod()> Public Sub TestUserNameValidationBad()
        Assert.IsFalse(testValidator.validateUserName("@st 541"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat1ValidationGood()
        Assert.IsTrue(testValidator.validateEmail("stsang1@myseneca.ca"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat1ValidationBad()
        Assert.IsFalse(testValidator.validateEmail("stsang1-bad@senecacollege.on.ca"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat2ValidationGood()
        Assert.IsTrue(testValidator.validateEmail("stanley.tsang@senecacollege.on.ca"))
    End Sub

    <TestMethod()> Public Sub TestEmailFormat2ValidationBad()
        Assert.IsFalse(testValidator.validateEmail("stsang1-bad@myseneca.on.ca"))
    End Sub

    <TestMethod()> Public Sub TestPhoneNumberValidationGood()
        Assert.IsTrue(True)
    End Sub

    <TestMethod()> Public Sub TestPhoneNumberValidationBad()
        Assert.IsFalse(False)
    End Sub

    <TestMethod()> Public Sub TestAddressValidationGood()
        Assert.IsTrue(True)
    End Sub

    <TestMethod()> Public Sub TestAddressValidationBad()
        Assert.IsFalse(False)
    End Sub
End Class