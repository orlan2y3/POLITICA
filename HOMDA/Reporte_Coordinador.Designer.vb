<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reporte_Coordinador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reporte_Coordinador))
        Me.cmb_coordinadores = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btsalir = New System.Windows.Forms.Button()
        Me.btimprimir = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmb_coordinadores
        '
        Me.cmb_coordinadores.FormattingEnabled = True
        Me.cmb_coordinadores.Location = New System.Drawing.Point(12, 25)
        Me.cmb_coordinadores.Name = "cmb_coordinadores"
        Me.cmb_coordinadores.Size = New System.Drawing.Size(239, 21)
        Me.cmb_coordinadores.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Coordinadores"
        '
        'btsalir
        '
        Me.btsalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btsalir.Image = CType(resources.GetObject("btsalir.Image"), System.Drawing.Image)
        Me.btsalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btsalir.Location = New System.Drawing.Point(165, 184)
        Me.btsalir.Name = "btsalir"
        Me.btsalir.Size = New System.Drawing.Size(107, 45)
        Me.btsalir.TabIndex = 33
        Me.btsalir.Text = "Salir"
        Me.btsalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btsalir.UseVisualStyleBackColor = True
        '
        'btimprimir
        '
        Me.btimprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btimprimir.Image = CType(resources.GetObject("btimprimir.Image"), System.Drawing.Image)
        Me.btimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btimprimir.Location = New System.Drawing.Point(12, 184)
        Me.btimprimir.Name = "btimprimir"
        Me.btimprimir.Size = New System.Drawing.Size(107, 45)
        Me.btimprimir.TabIndex = 34
        Me.btimprimir.Text = "Imprimir"
        Me.btimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btimprimir.UseVisualStyleBackColor = True
        '
        'Reporte_Coordinador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 241)
        Me.Controls.Add(Me.btimprimir)
        Me.Controls.Add(Me.btsalir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmb_coordinadores)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Reporte_Coordinador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmb_coordinadores As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btsalir As Button
    Friend WithEvents btimprimir As Button
End Class
