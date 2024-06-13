<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDTRentry
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
        txtPeriod = New TextBox()
        Label3 = New Label()
        txtParticulars = New TextBox()
        Label1 = New Label()
        txtVacleave_earned = New TextBox()
        Label2 = New Label()
        txtVactardy = New TextBox()
        Label4 = New Label()
        txtVacbal = New TextBox()
        Label5 = New Label()
        txtSickbal = New TextBox()
        Label6 = New Label()
        txtSicktardy = New TextBox()
        Label7 = New Label()
        txtSickleave_earned = New TextBox()
        Label8 = New Label()
        Label11 = New Label()
        Label9 = New Label()
        btnSave = New Button()
        txtName = New TextBox()
        txtSickWOP = New TextBox()
        Label10 = New Label()
        txtVacWOP = New TextBox()
        Label12 = New Label()
        SuspendLayout()
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label18.ForeColor = Color.DeepPink
        Label18.Location = New Point(29, 9)
        Label18.Name = "Label18"
        Label18.Size = New Size(223, 32)
        Label18.TabIndex = 38
        Label18.Text = "DTR Entry Form"
        ' 
        ' txtPeriod
        ' 
        txtPeriod.BackColor = SystemColors.Window
        txtPeriod.ForeColor = SystemColors.MenuHighlight
        txtPeriod.Location = New Point(138, 96)
        txtPeriod.Margin = New Padding(4)
        txtPeriod.Name = "txtPeriod"
        txtPeriod.Size = New Size(215, 23)
        txtPeriod.TabIndex = 40
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.ForeColor = Color.HotPink
        Label3.Location = New Point(78, 102)
        Label3.Margin = New Padding(4, 0, 4, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(61, 17)
        Label3.TabIndex = 39
        Label3.Text = "Period:"
        ' 
        ' txtParticulars
        ' 
        txtParticulars.BackColor = SystemColors.Window
        txtParticulars.ForeColor = SystemColors.MenuHighlight
        txtParticulars.Location = New Point(138, 128)
        txtParticulars.Margin = New Padding(4)
        txtParticulars.Name = "txtParticulars"
        txtParticulars.Size = New Size(215, 23)
        txtParticulars.TabIndex = 42
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.HotPink
        Label1.Location = New Point(45, 133)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(94, 17)
        Label1.TabIndex = 41
        Label1.Text = "Particulars:"
        ' 
        ' txtVacleave_earned
        ' 
        txtVacleave_earned.BackColor = SystemColors.Window
        txtVacleave_earned.ForeColor = SystemColors.MenuHighlight
        txtVacleave_earned.Location = New Point(183, 215)
        txtVacleave_earned.Margin = New Padding(4)
        txtVacleave_earned.Name = "txtVacleave_earned"
        txtVacleave_earned.Size = New Size(139, 23)
        txtVacleave_earned.TabIndex = 44
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.HotPink
        Label2.Location = New Point(101, 220)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 17)
        Label2.TabIndex = 43
        Label2.Text = "Earned:"
        ' 
        ' txtVactardy
        ' 
        txtVactardy.BackColor = SystemColors.Window
        txtVactardy.ForeColor = SystemColors.MenuHighlight
        txtVactardy.Location = New Point(183, 248)
        txtVactardy.Margin = New Padding(4)
        txtVactardy.Name = "txtVactardy"
        txtVactardy.Size = New Size(139, 23)
        txtVactardy.TabIndex = 46
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.HotPink
        Label4.Location = New Point(15, 251)
        Label4.Margin = New Padding(4, 0, 4, 0)
        Label4.Name = "Label4"
        Label4.Size = New Size(152, 17)
        Label4.TabIndex = 45
        Label4.Text = "UND/ TARDY/ LATE:"
        ' 
        ' txtVacbal
        ' 
        txtVacbal.BackColor = SystemColors.Window
        txtVacbal.ForeColor = SystemColors.MenuHighlight
        txtVacbal.Location = New Point(183, 308)
        txtVacbal.Margin = New Padding(4)
        txtVacbal.Name = "txtVacbal"
        txtVacbal.Size = New Size(139, 23)
        txtVacbal.TabIndex = 48
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.HotPink
        Label5.Location = New Point(94, 312)
        Label5.Margin = New Padding(4, 0, 4, 0)
        Label5.Name = "Label5"
        Label5.Size = New Size(73, 17)
        Label5.TabIndex = 47
        Label5.Text = "Balance:"
        ' 
        ' txtSickbal
        ' 
        txtSickbal.BackColor = SystemColors.Window
        txtSickbal.ForeColor = SystemColors.MenuHighlight
        txtSickbal.Location = New Point(546, 310)
        txtSickbal.Margin = New Padding(4)
        txtSickbal.Name = "txtSickbal"
        txtSickbal.Size = New Size(139, 23)
        txtSickbal.TabIndex = 54
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.ForeColor = Color.HotPink
        Label6.Location = New Point(471, 312)
        Label6.Margin = New Padding(4, 0, 4, 0)
        Label6.Name = "Label6"
        Label6.Size = New Size(73, 17)
        Label6.TabIndex = 53
        Label6.Text = "Balance:"
        ' 
        ' txtSicktardy
        ' 
        txtSicktardy.BackColor = SystemColors.Window
        txtSicktardy.ForeColor = SystemColors.MenuHighlight
        txtSicktardy.Location = New Point(546, 248)
        txtSicktardy.Margin = New Padding(4)
        txtSicktardy.Name = "txtSicktardy"
        txtSicktardy.Size = New Size(139, 23)
        txtSicktardy.TabIndex = 52
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.HotPink
        Label7.Location = New Point(420, 251)
        Label7.Margin = New Padding(4, 0, 4, 0)
        Label7.Name = "Label7"
        Label7.Size = New Size(122, 17)
        Label7.TabIndex = 51
        Label7.Text = "ABS/ UND/ W/P:"
        ' 
        ' txtSickleave_earned
        ' 
        txtSickleave_earned.BackColor = SystemColors.Window
        txtSickleave_earned.ForeColor = SystemColors.MenuHighlight
        txtSickleave_earned.Location = New Point(546, 214)
        txtSickleave_earned.Margin = New Padding(4)
        txtSickleave_earned.Name = "txtSickleave_earned"
        txtSickleave_earned.Size = New Size(139, 23)
        txtSickleave_earned.TabIndex = 50
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.HotPink
        Label8.Location = New Point(473, 216)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(66, 17)
        Label8.TabIndex = 49
        Label8.Text = "Earned:"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.ForeColor = Color.DeepPink
        Label11.Location = New Point(164, 172)
        Label11.Margin = New Padding(4, 0, 4, 0)
        Label11.Name = "Label11"
        Label11.Size = New Size(149, 22)
        Label11.TabIndex = 55
        Label11.Text = "Vacation Leave"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.ForeColor = Color.DeepPink
        Label9.Location = New Point(546, 173)
        Label9.Margin = New Padding(4, 0, 4, 0)
        Label9.Name = "Label9"
        Label9.Size = New Size(109, 22)
        Label9.TabIndex = 56
        Label9.Text = "Sick Leave"
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.Green
        btnSave.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnSave.ForeColor = SystemColors.ControlLightLight
        btnSave.Location = New Point(580, 364)
        btnSave.Margin = New Padding(4)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(105, 41)
        btnSave.TabIndex = 57
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        btnSave.Visible = False
        ' 
        ' txtName
        ' 
        txtName.BackColor = SystemColors.Window
        txtName.Enabled = False
        txtName.ForeColor = SystemColors.MenuHighlight
        txtName.Location = New Point(405, 42)
        txtName.Margin = New Padding(4)
        txtName.Name = "txtName"
        txtName.Size = New Size(280, 23)
        txtName.TabIndex = 59
        ' 
        ' txtSickWOP
        ' 
        txtSickWOP.BackColor = SystemColors.Window
        txtSickWOP.ForeColor = SystemColors.MenuHighlight
        txtSickWOP.Location = New Point(546, 279)
        txtSickWOP.Margin = New Padding(4)
        txtSickWOP.Name = "txtSickWOP"
        txtSickWOP.Size = New Size(139, 23)
        txtSickWOP.TabIndex = 63
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label10.ForeColor = Color.HotPink
        Label10.Location = New Point(400, 282)
        Label10.Margin = New Padding(4, 0, 4, 0)
        Label10.Name = "Label10"
        Label10.Size = New Size(144, 17)
        Label10.TabIndex = 62
        Label10.Text = "ABS. UND. W/O/P :"
        ' 
        ' txtVacWOP
        ' 
        txtVacWOP.BackColor = SystemColors.Window
        txtVacWOP.ForeColor = SystemColors.MenuHighlight
        txtVacWOP.Location = New Point(183, 279)
        txtVacWOP.Margin = New Padding(4)
        txtVacWOP.Name = "txtVacWOP"
        txtVacWOP.Size = New Size(139, 23)
        txtVacWOP.TabIndex = 61
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Font = New Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label12.ForeColor = Color.HotPink
        Label12.Location = New Point(23, 285)
        Label12.Margin = New Padding(4, 0, 4, 0)
        Label12.Name = "Label12"
        Label12.Size = New Size(144, 17)
        Label12.TabIndex = 60
        Label12.Text = "ABS. UND. W/O/P :"
        ' 
        ' frmDTRentry
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(721, 422)
        Controls.Add(txtSickWOP)
        Controls.Add(Label10)
        Controls.Add(txtVacWOP)
        Controls.Add(Label12)
        Controls.Add(txtName)
        Controls.Add(btnSave)
        Controls.Add(Label9)
        Controls.Add(Label11)
        Controls.Add(txtSickbal)
        Controls.Add(Label6)
        Controls.Add(txtSicktardy)
        Controls.Add(Label7)
        Controls.Add(txtSickleave_earned)
        Controls.Add(Label8)
        Controls.Add(txtVacbal)
        Controls.Add(Label5)
        Controls.Add(txtVactardy)
        Controls.Add(Label4)
        Controls.Add(txtVacleave_earned)
        Controls.Add(Label2)
        Controls.Add(txtParticulars)
        Controls.Add(Label1)
        Controls.Add(txtPeriod)
        Controls.Add(Label3)
        Controls.Add(Label18)
        ForeColor = Color.DeepPink
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmDTRentry"
        ShowIcon = False
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label18 As Label
    Friend WithEvents txtPeriod As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtParticulars As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtVacleave_earned As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtVactardy As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtVacbal As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSickbal As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtSicktardy As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSickleave_earned As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents btnSave As Button
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtSickWOP As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtVacWOP As TextBox
    Friend WithEvents Label12 As Label
End Class
