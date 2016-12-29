<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCASetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCASetup))
        Me.tcSetup = New System.Windows.Forms.TabControl()
        Me.tpCompany = New System.Windows.Forms.TabPage()
        Me.tpServer = New System.Windows.Forms.TabPage()
        Me.tpInventory = New System.Windows.Forms.TabPage()
        Me.tpReservation = New System.Windows.Forms.TabPage()
        Me.tcSetup.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSetup
        '
        Me.tcSetup.Controls.Add(Me.tpCompany)
        Me.tcSetup.Controls.Add(Me.tpServer)
        Me.tcSetup.Controls.Add(Me.tpInventory)
        Me.tcSetup.Controls.Add(Me.tpReservation)
        Me.tcSetup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcSetup.Location = New System.Drawing.Point(0, 0)
        Me.tcSetup.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tcSetup.Name = "tcSetup"
        Me.tcSetup.SelectedIndex = 0
        Me.tcSetup.Size = New System.Drawing.Size(745, 439)
        Me.tcSetup.TabIndex = 0
        '
        'tpCompany
        '
        Me.tpCompany.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpCompany.Location = New System.Drawing.Point(4, 24)
        Me.tpCompany.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tpCompany.Name = "tpCompany"
        Me.tpCompany.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tpCompany.Size = New System.Drawing.Size(805, 466)
        Me.tpCompany.TabIndex = 0
        Me.tpCompany.Text = "Company"
        Me.tpCompany.UseVisualStyleBackColor = True
        '
        'tpServer
        '
        Me.tpServer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpServer.Location = New System.Drawing.Point(4, 24)
        Me.tpServer.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tpServer.Name = "tpServer"
        Me.tpServer.Padding = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.tpServer.Size = New System.Drawing.Size(805, 466)
        Me.tpServer.TabIndex = 1
        Me.tpServer.Text = "Server"
        Me.tpServer.UseVisualStyleBackColor = True
        '
        'tpInventory
        '
        Me.tpInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpInventory.Location = New System.Drawing.Point(4, 24)
        Me.tpInventory.Name = "tpInventory"
        Me.tpInventory.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInventory.Size = New System.Drawing.Size(805, 466)
        Me.tpInventory.TabIndex = 2
        Me.tpInventory.Text = "Inventory"
        Me.tpInventory.UseVisualStyleBackColor = True
        '
        'tpReservation
        '
        Me.tpReservation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpReservation.Location = New System.Drawing.Point(4, 24)
        Me.tpReservation.Name = "tpReservation"
        Me.tpReservation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReservation.Size = New System.Drawing.Size(737, 411)
        Me.tpReservation.TabIndex = 3
        Me.tpReservation.Text = "Reservation"
        Me.tpReservation.UseVisualStyleBackColor = True
        '
        'frmCASetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(745, 439)
        Me.Controls.Add(Me.tcSetup)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCASetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "System Setup"
        Me.tcSetup.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcSetup As TabControl
    Friend WithEvents tpCompany As TabPage
    Friend WithEvents tpServer As TabPage
    Friend WithEvents tpInventory As TabPage
    Friend WithEvents tpReservation As TabPage
End Class
