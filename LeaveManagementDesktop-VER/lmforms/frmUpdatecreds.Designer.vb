<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUpdatecreds
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            ' Dispose of the CancellationTokenSource if it exists
            If cts IsNot Nothing Then
                cts.Dispose()
                cts = Nothing
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
        Label18 = New Label()
        Label14 = New Label()
        Label13 = New Label()
        txtSolo_parent_leave = New TextBox()
        txtForcedleave = New TextBox()
        btnDone = New Button()
        btnedit_save = New Button()
        txtSpecial_privilege_leave = New TextBox()
        txtSickleave = New TextBox()
        txtVacation = New TextBox()
        Labell = New Label()
        Label8 = New Label()
        Label7 = New Label()
        SuspendLayout()
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = Color.DeepPink
        Label18.Location = New Point(5, 4)
        Label18.Name = "Label18"
        Label18.Size = New Size(197, 32)
        Label18.TabIndex = 65
        Label18.Text = "Leave Credits"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.ForeColor = Color.DeepPink
        Label14.Location = New Point(42, 166)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(146, 17)
        Label14.TabIndex = 95
        Label14.Text = "Solo Parent Leave:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.ForeColor = Color.DeepPink
        Label13.Location = New Point(53, 138)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(135, 17)
        Label13.TabIndex = 94
        Label13.Text = "Special Privilege:"
        ' 
        ' txtSolo_parent_leave
        ' 
        txtSolo_parent_leave.ForeColor = SystemColors.MenuHighlight
        txtSolo_parent_leave.Location = New Point(199, 165)
        txtSolo_parent_leave.Name = "txtSolo_parent_leave"
        txtSolo_parent_leave.Size = New Size(166, 23)
        txtSolo_parent_leave.TabIndex = 93
        ' 
        ' txtForcedleave
        ' 
        txtForcedleave.ForeColor = SystemColors.MenuHighlight
        txtForcedleave.Location = New Point(199, 107)
        txtForcedleave.Name = "txtForcedleave"
        txtForcedleave.Size = New Size(166, 23)
        txtForcedleave.TabIndex = 92
        ' 
        ' btnDone
        ' 
        btnDone.BackColor = Color.DeepPink
        btnDone.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnDone.ForeColor = SystemColors.ControlLightLight
        btnDone.Location = New Point(279, 210)
        btnDone.Name = "btnDone"
        btnDone.Size = New Size(86, 37)
        btnDone.TabIndex = 91
        btnDone.Text = "Close"
        btnDone.UseVisualStyleBackColor = False
        ' 
        ' btnedit_save
        ' 
        btnedit_save.BackColor = Color.DeepPink
        btnedit_save.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnedit_save.ForeColor = SystemColors.ControlLightLight
        btnedit_save.Location = New Point(181, 210)
        btnedit_save.Name = "btnedit_save"
        btnedit_save.Size = New Size(86, 37)
        btnedit_save.TabIndex = 90
        btnedit_save.Text = "Edit"
        btnedit_save.UseVisualStyleBackColor = False
        ' 
        ' txtSpecial_privilege_leave
        ' 
        txtSpecial_privilege_leave.ForeColor = SystemColors.MenuHighlight
        txtSpecial_privilege_leave.Location = New Point(199, 136)
        txtSpecial_privilege_leave.Name = "txtSpecial_privilege_leave"
        txtSpecial_privilege_leave.Size = New Size(166, 23)
        txtSpecial_privilege_leave.TabIndex = 89
        ' 
        ' txtSickleave
        ' 
        txtSickleave.ForeColor = SystemColors.MenuHighlight
        txtSickleave.Location = New Point(199, 77)
        txtSickleave.Name = "txtSickleave"
        txtSickleave.Size = New Size(166, 23)
        txtSickleave.TabIndex = 88
        ' 
        ' txtVacation
        ' 
        txtVacation.ForeColor = SystemColors.MenuHighlight
        txtVacation.Location = New Point(199, 44)
        txtVacation.Name = "txtVacation"
        txtVacation.Size = New Size(166, 23)
        txtVacation.TabIndex = 87
        ' 
        ' Labell
        ' 
        Labell.AutoSize = True
        Labell.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Labell.ForeColor = Color.DeepPink
        Labell.Location = New Point(68, 109)
        Labell.Margin = New Padding(4, 0, 4, 0)
        Labell.Name = "Labell"
        Labell.Size = New Size(113, 17)
        Labell.TabIndex = 86
        Labell.Text = "Forced Leave:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.DeepPink
        Label8.Location = New Point(92, 78)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(93, 17)
        Label8.TabIndex = 85
        Label8.Text = "Sick Leave:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.DeepPink
        Label7.Location = New Point(60, 50)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 17)
        Label7.TabIndex = 84
        Label7.Text = "Vacation Leave:"
        ' 
        ' frmUpdatecreds
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(397, 276)
        ControlBox = False
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(txtSolo_parent_leave)
        Controls.Add(txtForcedleave)
        Controls.Add(btnDone)
        Controls.Add(btnedit_save)
        Controls.Add(txtSpecial_privilege_leave)
        Controls.Add(txtSickleave)
        Controls.Add(txtVacation)
        Controls.Add(Labell)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label18)
        FormBorderStyle = FormBorderStyle.Fixed3D
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmUpdatecreds"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Label18 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtSolo_parent_leave As TextBox
    Friend WithEvents txtForcedleave As TextBox
    Friend WithEvents btnDone As Button
    Friend WithEvents btnedit_save As Button
    Friend WithEvents txtSpecial_privilege_leave As TextBox
    Friend WithEvents txtSickleave As TextBox
    Friend WithEvents txtVacation As TextBox
    Friend WithEvents Labell As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
End Class
