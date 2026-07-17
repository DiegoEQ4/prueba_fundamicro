Imports System.Security.Cryptography
Imports System.Text
Imports System.Linq

Public Module PasswordHelper

    Public Function HashPassword(password As String) As String
        If String.IsNullOrEmpty(password) Then Throw New ArgumentNullException(NameOf(password))

        Dim iterations As Integer = 10000
        Dim salt(15) As Byte
        Using rng = New RNGCryptoServiceProvider()
            rng.GetBytes(salt)
        End Using

        Using pbkdf2 = New Rfc2898DeriveBytes(password, salt, iterations)
            Dim hash = pbkdf2.GetBytes(32)
            Return iterations.ToString() & ":" & Convert.ToBase64String(salt) & ":" & Convert.ToBase64String(hash)
        End Using
    End Function

    Public Function VerifyPassword(stored As String, password As String) As Boolean
        If String.IsNullOrEmpty(stored) OrElse String.IsNullOrEmpty(password) Then Return False

        Dim parts = stored.Split(":"c)
        If parts.Length <> 3 Then Return False

        Dim iterations = Integer.Parse(parts(0))
        Dim salt = Convert.FromBase64String(parts(1))
        Dim storedHash = Convert.FromBase64String(parts(2))

        Using pbkdf2 = New Rfc2898DeriveBytes(password, salt, iterations)
            Dim hash = pbkdf2.GetBytes(storedHash.Length)
            Return hash.SequenceEqual(storedHash)
        End Using
    End Function

End Module
