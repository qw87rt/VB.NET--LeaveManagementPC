<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPending
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPending))
        tblPending = New DataGridView()
        txtPending = New Label()
        TextBoxSearch = New TextBox()
        docLeavereq = New Printing.PrintDocument()
        previewLeavereq = New PrintPreviewDialog()
        printdialogLeavereq = New PrintDialog()
        PageSetupDialog1 = New PageSetupDialog()
        Label1 = New Label()
        btnPrint = New Button()
        pagesetup = New Button()
        btnView = New Button()
        print = New Button()
        btnFilterdept = New Button()
        Label2 = New Label()
        cmbDept = New ComboBox()
        txtSearch = New Label()
        txtLoading = New Label()
        CType(tblPending, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tblPending
        ' 
        tblPending.AllowUserToAddRows = False
        tblPending.AllowUserToDeleteRows = False
        tblPending.AllowUserToResizeRows = False
        tblPending.BackgroundColor = Color.FloralWhite
        tblPending.BorderStyle = BorderStyle.Fixed3D
        tblPending.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblPending.EnableHeadersVisualStyles = False
        tblPending.GridColor = Color.Gold
        resources.ApplyResources(tblPending, "tblPending")
        tblPending.Name = "tblPending"
        tblPending.ReadOnly = True
        tblPending.RowTemplate.Height = 25
        tblPending.VirtualMode = True
        ' 
        ' txtPending
        ' 
        resources.ApplyResources(txtPending, "txtPending")
        txtPending.BackColor = Color.Transparent
        txtPending.ForeColor = Color.DeepPink
        txtPending.Name = "txtPending"
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.ForeColor = Color.DeepPink
        resources.ApplyResources(TextBoxSearch, "TextBoxSearch")
        TextBoxSearch.Name = "TextBoxSearch"
        ' 
        ' docLeavereq
        ' 
        ' 
        ' previewLeavereq
        ' 
        resources.ApplyResources(previewLeavereq, "previewLeavereq")
        previewLeavereq.Document = docLeavereq
        previewLeavereq.Name = "PrintPreviewDialog1"
        ' 
        ' printdialogLeavereq
        ' 
        printdialogLeavereq.UseEXDialog = True
        ' 
        ' Label1
        ' 
        resources.ApplyResources(Label1, "Label1")
        Label1.BackColor = Color.Transparent
        Label1.ForeColor = Color.DeepPink
        Label1.Name = "Label1"
        ' 
        ' btnPrint
        ' 
        btnPrint.BackColor = Color.DeepPink
        resources.ApplyResources(btnPrint, "btnPrint")
        btnPrint.ForeColor = SystemColors.ControlLightLight
        btnPrint.Name = "btnPrint"
        btnPrint.UseVisualStyleBackColor = False
        ' 
        ' pagesetup
        ' 
        pagesetup.BackColor = Color.DeepPink
        resources.ApplyResources(pagesetup, "pagesetup")
        pagesetup.ForeColor = SystemColors.ControlLightLight
        pagesetup.Name = "pagesetup"
        pagesetup.UseVisualStyleBackColor = False
        ' 
        ' btnView
        ' 
        btnView.BackColor = Color.DeepPink
        resources.ApplyResources(btnView, "btnView")
        btnView.ForeColor = SystemColors.ControlLightLight
        btnView.Name = "btnView"
        btnView.UseVisualStyleBackColor = False
        ' 
        ' print
        ' 
        print.BackColor = Color.DeepPink
        resources.ApplyResources(print, "print")
        print.ForeColor = SystemColors.ControlLightLight
        print.Name = "print"
        print.UseVisualStyleBackColor = False
        ' 
        ' btnFilterdept
        ' 
        btnFilterdept.BackColor = Color.Yellow
        resources.ApplyResources(btnFilterdept, "btnFilterdept")
        btnFilterdept.ForeColor = SystemColors.MenuHighlight
        btnFilterdept.Name = "btnFilterdept"
        btnFilterdept.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        resources.ApplyResources(Label2, "Label2")
        Label2.BackColor = Color.Transparent
        Label2.ForeColor = Color.DeepPink
        Label2.Name = "Label2"
        ' 
        ' cmbDept
        ' 
        cmbDept.ForeColor = Color.DeepPink
        cmbDept.FormattingEnabled = True
        resources.ApplyResources(cmbDept, "cmbDept")
        cmbDept.Name = "cmbDept"
        ' 
        ' txtSearch
        ' 
        resources.ApplyResources(txtSearch, "txtSearch")
        txtSearch.ForeColor = Color.DeepPink
        txtSearch.Name = "txtSearch"
        ' 
        ' txtLoading
        ' 
        resources.ApplyResources(txtLoading, "txtLoading")
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.Name = "txtLoading"
        ' 
        ' frmPending
        ' 
        resources.ApplyResources(Me, "$this")
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ControlBox = False
        Controls.Add(txtLoading)
        Controls.Add(txtSearch)
        Controls.Add(btnFilterdept)
        Controls.Add(Label2)
        Controls.Add(cmbDept)
        Controls.Add(print)
        Controls.Add(btnView)
        Controls.Add(pagesetup)
        Controls.Add(btnPrint)
        Controls.Add(Label1)
        Controls.Add(TextBoxSearch)
        Controls.Add(txtPending)
        Controls.Add(tblPending)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmPending"
        CType(tblPending, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tblPending As DataGridView
    Friend WithEvents txtPending As Label
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents docLeavereq As Printing.PrintDocument
    Friend WithEvents previewLeavereq As PrintPreviewDialog
    Friend WithEvents printdialogLeavereq As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents btnPrint As Button
    Friend WithEvents pagesetup As Button
    Friend WithEvents btnView As Button
    Friend WithEvents print As Button
    Friend WithEvents btnFilterdept As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbDept As ComboBox
    Friend WithEvents txtSearch As Label
    Friend WithEvents txtLoading As Label
End Class
