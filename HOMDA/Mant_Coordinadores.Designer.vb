<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMantCoordinadores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMantCoordinadores))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCoord = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNuevo = New System.Windows.Forms.TextBox()
        Me.btnCambiar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(292, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Seleccione el Coordinador al que desea cambiarle el nombre"
        '
        'cmbCoord
        '
        Me.cmbCoord.FormattingEnabled = True
        Me.cmbCoord.Location = New System.Drawing.Point(15, 25)
        Me.cmbCoord.Name = "cmbCoord"
        Me.cmbCoord.Size = New System.Drawing.Size(329, 21)
        Me.cmbCoord.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 71)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(208, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Cambiar el nombre al coordinador con este"
        '
        'txtNuevo
        '
        Me.txtNuevo.Location = New System.Drawing.Point(15, 87)
        Me.txtNuevo.Name = "txtNuevo"
        Me.txtNuevo.Size = New System.Drawing.Size(326, 20)
        Me.txtNuevo.TabIndex = 1
        '
        'btnCambiar
        '
        Me.btnCambiar.Location = New System.Drawing.Point(127, 141)
        Me.btnCambiar.Name = "btnCambiar"
        Me.btnCambiar.Size = New System.Drawing.Size(108, 25)
        Me.btnCambiar.TabIndex = 2
        Me.btnCambiar.Text = "Actualiza"
        Me.btnCambiar.UseVisualStyleBackColor = True
        '
        'FrmMantCoordinadores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 173)
        Me.Controls.Add(Me.btnCambiar)
        Me.Controls.Add(Me.txtNuevo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbCoord)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMantCoordinadores"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "mantenimiento Nombres Coordinadores"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCoord As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtNuevo As TextBox
    Friend WithEvents btnCambiar As Button
End Class
