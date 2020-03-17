Imports System.Data.OleDb
Public Class Conexion
    Public CadenaConnection As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & Application.StartupPath & "\politico.mdb" _
    & ";Jet OLEDB:Database Password='';"

    Public Cnn As OleDbConnection = New OleDbConnection(CadenaConnection)
    Public Shared DB As Conexion = New Conexion
    Sub Conectar()
        Cnn.Open()
    End Sub
    Sub Desconectar()
        Cnn.Close()
    End Sub
End Class
