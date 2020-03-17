Imports System.Data.OleDb
Public Class Formulario
    Public ds As DataSet = New DataSet
    Dim StrSql As String = ""

    'DESARROLLADO POR ORLANDO REYNOSO Y ARCADIO SOLANO 2020

    Sub LlenaMovimientos()
        Try
            cmbMovimiento.Items.Clear()
            cmbIdMovimiento.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT *  FROM MOVIMIENTOS"
            Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    cmbIdMovimiento.Items.Add(dr("id"))
                    cmbMovimiento.Items.Add(dr("nombre").ToString)
                End While
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Sub LlenaProvincias()
        Try
            cmbProvincia.Items.Clear()
            cmbIdProvincia.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT *  FROM PROVINCIAS"
            Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    cmbIdProvincia.Items.Add(dr("id_provincia"))
                    cmbProvincia.Items.Add(dr("nombre_provincia").ToString)
                End While
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Sub LlenaMunicipios(id_provincia As Integer)
        Try
            cmbMunicipio.Items.Clear()
            cmbIdMunicipio.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT *  FROM MUNICIPIOS WHERE ID_PROVINCIA =" & id_provincia
            Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    cmbIdMunicipio.Items.Add(dr("id_municipio"))
                    cmbMunicipio.Items.Add(dr("nombre_municipio").ToString)
                End While
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Sub LlenaDistritos(id_provincia As Integer, id_municipio As Integer)
        Try
            cmbDistrito.Items.Clear()
            cmbIdDistrito.Items.Clear()

            Dim dr As OleDbDataReader
            Dim query As String = "SELECT *  FROM DISTRITOS_MUNICIPALES WHERE ID_PROVINCIA =" & id_provincia & " AND ID_MUNICIPIO =" & id_municipio
            Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
            dr = cmb.ExecuteReader()
            If dr.HasRows Then
                While dr.Read()
                    cmbIdDistrito.Items.Add(dr("id_distrito_municipal"))
                    cmbDistrito.Items.Add(dr("nombre").ToString)
                End While
                dr.Close()
            Else
                dr.Close()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
            Return
        End Try

    End Sub

    Private Sub Formulario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Dim fecha As String = Date.Today.ToString("dd/MM/yyyy")
            lbfecha.Text = "Fecha: " & fecha
            txtcoordinador.Focus()
            rdbnombre.Checked = True
            LlenaMovimientos()
            cmbMovimiento.SelectedIndex = 0
            LlenaProvincias()

            'Refrescar DataGriv
            ds.Clear()

            Dim da As OleDbDataAdapter = New OleDbDataAdapter(
            "SELECT TOP 100 id as Id, coordinador as Coordinador, nombre as Nombre, cedula as Cedula, telefono as Telefono,
            celular as Celular, correo as Correo, cargo as Cargo, colegio as Colegio, nucleo as Nucleo FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)

            da.Fill(ds, "afiliados")
            dgvformulario.DataSource = ds
            dgvformulario.DataMember = "afiliados"

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btlimpiar_Click(sender As Object, e As EventArgs) Handles btlimpiar.Click
        cmbNivel.Text = ""
        txtcodigo.Text = ""
        txtnombre.Text = ""
        mtbcedula.Text = ""
        mtbtelefono.Text = ""
        txtcorreo.Text = ""
        txtRecinto.Text = ""
        txtcoordinador.Text = ""
        txtnucleo.Text = ""
        txtbuscar.Text = ""
        txtSector.Text = ""
        cmbvehiculo.Text = ""
        txtCircuncripcion.Text = ""
        cmbcargo.Text = ""
        cmbestado.Text = ""
        cmbvehiculo.Text = ""
        mtbcelular.Text = ""
        txtfacebook.Text = ""
        txttwitter.Text = ""
        txtinstagram.Text = ""
        cmbestado.Text = ""
        rtbnota.Text = ""
        txtTelCreador.Text = ""
        txtCorreosCreador.Text = ""
        txtColegio.Text = ""
        txtCodRecinto.Text = ""
        txtDirRecinto.Text = ""

        cmbIdProvincia.Items.Clear()
        cmbProvincia.Items.Clear()
        cmbIdMunicipio.Items.Clear()
        cmbMunicipio.Items.Clear()
        cmbIdDistrito.Items.Clear()
        cmbDistrito.Items.Clear()
        cmbPartido.Text = ""

        LlenaProvincias()

    End Sub

    Private Sub btsalir_Click(sender As Object, e As EventArgs) Handles btsalir.Click
        Conexion.DB.Desconectar()
        End
    End Sub

    Private Sub btinsertar_Click(sender As Object, e As EventArgs) Handles btinsertar.Click
        Try
            If cmbNivel.Text = "" Then
                MsgBox("Debe seleccionar el nivel", MsgBoxStyle.Information)
                Return
            End If
            If Len(Trim(txtnombre.Text)) = 0 Then
                MsgBox("Nombre es Obligatorio", MsgBoxStyle.Information)
                Return
            End If
            'If cmbcargo.Text = "" Then
            '    MsgBox("Debe seleccionar el cargo", MsgBoxStyle.Information)
            '    Return
            'End If
            'If cmbvehiculo.Text = "" Then
            '    MsgBox("Debe seleccionar si tiene o no tiene vehiculo", MsgBoxStyle.Information)
            '    Return
            'End If
            'If cmbProvincia.Text = "" Then
            '    MsgBox("Debe seleccionar la provincia", MsgBoxStyle.Information)
            '    Return
            'End If
            'If cmbMunicipio.Text = "" Then
            '    MsgBox("Debe seleccionar el municipio", MsgBoxStyle.Information)
            '    Return
            'End If
            'If cmbDistrito.Text = "" Then
            '    MsgBox("Debe seleccionar el distrito municipal", MsgBoxStyle.Information)
            '    Return
            'End If
            'If cmbestado.Text = "" Then
            '    MsgBox("Debe seleccionar el estado", MsgBoxStyle.Information)
            '    Return
            'End If
            'If cmbPartido.Text = "" Then
            '    MsgBox("Debe seleccionar por que partido votó en el 2016", MsgBoxStyle.Information)
            '    Return
            'End If

            If IsNumeric(txtcodigo.Text) Then

                'Para validar que estos campos no tengan el caracter ( ' )
                If InStr(txtnombre.Text, "'") Then
                    txtnombre.Text = Cambiar(txtnombre.Text)
                End If
                If InStr(txtfacebook.Text, "'") Then
                    txtfacebook.Text = Cambiar(txtfacebook.Text)
                End If
                If InStr(txttwitter.Text, "'") Then
                    txttwitter.Text = Cambiar(txttwitter.Text)
                End If
                If InStr(txtinstagram.Text, "'") Then
                    txtinstagram.Text = Cambiar(txtinstagram.Text)
                End If
                If InStr(txtRecinto.Text, "'") Then
                    txtRecinto.Text = Cambiar(txtRecinto.Text)
                End If
                If InStr(txtDirRecinto.Text, "'") Then
                    txtDirRecinto.Text = Cambiar(txtDirRecinto.Text)
                End If
                If InStr(txtSector.Text, "'") Then
                    txtSector.Text = Cambiar(txtSector.Text)
                End If

                Dim cmd As OleDbCommand = New OleDbCommand("UPDATE afiliados SET id_movimiento =" & cmbIdMovimiento.Text _
                                                            & ",nivel ='" & cmbNivel.Text & "',nombre ='" & txtnombre.Text _
                                                            & "',cedula ='" & mtbcedula.Text & "',telefono ='" & mtbtelefono.Text _
                                                            & "',correo ='" & txtcorreo.Text & "',celular ='" & mtbcelular.Text _
                                                            & "',cargo ='" & cmbcargo.Text & "',nucleo ='" & txtnucleo.Text _
                                                            & "',coordinador ='" & txtcoordinador.Text & "',vehiculo ='" & cmbvehiculo.Text _
                                                            & "',facebook ='" & txtfacebook.Text & "',twitter ='" & txttwitter.Text & "',instagram ='" & txtinstagram.Text _
                                                            & "',estado ='" & cmbestado.Text & "',nota ='" & rtbnota.Text _
                                                            & "',telefono_creador ='" & txtTelCreador.Text & "',mail_creador ='" & txtCorreosCreador.Text _
                                                            & "',id_provincia =" & cmbIdProvincia.Text & ",descripcion_provincia ='" & cmbProvincia.Text _
                                                            & "',id_municipio =" & cmbIdMunicipio.Text & ",descripcion_municipio ='" & cmbMunicipio.Text _
                                                            & "',id_distrito_municipal =" & cmbIdDistrito.Text & ",descripcion_distrito_municipal ='" & cmbDistrito.Text _
                                                            & "',codigo_circunscripcion ='" & txtCircuncripcion.Text & "',codigo_recinto ='" & txtCodRecinto.Text _
                                                            & "',colegio ='" & txtColegio.Text & "',descripcion_recinto ='" & txtRecinto.Text _
                                                            & "',direccion_recinto ='" & txtDirRecinto.Text & "',descripcion_sector ='" & txtSector.Text _
                                                            & "',partido_voto_2016 ='" & cmbPartido.Text & "' where id = " & txtcodigo.Text)

                cmd.Connection = Conexion.DB.Cnn
                cmd.ExecuteNonQuery()
                MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)

                ds.Clear()
                If Len(Trim(txtbuscar.Text)) > 0 Then

                    ds.Clear()
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador, nombre as Nombre,
                    cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo, colegio as Colegio, nucleo as Nucleo 
                    FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)
                    da.Fill(ds, "afiliados")
                    dgvformulario.DataSource = ds
                    dgvformulario.DataMember = "afiliados"

                    btlimpiar.PerformClick()

                Else

                    ds.Clear()
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                    nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                    colegio as Colegio, nucleo as Nucleo FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)
                    da.Fill(ds, "afiliados")
                    dgvformulario.DataSource = ds
                    dgvformulario.DataMember = "afiliados"

                    btlimpiar.PerformClick()

                End If

            Else

                Dim cmd As OleDbCommand = New OleDbCommand("INSERT INTO afiliados (id_movimiento,nivel,nombre,cedula,telefono,correo,
                                                            celular,cargo,nucleo,coordinador,vehiculo,facebook,twitter,instagram,estado,nota,telefono_creador,
                                                            mail_creador,id_provincia,descripcion_provincia,id_municipio,descripcion_municipio,
                                                            id_distrito_municipal,descripcion_distrito_municipal,codigo_circunscripcion,codigo_recinto,
                                                            colegio,descripcion_recinto,direccion_recinto,descripcion_sector,partido_voto_2016) VALUES (" & cmbIdMovimiento.Text _
                                                            & ",'" & cmbNivel.Text & "','" & txtnombre.Text & "','" & mtbcedula.Text & "','" & mtbtelefono.Text & "', 
                                                            '" & txtcorreo.Text & "','" & mtbcelular.Text & "','" & cmbcargo.Text & "','" & txtnucleo.Text & "',
                                                            '" & txtcoordinador.Text & "','" & cmbvehiculo.Text & "','" & txtfacebook.Text & "','" & txttwitter.Text & "',
                                                            '" & txtinstagram.Text & "','" & cmbestado.Text & "','" & rtbnota.Text & "',
                                                            '" & txtTelCreador.Text & "','" & txtCorreosCreador.Text & "',
                                                            " & cmbIdProvincia.Text & ",'" & cmbProvincia.Text & "'," & cmbIdMunicipio.Text & ",'" & cmbMunicipio.Text & "',
                                                            " & cmbIdDistrito.Text & ",'" & cmbDistrito.Text & "','" & txtCircuncripcion.Text & "','" & txtCodRecinto.Text & "',
                                                            '" & txtColegio.Text & "','" & txtRecinto.Text & "','" & txtDirRecinto.Text & "','" & txtSector.Text & "','" & cmbPartido.Text & "')")
                cmd.Connection = Conexion.DB.Cnn
                cmd.ExecuteNonQuery()
                MsgBox("Grabado Con Éxito", MsgBoxStyle.Information)

                ds.Clear()
                If Len(Trim(txtbuscar.Text)) > 0 Then

                    ds.Clear()
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                    nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                    colegio as Colegio, nucleo as Nucleo FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)
                    da.Fill(ds, "afiliados")
                    dgvformulario.DataSource = ds
                    dgvformulario.DataMember = "afiliados"

                    btlimpiar.PerformClick()


                Else

                    ds.Clear()
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                    nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                    colegio as Colegio, nucleo as Nucleo FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)

                    da.Fill(ds, "afiliados")
                    dgvformulario.DataSource = ds
                    dgvformulario.DataMember = "afiliados"

                    btlimpiar.PerformClick()

                End If

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btbuscar_Click(sender As Object, e As EventArgs) Handles btbuscar.Click
        Try
            If rdbnombre.Checked = True And IsNumeric(txtbuscar.Text) Then
                MsgBox("Debe digitar un nombre valido", MsgBoxStyle.Information)
                Return
                txtbuscar.Focus()
            End If

            If rdbnombre.Checked = True Then
                ds.Clear()
                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                colegio as Colegio, nucleo as Nucleo FROM afiliados where nombre like '%" & txtbuscar.Text & "%'", Conexion.DB.Cnn)
                da.Fill(ds, "afiliados")
                dgvformulario.DataSource = ds
                dgvformulario.DataMember = "afiliados"

            ElseIf rdbcedula.Checked = True Then
                ds.Clear()
                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                colegio as Colegio, nucleo as Nucleo FROM afiliados where cedula like '%" & txtbuscar.Text & "%'", Conexion.DB.Cnn)
                da.Fill(ds, "afiliados")
                dgvformulario.DataSource = ds
                dgvformulario.DataMember = "afiliados"

            Else
                ds.Clear()
                Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                    nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                    colegio as Colegio, nucleo as Nucleo FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)
                da.Fill(ds, "afiliados")
                dgvformulario.DataSource = ds
                dgvformulario.DataMember = "afiliados"

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub bteliminar_Click(sender As Object, e As EventArgs) Handles bteliminar.Click
        Try
            If txtcodigo.Text = "" Then
                MsgBox("Debe Hacer Doble Clic en el Afiliado que Desea Eliminar", MsgBoxStyle.Information)
                Return
            End If

            Select Case MsgBox("Esta Seguro que Decea Eliminar Este Afiliado?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2)

                Case MsgBoxResult.Yes

                    Dim cmd As OleDbCommand = New OleDbCommand("DELETE * From afiliados Where id = " & txtcodigo.Text)
                    cmd.Connection = Conexion.DB.Cnn
                    cmd.ExecuteNonQuery()

                    'Refrescar DataGriv
                    ds.Clear()
                    Dim da As OleDbDataAdapter = New OleDbDataAdapter("SELECT TOP 100 id as Id, coordinador as Coordinador,
                    nombre as Nombre, cedula as Cedula, telefono as Telefono, celular as Celular, correo as Correo, cargo as Cargo,
                    colegio as Colegio, nucleo as Nucleo FROM afiliados ORDER BY id DESC", Conexion.DB.Cnn)
                    da.Fill(ds, "afiliados")
                    dgvformulario.DataSource = ds
                    dgvformulario.DataMember = "afiliados"

                    btlimpiar.PerformClick()

                Case MsgBoxResult.No
                    Return
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        Try
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\Rpt_General.rpt")
            Reporte.Crv_Reportes.ReportSource = Rpt

            Reporte.Crv_Reportes.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            Dim Reporte_Coordinador As New Reporte_Coordinador
            Reporte_Coordinador.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Label14.Visible = True Then
            Label14.Visible = False
        Else
            Label14.Visible = True
        End If
    End Sub

    Private Sub btimportar_Click(sender As Object, e As EventArgs)
        If importar = False Then
            Dim frmimportar As New Importar_Exel
            frmimportar.Show()
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        Try
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\Rpt_Sector.rpt")
            Reporte.Crv_Reportes.ReportSource = Rpt

            Reporte.Crv_Reportes.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        Try
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\Rpt_ListadoCoordinadores.rpt")
            Reporte.Crv_Reportes.ReportSource = Rpt

            Reporte.Crv_Reportes.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub btnucleo_Click(sender As Object, e As EventArgs)
        If nucleo = False Then
            Dim frmnucleo As New Mant_Nucleos
            frmnucleo.Show()
        End If
    End Sub

    Private Sub btcoordinador_Click(sender As Object, e As EventArgs)
        If coordinador = False Then
            Dim frmcoordinado As New FrmMantCoordinadores
            frmcoordinado.Show()
        End If
    End Sub

    Private Sub cmbProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbProvincia.SelectedValueChanged
        cmbIdProvincia.SelectedIndex = cmbProvincia.SelectedIndex

        LlenaMunicipios(cmbIdProvincia.Text)
        cmbIdDistrito.Items.Clear()
        cmbDistrito.Items.Clear()

    End Sub

    Private Sub cmbMovimiento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMovimiento.SelectedValueChanged
        cmbIdMovimiento.SelectedIndex = cmbMovimiento.SelectedIndex
    End Sub

    Private Sub cmbMunicipio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMunicipio.SelectedValueChanged
        cmbIdMunicipio.SelectedIndex = cmbMunicipio.SelectedIndex

        LlenaDistritos(cmbIdProvincia.Text, cmbIdMunicipio.Text)

    End Sub

    Private Sub cmbDistrito_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbDistrito.SelectedValueChanged
        cmbIdDistrito.SelectedIndex = cmbDistrito.SelectedIndex
    End Sub

    Private Sub cmbIdMovimiento_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdMovimiento.SelectedValueChanged
        cmbMovimiento.SelectedIndex = cmbIdMovimiento.SelectedIndex
    End Sub

    Private Sub cmbIdProvincia_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdProvincia.SelectedValueChanged
        cmbProvincia.SelectedIndex = cmbIdProvincia.SelectedIndex

        LlenaMunicipios(cmbIdProvincia.Text)
        cmbIdDistrito.Items.Clear()
        cmbDistrito.Items.Clear()

    End Sub

    Private Sub cmbIdMunicipio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdMunicipio.SelectedValueChanged
        cmbMunicipio.SelectedIndex = cmbIdMunicipio.SelectedIndex

        LlenaDistritos(cmbIdProvincia.Text, cmbIdMunicipio.Text)
    End Sub

    Private Sub cmbIdDistrito_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbIdDistrito.SelectedValueChanged
        cmbDistrito.SelectedIndex = cmbIdDistrito.SelectedIndex
    End Sub

    Private Sub dgvformulario_DoubleClick(sender As Object, e As EventArgs) Handles dgvformulario.DoubleClick

        txtcodigo.Text = dgvformulario.CurrentRow.Cells(0).Value

        Dim dr As OleDbDataReader
        Dim query As String = "SELECT *  FROM afiliados WHERE id =" & CLng(txtcodigo.Text)

        Dim cmb As OleDbCommand = New OleDbCommand(query, Conexion.DB.Cnn)
        dr = cmb.ExecuteReader()

        dr.Read()
        txtcodigo.Text = dr("id")
        cmbIdMovimiento.Text = dr("id_movimiento")
        cmbNivel.Text = dr("nivel").ToString
        txtnombre.Text = dr("nombre").ToString
        mtbcedula.Text = dr("cedula").ToString
        mtbtelefono.Text = dr("telefono").ToString
        txtcorreo.Text = dr("correo").ToString
        mtbcelular.Text = dr("celular").ToString
        cmbcargo.Text = dr("cargo").ToString
        txtnucleo.Text = dr("nucleo").ToString
        txtcoordinador.Text = dr("coordinador").ToString
        cmbvehiculo.Text = dr("vehiculo").ToString
        txtfacebook.Text = dr("facebook").ToString
        txttwitter.Text = dr("twitter").ToString
        txtinstagram.Text = dr("instagram").ToString
        If Len(dr("estado").ToString) > 0 Then
            cmbestado.Text = dr("estado").ToString
        End If
        rtbnota.Text = dr("nota").ToString
        txtTelCreador.Text = dr("telefono_creador").ToString
        txtCorreosCreador.Text = dr("mail_creador").ToString

        cmbIdProvincia.Text = dr("id_provincia")
        cmbIdMunicipio.Text = dr("id_municipio")
        cmbIdDistrito.Text = dr("id_distrito_municipal")

        txtCircuncripcion.Text = dr("codigo_circunscripcion").ToString
        txtCodRecinto.Text = dr("codigo_recinto").ToString
        txtColegio.Text = dr("colegio").ToString
        txtRecinto.Text = dr("descripcion_recinto").ToString
        txtDirRecinto.Text = dr("direccion_recinto").ToString
        txtSector.Text = dr("descripcion_sector").ToString
        cmbPartido.Text = dr("partido_voto_2016").ToString

        dr.Close()

    End Sub

    Private Sub txtcoordinador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcoordinador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbMovimiento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMovimiento.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbNivel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbNivel.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtTelCreador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTelCreador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCorreosCreador_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCorreosCreador.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtnucleo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnucleo.KeyPress
        txtnombre.Focus()
    End Sub

    Private Sub txtnombre_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnombre.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mtbcedula_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbcedula.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbcargo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbcargo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mtbtelefono_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbtelefono.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub mtbcelular_KeyPress(sender As Object, e As KeyPressEventArgs) Handles mtbcelular.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbvehiculo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbvehiculo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtcorreo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtcorreo.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtfacebook_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtfacebook.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txttwitter_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txttwitter.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtinstagram_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtinstagram.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbProvincia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbProvincia.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbMunicipio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbMunicipio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbDistrito_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDistrito.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCircuncripcion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCircuncripcion.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtColegio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtColegio.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCodRecinto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCodRecinto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRecinto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRecinto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDirRecinto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDirRecinto.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtSector_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSector.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbestado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbestado.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnMantProv_Click(sender As Object, e As EventArgs) Handles btnMantProv.Click
        Dim frmMP As New frmMantProvincias
        frmMP.Show()
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        Try
            Dim Reporte As New Reportes
            Dim Rpt As New CrystalDecisions.CrystalReports.Engine.ReportDocument
            Rpt.Load(Application.StartupPath & "\Rpt_Estado.rpt")
            Reporte.Crv_Reportes.ReportSource = Rpt

            Rpt.RecordSelectionFormula = "{afiliados.estado} = 'Inconforme'"

            Reporte.Crv_Reportes.RefreshReport()
            Reporte.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub cmbPartido_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPartido.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        Try
            Dim Reporte_Provincia As New Reporte_Provincias
            Reporte_Provincia.Show()

        Catch ex As Exception
            MsgBox(ex.Message, vbInformation)
        End Try
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub

    'DESARROLLADO POR ORLANDO REYNOSO Y ARCADIO SOLANO 2020
End Class