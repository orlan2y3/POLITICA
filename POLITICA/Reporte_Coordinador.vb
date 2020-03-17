Imports System.Data.OleDb
Public Class Reporte_Coordinador
    Dim ds As DataSet = New DataSet
    Private Sub Reporte_Coordinador_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT DISTINCT coordinador FROM afiliados"
            Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
            dr = cmb.ExecuteReader()

            cmb_coordinadores.Items.Clear()

            While dr.Read()
                'If Len(Trim(dr("coordinador").ToString)) > 0 Then
                cmb_coordinadores.Items.Add(dr("coordinador").ToString)
                'End If
            End While
            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        Dim Reporte As New Reportes
        Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Rpt.Load(Application.StartupPath & "\Rpt_Coordinadores.rpt")
        Rpt.RecordSelectionFormula = "{afiliados.coordinador} ='" & cmb_coordinadores.Text & "'"
        Reporte.Crv_Reportes.ReportSource = Rpt


        Reporte.Crv_Reportes.RefreshReport()
        Reporte.Show()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Close()
    End Sub
End Class