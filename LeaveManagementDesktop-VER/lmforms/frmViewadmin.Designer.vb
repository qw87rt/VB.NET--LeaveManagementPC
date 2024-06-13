<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmViewadmin
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
        cmbDept = New ComboBox()
        txtContactnumber = New TextBox()
        Label12 = New Label()
        txtMiddlename = New TextBox()
        txtFirstname = New TextBox()
        Label11 = New Label()
        Label10 = New Label()
        txtAdminid = New TextBox()
        txtPassword = New TextBox()
        txtLastname = New TextBox()
        Label6 = New Label()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label18 = New Label()
        btnedit_save = New Button()
        Label4 = New Label()
        cmbAccess_level = New ComboBox()
        SuspendLayout()
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(461, 125)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(167, 23)
        cmbDept.TabIndex = 114
        cmbDept.Text = " "
        ' 
        ' txtContactnumber
        ' 
        txtContactnumber.ForeColor = SystemColors.MenuHighlight
        txtContactnumber.Location = New Point(124, 227)
        txtContactnumber.Name = "txtContactnumber"
        txtContactnumber.Size = New Size(167, 23)
        txtContactnumber.TabIndex = 113
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = Color.DeepPink
        Label12.Location = New Point(24, 229)
        Label12.Name = "Label12"
        Label12.Size = New Size(94, 17)
        Label12.TabIndex = 112
        Label12.Text = "Contact No:"
        ' 
        ' txtMiddlename
        ' 
        txtMiddlename.ForeColor = SystemColors.MenuHighlight
        txtMiddlename.Location = New Point(126, 196)
        txtMiddlename.Name = "txtMiddlename"
        txtMiddlename.Size = New Size(168, 23)
        txtMiddlename.TabIndex = 111
        ' 
        ' txtFirstname
        ' 
        txtFirstname.ForeColor = SystemColors.MenuHighlight
        txtFirstname.Location = New Point(126, 162)
        txtFirstname.Name = "txtFirstname"
        txtFirstname.Size = New Size(168, 23)
        txtFirstname.TabIndex = 110
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.DeepPink
        Label11.Location = New Point(18, 197)
        Label11.Name = "Label11"
        Label11.Size = New Size(100, 17)
        Label11.TabIndex = 109
        Label11.Text = "Middlename:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.DeepPink
        Label10.Location = New Point(32, 163)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 17)
        Label10.TabIndex = 108
        Label10.Text = "Firstname:"
        ' 
        ' txtAdminid
        ' 
        txtAdminid.ForeColor = SystemColors.MenuHighlight
        txtAdminid.Location = New Point(528, 56)
        txtAdminid.Name = "txtAdminid"
        txtAdminid.Size = New Size(100, 23)
        txtAdminid.TabIndex = 106
        ' 
        ' txtPassword
        ' 
        txtPassword.ForeColor = SystemColors.MenuHighlight
        txtPassword.Location = New Point(462, 196)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(166, 23)
        txtPassword.TabIndex = 105
        ' 
        ' txtLastname
        ' 
        txtLastname.ForeColor = SystemColors.MenuHighlight
        txtLastname.Location = New Point(126, 127)
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(168, 23)
        txtLastname.TabIndex = 103
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.DeepPink
        Label6.Location = New Point(369, 197)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(85, 17)
        Label6.TabIndex = 102
        Label6.Text = "Password:"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(453, 62)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(79, 17)
        Label1.TabIndex = 99
        Label1.Text = "Admin ID:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DeepPink
        Label2.Location = New Point(357, 124)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 17)
        Label2.TabIndex = 98
        Label2.Text = "Office/Dept:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.DeepPink
        Label3.Location = New Point(33, 129)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 17)
        Label3.TabIndex = 97
        Label3.Text = "Lastname:"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = Color.DeepPink
        Label18.Location = New Point(18, 24)
        Label18.Name = "Label18"
        Label18.Size = New Size(105, 32)
        Label18.TabIndex = 96
        Label18.Text = "Details"
        ' 
        ' btnedit_save
        ' 
        btnedit_save.BackColor = Color.DeepPink
        btnedit_save.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnedit_save.ForeColor = SystemColors.ControlLightLight
        btnedit_save.Location = New Point(528, 269)
        btnedit_save.Name = "btnedit_save"
        btnedit_save.Size = New Size(86, 37)
        btnedit_save.TabIndex = 115
        btnedit_save.Text = "Edit"
        btnedit_save.UseVisualStyleBackColor = False
        btnedit_save.Visible = False
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.DeepPink
        Label4.Location = New Point(351, 170)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 17)
        Label4.TabIndex = 116
        Label4.Text = "Access Level:"
        ' 
        ' cmbAccess_level
        ' 
        cmbAccess_level.ForeColor = Color.DeepPink
        cmbAccess_level.FormattingEnabled = True
        cmbAccess_level.Location = New Point(462, 164)
        cmbAccess_level.Margin = New Padding(2, 3, 2, 3)
        cmbAccess_level.Name = "cmbAccess_level"
        cmbAccess_level.Size = New Size(167, 23)
        cmbAccess_level.TabIndex = 117
        cmbAccess_level.Text = " "
        ' 
        ' frmViewadmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(664, 341)
        Controls.Add(cmbAccess_level)
        Controls.Add(Label4)
        Controls.Add(btnedit_save)
        Controls.Add(cmbDept)
        Controls.Add(txtContactnumber)
        Controls.Add(Label12)
        Controls.Add(txtMiddlename)
        Controls.Add(txtFirstname)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(txtAdminid)
        Controls.Add(txtPassword)
        Controls.Add(txtLastname)
        Controls.Add(Label6)
        Controls.Add(Label1)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label18)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmViewadmin"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents txtContactnumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMiddlename As TextBox
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtAdminid As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents btnedit_save As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbAccess_level As ComboBox
End Class
