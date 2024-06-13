<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRegistadmin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmRegistadmin))
        Label1 = New Label()
        txtContactnumber = New TextBox()
        Label12 = New Label()
        txtMiddlename = New TextBox()
        txtFirstname = New TextBox()
        Label11 = New Label()
        Label10 = New Label()
        txtPassword = New TextBox()
        txtLastname = New TextBox()
        Label6 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        cmbAccesslevel = New ComboBox()
        btnCancel = New Button()
        btnSave = New Button()
        cmbDept = New ComboBox()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FloralWhite
        Label1.Font = New Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(28, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(149, 37)
        Label1.TabIndex = 0
        Label1.Text = "Register"
        ' 
        ' txtContactnumber
        ' 
        txtContactnumber.Location = New Point(257, 225)
        txtContactnumber.Name = "txtContactnumber"
        txtContactnumber.Size = New Size(190, 23)
        txtContactnumber.TabIndex = 81
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.FloralWhite
        Label12.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = Color.DeepPink
        Label12.Location = New Point(108, 226)
        Label12.Name = "Label12"
        Label12.Size = New Size(132, 17)
        Label12.TabIndex = 76
        Label12.Text = "Contact Number:"
        ' 
        ' txtMiddlename
        ' 
        txtMiddlename.Location = New Point(255, 144)
        txtMiddlename.Name = "txtMiddlename"
        txtMiddlename.Size = New Size(189, 23)
        txtMiddlename.TabIndex = 79
        ' 
        ' txtFirstname
        ' 
        txtFirstname.Location = New Point(255, 112)
        txtFirstname.Name = "txtFirstname"
        txtFirstname.Size = New Size(189, 23)
        txtFirstname.TabIndex = 78
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.BackColor = Color.FloralWhite
        Label11.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.DeepPink
        Label11.Location = New Point(108, 146)
        Label11.Name = "Label11"
        Label11.Size = New Size(100, 17)
        Label11.TabIndex = 75
        Label11.Text = "Middlename:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.BackColor = Color.FloralWhite
        Label10.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.DeepPink
        Label10.Location = New Point(108, 119)
        Label10.Name = "Label10"
        Label10.Size = New Size(86, 17)
        Label10.TabIndex = 74
        Label10.Text = "Firstname:"
        ' 
        ' txtPassword
        ' 
        txtPassword.Location = New Point(256, 173)
        txtPassword.Name = "txtPassword"
        txtPassword.Size = New Size(189, 23)
        txtPassword.TabIndex = 80
        ' 
        ' txtLastname
        ' 
        txtLastname.Location = New Point(256, 83)
        txtLastname.Name = "txtLastname"
        txtLastname.Size = New Size(189, 23)
        txtLastname.TabIndex = 77
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.BackColor = Color.FloralWhite
        Label6.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.DeepPink
        Label6.Location = New Point(108, 174)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(85, 17)
        Label6.TabIndex = 73
        Label6.Text = "Password:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.FloralWhite
        Label2.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DeepPink
        Label2.Location = New Point(108, 255)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 17)
        Label2.TabIndex = 72
        Label2.Text = "Office/Dept:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FloralWhite
        Label3.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.DeepPink
        Label3.Location = New Point(110, 84)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(84, 17)
        Label3.TabIndex = 71
        Label3.Text = "Lastname:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.BackColor = Color.FloralWhite
        Label4.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.DeepPink
        Label4.Location = New Point(110, 283)
        Label4.Name = "Label4"
        Label4.Size = New Size(110, 17)
        Label4.TabIndex = 70
        Label4.Text = "Access Level:"
        ' 
        ' cmbAccesslevel
        ' 
        cmbAccesslevel.FormattingEnabled = True
        cmbAccesslevel.Location = New Point(256, 281)
        cmbAccesslevel.Name = "cmbAccesslevel"
        cmbAccesslevel.Size = New Size(63, 23)
        cmbAccesslevel.TabIndex = 83
        ' 
        ' btnCancel
        ' 
        btnCancel.BackColor = Color.DeepPink
        btnCancel.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnCancel.ForeColor = SystemColors.ControlLightLight
        btnCancel.Location = New Point(479, 350)
        btnCancel.Name = "btnCancel"
        btnCancel.Size = New Size(86, 37)
        btnCancel.TabIndex = 85
        btnCancel.Text = "Cancel"
        btnCancel.UseVisualStyleBackColor = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.DeepPink
        btnSave.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSave.ForeColor = SystemColors.ControlLightLight
        btnSave.Location = New Point(382, 350)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(86, 37)
        btnSave.TabIndex = 84
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(257, 254)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(191, 23)
        cmbDept.TabIndex = 95
        cmbDept.Text = " "
        ' 
        ' frmRegistadmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(592, 413)
        Controls.Add(cmbDept)
        Controls.Add(btnCancel)
        Controls.Add(btnSave)
        Controls.Add(cmbAccesslevel)
        Controls.Add(Label4)
        Controls.Add(txtContactnumber)
        Controls.Add(Label12)
        Controls.Add(txtMiddlename)
        Controls.Add(txtFirstname)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(txtPassword)
        Controls.Add(txtLastname)
        Controls.Add(Label6)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label1)
        ForeColor = Color.DeepPink
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmRegistadmin"
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents txtContactnumber As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtMiddlename As TextBox
    Friend WithEvents txtFirstname As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents txtLastname As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cmbAccesslevel As ComboBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents cmbDept As ComboBox
End Class
