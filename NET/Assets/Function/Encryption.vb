
Imports System.Security.Cryptography

Public Class EncryptionHelper
    Private Shared ReadOnly Key256 As Byte() = GenerateRandomKey(32)
    Private Shared ReadOnly IVLength As Integer = 16 ' AES block size

    ' Generate a random key of the specified length
    Private Shared Function GenerateRandomKey(length As Integer) As Byte()
        Using rng As New RNGCryptoServiceProvider()
            Dim key As Byte() = New Byte(length - 1) {}
            rng.GetBytes(key)
            Return key
        End Using
    End Function

    ' Generate a random string to append to the plaintext
    Private Shared Function GenerateRandomString(length As Integer) As String
        Dim chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim stringChars As Char() = New Char(length - 1) {}
        Dim random As New Random()

        For i As Integer = 0 To stringChars.Length - 1
            stringChars(i) = chars(random.Next(chars.Length))
        Next

        Return New String(stringChars)
    End Function

    Public Shared Function EncryptString(plainText As String) As String
        Try
            ' Append additional random data to the plaintext
            Dim randomData As String = GenerateRandomString(100) ' Increased length to 100 characters
            plainText &= randomData

            Using aes As Aes = aes.Create()
                aes.Key = Key256
                aes.GenerateIV() ' Generate a new random IV for each encryption
                Dim iv As Byte() = aes.IV
                Dim encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, iv)

                Using ms As New System.IO.MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                        Using sw As New System.IO.StreamWriter(cs)
                            sw.Write(plainText)
                        End Using
                    End Using

                    Dim encryptedBytes As Byte() = ms.ToArray()
                    Dim combinedBytes As Byte() = New Byte(iv.Length + encryptedBytes.Length - 1) {}
                    Array.Copy(iv, 0, combinedBytes, 0, iv.Length)
                    Array.Copy(encryptedBytes, 0, combinedBytes, iv.Length, encryptedBytes.Length)
                    Return ToUrlSafeBase64String(combinedBytes)
                End Using
            End Using
        Catch ex As Exception
            ' Handle or log the exception as needed
            Return Nothing
        End Try
    End Function

    Public Shared Function DecryptString(encryptedText As String) As String
        Try
            Dim combinedBytes As Byte() = FromUrlSafeBase64String(encryptedText)
            Using aes As Aes = aes.Create()
                aes.Key = Key256
                Dim iv As Byte() = New Byte(IVLength - 1) {}
                Dim cipherBytes As Byte() = New Byte(combinedBytes.Length - iv.Length - 1) {}
                Array.Copy(combinedBytes, iv, iv.Length)
                Array.Copy(combinedBytes, iv.Length, cipherBytes, 0, cipherBytes.Length)
                aes.IV = iv
                Dim decryptor As ICryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV)

                Using ms As New System.IO.MemoryStream(cipherBytes)
                    Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                        Using sr As New System.IO.StreamReader(cs)
                            ' Strip the random data after decryption
                            Dim result As String = sr.ReadToEnd()
                            Return result.Substring(0, result.Length - 100) ' Adjust to match the random data length
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Handle or log the exception as needed
            Return Nothing
        End Try
    End Function

    Private Shared Function ToUrlSafeBase64String(bytes As Byte()) As String
        Dim base64 = Convert.ToBase64String(bytes)
        Return base64.Replace("+", "-").Replace("/", "_").Replace("=", "")
    End Function

    Private Shared Function FromUrlSafeBase64String(base64 As String) As Byte()
        Dim paddedBase64 = base64.Replace("-", "+").Replace("_", "/")
        Select Case paddedBase64.Length Mod 4
            Case 2
                paddedBase64 &= "=="
            Case 3
                paddedBase64 &= "="
        End Select
        Return Convert.FromBase64String(paddedBase64)
    End Function
End Class
