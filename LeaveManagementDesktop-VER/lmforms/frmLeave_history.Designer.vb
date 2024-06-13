<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmLeave_history
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeave_history))
        tblHistory = New DataGridView()
        txtLoading = New Label()
        txtPending = New Label()
        docLeavereq = New Printing.PrintDocument()
        previewLeavereq = New PrintPreviewDialog()
        printdialogLeavereq = New PrintDialog()
        PageSetupDialog1 = New PageSetupDialog()
        txtName = New Label()
        CType(tblHistory, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tblHistory
        ' 
        tblHistory.AllowUserToResizeRows = False
        tblHistory.BackgroundColor = Color.FloralWhite
        tblHistory.BorderStyle = BorderStyle.Fixed3D
        tblHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblHistory.EnableHeadersVisualStyles = False
        tblHistory.GridColor = Color.Gold
        tblHistory.Location = New Point(52, 108)
        tblHistory.Margin = New Padding(2, 3, 2, 3)
        tblHistory.Name = "tblHistory"
        tblHistory.ReadOnly = True
        tblHistory.RowHeadersWidth = 51
        tblHistory.RowTemplate.Height = 25
        tblHistory.Size = New Size(493, 435)
        tblHistory.TabIndex = 48
        tblHistory.VirtualMode = True
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(195, 291)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 58
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' txtPending
        ' 
        txtPending.AutoSize = True
        txtPending.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtPending.ForeColor = Color.DeepPink
        txtPending.ImeMode = ImeMode.NoControl
        txtPending.Location = New Point(22, 27)
        txtPending.Margin = New Padding(2, 0, 2, 0)
        txtPending.Name = "txtPending"
        txtPending.Size = New Size(196, 32)
        txtPending.TabIndex = 59
        txtPending.Text = "Leave History"
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
        ' txtName
        ' 
        txtName.AutoSize = True
        txtName.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtName.ForeColor = Color.DeepPink
        txtName.ImeMode = ImeMode.NoControl
        txtName.Location = New Point(52, 76)
        txtName.Name = "txtName"
        txtName.Size = New Size(13, 19)
        txtName.TabIndex = 60
        txtName.Text = " "
        ' 
        ' frmLeave_history
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(604, 643)
        Controls.Add(txtName)
        Controls.Add(txtPending)
        Controls.Add(txtLoading)
        Controls.Add(tblHistory)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLeave_history"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        CType(tblHistory, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tblHistory As DataGridView
    Friend WithEvents txtLoading As Label
    Friend WithEvents txtPending As Label
    Friend WithEvents docLeavereq As Printing.PrintDocument
    Friend WithEvents previewLeavereq As PrintPreviewDialog
    Friend WithEvents printdialogLeavereq As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents txtName As Label
End Class
