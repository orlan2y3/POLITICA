Imports System.Data.OleDb
Public Class FrmMantCoordinadores
    Sub ActualizaCoordinadores()
        cmbCoord.Items.Clear()

        Dim dr As OleDbDataReader
        Dim query As String = "SELECT DISTINCT(coordinador) FROM afiliados ORDER BY COORDINADOR ASC"

        Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
        dr = cmb.ExecuteReader()

        While dr.Read()
            cmbCoord.Items.Add(dr("coordinador"))
        End While
        dr.Close()

    End Sub

    Private Sub FrmMantCoordinadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        coordinador = True
        ActualizaCoordinadores()
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        If cmbCoord.Text = "" Then
            MsgBox("Debe seleccionar el coordinador", vbInformation)
            cmbCoord.Focus()
            Return
        End If

        If Len(Trim(txtNuevo.Text)) = 0 Then
            MsgBox("Debe digitar el nombre del coordinador", vbInformation)
            cmbCoord.Focus()
            Return
        End If

        Dim R As Long = 0

        Dim query As String = "UPDATE AFILIADOS SET COORDINADOR ='" & Trim(txtNuevo.Text) & "' WHERE COORDINADOR ='" & cmbCoord.Text & "'"

        Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
        R = cmb.ExecuteNonQuery()
        If R > 0 Then
            MsgBox("Coordinador actualizado", vbInformation)
            ActualizaCoordinadores()
            txtNuevo.Text = ""

            Return
        Else
            MsgBox("No fue posible actualizar ese coordinador", vbCritical)
            Return
        End If

    End Sub

    Private Sub FrmMantCoordinadores_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        coordinador = False
    End Sub
End Class