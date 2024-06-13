<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadmin
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
        Admins = New Label()
        tblAdmins = New DataGridView()
        Label1 = New Label()
        TextBoxSearch = New TextBox()
        txtSearch = New Label()
        txtLoading = New Label()
        btnView = New Button()
        CType(tblAdmins, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Admins
        ' 
        Admins.AutoSize = True
        Admins.Font = New Font("Arial Rounded MT Bold", 20.25F, FontStyle.Regular, GraphicsUnit.Point)
        Admins.ForeColor = Color.DeepPink
        Admins.Location = New Point(198, 44)
        Admins.Margin = New Padding(2, 0, 2, 0)
        Admins.Name = "Admins"
        Admins.Size = New Size(152, 32)
        Admins.TabIndex = 12
        Admins.Text = "Admin List"
        ' 
        ' tblAdmins
        ' 
        tblAdmins.AllowUserToResizeRows = False
        tblAdmins.BackgroundColor = Color.FloralWhite
        tblAdmins.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        tblAdmins.Location = New Point(409, 125)
        tblAdmins.Margin = New Padding(2, 3, 2, 3)
        tblAdmins.Name = "tblAdmins"
        tblAdmins.RowHeadersWidth = 51
        tblAdmins.RowTemplate.Height = 25
        tblAdmins.Size = New Size(541, 443)
        tblAdmins.TabIndex = 13
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Narrow", 8F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(798, 67)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 15)
        Label1.TabIndex = 21
        Label1.Text = "Lastname/ Department"
        ' 
        ' TextBoxSearch
        ' 
        TextBoxSearch.Location = New Point(801, 85)
        TextBoxSearch.Margin = New Padding(2, 3, 2, 3)
        TextBoxSearch.Name = "TextBoxSearch"
        TextBoxSearch.Size = New Size(149, 23)
        TextBoxSearch.TabIndex = 20
        ' 
        ' txtSearch
        ' 
        txtSearch.AutoSize = True
        txtSearch.Font = New Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        txtSearch.ForeColor = Color.DeepPink
        txtSearch.Location = New Point(740, 86)
        txtSearch.Margin = New Padding(2, 0, 2, 0)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(63, 20)
        txtSearch.TabIndex = 19
        txtSearch.Text = "Search: "
        ' 
        ' txtLoading
        ' 
        txtLoading.AutoSize = True
        txtLoading.Font = New Font("Arial", 12F, FontStyle.Italic, GraphicsUnit.Point)
        txtLoading.ForeColor = Color.DeepPink
        txtLoading.ImeMode = ImeMode.NoControl
        txtLoading.Location = New Point(595, 284)
        txtLoading.Name = "txtLoading"
        txtLoading.Size = New Size(214, 19)
        txtLoading.TabIndex = 61
        txtLoading.Text = "Fetching data... Please wait..."
        ' 
        ' btnView
        ' 
        btnView.BackColor = Color.DeepPink
        btnView.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        btnView.ForeColor = SystemColors.ButtonHighlight
        btnView.Location = New Point(788, 574)
        btnView.Margin = New Padding(2, 3, 2, 3)
        btnView.Name = "btnView"
        btnView.Size = New Size(137, 47)
        btnView.TabIndex = 62
        btnView.Text = "View"
        btnView.UseVisualStyleBackColor = False
        ' 
        ' frmListadmin
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(1360, 709)
        ControlBox = False
        Controls.Add(btnView)
        Controls.Add(txtLoading)
        Controls.Add(Label1)
        Controls.Add(TextBoxSearch)
        Controls.Add(txtSearch)
        Controls.Add(tblAdmins)
        Controls.Add(Admins)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        MinimizeBox = False
        Name = "frmListadmin"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        CType(tblAdmins, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Admins As Label
    Friend WithEvents tblAdmins As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBoxSearch As TextBox
    Friend WithEvents txtSearch As Label
    Friend WithEvents txtLoading As Label
    Friend WithEvents btnView As Button
End Class
