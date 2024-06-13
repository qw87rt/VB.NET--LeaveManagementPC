<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainform
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainform))
        MenuStrip1 = New MenuStrip()
        ManageLeavesToolStripMenuItem = New ToolStripMenuItem()
        PendingToolStripMenuItem = New ToolStripMenuItem()
        ApprovedToolStripMenuItem = New ToolStripMenuItem()
        DeniedToolStripMenuItem = New ToolStripMenuItem()
        ManageUsersToolStripMenuItem = New ToolStripMenuItem()
        LogoutExitToolStripMenuItem = New ToolStripMenuItem()
        RToolStripMenuItem = New ToolStripMenuItem()
        EmployeeToolStripMenuItem = New ToolStripMenuItem()
        AdminToolStripMenuItem = New ToolStripMenuItem()
        IyrjhfToolStripMenuItem = New ToolStripMenuItem()
        AdminListToolStripMenuItem = New ToolStripMenuItem()
        SummaryToolStripMenuItem = New ToolStripMenuItem()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.AutoSize = False
        MenuStrip1.BackColor = Color.DeepPink
        MenuStrip1.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        MenuStrip1.ImageScalingSize = New Size(20, 20)
        MenuStrip1.Items.AddRange(New ToolStripItem() {ManageLeavesToolStripMenuItem, ManageUsersToolStripMenuItem, LogoutExitToolStripMenuItem, RToolStripMenuItem, IyrjhfToolStripMenuItem})
        MenuStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(884, 45)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' ManageLeavesToolStripMenuItem
        ' 
        ManageLeavesToolStripMenuItem.BackColor = Color.DeepPink
        ManageLeavesToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {PendingToolStripMenuItem, ApprovedToolStripMenuItem, DeniedToolStripMenuItem})
        ManageLeavesToolStripMenuItem.ForeColor = Color.Gold
        ManageLeavesToolStripMenuItem.ImageTransparentColor = Color.Transparent
        ManageLeavesToolStripMenuItem.Name = "ManageLeavesToolStripMenuItem"
        ManageLeavesToolStripMenuItem.ShowShortcutKeys = False
        ManageLeavesToolStripMenuItem.Size = New Size(149, 41)
        ManageLeavesToolStripMenuItem.Text = "Leave Requests"
        ' 
        ' PendingToolStripMenuItem
        ' 
        PendingToolStripMenuItem.BackColor = Color.DeepPink
        PendingToolStripMenuItem.ForeColor = Color.NavajoWhite
        PendingToolStripMenuItem.Name = "PendingToolStripMenuItem"
        PendingToolStripMenuItem.Size = New Size(154, 22)
        PendingToolStripMenuItem.Text = "Pending"
        ' 
        ' ApprovedToolStripMenuItem
        ' 
        ApprovedToolStripMenuItem.BackColor = Color.DeepPink
        ApprovedToolStripMenuItem.ForeColor = Color.NavajoWhite
        ApprovedToolStripMenuItem.Name = "ApprovedToolStripMenuItem"
        ApprovedToolStripMenuItem.Size = New Size(154, 22)
        ApprovedToolStripMenuItem.Text = "Approved"
        ' 
        ' DeniedToolStripMenuItem
        ' 
        DeniedToolStripMenuItem.BackColor = Color.DeepPink
        DeniedToolStripMenuItem.ForeColor = Color.NavajoWhite
        DeniedToolStripMenuItem.Name = "DeniedToolStripMenuItem"
        DeniedToolStripMenuItem.Size = New Size(154, 22)
        DeniedToolStripMenuItem.Text = "Denied"
        ' 
        ' ManageUsersToolStripMenuItem
        ' 
        ManageUsersToolStripMenuItem.BackColor = Color.DeepPink
        ManageUsersToolStripMenuItem.ForeColor = Color.Gold
        ManageUsersToolStripMenuItem.Name = "ManageUsersToolStripMenuItem"
        ManageUsersToolStripMenuItem.Size = New Size(148, 41)
        ManageUsersToolStripMenuItem.Text = "|   Leave Card    |"
        ' 
        ' LogoutExitToolStripMenuItem
        ' 
        LogoutExitToolStripMenuItem.Alignment = ToolStripItemAlignment.Right
        LogoutExitToolStripMenuItem.BackColor = Color.Crimson
        LogoutExitToolStripMenuItem.ForeColor = Color.Gold
        LogoutExitToolStripMenuItem.Name = "LogoutExitToolStripMenuItem"
        LogoutExitToolStripMenuItem.Size = New Size(76, 41)
        LogoutExitToolStripMenuItem.Text = "Logout"
        ' 
        ' RToolStripMenuItem
        ' 
        RToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {EmployeeToolStripMenuItem, AdminToolStripMenuItem})
        RToolStripMenuItem.ForeColor = Color.Gold
        RToolStripMenuItem.Name = "RToolStripMenuItem"
        RToolStripMenuItem.Size = New Size(108, 41)
        RToolStripMenuItem.Text = "Register    |"
        ' 
        ' EmployeeToolStripMenuItem
        ' 
        EmployeeToolStripMenuItem.BackColor = Color.DeepPink
        EmployeeToolStripMenuItem.ForeColor = Color.Gold
        EmployeeToolStripMenuItem.Name = "EmployeeToolStripMenuItem"
        EmployeeToolStripMenuItem.Size = New Size(180, 22)
        EmployeeToolStripMenuItem.Text = "Employee"
        ' 
        ' AdminToolStripMenuItem
        ' 
        AdminToolStripMenuItem.BackColor = Color.DeepPink
        AdminToolStripMenuItem.ForeColor = Color.Gold
        AdminToolStripMenuItem.Name = "AdminToolStripMenuItem"
        AdminToolStripMenuItem.Size = New Size(180, 22)
        AdminToolStripMenuItem.Text = "Admin"
        ' 
        ' IyrjhfToolStripMenuItem
        ' 
        IyrjhfToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {AdminListToolStripMenuItem, SummaryToolStripMenuItem})
        IyrjhfToolStripMenuItem.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        IyrjhfToolStripMenuItem.ForeColor = Color.Gold
        IyrjhfToolStripMenuItem.Name = "IyrjhfToolStripMenuItem"
        IyrjhfToolStripMenuItem.Size = New Size(70, 41)
        IyrjhfToolStripMenuItem.Text = "More.."
        ' 
        ' AdminListToolStripMenuItem
        ' 
        AdminListToolStripMenuItem.BackColor = Color.DeepPink
        AdminListToolStripMenuItem.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        AdminListToolStripMenuItem.ForeColor = Color.Gold
        AdminListToolStripMenuItem.Name = "AdminListToolStripMenuItem"
        AdminListToolStripMenuItem.Size = New Size(180, 22)
        AdminListToolStripMenuItem.Text = "Admin List"
        ' 
        ' SummaryToolStripMenuItem
        ' 
        SummaryToolStripMenuItem.BackColor = Color.DeepPink
        SummaryToolStripMenuItem.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        SummaryToolStripMenuItem.ForeColor = Color.Gold
        SummaryToolStripMenuItem.Name = "SummaryToolStripMenuItem"
        SummaryToolStripMenuItem.Size = New Size(180, 22)
        SummaryToolStripMenuItem.Text = "Summary"
        ' 
        ' mainform
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.FloralWhite
        ClientSize = New Size(884, 461)
        Controls.Add(MenuStrip1)
        ForeColor = SystemColors.ControlText
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Margin = New Padding(2, 3, 2, 3)
        MaximizeBox = False
        MinimizeBox = False
        Name = "mainform"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Leave Management System"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ManageLeavesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManageUsersToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LogoutExitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PendingToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ApprovedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DeniedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents EmployeeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdminToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents IyrjhfToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdminListToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SummaryToolStripMenuItem As ToolStripMenuItem
End Class
