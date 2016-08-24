'###################################################################################
'##    ShipmentClasses.vb                                   RoyalMailSAPIv2NET    ##
'##                           © 2016 White Hinge Ltd                              ##
'##                                                                               ##
'##   ==== Authored By (Enter your name here if you contributed) ==============   ##
'##       Lee Butler (WHL),  Colin McAloon (WHL)                                  ##
'##                                                                               ##
'###################################################################################

'See here for "Inspiration": http://stackoverflow.com/questions/11509053/adding-http-headers-to-a-service-reference-service-method

Imports System.ServiceModel
Imports System.ServiceModel.Channels
Imports System.ServiceModel.Description
Imports System.ServiceModel.Dispatcher



Public Class HttpHeaderMessageInspector
    Implements IClientMessageInspector
    Private ReadOnly _httpHeaders As Dictionary(Of String, String)

    Public Sub New(httpHeaders As Dictionary(Of String, String))
        Me._httpHeaders = httpHeaders
    End Sub


    Public Sub AfterReceiveReply(ByRef reply As Message, correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
    End Sub

    Public Function BeforeSendRequest(ByRef request As Message, channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
        Dim httpRequestMessage As HttpRequestMessageProperty
        Dim httpRequestMessageObject As Object

        If request.Properties.TryGetValue(HttpRequestMessageProperty.Name, httpRequestMessageObject) Then
            httpRequestMessage = TryCast(httpRequestMessageObject, HttpRequestMessageProperty)

            For Each httpHeader As KeyValuePair(Of String, String) In _httpHeaders
                httpRequestMessage.Headers(httpHeader.Key) = httpHeader.Value
            Next
        Else
            httpRequestMessage = New HttpRequestMessageProperty()

            For Each httpHeader As KeyValuePair(Of String, String) In _httpHeaders
                httpRequestMessage.Headers.Add(httpHeader.Key, httpHeader.Value)
            Next
            request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage)
        End If
        Return Nothing
    End Function
End Class

Friend Class HttpHeadersEndpointBehavior
    Implements IEndpointBehavior
    Private ReadOnly _httpHeaders As Dictionary(Of String, String)

    Public Sub New(httpHeaders As Dictionary(Of String, String))
        Me._httpHeaders = httpHeaders
    End Sub
    Sub AddBindingParameters(endpoint As ServiceEndpoint, bindingParameters As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
    End Sub

    Public Sub ApplyClientBehavior(endpoint As ServiceEndpoint, clientRuntime As ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
        Dim inspector = New HttpHeaderMessageInspector(Me._httpHeaders)

        clientRuntime.MessageInspectors.Add(inspector)
    End Sub

    Public Sub ApplyDispatchBehavior(endpoint As ServiceEndpoint, endpointDispatcher As EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
    End Sub
    Public Sub Validate(endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
    End Sub
End Class

