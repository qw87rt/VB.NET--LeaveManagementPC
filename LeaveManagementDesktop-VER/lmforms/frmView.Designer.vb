<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmView))
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label12 = New Label()
        Label13 = New Label()
        Label14 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        btnSet = New Button()
        btnApprove = New Button()
        btnDeny = New Button()
        txtRequestid = New TextBox()
        txtDepartment = New TextBox()
        txtName = New TextBox()
        txtPosition = New TextBox()
        txtSalary = New TextBox()
        txtDescription = New TextBox()
        txtDuration = New TextBox()
        txtInclusivedates = New TextBox()
        txtVacation = New TextBox()
        txtSickleave = New TextBox()
        txtDeductedvacation = New TextBox()
        txtDeductedsick = New TextBox()
        txtNetvacation = New TextBox()
        txtNetsick = New TextBox()
        Label17 = New Label()
        txtDatefiled = New TextBox()
        Label18 = New Label()
        btnEdit = New Button()
        cmbReasonid = New ComboBox()
        cmbLeaveid = New ComboBox()
        cmbCommutation = New ComboBox()
        btnRevert = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Italic, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(800, 19)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(129, 17)
        Label1.TabIndex = 0
        Label1.Text = "Control Number:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.HotPink
        Label2.Location = New Point(19, 126)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(95, 17)
        Label2.TabIndex = 1
        Label2.Text = "Office/Dept:"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.HotPink
        Label3.Location = New Point(63, 88)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(55, 17)
        Label3.TabIndex = 2
        Label3.Text = "Name:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.HotPink
        Label4.Location = New Point(49, 194)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(60, 17)
        Label4.TabIndex = 3
        Label4.Text = "Salary:"
        Label4.Visible = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.HotPink
        Label5.Location = New Point(40, 159)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(71, 17)
        Label5.TabIndex = 4
        Label5.Text = "Position:"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(626, 112)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(63, 17)
        Label6.TabIndex = 5
        Label6.Text = "Details:"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(577, 84)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(114, 17)
        Label7.TabIndex = 6
        Label7.Text = "Type of Leave:"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(607, 246)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(76, 17)
        Label8.TabIndex = 7
        Label8.Text = "Duration:"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(564, 207)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(124, 17)
        Label9.TabIndex = 8
        Label9.Text = "Inclusive Dates:"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.Location = New Point(572, 279)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(109, 17)
        Label10.TabIndex = 9
        Label10.Text = "Commutation:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.DeepPink
        Label11.Location = New Point(307, 312)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(136, 22)
        Label11.TabIndex = 10
        Label11.Text = "Leave Credits"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.Location = New Point(464, 356)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(120, 17)
        Label12.TabIndex = 11
        Label12.Text = "Vacation Leave"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Arial Rounded MT Bold", 11F, FontStyle.Regular, GraphicsUnit.Point)
        Label13.Location = New Point(622, 355)
        Label13.Margin = New Padding(4, 0, 4, 0)
        Label13.Name = "Label13"
        Label13.Size = New Size(88, 17)
        Label13.TabIndex = 12
        Label13.Text = "Sick Leave"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label14.Location = New Point(342, 398)
        Label14.Margin = New Padding(4, 0, 4, 0)
        Label14.Name = "Label14"
        Label14.Size = New Size(101, 17)
        Label14.TabIndex = 13
        Label14.Text = "Total Earned"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label15.Location = New Point(285, 431)
        Label15.Margin = New Padding(4, 0, 4, 0)
        Label15.Name = "Label15"
        Label15.Size = New Size(158, 17)
        Label15.TabIndex = 14
        Label15.Text = "Less this Application"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label16.Location = New Point(375, 465)
        Label16.Margin = New Padding(4, 0, 4, 0)
        Label16.Name = "Label16"
        Label16.Size = New Size(68, 17)
        Label16.TabIndex = 15
        Label16.Text = "Balance"
        ' 
        ' btnSet
        ' 
        btnSet.BackColor = Color.DeepPink
        btnSet.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSet.ForeColor = SystemColors.ControlLightLight
        btnSet.Location = New Point(720, 426)
        btnSet.Margin = New Padding(4)
        btnSet.Name = "btnSet"
        btnSet.Size = New Size(44, 27)
        btnSet.TabIndex = 16
        btnSet.Text = "Set"
        btnSet.UseVisualStyleBackColor = False
        btnSet.Visible = False
        ' 
        ' btnApprove
        ' 
        btnApprove.BackColor = Color.Green
        btnApprove.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnApprove.ForeColor = SystemColors.ControlLightLight
        btnApprove.Location = New Point(879, 504)
        btnApprove.Margin = New Padding(4)
        btnApprove.Name = "btnApprove"
        btnApprove.Size = New Size(161, 41)
        btnApprove.TabIndex = 17
        btnApprove.Text = "Approve"
        btnApprove.UseVisualStyleBackColor = False
        btnApprove.Visible = False
        ' 
        ' btnDeny
        ' 
        btnDeny.BackColor = Color.Red
        btnDeny.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnDeny.ForeColor = SystemColors.ControlLightLight
        btnDeny.Location = New Point(710, 504)
        btnDeny.Margin = New Padding(4)
        btnDeny.Name = "btnDeny"
        btnDeny.Size = New Size(161, 41)
        btnDeny.TabIndex = 18
        btnDeny.Text = "Deny"
        btnDeny.UseVisualStyleBackColor = False
        btnDeny.Visible = False
        ' 
        ' txtRequestid
        ' 
        txtRequestid.Location = New Point(960, 15)
        txtRequestid.Margin = New Padding(4)
        txtRequestid.Name = "txtRequestid"
        txtRequestid.Size = New Size(110, 26)
        txtRequestid.TabIndex = 19
        ' 
        ' txtDepartment
        ' 
        txtDepartment.BackColor = SystemColors.Window
        txtDepartment.ForeColor = SystemColors.MenuHighlight
        txtDepartment.Location = New Point(118, 122)
        txtDepartment.Margin = New Padding(4)
        txtDepartment.Name = "txtDepartment"
        txtDepartment.Size = New Size(389, 26)
        txtDepartment.TabIndex = 20
        ' 
        ' txtName
        ' 
        txtName.BackColor = SystemColors.Window
        txtName.ForeColor = SystemColors.MenuHighlight
        txtName.Location = New Point(119, 84)
        txtName.Margin = New Padding(4)
        txtName.Name = "txtName"
        txtName.Size = New Size(388, 26)
        txtName.TabIndex = 21
        ' 
        ' txtPosition
        ' 
        txtPosition.BackColor = SystemColors.Window
        txtPosition.ForeColor = SystemColors.MenuHighlight
        txtPosition.Location = New Point(116, 156)
        txtPosition.Margin = New Padding(4)
        txtPosition.Name = "txtPosition"
        txtPosition.Size = New Size(391, 26)
        txtPosition.TabIndex = 22
        ' 
        ' txtSalary
        ' 
        txtSalary.BackColor = SystemColors.Window
        txtSalary.ForeColor = SystemColors.MenuHighlight
        txtSalary.Location = New Point(116, 190)
        txtSalary.Margin = New Padding(4)
        txtSalary.Name = "txtSalary"
        txtSalary.Size = New Size(142, 26)
        txtSalary.TabIndex = 23
        txtSalary.Visible = False
        ' 
        ' txtDescription
        ' 
        txtDescription.BackColor = SystemColors.Window
        txtDescription.Font = New Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtDescription.ForeColor = SystemColors.MenuHighlight
        txtDescription.Location = New Point(695, 145)
        txtDescription.Margin = New Padding(4)
        txtDescription.Name = "txtDescription"
        txtDescription.Size = New Size(336, 23)
        txtDescription.TabIndex = 25
        ' 
        ' txtDuration
        ' 
        txtDuration.BackColor = SystemColors.Window
        txtDuration.ForeColor = SystemColors.MenuHighlight
        txtDuration.Location = New Point(696, 242)
        txtDuration.Margin = New Padding(4)
        txtDuration.Name = "txtDuration"
        txtDuration.Size = New Size(56, 26)
        txtDuration.TabIndex = 26
        ' 
        ' txtInclusivedates
        ' 
        txtInclusivedates.BackColor = SystemColors.Window
        txtInclusivedates.ForeColor = SystemColors.MenuHighlight
        txtInclusivedates.Location = New Point(696, 204)
        txtInclusivedates.Margin = New Padding(4)
        txtInclusivedates.Name = "txtInclusivedates"
        txtInclusivedates.Size = New Size(336, 26)
        txtInclusivedates.TabIndex = 27
        ' 
        ' txtVacation
        ' 
        txtVacation.BackColor = SystemColors.Window
        txtVacation.ForeColor = SystemColors.MenuHighlight
        txtVacation.Location = New Point(467, 394)
        txtVacation.Margin = New Padding(4)
        txtVacation.Name = "txtVacation"
        txtVacation.Size = New Size(105, 26)
        txtVacation.TabIndex = 29
        ' 
        ' txtSickleave
        ' 
        txtSickleave.BackColor = SystemColors.Window
        txtSickleave.ForeColor = SystemColors.MenuHighlight
        txtSickleave.Location = New Point(607, 394)
        txtSickleave.Margin = New Padding(4)
        txtSickleave.Name = "txtSickleave"
        txtSickleave.Size = New Size(105, 26)
        txtSickleave.TabIndex = 30
        ' 
        ' txtDeductedvacation
        ' 
        txtDeductedvacation.BackColor = SystemColors.Window
        txtDeductedvacation.ForeColor = SystemColors.MenuHighlight
        txtDeductedvacation.Location = New Point(467, 426)
        txtDeductedvacation.Margin = New Padding(4)
        txtDeductedvacation.Name = "txtDeductedvacation"
        txtDeductedvacation.Size = New Size(105, 26)
        txtDeductedvacation.TabIndex = 31
        ' 
        ' txtDeductedsick
        ' 
        txtDeductedsick.BackColor = SystemColors.Window
        txtDeductedsick.ForeColor = SystemColors.MenuHighlight
        txtDeductedsick.Location = New Point(607, 425)
        txtDeductedsick.Margin = New Padding(4)
        txtDeductedsick.Name = "txtDeductedsick"
        txtDeductedsick.Size = New Size(105, 26)
        txtDeductedsick.TabIndex = 32
        ' 
        ' txtNetvacation
        ' 
        txtNetvacation.BackColor = SystemColors.Window
        txtNetvacation.ForeColor = SystemColors.MenuHighlight
        txtNetvacation.Location = New Point(467, 458)
        txtNetvacation.Margin = New Padding(4)
        txtNetvacation.Name = "txtNetvacation"
        txtNetvacation.Size = New Size(105, 26)
        txtNetvacation.TabIndex = 33
        ' 
        ' txtNetsick
        ' 
        txtNetsick.BackColor = SystemColors.Window
        txtNetsick.ForeColor = SystemColors.MenuHighlight
        txtNetsick.Location = New Point(608, 456)
        txtNetsick.Margin = New Padding(4)
        txtNetsick.Name = "txtNetsick"
        txtNetsick.Size = New Size(105, 26)
        txtNetsick.TabIndex = 34
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label17.ForeColor = Color.HotPink
        Label17.Location = New Point(785, 242)
        Label17.Margin = New Padding(4, 0, 4, 0)
        Label17.Name = "Label17"
        Label17.Size = New Size(86, 17)
        Label17.TabIndex = 35
        Label17.Text = "Date Filed:"
        ' 
        ' txtDatefiled
        ' 
        txtDatefiled.BackColor = SystemColors.Window
        txtDatefiled.ForeColor = SystemColors.MenuHighlight
        txtDatefiled.Location = New Point(879, 242)
        txtDatefiled.Margin = New Padding(4)
        txtDatefiled.Name = "txtDatefiled"
        txtDatefiled.Size = New Size(152, 26)
        txtDatefiled.TabIndex = 36
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = Color.DeepPink
        Label18.Location = New Point(38, 19)
        Label18.Name = "Label18"
        Label18.Size = New Size(209, 32)
        Label18.TabIndex = 37
        Label18.Text = "Leave Request"
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.DeepPink
        btnEdit.ForeColor = SystemColors.ButtonHighlight
        btnEdit.Location = New Point(934, 310)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(97, 28)
        btnEdit.TabIndex = 38
        btnEdit.Text = "Edit"
        btnEdit.UseVisualStyleBackColor = False
        btnEdit.Visible = False
        ' 
        ' cmbReasonid
        ' 
        cmbReasonid.Enabled = False
        cmbReasonid.ForeColor = SystemColors.MenuHighlight
        cmbReasonid.FormattingEnabled = True
        cmbReasonid.Location = New Point(696, 112)
        cmbReasonid.Name = "cmbReasonid"
        cmbReasonid.Size = New Size(335, 26)
        cmbReasonid.TabIndex = 39
        ' 
        ' cmbLeaveid
        ' 
        cmbLeaveid.Enabled = False
        cmbLeaveid.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        cmbLeaveid.ForeColor = SystemColors.MenuHighlight
        cmbLeaveid.FormattingEnabled = True
        cmbLeaveid.Location = New Point(696, 80)
        cmbLeaveid.Name = "cmbLeaveid"
        cmbLeaveid.Size = New Size(336, 25)
        cmbLeaveid.TabIndex = 40
        ' 
        ' cmbCommutation
        ' 
        cmbCommutation.Enabled = False
        cmbCommutation.ForeColor = SystemColors.MenuHighlight
        cmbCommutation.FormattingEnabled = True
        cmbCommutation.Location = New Point(695, 275)
        cmbCommutation.Name = "cmbCommutation"
        cmbCommutation.Size = New Size(335, 26)
        cmbCommutation.TabIndex = 41
        ' 
        ' btnRevert
        ' 
        btnRevert.BackColor = Color.Red
        btnRevert.ForeColor = SystemColors.ButtonHighlight
        btnRevert.Location = New Point(953, 504)
        btnRevert.Name = "btnRevert"
        btnRevert.Size = New Size(90, 40)
        btnRevert.TabIndex = 42
        btnRevert.Text = "Revert"
        btnRevert.UseVisualStyleBackColor = False
        btnRevert.Visible = False
        ' 
        ' frmView
        ' 
        AutoScaleDimensions = New SizeF(10F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Window
        ClientSize = New Size(1076, 572)
        Controls.Add(btnRevert)
        Controls.Add(cmbCommutation)
        Controls.Add(cmbLeaveid)
        Controls.Add(cmbReasonid)
        Controls.Add(btnEdit)
        Controls.Add(Label18)
        Controls.Add(txtDatefiled)
        Controls.Add(Label17)
        Controls.Add(txtNetsick)
        Controls.Add(txtNetvacation)
        Controls.Add(txtDeductedsick)
        Controls.Add(txtDeductedvacation)
        Controls.Add(txtSickleave)
        Controls.Add(txtVacation)
        Controls.Add(txtInclusivedates)
        Controls.Add(txtDuration)
        Controls.Add(txtDescription)
        Controls.Add(txtSalary)
        Controls.Add(txtPosition)
        Controls.Add(txtName)
        Controls.Add(txtDepartment)
        Controls.Add(txtRequestid)
        Controls.Add(btnDeny)
        Controls.Add(btnApprove)
        Controls.Add(btnSet)
        Controls.Add(Label16)
        Controls.Add(Label15)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ForeColor = Color.HotPink
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmView"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        TopMost = True
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents btnSet As Button
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnDeny As Button
    Friend WithEvents txtRequestid As TextBox
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtPosition As TextBox
    Friend WithEvents txtSalary As TextBox
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents txtDuration As TextBox
    Friend WithEvents txtInclusivedates As TextBox
    Friend WithEvents txtVacation As TextBox
    Friend WithEvents txtSickleave As TextBox
    Friend WithEvents txtDeductedvacation As TextBox
    Friend WithEvents txtDeductedsick As TextBox
    Friend WithEvents txtNetvacation As TextBox
    Friend WithEvents txtNetsick As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtDatefiled As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents btnEdit As Button
    Friend WithEvents cmbReasonid As ComboBox
    Friend WithEvents cmbLeaveid As ComboBox
    Friend WithEvents cmbCommutation As ComboBox
    Friend WithEvents btnRevert As Button
End Class
