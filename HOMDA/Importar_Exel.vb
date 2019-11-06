Imports Microsoft.Office.Interop
Imports System.Data.OleDb

Public Class Importar_Exel
    Dim Archivo As String
    Dim NombreArchivo As String
    Dim Cancelar As Boolean

    Dim trans As OleDbTransaction


    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "Archivos de Excel|*.xlsx"
        openFile.Title = "Seleccionar el archivo de Excel"
        openFile.ShowDialog()

        If openFile.SafeFileName <> "" Then
            Archivo = openFile.FileName
            txtRuta.Text = Archivo
            NombreArchivo = openFile.SafeFileName

            btnImportar.Enabled = True
            Cancelar = False

        Else
            Archivo = "" : NombreArchivo = "" : txtLabel.Text = ""
            Return
        End If
    End Sub

    Private Sub btnImportar_Click(sender As Object, e As EventArgs) Handles btnImportar.Click
        Try
            If Archivo = "" Then
                MsgBox("Debe seleccionar el archivo de Excel que desea importar", vbInformation)
                Return
            End If

            btnImportar.Enabled = False

            Dim ObjExcel As Excel.Application
            Dim Libro As Excel.Workbook
            Dim Hoja As Excel.Worksheet

            ' Start Excel and get Application object.
            ObjExcel = CreateObject("Excel.Application")
            ObjExcel.Visible = False    'Evita que el archivo de excel abra en la pantalla

            ' Abrir el archivo de excel
            Libro = ObjExcel.Workbooks.Open(txtRuta.Text)

            ' Activar la hoja #1 del libro
            Hoja = ObjExcel.Worksheets(1)

            btnBuscar.Enabled = False
            PB1.Focus()

            Dim X As Long = 2
            Dim Cant As Long = 0
            Dim Reg As Boolean = True
            Dim Total As Long

            txtLabel.Text = "Revisando el archivo..."

            'Contar la cantidad de lineas que tiene el archivo de excel
            While Reg
                If Hoja.Cells(X, 1).Value <> String.Empty Or Hoja.Cells(X, 1).Value IsNot Nothing Then
                    Cant = Cant + 1
                    X = X + 1

                    txtLabel.Text = "Revisando " & FormatNumber(Cant, 0)
                    Application.DoEvents()
                Else
                    Reg = False
                End If
            End While

            X = 0
            Total = Cant
            PB1.Maximum = Cant

            Dim Ced As String
            Dim Nombre As String
            Dim Apellido1 As String
            Dim Apellido2 As String
            Dim NombreCompleto As String
            Dim Tel_Res As String
            Dim Tel_Tra As String
            Dim Tel_Cel As String
            Dim telefono As String
            Dim Correo As String
            Dim Prov As String
            Dim Mun As String
            Dim Sector As String
            Dim Veh As String

            Dim mesa As String = ""
            Dim recinto As String = ""
            Dim distrito As String = ""
            Dim coordinador As String = ""
            Dim nucleo As String = ""


            Dim fecha_importacion As String
            fecha_importacion = Date.Today.ToString("yyyy/MM/dd")

            Cant = 0

            'Leer las celdas de la hoja de Excel
            trans = Conexion.DB.Cnn.BeginTransaction

            For X = 2 To Total
                Ced = "" : Nombre = "" : Apellido1 = "" : Apellido2 = "" : NombreCompleto = "" : Correo = ""
                Tel_Res = "" : Tel_Tra = "" : Tel_Cel = "" : Prov = "" : Mun = "" : Sector = "" : Veh = "" : telefono = ""

                If Hoja.Cells(X, 1).Value IsNot Nothing Then    'Verificar que la celda no es nula
                    If Hoja.Cells(X, 1).Value.ToString <> String.Empty Then 'Verificar que la celda no esta vacia
                        Ced = Hoja.Cells(X, 1).Value.ToString   'Leer la celda (Linea, Columna)
                    End If
                End If

                If Hoja.Cells(X, 2).Value IsNot Nothing Then    'Si se le pone .ToString no funciona
                    If Hoja.Cells(X, 2).Value.ToString <> String.Empty Then 'Solo funciona con .ToString
                        Nombre = Hoja.Cells(X, 2).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 3).Value IsNot Nothing Then
                    If Hoja.Cells(X, 3).Value.ToString <> String.Empty Then
                        Apellido1 = Hoja.Cells(X, 3).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 4).Value IsNot Nothing Then
                    If Hoja.Cells(X, 4).Value.ToString <> String.Empty Then
                        Apellido2 = Hoja.Cells(X, 4).Value.ToString
                    End If
                End If

                NombreCompleto = Nombre & " " & Apellido1 & " " & Apellido2

                If Hoja.Cells(X, 5).Value IsNot Nothing Then
                    If Hoja.Cells(X, 5).Value.ToString <> String.Empty Then
                        Tel_Res = Hoja.Cells(X, 5).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 6).Value IsNot Nothing Then
                    If Hoja.Cells(X, 6).Value.ToString <> String.Empty Then
                        Tel_Tra = Hoja.Cells(X, 6).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 7).Value IsNot Nothing Then
                    If Hoja.Cells(X, 7).Value.ToString <> String.Empty Then
                        Tel_Cel = Hoja.Cells(X, 7).Value.ToString
                    End If
                End If

                If Len(Tel_Cel) > 0 Then
                    telefono = Tel_Cel
                ElseIf Len(Tel_Res) > 0 Then
                    telefono = Tel_Res
                Else
                    telefono = Tel_Tra
                End If

                If telefono = "9999999999" Then
                    telefono = ""
                End If

                If Hoja.Cells(X, 8).Value IsNot Nothing Then
                    If Hoja.Cells(X, 8).Value.ToString <> String.Empty Then
                        Correo = Hoja.Cells(X, 8).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 12).Value IsNot Nothing Then
                    If Hoja.Cells(X, 12).Value.ToString <> String.Empty Then
                        Veh = Hoja.Cells(X, 12).Value.ToString
                    End If
                End If

                If Veh = "" Then
                    Veh = "No"
                ElseIf Veh = "0" Then
                    Veh = "No"
                Else
                    Veh = "Si"
                End If


                If Hoja.Cells(X, 14).Value IsNot Nothing Then
                    If Hoja.Cells(X, 14).Value.ToString <> String.Empty Then
                        Prov = Hoja.Cells(X, 14).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 15).Value IsNot Nothing Then
                    If Hoja.Cells(X, 15).Value.ToString <> String.Empty Then
                        Mun = Hoja.Cells(X, 15).Value.ToString
                    End If
                End If

                If Hoja.Cells(X, 16).Value IsNot Nothing Then
                    If Hoja.Cells(X, 16).Value.ToString <> String.Empty Then
                        Sector = Hoja.Cells(X, 16).Value.ToString
                    End If
                End If

                coordinador = "Sin Coordinador"
                nucleo = "0"

                'Insertar campos a la tabla ****

                Dim Qwerty As String = "INSERT INTO afiliados (nombre, cedula, telefono, Correo,
                                                           provincia, municipio, Sector, vehiculo, fecha_importacion, mesa, recinto_electoral, distrito, coordinador, nucleo) VALUES ('" _
                                                                & NombreCompleto & "','" & Ced & "','" & telefono & "','" & Correo & "','" & Prov & "','" & Mun & "','" & Sector & "','" & Veh & "','" & fecha_importacion & "','" & mesa & "', '" & recinto & "', '" & distrito & "', '" & coordinador & "', '" & nucleo & "')"

                Dim cmd As OleDbCommand = New OleDbCommand(Qwerty, Conexion.DB.Cnn, trans)
                cmd.Connection = Conexion.DB.Cnn
                cmd.ExecuteNonQuery()

                '*******************************

                Cant = Cant + 1
                PB1.Value = Cant

                txtLabel.Text = "Importando " & FormatNumber(Cant, 0) & " de " & FormatNumber(Total, 0)

                Application.DoEvents()

            Next

            txtLabel.Text = "Archivo " & NombreArchivo & " importado:  " & Cant & " Registros"

            Libro.Close()
            txtRuta.Text = ""
            btnBuscar.Enabled = True
            trans.Commit()
            MsgBox("Archivo Importado Satisfactoriamente", MsgBoxStyle.Information)

        Catch ex As Exception
            trans.Rollback()
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Archivo = "" : NombreArchivo = "" : txtLabel.Text = ""
        importar = True
    End Sub

    Private Sub Importar_Exel_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        importar = False
    End Sub
End Class