<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLeavecard
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLeavecard))
        tblLeavecard = New DataGridView()
        Label1 = New Label()
        Label2 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        pagesetup = New Button()
        print = New Button()
        btnPreview = New Button()
        docLeavereq = New Printing.PrintDocument()
        previewLeavereq = New PrintPreviewDialog()
        printdialogLeavereq = New PrintDialog()
        PageSetupDialog1 = New PageSetupDialog()
        txtName = New TextBox()
        txtDepartment = New TextBox()
        btnEdit = New Button()
        btnSave = New Button()
        btnCredits = New Button()
        txtLoading = New Label()
        Button1 = New Button()
        CType(tblLeavecard, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' tblLeavecard
        ' 
        tblLeavecard.AllowUserToAddRows = False
        tblLeavecard.AllowUserToDeleteRows = False
        tblLeavecard.AllowUserToResizeRows = False
        tblLeavecard.BackgroundColor = Color.FloralWhite
        tblLeavecard.BorderStyle = BorderStyle.Fixed3D
        tblLeavecard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        tblLeavecard.EditMode = DataGridViewEditMode.EditOnEnter
        tblLeavecard.EnableHeadersVisualStyles = False
        tblLeavecard.GridColor = Color.Teal
        tblLeavecard.Location = New Point(30, 160)
        tblLeavecard.Name = "tblLeavecard"
        tblLeavecard.RowHeadersWidth = 51
        tblLeavecard.RowTemplate.Height = 25
        tblLeavecard.Size = New Size(1280, 464)
        tblLeavecard.TabIndex = 15
        tblLeavecard.VirtualMode = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(27, 76)
        Label1.Name = "Label1"
        Label1.Size = New Size(74, 22)
        Label1.TabIndex = 16
        Label1.Text = "Name: "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DeepPink
        Label2.Location = New Point(387, 81)
        Label2.Name = "Label2"
        Label2.Size = New Size(146, 22)
        Label2.TabIndex = 17
        Label2.Text = "Division/Office:"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.DeepPink
        Label4.Location = New Point(472, 121)
        Label4.Name = "Label4"
        Label4.Size = New Size(181, 22)
        Label4.TabIndex = 19
        Label4.Text = "VACATION LEAVE"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.DeepPink
        Label5.Location = New Point(851, 121)
        Label5.Name = "Label5"
        Label5.Size = New Size(126, 22)
        Label5.TabIndex = 20
        Label5.Text = "SICK LEAVE"
        ' 
        ' pagesetup
        ' 
        pagesetup.BackColor = Color.DeepPink
        pagesetup.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        pagesetup.ForeColor = SystemColors.ControlLightLight
        pagesetup.ImeMode = ImeMode.NoControl
        pagesetup.Location = New Point(1179, 80)
        pagesetup.Name = "pagesetup"
        pagesetup.Size = New Size(79, 57)
        pagesetup.TabIndex = 27
        pagesetup.Text = "Page Setup"
        pagesetup.UseVisualStyleBackColor = False
        ' 
        ' print
        ' 
        print.BackColor = Color.DeepPink
        print.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        print.ForeColor = SystemColors.ControlLightLight
        print.ImeMode = ImeMode.NoControl
        print.Location = New Point(1105, 80)
        print.Name = "print"
        print.Size = New Size(68, 57)
        print.TabIndex = 26
        print.Text = "Print"
        print.UseVisualStyleBackColor = False
        ' 
        ' btnPreview
        ' 
        btnPreview.BackColor = Color.DeepPink
        btnPreview.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnPreview.ForeColor = SystemColors.ControlLightLight
        btnPreview.ImeMode = ImeMode.NoControl
        btnPreview.Location = New Point(1017, 80)
        btnPreview.Name = "btnPreview"
        btnPreview.Size = New Size(82, 57)
        btnPreview.TabIndex = 25
        btnPreview.Text = "Preview"
        btnPreview.UseVisualStyleBackColor = False
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
        ' txtName
        ' 
        txtName.Enabled = False
        txtName.Location = New Point(107, 79)
        txtName.Name = "txtName"
        txtName.Size = New Size(191, 23)
        txtName.TabIndex = 28
        ' 
        ' txtDepartment
        ' 
        txtDepartment.Enabled = False
        txtDepartment.Location = New Point(552, 80)
        txtDepartment.Name = "txtDepartment"
        txtDepartment.Size = New Size(130, 23)
        txtDepartment.TabIndex = 29
        ' 
        ' btnEdit
        ' 
        btnEdit.BackColor = Color.DeepPink
        btnEdit.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnEdit.ForeColor = SystemColors.ControlLightLight
        btnEdit.ImeMode = ImeMode.NoControl
        btnEdit.Location = New Point(1169, 640)
        btnEdit.Name = "btnEdit"
        btnEdit.Size = New Size(141, 57)
        btnEdit.TabIndex = 30
        btnEdit.Text = "Edit Leave Card"
        btnEdit.UseVisualStyleBackColor = False
        btnEdit.Visible = False
        ' 
        ' btnSave
        ' 
        btnSave.BackColor = Color.MediumSeaGreen
        btnSave.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnSave.ForeColor = SystemColors.ControlLightLight
        btnSave.ImeMode = ImeMode.NoControl
        btnSave.Location = New Point(1169, 640)
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(141, 57)
        btnSave.TabIndex = 31
        btnSave.Text = "Save"
        btnSave.UseVisualStyleBackColor = False
        ' 
        ' btnCredits
        ' 
        btnCredits.BackColor = Color.DeepPink
        btnCredits.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnCredits.ForeColor = SystemColors.ControlLightLight
        btnCredits.ImeMode = ImeMode.NoControl
        btnCredits.Location = New Point(1007, 642)
        btnCredits.Name = "btnCredits"
        btnCredits.Size = New Size(141, 57)
        btnCredits.TabIndex = 32
        btnCredits.Text = "Modify Leave Credits"
        btnCredits.UseVisualStyleBackColor = False
        btnCredits.Visible = False
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(562, 358)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 57
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Crimson
        Button1.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Button1.ForeColor = SystemColors.ControlLightLight
        Button1.ImeMode = ImeMode.NoControl
        Button1.Location = New Point(1269, 15)
        Button1.Name = "Button1"
        Button1.Size = New Size(68, 37)
        Button1.TabIndex = 58
        Button1.Text = "Close"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' frmLeavecard
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1360, 709)
        ControlBox = False
        Controls.Add(Button1)
        Controls.Add(txtLoading)
        Controls.Add(btnCredits)
        Controls.Add(btnSave)
        Controls.Add(btnEdit)
        Controls.Add(txtDepartment)
        Controls.Add(txtName)
        Controls.Add(pagesetup)
        Controls.Add(print)
        Controls.Add(btnPreview)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(tblLeavecard)
        ForeColor = SystemColors.ControlLightLight
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmLeavecard"
        ShowInTaskbar = False
        CType(tblLeavecard, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents tblLeavecard As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pagesetup As Button
    Friend WithEvents print As Button
    Friend WithEvents btnPreview As Button
    Friend WithEvents docLeavereq As Printing.PrintDocument
    Friend WithEvents previewLeavereq As PrintPreviewDialog
    Friend WithEvents printdialogLeavereq As PrintDialog
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtDepartment As TextBox
    Friend WithEvents btnEdit As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCredits As Button
    Friend WithEvents txtLoading As Label
    Friend WithEvents Button1 As Button
End Class
