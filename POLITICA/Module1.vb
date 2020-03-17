Imports System.Data.OleDb
Module Module1
    Public objReader As OleDbDataReader
    Public objCmd As OleDbCommand
    Public importar As Boolean = False
    Public nucleo As Boolean = False
    Public coordinador As Boolean = False
    Public RA As Long

    Function Efecha(Fecha As String) As String
        Dim Resul As String

        Resul = Mid(Fecha, 7, 4) & "/" & Mid(Fecha, 4, 2) & "/" & Mid(Fecha, 1, 2)
        Return Resul
    End Function
    Function Lfecha(Fecha As String) As String
        Dim Resul As String

        Resul = Mid(Fecha, 9, 2) & "/" & Mid(Fecha, 6, 2) & "/" & Mid(Fecha, 1, 4)
        Return Resul
    End Function

    Function Cambiar(Valor As String) As String
        Dim Cadena As String
        Cadena = Replace(Valor, "'", "´", 1)
        Return Cadena
    End Function

End Module
