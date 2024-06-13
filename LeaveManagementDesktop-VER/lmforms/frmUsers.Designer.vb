<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmUsers
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
        btnView = New Button()
        TextBoxSearch = New TextBox()
        txtSearch = New Label()
        tblUsers = New DataGridView()
        txtBalances = New Label()
        Label1 = New Label()
        btnFilterdept = New Button()
        Label3 = New Label()
        cmbDept = New ComboBox()
        btnLeavecard = New Button()
        btnHistory = New Button()
        txtLoading = New Label()
        btnDtr = New Button()
        CType(tblUsers, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' btnView
        ' 
        btnView.BackColor = Color.DeepPink
        btnView.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnView.Location = New Point(1127, 382)
        btnView.Margin = New Padding(2, 3, 2, 3)
        btnView.Name = "btnView"
        btnView.Size = New Size(137, 47)
        btnView.TabIndex = 16
        btnView.Text = "Employee Information"
        btnView.UseVisualStyleBackColor = False
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Location = New Point(892, 95)
        TextBoxSearch.Margin = New Padding(2, 3, 2, 3)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(208, 23)
        TextBoxSearch.TabIndex = 14
        ' 
        ' txtSearch
        ' 
        txtSearch.AutoSize = True
        txtSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        txtSearch.ForeColor = Color.DeepPink
        txtSearch.Location = New Point(831, 96)
        txtSearch.Margin = New Padding(2, 0, 2, 0)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(63, 20)
        txtSearch.TabIndex = 13
        txtSearch.Text = "Search: "
        ' 
        ' tblUsers
        ' 
        tblUsers.AllowUserToResizeRows = False
        tblUsers.BackgroundColor = Color.FloralWhite
        tblUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblUsers.Location = New Point(176, 134)
        tblUsers.Margin = New Padding(2, 3, 2, 3)
        tblUsers.Name = "tblUsers"
        tblUsers.RowHeadersWidth = 51
        tblUsers.RowTemplate.Height = 25
        tblUsers.Size = New Size(924, 535)
        tblUsers.TabIndex = 12
        ' 
        ' txtBalances
        ' 
        txtBalances.AutoSize = True
        txtBalances.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtBalances.ForeColor = Color.DeepPink
        txtBalances.Location = New Point(52, 39)
        txtBalances.Margin = New Padding(2, 0, 2, 0)
        txtBalances.Name = "txtBalances"
        txtBalances.Size = New Size(158, 32)
        txtBalances.TabIndex = 11
        txtBalances.Text = "Employees"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Narrow", 8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(889, 77)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 15)
        Label1.TabIndex = 18
        Label1.Text = "Lastname/ Department"
        ' 
        ' btnFilterdept
        ' 
        btnFilterdept.BackColor = Color.Yellow
        btnFilterdept.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFilterdept.ForeColor = SystemColors.MenuHighlight
        btnFilterdept.ImeMode = ImeMode.NoControl
        btnFilterdept.Location = New Point(303, 96)
        btnFilterdept.Margin = New Padding(2, 3, 2, 3)
        btnFilterdept.Name = "btnFilterdept"
        btnFilterdept.Size = New Size(29, 27)
        btnFilterdept.TabIndex = 39
        btnFilterdept.Text = "➜"
        btnFilterdept.UseVisualStyleBackColor = False
        btnFilterdept.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.DeepPink
        Label3.ImeMode = ImeMode.NoControl
        Label3.Location = New Point(176, 77)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(114, 15)
        Label3.TabIndex = 38
        Label3.Text = "Filter by department"
        Label3.Visible = False
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(176, 98)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(121, 23)
        cmbDept.TabIndex = 37
        cmbDept.Text = "Department"
        cmbDept.Visible = False
        ' 
        ' btnLeavecard
        ' 
        btnLeavecard.BackColor = Color.DeepPink
        btnLeavecard.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnLeavecard.Location = New Point(1127, 245)
        btnLeavecard.Margin = New Padding(2, 3, 2, 3)
        btnLeavecard.Name = "btnLeavecard"
        btnLeavecard.Size = New Size(137, 47)
        btnLeavecard.TabIndex = 58
        btnLeavecard.Text = "Leave Card"
        btnLeavecard.UseVisualStyleBackColor = False
        ' 
        ' btnHistory
        ' 
        btnHistory.BackColor = Color.DeepPink
        btnHistory.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnHistory.Location = New Point(1127, 313)
        btnHistory.Margin = New Padding(2, 3, 2, 3)
        btnHistory.Name = "btnHistory"
        btnHistory.Size = New Size(137, 47)
        btnHistory.TabIndex = 59
        btnHistory.Text = "Leave History"
        btnHistory.UseVisualStyleBackColor = False
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(578, 387)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 60
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' btnDtr
        ' 
        btnDtr.BackColor = Color.DeepPink
        btnDtr.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnDtr.Location = New Point(1127, 448)
        btnDtr.Margin = New Padding(2, 3, 2, 3)
        btnDtr.Name = "btnDtr"
        btnDtr.Size = New Size(137, 47)
        btnDtr.TabIndex = 61
        btnDtr.Text = "DTR Entry"
        btnDtr.UseVisualStyleBackColor = False
        btnDtr.Visible = False
        ' 
        ' frmUsers
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1370, 742)
        ControlBox = False
        Controls.Add(btnDtr)
        Controls.Add(txtLoading)
        Controls.Add(btnHistory)
        Controls.Add(btnLeavecard)
        Controls.Add(btnFilterdept)
        Controls.Add(Label3)
        Controls.Add(cmbDept)
        Controls.Add(Label1)
        Controls.Add(btnView)
        Controls.Add(TextBoxSearch)
        Controls.Add(txtSearch)
        Controls.Add(tblUsers)
        Controls.Add(txtBalances)
        ForeColor = SystemColors.ControlLightLight
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(2, 3, 2, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmUsers"
        StartPosition = FormStartPosition.CenterScreen
        CType(tblUsers, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnView As Button
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents txtSearch As Label
    Friend WithEvents tblUsers As DataGridView
    Friend WithEvents txtBalances As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnFilterdept As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents btnLeavecard As Button
    Friend WithEvents btnHistory As Button
    Friend WithEvents txtLoading As Label
    Friend WithEvents btnDtr As Button
End Class
