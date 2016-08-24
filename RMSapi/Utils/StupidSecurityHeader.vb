'###################################################################################
'##    StupidSecurityHeader.vb                              RoyalMailSAPIv2NET    ##
'##                           © 2016 White Hinge Ltd                              ##
'##                                                                               ##
'##   ==== Authored By (Enter your name here if you contributed) ==============   ##
'##       Lee Butler (WHL),  Colin McAloon (WHL)                                  ##
'##                                                                               ##
'###################################################################################

Imports Microsoft.VisualBasic
Imports System.ServiceModel.Dispatcher
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.Xml
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher.ClientRuntime
Imports System
Imports System.IdentityModel.Selectors.SecurityTokenSerializer
Imports System.ServiceModel.Security
Imports System.IdentityModel.Tokens
Imports System.Security.Cryptography


Public Class CustomCredentials
    Inherits ClientCredentials
    Public Sub New()
    End Sub

    Protected Sub New(cc As CustomCredentials)
        MyBase.New(cc)
    End Sub
    Dim _dg As PasswordDigest.DigestData
    Public Sub New(DGs As PasswordDigest.DigestData)
        _dg = DGs
    End Sub

    Public Overrides Function CreateSecurityTokenManager() As System.IdentityModel.Selectors.SecurityTokenManager
        Return New CustomSecurityTokenManager(Me, _dg)
    End Function

    Protected Overrides Function CloneCore() As ClientCredentials
        Return New CustomCredentials(Me)
    End Function
End Class

Public Class CustomSecurityTokenManager
    Inherits ClientCredentialsSecurityTokenManager
    Dim _dg As PasswordDigest.DigestData
    Public Sub New(cred As CustomCredentials, DGs As PasswordDigest.DigestData)
        MyBase.New(cred)
        _dg = DGs
    End Sub

    Public Overrides Function CreateSecurityTokenSerializer(version As System.IdentityModel.Selectors.SecurityTokenVersion) As System.IdentityModel.Selectors.SecurityTokenSerializer
        Return New CustomTokenSerializer(System.ServiceModel.Security.SecurityVersion.WSSecurity11, _dg)
    End Function
End Class

Public Class CustomTokenSerializer
    Inherits WSSecurityTokenSerializer
    Dim _dg As PasswordDigest.DigestData
    Public Sub New(sv As SecurityVersion, DGs As PasswordDigest.DigestData)
        MyBase.New(sv)
        _dg = DGs
    End Sub

    'Protected Overrides Sub WriteKeyIdentifierClauseCore(writer As XmlWriter, keyIdentifierClause As SecurityKeyIdentifierClause)
    '    MyBase.WriteKeyIdentifierClauseCore(writer, keyIdentifierClause)

    '    writer.WriteRaw("TestClause")

    'End Sub

    Protected Overrides Sub WriteTokenCore(writer As System.Xml.XmlWriter, token As System.IdentityModel.Tokens.SecurityToken)

        'Here's a header that is formatted right,
        Dim header As String = "<wsse:UsernameToken><wsse:Username>" + _dg.Username + "</wsse:Username><wsse:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">" + _dg.Password + "</wsse:Password><wsse:Nonce EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">" + _dg.EncodedNonce + "</wsse:Nonce><wsu:Created>" + _dg.Created + "</wsu:Created></wsse:UsernameToken>"

        writer.WriteRaw(header)


    End Sub

End Class