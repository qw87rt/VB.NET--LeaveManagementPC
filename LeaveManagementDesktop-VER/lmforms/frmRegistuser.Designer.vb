<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistuser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistuser))
        txtContactnumber = New TextBox()
        Label12 = New Label()
        txtMiddlename = New TextBox()
        txtFirstname = New TextBox()
        Label11 = New Label()
        Label10 = New Label()
        txtSpecialpriv = New TextBox()
        txtSickleave = New TextBox()
        txtVacation = New TextBox()
        txtSalary = New TextBox()
        txtPosition = New TextBox()
        txtLastname = New TextBox()
        Label9 = New Label()
        Label8 = New Label()
        Label7 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        btnCancel = New Button()
        btnSave = New Button()
        Label1 = New Label()
        Label13 = New Label()
        txtForcedleave = New TextBox()
        txtSoloparent = New TextBox()
        Label18 = New Label()
        cmbDept = New ComboBox()
        SuspendLayout()
        ' 
        ' txtContactnumber
        ' 
        txtContactnumber.Location = New Point(555, 168)
        txtContactnumber.Name = "txtContactnumber"
        txtContactnumber.Size = New Size(191, 23)
        txtContactnumber.TabIndex = 86
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = Color.DeepPink
        Label12.Location = New Point(400, 171)
        Label12.Name = "Label12"
        Label12.Size = New Size(132, 17)
        Label12.TabIndex = 78
        Label12.Text = "Contact Number:"
        ' 
        ' txtMiddlename
        ' 
        txtMiddlename.Location = New Point(162, 137)
        txtMiddlename.Name = "txtMiddlename"
        txtMiddlename.Size = New Size(189, 23)
        txtMiddlename.TabIndex = 81
        ' 
        ' txtFirstname
        ' 
        txtFirstname.Location = New Point(162, 101)
        txtFirstname.Name = "txtFirstname"
        txtFirstname.Size = New Size(189, 23)
        txtFirstname.TabIndex = 80
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.DeepPink
        Label11.Location = New Point(53, 137)
        Label11.Name = "Label11"
        Label11.Size = New Size(100, 17)
        Label11.TabIndex = 77
        Label11.Text = "Middlename:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.DeepPink
        Label10.Location = New Point(53, 108)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 17)
        Label10.TabIndex = 76
        Label10.Text = "Firstname:"
        ' 
        ' txtSpecialpriv
        ' 
        txtSpecialpriv.Location = New Point(366, 283)
        txtSpecialpriv.Name = "txtSpecialpriv"
        txtSpecialpriv.Size = New Size(166, 23)
        txtSpecialpriv.TabIndex = 89
        ' 
        ' txtSickleave
        ' 
        txtSickleave.Location = New Point(366, 254)
        txtSickleave.Name = "txtSickleave"
        txtSickleave.Size = New Size(166, 23)
        txtSickleave.TabIndex = 88
        ' 
        ' txtVacation
        ' 
        txtVacation.Location = New Point(366, 224)
        txtVacation.Name = "txtVacation"
        txtVacation.Size = New Size(166, 23)
        txtVacation.TabIndex = 87
        ' 
        ' txtSalary
        ' 
        txtSalary.Location = New Point(555, 139)
        txtSalary.Name = "txtSalary"
        txtSalary.Size = New Size(191, 23)
        txtSalary.TabIndex = 85
        ' 
        ' txtPosition
        ' 
        txtPosition.Location = New Point(554, 108)
        txtPosition.Name = "txtPosition"
        txtPosition.Size = New Size(192, 23)
        txtPosition.TabIndex = 84
        ' 
        ' txtLastname
        ' 
        txtLastname.Location = New Point(162, 72)
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(189, 23)
        txtLastname.TabIndex = 79
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.ForeColor = Color.DeepPink
        Label9.Location = New Point(203, 283)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(135, 17)
        Label9.TabIndex = 75
        Label9.Text = "Special Privilege:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.DeepPink
        Label8.Location = New Point(203, 254)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(93, 17)
        Label8.TabIndex = 74
        Label8.Text = "Sick Leave:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.DeepPink
        Label7.Location = New Point(203, 225)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 17)
        Label7.TabIndex = 73
        Label7.Text = "Vacation Leave:"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.DeepPink
        Label5.Location = New Point(400, 108)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(71, 17)
        Label5.TabIndex = 71
        Label5.Text = "Position:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.DeepPink
        Label4.Location = New Point(400, 139)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(60, 17)
        Label4.TabIndex = 70
        Label4.Text = "Salary:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DeepPink
        Label2.Location = New Point(400, 73)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 17)
        Label2.TabIndex = 69
        Label2.Text = "Office/Dept:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.DeepPink
        Label3.Location = New Point(53, 78)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 17)
        Label3.TabIndex = 68
        Label3.Text = "Lastname:"
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.DeepPink
        btnCancel.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(687, 386)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(86, 37)
        btnCancel.TabIndex = 93
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.DeepPink
        btnSave.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSave.ForeColor = SystemColors.ControlLightLight
        btnSave.Location = New Point(586, 387)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(86, 37)
        btnSave.TabIndex = 92
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(203, 313)
        Label1.Name = "Label1"
        Label1.Size = New Size(113, 17)
        Label1.TabIndex = 67
        Label1.Text = "Forced Leave:"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.ForeColor = Color.DeepPink
        Label13.Location = New Point(203, 342)
        Label13.Name = "Label13"
        Label13.Size = New Size(146, 17)
        Label13.TabIndex = 66
        Label13.Text = "Solo Parent Leave:"
        ' 
        ' txtForcedleave
        ' 
        txtForcedleave.Location = New Point(366, 312)
        txtForcedleave.Name = "txtForcedleave"
        txtForcedleave.Size = New Size(166, 23)
        txtForcedleave.TabIndex = 90
        ' 
        ' txtSoloparent
        ' 
        txtSoloparent.Location = New Point(366, 341)
        txtSoloparent.Name = "txtSoloparent"
        txtSoloparent.Size = New Size(166, 23)
        txtSoloparent.TabIndex = 91
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = Color.DeepPink
        Label18.Location = New Point(22, 22)
        Label18.Name = "Label18"
        Label18.Size = New Size(126, 32)
        Label18.TabIndex = 65
        Label18.Text = "Register"
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(554, 77)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(191, 23)
        cmbDept.TabIndex = 94
        cmbDept.Text = " "
        ' 
        ' frmRegistuser
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(800, 450)
        Controls.Add(cmbDept)
        Controls.Add(Label18)
        Controls.Add(txtSoloparent)
        Controls.Add(txtForcedleave)
        Controls.Add(Label13)
        Controls.Add(Label1)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(txtContactnumber)
        Controls.Add(Label12)
        Controls.Add(txtMiddlename)
        Controls.Add(txtFirstname)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(txtSpecialpriv)
        Controls.Add(txtSickleave)
        Controls.Add(txtVacation)
        Controls.Add(txtSalary)
        Controls.Add(txtPosition)
        Controls.Add(txtLastname)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label3)
        ForeColor = SystemColors.ControlLightLight
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmRegistuser"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtContactnumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMiddlename As TextBox
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtSpecialpriv As TextBox
    Friend WithEvents txtSickleave As TextBox
    Friend WithEvents txtVacation As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents txtPosition As TextBox
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtForcedleave As TextBox
    Friend WithEvents txtSoloparent As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents Panel1 As Panel
End Class
