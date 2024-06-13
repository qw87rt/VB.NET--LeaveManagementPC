<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewuser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmViewuser))
        Label18 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Labell = New Label()
        txtLastname = New TextBox()
        txtPosition = New TextBox()
        txtPassword = New TextBox()
        txtUserid = New TextBox()
        txtSalary = New TextBox()
        txtVacation = New TextBox()
        txtSickleave = New TextBox()
        txtSpecial_privilege_leave = New TextBox()
        btnedit_save = New Button()
        Label10 = New Label()
        Label11 = New Label()
        txtFirstname = New TextBox()
        txtMiddlename = New TextBox()
        Label12 = New Label()
        txtContactnumber = New TextBox()
        txtForcedleave = New TextBox()
        txtSolo_parent_leave = New TextBox()
        Label13 = New Label()
        Label14 = New Label()
        cmbDept = New ComboBox()
        SuspendLayout()
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = Color.DeepPink
        Label18.Location = New Point(12, 13)
        Label18.Name = "Label18"
        Label18.Size = New Size(105, 32)
        Label18.TabIndex = 38
        Label18.Text = "Details"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.DeepPink
        Label3.Location = New Point(33, 73)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 17)
        Label3.TabIndex = 39
        Label3.Text = "Lastname:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DeepPink
        Label2.Location = New Point(22, 160)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 17)
        Label2.TabIndex = 40
        Label2.Text = "Office/Dept:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(392, 18)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(68, 17)
        Label1.TabIndex = 41
        Label1.Text = "User ID:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.DeepPink
        Label5.Location = New Point(329, 132)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(71, 17)
        Label5.TabIndex = 43
        Label5.Text = "Position:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.DeepPink
        Label4.Location = New Point(338, 164)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(60, 17)
        Label4.TabIndex = 42
        Label4.Text = "Salary:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.DeepPink
        Label6.Location = New Point(314, 102)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(85, 17)
        Label6.TabIndex = 44
        Label6.Text = "Password:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.DeepPink
        Label7.Location = New Point(127, 242)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 17)
        Label7.TabIndex = 45
        Label7.Text = "Vacation Leave:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.DeepPink
        Label8.Location = New Point(159, 272)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(93, 17)
        Label8.TabIndex = 46
        Label8.Text = "Sick Leave:"
        ' 
        ' Labell
        ' 
        Labell.AutoSize = True
        Labell.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Labell.ForeColor = Color.DeepPink
        Labell.Location = New Point(135, 303)
        Labell.Margin = New Padding(4, 0, 4, 0)
        Labell.Name = "Labell"
        Labell.Size = New Size(113, 17)
        Labell.TabIndex = 47
        Labell.Text = "Forced Leave:"
        ' 
        ' txtLastname
        ' 
        txtLastname.ForeColor = SystemColors.MenuHighlight
        txtLastname.Location = New Point(126, 71)
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(168, 23)
        txtLastname.TabIndex = 48
        ' 
        ' txtPosition
        ' 
        txtPosition.ForeColor = SystemColors.MenuHighlight
        txtPosition.Location = New Point(408, 130)
        txtPosition.Name = "txtPosition"
        txtPosition.Size = New Size(159, 23)
        txtPosition.TabIndex = 50
        ' 
        ' txtPassword
        ' 
        txtPassword.ForeColor = SystemColors.MenuHighlight
        txtPassword.Location = New Point(407, 101)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(160, 23)
        txtPassword.TabIndex = 51
        ' 
        ' txtUserid
        ' 
        txtUserid.ForeColor = SystemColors.MenuHighlight
        txtUserid.Location = New Point(467, 12)
        txtUserid.Name = "txtUserid"
        txtUserid.Size = New Size(100, 23)
        txtUserid.TabIndex = 52
        ' 
        ' txtSalary
        ' 
        txtSalary.ForeColor = SystemColors.MenuHighlight
        txtSalary.Location = New Point(409, 163)
        txtSalary.Name = "txtSalary"
        txtSalary.Size = New Size(158, 23)
        txtSalary.TabIndex = 53
        ' 
        ' txtVacation
        ' 
        txtVacation.ForeColor = SystemColors.MenuHighlight
        txtVacation.Location = New Point(266, 236)
        txtVacation.Name = "txtVacation"
        txtVacation.Size = New Size(166, 23)
        txtVacation.TabIndex = 54
        ' 
        ' txtSickleave
        ' 
        txtSickleave.ForeColor = SystemColors.MenuHighlight
        txtSickleave.Location = New Point(266, 271)
        txtSickleave.Name = "txtSickleave"
        txtSickleave.Size = New Size(166, 23)
        txtSickleave.TabIndex = 55
        ' 
        ' txtSpecial_privilege_leave
        ' 
        txtSpecial_privilege_leave.ForeColor = SystemColors.MenuHighlight
        txtSpecial_privilege_leave.Location = New Point(266, 330)
        txtSpecial_privilege_leave.Name = "txtSpecial_privilege_leave"
        txtSpecial_privilege_leave.Size = New Size(166, 23)
        txtSpecial_privilege_leave.TabIndex = 56
        ' 
        ' btnedit_save
        ' 
        btnedit_save.BackColor = Color.DeepPink
        btnedit_save.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnedit_save.ForeColor = SystemColors.ControlLightLight
        btnedit_save.Location = New Point(489, 408)
        btnedit_save.Name = "btnedit_save"
        btnedit_save.Size = New Size(86, 37)
        btnedit_save.TabIndex = 57
        btnedit_save.Text = "Edit"
        btnedit_save.UseVisualStyleBackColor = False
        btnedit_save.Visible = False
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.DeepPink
        Label10.Location = New Point(32, 101)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 17)
        Label10.TabIndex = 59
        Label10.Text = "Firstname:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.DeepPink
        Label11.Location = New Point(18, 129)
        Label11.Name = "Label11"
        Label11.Size = New Size(100, 17)
        Label11.TabIndex = 60
        Label11.Text = "Middlename:"
        ' 
        ' txtFirstname
        ' 
        txtFirstname.ForeColor = SystemColors.MenuHighlight
        txtFirstname.Location = New Point(126, 100)
        txtFirstname.Name = "txtFirstname"
        txtFirstname.Size = New Size(168, 23)
        txtFirstname.TabIndex = 61
        ' 
        ' txtMiddlename
        ' 
        txtMiddlename.ForeColor = SystemColors.MenuHighlight
        txtMiddlename.Location = New Point(126, 128)
        txtMiddlename.Name = "txtMiddlename"
        txtMiddlename.Size = New Size(168, 23)
        txtMiddlename.TabIndex = 62
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = Color.DeepPink
        Label12.Location = New Point(306, 73)
        Label12.Name = "Label12"
        Label12.Size = New Size(94, 17)
        Label12.TabIndex = 63
        Label12.Text = "Contact No:"
        ' 
        ' txtContactnumber
        ' 
        txtContactnumber.ForeColor = SystemColors.MenuHighlight
        txtContactnumber.Location = New Point(406, 71)
        txtContactnumber.Name = "txtContactnumber"
        txtContactnumber.Size = New Size(161, 23)
        txtContactnumber.TabIndex = 64
        ' 
        ' txtForcedleave
        ' 
        txtForcedleave.ForeColor = SystemColors.MenuHighlight
        txtForcedleave.Location = New Point(266, 301)
        txtForcedleave.Name = "txtForcedleave"
        txtForcedleave.Size = New Size(166, 23)
        txtForcedleave.TabIndex = 65
        ' 
        ' txtSolo_parent_leave
        ' 
        txtSolo_parent_leave.ForeColor = SystemColors.MenuHighlight
        txtSolo_parent_leave.Location = New Point(266, 359)
        txtSolo_parent_leave.Name = "txtSolo_parent_leave"
        txtSolo_parent_leave.Size = New Size(166, 23)
        txtSolo_parent_leave.TabIndex = 66
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.ForeColor = Color.DeepPink
        Label13.Location = New Point(120, 332)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(135, 17)
        Label13.TabIndex = 67
        Label13.Text = "Special Privilege:"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.ForeColor = Color.DeepPink
        Label14.Location = New Point(109, 360)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(146, 17)
        Label14.TabIndex = 68
        Label14.Text = "Solo Parent Leave:"
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(126, 161)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(167, 23)
        cmbDept.TabIndex = 95
        cmbDept.Text = " "
        ' 
        ' frmViewuser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(595, 463)
        Controls.Add(cmbDept)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(txtSolo_parent_leave)
        Controls.Add(txtForcedleave)
        Controls.Add(txtContactnumber)
        Controls.Add(Label12)
        Controls.Add(txtMiddlename)
        Controls.Add(txtFirstname)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(btnedit_save)
        Controls.Add(txtSpecial_privilege_leave)
        Controls.Add(txtSickleave)
        Controls.Add(txtVacation)
        Controls.Add(txtSalary)
        Controls.Add(txtUserid)
        Controls.Add(txtPassword)
        Controls.Add(txtPosition)
        Controls.Add(txtLastname)
        Controls.Add(Labell)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label18)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmViewuser"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Labell As Label
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents txtPosition As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtUserid As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents txtVacation As TextBox
    Friend WithEvents txtSickleave As TextBox
    Friend WithEvents txtSpecial_privilege_leave As TextBox
    Friend WithEvents btnedit_save As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents txtMiddlename As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtContactnumber As TextBox
    Friend WithEvents txtForcedleave As TextBox
    Friend WithEvents txtSolo_parent_leave As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbDept As ComboBox
End Class
