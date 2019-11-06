Imports System.Data.OleDb

Public Class Mant_Nucleos
    Sub ActualizaCoordinadores()
        cmbCoord.Items.Clear()

        Dim dr As OleDbDataReader
        Dim query As String = "SELECT DISTINCT(nucleo) FROM afiliados ORDER BY nucleo ASC"

        Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
        dr = cmb.ExecuteReader()

        While dr.Read()
            cmbCoord.Items.Add(dr("nucleo"))
        End While
        dr.Close()

    End Sub

    Private Sub FrmMantCoordinadores_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        nucleo = True
        ActualizaCoordinadores()
    End Sub

    Private Sub btnCambiar_Click(sender As Object, e As EventArgs) Handles btnCambiar.Click
        If cmbCoord.Text = "" Then
            MsgBox("Debe seleccionar el nucleo", vbInformation)
            cmbCoord.Focus()
            Return
        End If

        If Len(Trim(txtNuevo.Text)) = 0 Then
            MsgBox("Debe digitar el nombre del nucleo", vbInformation)
            cmbCoord.Focus()
            Return
        End If

        Dim R As Long = 0

        Dim query As String = "UPDATE AFILIADOS SET nucleo ='" & Trim(txtNuevo.Text) & "' WHERE nucleo ='" & cmbCoord.Text & "'"

        Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
        R = cmb.ExecuteNonQuery()
        If R > 0 Then
            MsgBox("nucleo actualizado", vbInformation)
            ActualizaCoordinadores()
            txtNuevo.Text = ""

            Return
        Else
            MsgBox("No fue posible actualizar ese nucleo", vbCritical)
            Return
        End If

    End Sub

    Private Sub Mant_Nucleos_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        nucleo = False
    End Sub
End Class