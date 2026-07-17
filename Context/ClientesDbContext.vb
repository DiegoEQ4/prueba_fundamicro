Imports System.Data.Entity

Public Class ClientesDbContext
    Inherits DbContext
    Sub New()
        MyBase.New("name=DatabaseConnection")
    End Sub

    'TABLAS
    Public Property Clientes As DbSet(Of Clientes)
    Public Property Bitacora As DbSet(Of Bitacora)

    Public Property Usuarios As DbSet(Of Usuarios)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
    End Sub

End Class
