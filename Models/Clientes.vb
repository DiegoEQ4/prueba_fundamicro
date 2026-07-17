Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("clientes")>
Public Class Clientes
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property id As Integer

    <Required(ErrorMessage:="El nombre es obligatorio.")>
    Public Property nombre As String

    <Required(ErrorMessage:="El apellido es obligatorio.")>
    Public Property apellido As String

    <Required(ErrorMessage:="El email es obligatorio.")>
    <EmailAddress(ErrorMessage:="El formato del correo electrónico no es válido.")>
    Public Property email As String

    <Required(ErrorMessage:="La dirección es obligatoria.")>
    Public Property direccion As String

End Class
