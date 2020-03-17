Imports System.Data.OleDb
Public Class Entrada
    Private Sub btentrar_Click(sender As Object, e As EventArgs) Handles btentrar.Click
        Try

            If txtusuario.Text = "" Or txtcontraseña.Text = "" Then
                MsgBox("Debe Digitar Un Usuario Y/O Contraseña", MsgBoxStyle.Information)
                Return
            End If

            Conexion.DB.Conectar()

            Dim cmd As New OleDbCommand
            Dim Reader As OleDbDataReader
            cmd.CommandText = "SELECT nombre from usuarios where usuario = '" + txtusuario.Text + "' and contrasena = '" + txtcontraseña.Text + "'"
            cmd.CommandType = CommandType.Text
            cmd.Connection = Conexion.DB.Cnn
            Reader = cmd.ExecuteReader()

            If Reader.Read Then
                Dim Formulario As New Formulario
                Formulario.Show()
                Me.Close()
            Else
                Conexion.DB.Desconectar()
                MsgBox("Acceso Negado ** Nombre de Usuario y/o Contraseña Incorrectos **", MsgBoxStyle.Critical)
                txtusuario.Focus()
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Conexion.DB.Desconectar()
        End
    End Sub
    Private Sub txtusuario_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtusuario.KeyPress, txtcontraseña.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub
    Private Sub FrmEntrada_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtusuario.Focus()
    End Sub
End Class
