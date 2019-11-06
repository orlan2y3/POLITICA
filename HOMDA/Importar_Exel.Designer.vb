<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Importar_Exel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Importar_Exel))
        Me.txtLabel = New System.Windows.Forms.TextBox()
        Me.PB1 = New System.Windows.Forms.ProgressBar()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'txtLabel
        '
        Me.txtLabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtLabel.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLabel.ForeColor = System.Drawing.Color.Blue
        Me.txtLabel.Location = New System.Drawing.Point(12, 125)
        Me.txtLabel.Name = "txtLabel"
        Me.txtLabel.ReadOnly = True
        Me.txtLabel.Size = New System.Drawing.Size(472, 18)
        Me.txtLabel.TabIndex = 10
        Me.txtLabel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PB1
        '
        Me.PB1.Location = New System.Drawing.Point(13, 150)
        Me.PB1.Margin = New System.Windows.Forms.Padding(2)
        Me.PB1.Name = "PB1"
        Me.PB1.Size = New System.Drawing.Size(471, 20)
        Me.PB1.TabIndex = 9
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(171, 38)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(171, 39)
        Me.btnBuscar.TabIndex = 8
        Me.btnBuscar.Text = "Buscar archivo de Excel"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtRuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRuta.Location = New System.Drawing.Point(12, 12)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(470, 22)
        Me.txtRuta.TabIndex = 7
        Me.txtRuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnImportar
        '
        Me.btnImportar.Enabled = False
        Me.btnImportar.Image = CType(resources.GetObject("btnImportar.Image"), System.Drawing.Image)
        Me.btnImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImportar.Location = New System.Drawing.Point(171, 187)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(159, 39)
        Me.btnImportar.TabIndex = 6
        Me.btnImportar.Text = "Importar desde Excel"
        Me.btnImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'Importar_Exel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 242)
        Me.Controls.Add(Me.txtLabel)
        Me.Controls.Add(Me.PB1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtRuta)
        Me.Controls.Add(Me.btnImportar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Importar_Exel"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar_Exel"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtLabel As TextBox
    Friend WithEvents PB1 As ProgressBar
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtRuta As TextBox
    Friend WithEvents btnImportar As Button
End Class
