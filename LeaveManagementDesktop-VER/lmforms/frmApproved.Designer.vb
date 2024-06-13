<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApproved
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApproved))
        Label1 = New Label()
        cmbMonth = New ComboBox()
        cmbYear = New ComboBox()
        TextBoxSearch = New TextBox()
        txtSearch = New Label()
        txtPending = New Label()
        tblApproved = New DataGridView()
        docLeavereq = New Printing.PrintDocument()
        previewLeavereq = New PrintPreviewDialog()
        printdialogLeavereq = New PrintDialog()
        PageSetupDialog1 = New PageSetupDialog()
        btnFilter = New Button()
        Label2 = New Label()
        btnView = New Button()
        btnFilterdept = New Button()
        Label3 = New Label()
        cmbDept = New ComboBox()
        btnPrint = New Button()
        print = New Button()
        pagesetup = New Button()
        txtLoading = New Label()
        CType(tblApproved, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.DeepPink
        Label1.ImeMode = ImeMode.NoControl
        Label1.Location = New Point(51, 89)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(101, 15)
        Label1.TabIndex = 20
        Label1.Text = "Filter by date filed"
        ' 
        ' cmbMonth
        ' 
        cmbMonth.ForeColor = Color.DeepPink
        cmbMonth.FormattingEnabled = True
        cmbMonth.Location = New Point(177, 108)
        cmbMonth.Margin = New Padding(2, 3, 2, 3)
        cmbMonth.Name = "cmbMonth"
        cmbMonth.Size = New Size(121, 23)
        cmbMonth.TabIndex = 19
        cmbMonth.Text = "Month"
        ' 
        ' cmbYear
        ' 
        cmbYear.ForeColor = Color.DeepPink
        cmbYear.FormattingEnabled = True
        cmbYear.Location = New Point(51, 109)
        cmbYear.Margin = New Padding(2, 3, 2, 3)
        cmbYear.Name = "cmbYear"
        cmbYear.Size = New Size(121, 23)
        cmbYear.TabIndex = 18
        cmbYear.Text = "Year"
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Location = New Point(962, 108)
        TextBoxSearch.Margin = New Padding(2, 3, 2, 3)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(163, 23)
        TextBoxSearch.TabIndex = 17
        ' 
        ' txtSearch
        ' 
        txtSearch.AutoSize = True
        txtSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        txtSearch.ForeColor = Color.DeepPink
        txtSearch.ImeMode = ImeMode.NoControl
        txtSearch.Location = New Point(898, 108)
        txtSearch.Margin = New Padding(2, 0, 2, 0)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(63, 20)
        txtSearch.TabIndex = 16
        txtSearch.Text = "Search: "
        ' 
        ' txtPending
        ' 
        txtPending.AutoSize = True
        txtPending.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtPending.ForeColor = Color.DeepPink
        txtPending.ImeMode = ImeMode.NoControl
        txtPending.Location = New Point(35, 34)
        txtPending.Margin = New Padding(2, 0, 2, 0)
        txtPending.Name = "txtPending"
        txtPending.Size = New Size(274, 32)
        txtPending.TabIndex = 15
        txtPending.Text = "Approved Requests"
        ' 
        ' tblApproved
        ' 
        tblApproved.AllowUserToResizeRows = False
        tblApproved.BackgroundColor = Color.FloralWhite
        tblApproved.BorderStyle = BorderStyle.Fixed3D
        tblApproved.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblApproved.EnableHeadersVisualStyles = False
        tblApproved.GridColor = Color.Gold
        tblApproved.Location = New Point(51, 146)
        tblApproved.Margin = New Padding(2, 3, 2, 3)
        tblApproved.Name = "tblApproved"
        tblApproved.ReadOnly = True
        tblApproved.RowHeadersWidth = 51
        tblApproved.RowTemplate.Height = 25
        tblApproved.Size = New Size(1074, 502)
        tblApproved.TabIndex = 14
        tblApproved.VirtualMode = True
        ' 
        ' docLeavereq
        ' 
        ' 
        ' previewLeavereq
        ' 
        previewLeavereq.AutoScrollMargin = New Size(0, 0)
        previewLeavereq.AutoScrollMinSize = New Size(0, 0)
        previewLeavereq.ClientSize = New Size(400, 300)
        previewLeavereq.Document = docLeavereq
        previewLeavereq.Enabled = True
        previewLeavereq.Icon = CType(resources.GetObject("previewLeavereq.Icon"), Icon)
        previewLeavereq.Name = "PrintPreviewDialog1"
        previewLeavereq.Visible = False
        ' 
        ' printdialogLeavereq
        ' 
        printdialogLeavereq.UseEXDialog = True
        ' 
        ' btnFilter
        ' 
        btnFilter.BackColor = Color.Yellow
        btnFilter.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFilter.ForeColor = SystemColors.MenuHighlight
        btnFilter.Location = New Point(302, 105)
        btnFilter.Margin = New Padding(2, 3, 2, 3)
        btnFilter.Name = "btnFilter"
        btnFilter.Size = New Size(30, 29)
        btnFilter.TabIndex = 26
        btnFilter.Text = "➜"
        btnFilter.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.ForeColor = Color.DeepPink
        Label2.ImeMode = ImeMode.NoControl
        Label2.Location = New Point(962, 85)
        Label2.Margin = New Padding(2, 0, 2, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(91, 15)
        Label2.TabIndex = 28
        Label2.Text = "Lastname/ Dept"
        ' 
        ' btnView
        ' 
        btnView.BackColor = Color.DeepPink
        btnView.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnView.ForeColor = SystemColors.ControlLightLight
        btnView.ImeMode = ImeMode.NoControl
        btnView.Location = New Point(1167, 243)
        btnView.Margin = New Padding(2, 3, 2, 3)
        btnView.Name = "btnView"
        btnView.Size = New Size(141, 57)
        btnView.TabIndex = 32
        btnView.Text = "Manage Leave"
        btnView.UseVisualStyleBackColor = False
        ' 
        ' btnFilterdept
        ' 
        btnFilterdept.BackColor = Color.Yellow
        btnFilterdept.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnFilterdept.ForeColor = SystemColors.MenuHighlight
        btnFilterdept.ImeMode = ImeMode.NoControl
        btnFilterdept.Location = New Point(544, 106)
        btnFilterdept.Margin = New Padding(2, 3, 2, 3)
        btnFilterdept.Name = "btnFilterdept"
        btnFilterdept.Size = New Size(34, 29)
        btnFilterdept.TabIndex = 36
        btnFilterdept.Text = "➜"
        btnFilterdept.UseVisualStyleBackColor = False
        btnFilterdept.Visible = False
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.ForeColor = Color.DeepPink
        Label3.ImeMode = ImeMode.NoControl
        Label3.Location = New Point(413, 90)
        Label3.Margin = New Padding(2, 0, 2, 0)
        Label3.Name = "Label3"
        Label3.Size = New Size(114, 15)
        Label3.TabIndex = 35
        Label3.Text = "Filter by department"
        Label3.Visible = False
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        cmbDept.Location = New Point(415, 110)
        cmbDept.Margin = New Padding(2, 3, 2, 3)
        cmbDept.Name = "cmbDept"
        cmbDept.Size = New Size(121, 23)
        cmbDept.TabIndex = 34
        cmbDept.Text = "Department"
        cmbDept.Visible = False
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.DeepPink
        btnPrint.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnPrint.ForeColor = SystemColors.ControlLightLight
        btnPrint.ImeMode = ImeMode.NoControl
        btnPrint.Location = New Point(1167, 332)
        btnPrint.Margin = New Padding(2, 3, 2, 3)
        btnPrint.Name = "btnPrint"
        btnPrint.Size = New Size(141, 57)
        btnPrint.TabIndex = 54
        btnPrint.Text = "Print Preview"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' print
        ' 
        print.BackColor = Color.DeepPink
        print.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        print.ForeColor = SystemColors.ControlLightLight
        print.ImeMode = ImeMode.NoControl
        print.Location = New Point(1167, 414)
        print.Margin = New Padding(2, 3, 2, 3)
        print.Name = "print"
        print.Size = New Size(141, 57)
        print.TabIndex = 53
        print.Text = "Print"
        print.UseVisualStyleBackColor = False
        ' 
        ' pagesetup
        ' 
        pagesetup.BackColor = Color.DeepPink
        pagesetup.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        pagesetup.ForeColor = SystemColors.ControlLightLight
        pagesetup.ImeMode = ImeMode.NoControl
        pagesetup.Location = New Point(1167, 492)
        pagesetup.Margin = New Padding(2, 3, 2, 3)
        pagesetup.Name = "pagesetup"
        pagesetup.Size = New Size(141, 57)
        pagesetup.TabIndex = 52
        pagesetup.Text = "Page Setup"
        pagesetup.UseVisualStyleBackColor = False
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(563, 370)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 55
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' frmApproved
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1370, 742)
        ControlBox = False
        Controls.Add(txtLoading)
        Controls.Add(btnPrint)
        Controls.Add(print)
        Controls.Add(pagesetup)
        Controls.Add(btnFilterdept)
        Controls.Add(Label3)
        Controls.Add(cmbDept)
        Controls.Add(btnView)
        Controls.Add(Label2)
        Controls.Add(btnFilter)
        Controls.Add(Label1)
        Controls.Add(cmbMonth)
        Controls.Add(cmbYear)
        Controls.Add(TextBoxSearch)
        Controls.Add(txtSearch)
        Controls.Add(txtPending)
        Controls.Add(tblApproved)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(2, 3, 2, 3)
        Name = "frmApproved"
        StartPosition = FormStartPosition.CenterScreen
        CType(tblApproved, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbMonth As ComboBox
    Friend WithEvents cmbYear As ComboBox
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents txtSearch As Label
    Friend WithEvents txtPending As Label
    Friend WithEvents tblApproved As DataGridView
    Friend WithEvents docLeavereq As Printing.PrintDocument
    Friend WithEvents previewLeavereq As PrintPreviewDialog
    Friend WithEvents printdialogLeavereq As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents btnFilter As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btnView As Button
    Friend WithEvents btnFilterdept As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents btnPrint As Button
    Friend WithEvents print As Button
    Friend WithEvents pagesetup As Button
    Friend WithEvents txtLoading As Label
End Class
