Public Class frmMantProvincias
    Dim StrSql As String

    Private Sub FormatGrid()
        DG.Rows.Clear()
        DG.ColumnCount = 2
        DG.Columns(0).HeaderText = "ID"
        DG.Columns(1).HeaderText = "NOMBRE PROVINCIAS"

        DG.Columns(0).Visible = False
        DG.Columns(1).Width = 350

        ' desactivar los estilos visuales del sistema
        DG.EnableHeadersVisualStyles = False
        DG.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable

        ' estilo para la cabecera del grid
        Dim styCabeceras As DataGridViewCellStyle = New DataGridViewCellStyle()
        styCabeceras.BackColor = Color.YellowGreen
        'styCabeceras.ForeColor = Color.MediumAquamarine
        'styCabeceras.Font = New Font("Comic Sans MS", 12, FontStyle.Italic Or FontStyle.Bold)

        ' asignar estilo al grid
        DG.ColumnHeadersDefaultCellStyle = styCabeceras

    End Sub

    Sub ActualizaGrid()
        Try
            DG.Rows.Clear()
            FormatGrid()

            StrSql = "SELECT * FROM PROVINCIAS"
            objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
            objReader = objCmd.ExecuteReader
            If objReader.HasRows Then
                While objReader.Read()
                    DG.Rows.Add(objReader("id_provincia"), objReader("nombre_provincia"))
                End While
                objReader.Close()
            Else
                objReader.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub frmMantProvincias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizaGrid()

    End Sub

    Private Sub DG_DoubleClick(sender As Object, e As EventArgs) Handles DG.DoubleClick
        Try

            If Not DG.CurrentRow.IsNewRow Then
                txtNombre.BackColor = Color.Yellow

                txtId.Text = DG.Item(0, DG.CurrentRow.Index).Value
                txtNombre.Text = DG.Item(1, DG.CurrentRow.Index).Value

                btnEliminar.Enabled = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        If Len(Trim(txtNombre.Text)) = 0 Then
            MsgBox("Debe digitar el nombre de la provincia", vbInformation)
            txtNombre.Focus()
            Return
        End If

        Try

            If txtId.Text = "" Then
                StrSql = "SELECT ID_PROVINCIA FROM PROVINCIAS WHERE NOMBRE_PROVINCIA ='" & Trim(txtNombre.Text) & "'"
                objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    MsgBox("Ese nombre de provincia ya existe", vbCritical)
                    objReader.Close()
                    txtNombre.Focus()
                    Return
                Else
                    objReader.Close()
                End If

                StrSql = "INSERT INTO PROVINCIAS(NOMBRE_PROVINCIA) VALUES('" & Trim(txtNombre.Text) & "')"
                objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
                RA = objCmd.ExecuteNonQuery()
                If RA > 0 Then
                    ActualizaGrid()
                    txtId.Text = "" : txtNombre.Text = "" : txtNombre.Focus()
                Else
                    MsgBox("No fue posible grabar la información", vbInformation)
                    Return
                End If

            Else
                StrSql = "SELECT ID_PROVINCIA FROM PROVINCIAS WHERE NOMBRE_PROVINCIA ='" _
                & Trim(txtNombre.Text) & "' AND ID_PROVINCIA <>" & CLng(txtId.Text)
                objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
                objReader = objCmd.ExecuteReader
                If objReader.HasRows Then
                    MsgBox("Esa provincia ya existe", vbCritical)
                    objReader.Close()
                    txtNombre.Focus()
                    Return
                Else
                    objReader.Close()
                End If

                StrSql = "UPDATE PROVINCIAS SET NOMBRE_PROVINCIA ='" & Trim(txtNombre.Text) & "' WHERE ID_PROVINCIA =" & CLng(txtId.Text)
                objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
                RA = objCmd.ExecuteNonQuery()
                If RA > 0 Then
                    ActualizaGrid()
                    txtNombre.BackColor = Color.White
                    txtId.Text = "" : txtNombre.Text = "" : txtNombre.Focus()
                Else
                    MsgBox("No fue posible actualizar el nombre de la provincia", vbInformation)
                    Return
                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtId.Text = "" Then
            MsgBox("Debe seleccionar la provincia que desea eliminar", vbInformation)
            Return
        End If

        StrSql = "SELECT TOP 1 ID_PROVINCIA FROM AFILIADOS WHERE ID_PROVINCIA =" & CLng(txtId.Text)
        objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
        objReader = objCmd.ExecuteReader
        If objReader.HasRows Then
            MsgBox("No se puede eliminar, porque hay electores con esa provincia", vbInformation)
            objReader.Close()
            Return
        Else
            objReader.Close()
        End If

        If MsgBox("Seguro que desea eliminar ese departamento", vbQuestion + vbYesNo + vbDefaultButton2) = vbNo Then
            Return
        End If

        Try

            StrSql = "DELETE FROM RH_PONCHE_DEPARTAMENTOS WHERE ID =" & CLng(txtId.Text)
            objCmd = New OleDb.OleDbCommand(StrSql, Conexion.DB.Cnn)
            RA = objCmd.ExecuteNonQuery()
            If RA > 0 Then
                ActualizaGrid()
                txtNombre.BackColor = Color.White
                btnEliminar.Enabled = False
                txtId.Text = "" : txtNombre.Text = "" : txtNombre.Focus()
            Else
                MsgBox("No fue posible eliminar el departamento", vbInformation)
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try

    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        txtNombre.BackColor = Color.White
        btnEliminar.Enabled = False
        txtId.Text = "" : txtNombre.Text = "" : txtNombre.Focus()

    End Sub

    Private Sub txtNombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNombre.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            btnGrabar.Focus()
        End If
    End Sub

    Private Sub btnSalir_Click_1(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
End Class