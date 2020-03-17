<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Reportes))
        Me.Crv_Reportes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Crv_Reportes
        '
        Me.Crv_Reportes.ActiveViewIndex = -1
        Me.Crv_Reportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Crv_Reportes.Cursor = System.Windows.Forms.Cursors.Default
        Me.Crv_Reportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Crv_Reportes.Location = New System.Drawing.Point(0, 0)
        Me.Crv_Reportes.Name = "Crv_Reportes"
        Me.Crv_Reportes.Size = New System.Drawing.Size(667, 451)
        Me.Crv_Reportes.TabIndex = 0
        Me.Crv_Reportes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'Reportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 451)
        Me.Controls.Add(Me.Crv_Reportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Reportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Crv_Reportes As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
