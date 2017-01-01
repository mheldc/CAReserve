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
        Me.tpReserve = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.tcSetup.SuspendLayout()
        Me.tpReserve.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcSetup
        '
        Me.tcSetup.Controls.Add(Me.tpCompany)
        Me.tcSetup.Controls.Add(Me.tpServer)
        Me.tcSetup.Controls.Add(Me.tpInventory)
        Me.tcSetup.Controls.Add(Me.tpReserve)
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
        Me.tpCompany.Size = New System.Drawing.Size(737, 411)
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
        Me.tpServer.Size = New System.Drawing.Size(737, 411)
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
        Me.tpInventory.Size = New System.Drawing.Size(737, 411)
        Me.tpInventory.TabIndex = 2
        Me.tpInventory.Text = "Inventory"
        Me.tpInventory.UseVisualStyleBackColor = True
        '
        'tpReserve
        '
        Me.tpReserve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tpReserve.Controls.Add(Me.Panel2)
        Me.tpReserve.Controls.Add(Me.CheckBox2)
        Me.tpReserve.Controls.Add(Me.Panel1)
        Me.tpReserve.Controls.Add(Me.CheckBox1)
        Me.tpReserve.Location = New System.Drawing.Point(4, 24)
        Me.tpReserve.Name = "tpReserve"
        Me.tpReserve.Padding = New System.Windows.Forms.Padding(3)
        Me.tpReserve.Size = New System.Drawing.Size(737, 411)
        Me.tpReserve.TabIndex = 3
        Me.tpReserve.Text = "Reservation"
        Me.tpReserve.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TextBox2)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Location = New System.Drawing.Point(7, 27)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(722, 75)
        Me.Panel2.TabIndex = 12
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(198, 39)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(85, 23)
        Me.TextBox2.TabIndex = 8
        Me.TextBox2.Text = "0.00"
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Location = New System.Drawing.Point(4, 40)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(193, 19)
        Me.RadioButton2.TabIndex = 7
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Text = "Reservation fee amounting to P"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(186, 13)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(42, 23)
        Me.TextBox1.TabIndex = 6
        Me.TextBox1.Text = "100"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(4, 13)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(350, 19)
        Me.RadioButton1.TabIndex = 5
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Reservation fee amounting to                 % of room rate value."
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(7, 119)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(174, 19)
        Me.CheckBox2.TabIndex = 10
        Me.CheckBox2.Text = "Require Reservation Period"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.CheckBox4)
        Me.Panel1.Controls.Add(Me.CheckBox3)
        Me.Panel1.Location = New System.Drawing.Point(7, 140)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(722, 159)
        Me.Panel1.TabIndex = 11
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(106, 26)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(42, 23)
        Me.TextBox3.TabIndex = 8
        Me.TextBox3.Text = "1"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(3, 28)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(300, 19)
        Me.CheckBox4.TabIndex = 7
        Me.CheckBox4.Text = "Notify reservee                day prior to reserved date."
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(3, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(200, 19)
        Me.CheckBox3.TabIndex = 6
        Me.CheckBox3.Text = "Auto-cancel expired reservation"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(7, 6)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(156, 19)
        Me.CheckBox1.TabIndex = 9
        Me.CheckBox1.Text = "Require Reservation Fee"
        Me.CheckBox1.UseVisualStyleBackColor = True
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
        Me.tpReserve.ResumeLayout(False)
        Me.tpReserve.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tcSetup As TabControl
    Friend WithEvents tpCompany As TabPage
    Friend WithEvents tpServer As TabPage
    Friend WithEvents tpInventory As TabPage
    Friend WithEvents tpReserve As TabPage
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents CheckBox4 As CheckBox
    Friend WithEvents CheckBox3 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
End Class
