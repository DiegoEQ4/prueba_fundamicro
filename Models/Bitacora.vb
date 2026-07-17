Imports System.ComponentModel.DataAnnotations
Imports System.ComponentModel.DataAnnotations.Schema

<Table("bitacora")>
Public Class Bitacora
    <Key>
    <DatabaseGenerated(DatabaseGeneratedOption.Identity)>
    Public Property id As Integer

    Public Property action As String

    Public Property cliente_id As Integer

    Public Property fecha_hora As DateTime

    Public Property usuario As String

End Class
