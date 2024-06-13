<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFeed
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
        txtFeedback = New RichTextBox()
        btnSubmit = New Button()
        Label1 = New Label()
        TextBox1 = New TextBox()
        btnClose = New Button()
        SuspendLayout()
        ' 
        ' txtFeedback
        ' 
        txtFeedback.Font = New Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point)
        txtFeedback.ForeColor = Color.DeepPink
        txtFeedback.Location = New Point(94, 50)
        txtFeedback.Margin = New Padding(2, 2, 2, 2)
        txtFeedback.Name = "txtFeedback"
        txtFeedback.Size = New Size(546, 219)
        txtFeedback.TabIndex = 0
        txtFeedback.Text = ""
        ' 
        ' btnSubmit
        ' 
        btnSubmit.BackColor = Color.DeepPink
        btnSubmit.Cursor = Cursors.Hand
        btnSubmit.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        btnSubmit.ForeColor = SystemColors.ButtonHighlight
        btnSubmit.Location = New Point(558, 275)
        btnSubmit.Margin = New Padding(2, 2, 2, 2)
        btnSubmit.Name = "btnSubmit"
        btnSubmit.Size = New Size(79, 26)
        btnSubmit.TabIndex = 1
        btnSubmit.Text = "Submit"
        btnSubmit.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        Label1.Location = New Point(19, 16)
        Label1.Margin = New Padding(2, 0, 2, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(139, 19)
        Label1.TabIndex = 2
        Label1.Text = "Department/Office:"
        ' 
        ' TextBox1
        ' 
        TextBox1.ForeColor = Color.DeepPink
        TextBox1.Location = New Point(156, 16)
        TextBox1.Margin = New Padding(2, 2, 2, 2)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(184, 23)
        TextBox1.TabIndex = 3
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.DeepPink
        btnClose.Cursor = Cursors.Hand
        btnClose.Font = New Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point)
        btnClose.ForeColor = SystemColors.ButtonHighlight
        btnClose.Location = New Point(474, 275)
        btnClose.Margin = New Padding(2, 2, 2, 2)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(79, 26)
        btnClose.TabIndex = 4
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' frmFeed
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        ClientSize = New Size(687, 338)
        ControlBox = False
        Controls.Add(btnClose)
        Controls.Add(TextBox1)
        Controls.Add(Label1)
        Controls.Add(btnSubmit)
        Controls.Add(txtFeedback)
        ForeColor = Color.DeepPink
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(2, 2, 2, 2)
        MinimizeBox = False
        Name = "frmFeed"
        StartPosition = FormStartPosition.CenterScreen
        Text = " "
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtFeedback As RichTextBox
    Friend WithEvents btnSubmit As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnClose As Button
End Class
