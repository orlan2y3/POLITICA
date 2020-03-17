Imports System.Data.OleDb
Public Class Reporte_Provincias
    Dim ds As DataSet = New DataSet

    Sub LlenaProvincias()
        Try

            cmbIdProvincia.Items.Clear()
            cmbProvincia.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT id_provincia, nombre_provincia FROM provincias"
            Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
            dr = cmb.ExecuteReader()

            While dr.Read()
                cmbIdProvincia.Items.Add(dr("id_provincia"))
                cmbProvincia.Items.Add(dr("nombre_provincia"))
            End While
            dr.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Reporte_Provincias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LlenaProvincias()
    End Sub

    Private Sub btimprimir_Click(sender As Object, e As EventArgs) Handles btimprimir.Click
        If cmbProvincia.Text = "" Then
            MsgBox("Debe seleccionar la provincia", vbInformation)
            Return
        End If

        Dim Reporte As New Reportes
        Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
        Rpt.Load(Application.StartupPath & "\Rpt_Sector.rpt")
        Rpt.RecordSelectionFormula = "{afiliados.id_provincia} =" & cmbIdProvincia.Text
        Reporte.Crv_Reportes.ReportSource = Rpt

        Reporte.Crv_Reportes.RefreshReport()
        Reporte.Show()
    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Close()
    End Sub

    Private Sub cmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedValueChanged
        cmbIdProvincia.SelectedIndex = cmbProvincia.SelectedIndex
    End Sub
End Class