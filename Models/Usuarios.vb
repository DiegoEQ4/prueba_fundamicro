Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("usuarios")>
Public Class Usuarios
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property id As Integer

    Public Property nombre_completo As String

    Public Property username As String

    Public Property pass As String

End Class
