Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher
Imports System.Xml

'http://stackoverflow.com/questions/31595770/c-sharp-wcf-namespaces-move-to-header-use-ns-prefix/31597758 helped a lot with this. Also thanks Charlotte Fry. But for fucks sake is the XML standard really that hard to comply with?

''' <summary>
''' Custom implementation of System.ServiceModel.Channels.Message which 'fixes' SOAP envelopes for RMs bullshit implementation of XML. 
''' </summary>
Friend Class RMMessage
    Inherits Message

    Private message As Message
    Private _dg As PasswordDigest.DigestData
    Public Sub New(Message As Message, dg As PasswordDigest.DigestData)
        Me.message = Message
        _dg = dg
    End Sub

    Public Overrides ReadOnly Property Headers() As MessageHeaders
        Get
            Return message.Headers
        End Get
    End Property
    Public Overrides ReadOnly Property Properties() As MessageProperties
        Get
            Return message.Properties
        End Get
    End Property
    Public Overrides ReadOnly Property Version() As MessageVersion
        Get
            Return message.Version
        End Get
    End Property
    Protected Overrides Sub OnWriteStartBody(writer As XmlDictionaryWriter)
        writer.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/")
    End Sub
    Protected Overrides Sub OnWriteBodyContents(writer As XmlDictionaryWriter)
        message.WriteBodyContents(writer)
    End Sub
    Protected Overrides Sub OnWriteStartEnvelope(writer As XmlDictionaryWriter)
        writer.WriteStartElement("soapenv", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/")
        writer.WriteAttributeString("xmlns", "v2", Nothing, "http://www.royalmailgroup.com/api/ship/V2")
        writer.WriteAttributeString("xmlns", "v1", Nothing, "http://www.royalmailgroup.com/integration/core/V1")
        writer.WriteAttributeString("xmlns", "xsi", Nothing, "http://www.w3.org/2001/XMLSchema-instance")
        writer.WriteAttributeString("xmlns", "xsd", Nothing, "http://www.w3.org/2001/XMLSchema")
    End Sub
    Protected Overrides Sub OnWriteStartHeaders(writer As XmlDictionaryWriter)
        'writer.WriteStartElement("soapenv", "header", Nothing)

        ' Dim wsseNS As String = "wsse"
        ' Dim header As String = "<" + wsseNS + ":UsernameToken><" + wsseNS + ":Username>" + _dg.Username + "</" + wsseNS + ":Username><" + wsseNS + ":Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest"">" + _dg.Password + "</" + wsseNS + ":Password><" + wsseNS + ":Nonce EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary"">" + _dg.EncodedNonce + "</" + wsseNS + ":Nonce><wsu:Created>" + _dg.Created + "</wsu:Created></" + wsseNS + ":UsernameToken>"
        ' Dim normal As String = "<" + wsseNS + ":Security xmlns:" + wsseNS + "=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"" xmlns:wsu=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">" + header + "</" + wsseNS + ":Security>"

        'Do nothing?
        message.Headers.Clear()
        MyBase.OnWriteStartHeaders(writer)
        ' writer.WriteRaw(normal)

        ' writer.WriteEndElement()

        'writer.WriteEndElement()
    End Sub

End Class


'There's so must nasty hackiness here it's unreal.

Public Class RMMessageFormatter
    Implements IClientMessageFormatter
    Private _dg As PasswordDigest.DigestData
    Private formatter As IClientMessageFormatter

    Public Sub New(Formatter As IClientMessageFormatter, dg As PasswordDigest.DigestData)
        Me.formatter = Formatter
        _dg = dg
    End Sub
    Public Function DeserializeReply(message As Message, params As Object()) As Object Implements IClientMessageFormatter.DeserializeReply
        Return formatter.DeserializeReply(message, params)
    End Function
    Public Function SerializeRequest(Version As MessageVersion, Params As Object()) As Message Implements IClientMessageFormatter.SerializeRequest
        Dim msg As Message = Me.formatter.SerializeRequest(Version, Params)

        Return New RMMessage(msg, _dg)
    End Function

End Class

Friend Class RMEndpointBehaviour
    Implements IOperationBehavior
    Private _dg As PasswordDigest.DigestData
    Public Sub New(dg)
        'Nothing...
        _dg = dg
    End Sub

    Public Sub ApplyClientBehavior(operationDescription As OperationDescription, clientOperation As ClientOperation) Implements IOperationBehavior.ApplyClientBehavior
        Dim currentformatter As IClientMessageFormatter = clientOperation.Formatter
        clientOperation.Formatter = New RMMessageFormatter(currentformatter, _dg)

    End Sub

    Public Sub AddBindingParameters(operationDescription As OperationDescription, bindingParameters As BindingParameterCollection) Implements IOperationBehavior.AddBindingParameters
        'ew
    End Sub

    Public Sub ApplyDispatchBehavior(operationDescription As OperationDescription, dispatchOperation As DispatchOperation) Implements IOperationBehavior.ApplyDispatchBehavior
        'Ewww
    End Sub

    Public Sub Validate(operationDescription As OperationDescription) Implements IOperationBehavior.Validate
        'RIP "Validation"
    End Sub
End Class


