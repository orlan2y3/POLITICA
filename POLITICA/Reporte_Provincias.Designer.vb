<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reporte_Provincias
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reporte_Provincias))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btimprimir = New System.Windows.Forms.Button()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.cmbIdProvincia = New System.Windows.Forms.ComboBox()
        Me.cmbProvincia = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(149, 16)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Seleccione la Provincia"
        '
        'btimprimir
        '
        Me.btimprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btimprimir.Image = CType(resources.GetObject("btimprimir.Image"), System.Drawing.Image)
        Me.btimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btimprimir.Location = New System.Drawing.Point(65, 182)
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(107, 45)
        Me.btimprimir.TabIndex = 38
        Me.btimprimir.Text = "Imprimir"
        Me.btimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btimprimir.UseVisualStyleBackColor = True
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = CType(resources.GetObject("btsalir.Image"), System.Drawing.Image)
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(218, 182)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(107, 45)
        Me.btsalir.TabIndex = 37
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'cmbIdProvincia
        '
        Me.cmbIdProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdProvincia.FormattingEnabled = True
        Me.cmbIdProvincia.Items.AddRange(New Object() {"Coordinador Provincial", "Coordinador Municipal", "Coordinador Distrito Municipal", "Coordinador Comite de Base", "Coordinador de la Juventud y Deporte", "Encargado de la Mujer", "Encargado Sector Salud", "Encargado Sector Agropecuario", "Encargado Sector Magisterial", "Encargado Sector Deporte", "Encargado Sector Arte y Cultura", "Encargado Sector Prensa", "Encargado de Redes Sociales"})
        Me.cmbIdProvincia.Location = New System.Drawing.Point(81, 26)
        Me.cmbIdProvincia.Name = "cmbIdProvincia"
        Me.cmbIdProvincia.Size = New System.Drawing.Size(46, 21)
        Me.cmbIdProvincia.TabIndex = 83
        Me.cmbIdProvincia.Visible = False
        '
        'cmbProvincia
        '
        Me.cmbProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProvincia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbProvincia.FormattingEnabled = True
        Me.cmbProvincia.Location = New System.Drawing.Point(12, 28)
        Me.cmbProvincia.Name = "cmbProvincia"
        Me.cmbProvincia.Size = New System.Drawing.Size(364, 24)
        Me.cmbProvincia.TabIndex = 82
        '
        'Reporte_Provincias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(389, 237)
        Me.Controls.Add(Me.cmbIdProvincia)
        Me.Controls.Add(Me.cmbProvincia)
        Me.Controls.Add(Me.btimprimir)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Reporte_Provincias"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte por Provincias"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btimprimir As Button
    Friend WithEvents btsalir As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbIdProvincia As ComboBox
    Friend WithEvents cmbProvincia As ComboBox
End Class
