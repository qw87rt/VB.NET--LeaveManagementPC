<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBalances
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
        TextBoxSearch = New TextBox()
        txtSearch = New Label()
        tblBalances = New DataGridView()
        Label1 = New Label()
        txtBalances = New Label()
        btnView = New Button()
        txtLoading = New Label()
        btnFilterdept = New Button()
        Label3 = New Label()
        cmbDept = New ComboBox()
        CType(tblBalances, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Location = New Point(947, 137)
        TextBoxSearch.Margin = New Padding(2, 3, 2, 3)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(123, 23)
        TextBoxSearch.TabIndex = 8
        ' 
        ' txtSearch
        ' 
        txtSearch.AutoSize = True
        txtSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        txtSearch.ForeColor = Color.DeepPink
        txtSearch.Location = New Point(887, 135)
        txtSearch.Margin = New Padding(2, 0, 2, 0)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(63, 20)
        txtSearch.TabIndex = 7
        txtSearch.Text = "Search: "
        ' 
        ' tblBalances
        ' 
        tblBalances.AllowUserToResizeRows = False
        tblBalances.BackgroundColor = Color.FloralWhite
        tblBalances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblBalances.Location = New Point(328, 180)
        tblBalances.Margin = New Padding(2, 3, 2, 3)
        tblBalances.Name = "tblBalances"
        tblBalances.RowHeadersWidth = 51
        tblBalances.RowTemplate.Height = 25
        tblBalances.Size = New Size(742, 426)
        tblBalances.TabIndex = 6
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.DeepPink
        Label1.ImeMode = ImeMode.NoControl
        Label1.Location = New Point(947, 117)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(58, 15)
        Label1.TabIndex = 22
        Label1.Text = "Lastname"
        ' 
        ' txtBalances
        ' 
        txtBalances.AutoSize = True
        txtBalances.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtBalances.ForeColor = Color.DeepPink
        txtBalances.ImeMode = ImeMode.NoControl
        txtBalances.Location = New Point(242, 44)
        txtBalances.Margin = New Padding(2, 0, 2, 0)
        txtBalances.Name = "txtBalances"
        txtBalances.Size = New Size(165, 32)
        txtBalances.TabIndex = 23
        txtBalances.Text = "Leave Card"
        ' 
        ' btnView
        ' 
        btnView.BackColor = Color.DeepPink
        btnView.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnView.ForeColor = SystemColors.ControlLightLight
        btnView.ImeMode = ImeMode.NoControl
        btnView.Location = New Point(894, 625)
        btnView.Margin = New Padding(2, 3, 2, 3)
        btnView.Name = "btnView"
        btnView.Size = New Size(176, 42)
        btnView.TabIndex = 24
        btnView.Text = "View Leave Card"
        btnView.UseVisualStyleBackColor = False
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(695, 395)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 56
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' btnFilterdept
        ' 
        btnFilterdept.BackColor = Color.Yellow
        btnFilterdept.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFilterdept.ForeColor = SystemColors.MenuHighlight
        btnFilterdept.ImeMode = ImeMode.NoControl
        btnFilterdept.Location = New Point(454, 133)
        btnFilterdept.Margin = New Padding(2, 3, 2, 3)
        btnFilterdept.Name = "btnFilterdept"
        btnFilterdept.Size = New Size(29, 27)
        btnFilterdept.TabIndex = 63
        btnFilterdept.Text = "➜"
        btnFilterdept.UseVisualStyleBackColor = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.DeepPink
        Label3.ImeMode = ImeMode.NoControl
        Label3.Location = New Point(324, 117)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(114, 15)
        Label3.TabIndex = 62
        Label3.Text = "Filter by department"
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(326, 135)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(121, 23)
        cmbDept.TabIndex = 61
        cmbDept.Text = "Department"
        ' 
        ' frmBalances
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1360, 709)
        ControlBox = False
        Controls.Add(btnFilterdept)
        Controls.Add(Label3)
        Controls.Add(cmbDept)
        Controls.Add(txtLoading)
        Controls.Add(btnView)
        Controls.Add(txtBalances)
        Controls.Add(Label1)
        Controls.Add(TextBoxSearch)
        Controls.Add(txtSearch)
        Controls.Add(tblBalances)
        ForeColor = SystemColors.ControlLightLight
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(2, 3, 2, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmBalances"
        StartPosition = FormStartPosition.CenterScreen
        CType(tblBalances, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents txtSearch As Label
    Friend WithEvents tblBalances As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBalances As Label
    Friend WithEvents btnView As Button
    Friend WithEvents txtLoading As Label
    Friend WithEvents btnFilterdept As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDept As ComboBox
End Class
