'//---------------------------------------------------------------------------------*/
'// This code has been written as a sample to demonstrate how the password digest   */
'// can be calculated, to populate the WS-security header of the SAPI SOAP service. */
'// The security header for the SAPI service needs to provide,                      */
'//  Username as - <wsse:Username> YOURUSENAME</wsse:Username>                      */
'// where YOURUSENAME Is the username provided by RMG               */
'//  Password as - <wsse:Password Type = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest" > PasswordDigest</wsse:Password> */
'// where PASSWORDDIGEST Is calculated as shown in the code below    */
'//  Nonce as - <wsse:Nonce EncodingType = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary" > ENCODEDNONCE</wsse:Nonce>   */
'// where ENCODEDNONCE Is shown in the code below
'// Creation date - <wsu:Created> CREATIONDATE</wsu:Created>                         */
'// where CREATIONDATE Is shown in the code below                   */
'//
'// To Use code below, one must a) Change the password to your password             */
'//                                                                                */
'//                                                                                */
'//                                                                                */
'//       Author:    RMG, Lee Butler(Whl)                                          */
'//       Version:    1.0                                                          */
'//       Date:      08/10/2014                                                    */
'//                                                                                */
'//                                                                                */
'//      11/08/2016 - Modified to a function which spits out a digest from param.  */
'//                   And translated to VB for the rest of the project.            */
'//--------------------------------------------------------------------------------*/



Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Security.Cryptography
Imports System.Text
Imports System.Threading.Tasks

Namespace PasswordDigest


    Public Module DigestGenerator

        Public Class DigestData
            Public Nonce As String
            Public Created As String
            Public Username As String
            Public Password As String
            Public EncodedNonce As String
        End Class


        Public Function GetSHA1(input) As Byte()
            Return SHA1Managed.Create().ComputeHash(Encoding.Default.GetBytes(input))
        End Function

        Public Function GetDigest(Sha1Pass As String, Username As String) As DigestData
            '// The value below should be changed to your password.  If you store the password  */
            '// as hashed in your database, you will need to change the code below to remove hashing */
            'Private Const String PASSWORD_STRING = @"DummyPassword*";
            Dim response As New DigestData
            response.Username = Username
            response.Created = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
            response.Nonce = (New Random().Next(0, Int32.MaxValue)).ToString()

            Dim digestInput As String = String.Concat(response.Nonce, response.Created, Sha1Pass)

            Dim TempDigest As Byte() = GetSHA1(digestInput)

            response.Password = Convert.ToBase64String(TempDigest)
            response.EncodedNonce = Convert.ToBase64String(Encoding.Default.GetBytes(response.Nonce))

            Return response
        End Function

    End Module
End Namespace
