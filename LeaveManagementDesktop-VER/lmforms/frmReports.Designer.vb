<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReports
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReports))
        txtPending = New Label()
        btnFilterdept = New Button()
        Label3 = New Label()
        cmbDept = New ComboBox()
        btnFilter = New Button()
        Label1 = New Label()
        cmbMonth = New ComboBox()
        cmbYear = New ComboBox()
        Label2 = New Label()
        TextBoxSearch = New TextBox()
        txtSearch = New Label()
        tblReports = New DataGridView()
        txtLoading = New Label()
        CType(tblReports, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' txtPending
        ' 
        txtPending.AutoSize = True
        txtPending.BackColor = Color.Transparent
        txtPending.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtPending.ForeColor = Color.DeepPink
        txtPending.ImeMode = ImeMode.NoControl
        txtPending.Location = New Point(37, 48)
        txtPending.Margin = New Padding(2, 0, 2, 0)
        txtPending.Name = "txtPending"
        txtPending.Size = New Size(224, 32)
        txtPending.TabIndex = 2
        txtPending.Text = "Leave Requests"
        ' 
        ' btnFilterdept
        ' 
        btnFilterdept.BackColor = Color.Yellow
        btnFilterdept.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFilterdept.ForeColor = SystemColors.MenuHighlight
        btnFilterdept.ImeMode = ImeMode.NoControl
        btnFilterdept.Location = New Point(632, 109)
        btnFilterdept.Margin = New Padding(2, 3, 2, 3)
        btnFilterdept.Name = "btnFilterdept"
        btnFilterdept.Size = New Size(28, 28)
        btnFilterdept.TabIndex = 43
        btnFilterdept.Text = "➜"
        btnFilterdept.UseVisualStyleBackColor = False
        btnFilterdept.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.ForeColor = Color.DeepPink
        Label3.ImeMode = ImeMode.NoControl
        Label3.Location = New Point(503, 93)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(114, 15)
        Label3.TabIndex = 42
        Label3.Text = "Filter by department"
        Label3.Visible = False
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(505, 111)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(121, 23)
        cmbDept.TabIndex = 41
        cmbDept.Text = "Department"
        cmbDept.Visible = False
        ' 
        ' btnFilter
        ' 
        btnFilter.BackColor = Color.Yellow
        btnFilter.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFilter.ForeColor = SystemColors.MenuHighlight
        btnFilter.Location = New Point(393, 107)
        btnFilter.Margin = New Padding(2, 3, 2, 3)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(28, 27)
        btnFilter.TabIndex = 40
        btnFilter.Text = "➜"
        btnFilter.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.ForeColor = Color.DeepPink
        Label1.ImeMode = ImeMode.NoControl
        Label1.Location = New Point(141, 93)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(101, 15)
        Label1.TabIndex = 39
        Label1.Text = "Filter by date filed"
        ' 
        ' cmbMonth
        ' 
        cmbMonth.ForeColor = Color.DeepPink
        cmbMonth.FormattingEnabled = True
        cmbMonth.Location = New Point(267, 109)
        cmbMonth.Margin = New Padding(2, 3, 2, 3)
        cmbMonth.Name = "cmbMonth"
        cmbMonth.Size = New Size(121, 23)
        cmbMonth.TabIndex = 38
        cmbMonth.Text = "Month"
        ' 
        ' cmbYear
        ' 
        cmbYear.ForeColor = Color.DeepPink
        cmbYear.FormattingEnabled = True
        cmbYear.Location = New Point(141, 110)
        cmbYear.Margin = New Padding(2, 3, 2, 3)
        cmbYear.Name = "cmbYear"
        cmbYear.Size = New Size(121, 23)
        cmbYear.TabIndex = 37
        cmbYear.Text = "Year"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.DeepPink
        Label2.ImeMode = ImeMode.NoControl
        Label2.Location = New Point(1039, 88)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(58, 15)
        Label2.TabIndex = 46
        Label2.Text = "Lastname"
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Location = New Point(1039, 111)
        TextBoxSearch.Margin = New Padding(2, 3, 2, 3)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(163, 23)
        TextBoxSearch.TabIndex = 45
        ' 
        ' txtSearch
        ' 
        txtSearch.AutoSize = True
        txtSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        txtSearch.ForeColor = Color.DeepPink
        txtSearch.ImeMode = ImeMode.NoControl
        txtSearch.Location = New Point(975, 111)
        txtSearch.Margin = New Padding(2, 0, 2, 0)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(63, 20)
        txtSearch.TabIndex = 44
        txtSearch.Text = "Search: "
        ' 
        ' tblReports
        ' 
        tblReports.AllowUserToResizeRows = False
        tblReports.BackgroundColor = Color.FloralWhite
        tblReports.BorderStyle = BorderStyle.Fixed3D
        tblReports.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblReports.EnableHeadersVisualStyles = False
        tblReports.GridColor = Color.Gold
        tblReports.Location = New Point(137, 151)
        tblReports.Margin = New Padding(2, 3, 2, 3)
        tblReports.Name = "tblReports"
        tblReports.ReadOnly = True
        tblReports.RowHeadersWidth = 51
        tblReports.RowTemplate.Height = 25
        tblReports.Size = New Size(1065, 487)
        tblReports.TabIndex = 47
        tblReports.VirtualMode = True
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(536, 363)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 56
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' frmReports
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1350, 676)
        ControlBox = False
        Controls.Add(txtLoading)
        Controls.Add(tblReports)
        Controls.Add(Label2)
        Controls.Add(TextBoxSearch)
        Controls.Add(txtSearch)
        Controls.Add(btnFilterdept)
        Controls.Add(Label3)
        Controls.Add(cmbDept)
        Controls.Add(btnFilter)
        Controls.Add(Label1)
        Controls.Add(cmbMonth)
        Controls.Add(cmbYear)
        Controls.Add(txtPending)
        ForeColor = Color.DeepPink
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmReports"
        StartPosition = FormStartPosition.CenterScreen
        CType(tblReports, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtPending As Label
    Friend WithEvents btnFilterdept As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents btnFilter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents txtSearch As Label
    Friend WithEvents tblReports As DataGridView
    Friend WithEvents txtLoading As Label
End Class
