<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Label1 = New Label()
        Label2 = New Label()
        TXTadminid = New TextBox()
        TXTpassword = New TextBox()
        BTNsignin = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.DeepPink
        Label1.Location = New Point(51, 81)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.MinimumSize = New Size(71, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(84, 21)
        Label1.TabIndex = 0
        Label1.Text = "Admin ID:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = Color.DeepPink
        Label2.Location = New Point(43, 112)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.MinimumSize = New Size(71, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 21)
        Label2.TabIndex = 1
        Label2.Text = "Password:"
        ' 
        ' TXTadminid
        ' 
        TXTadminid.BackColor = Color.MistyRose
        TXTadminid.Font = New Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        TXTadminid.Location = New Point(139, 79)
        TXTadminid.Margin = New Padding(4)
        TXTadminid.Name = "TXTadminid"
        TXTadminid.Size = New Size(228, 23)
        TXTadminid.TabIndex = 2
        ' 
        ' TXTpassword
        ' 
        TXTpassword.BackColor = Color.MistyRose
        TXTpassword.Font = New Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        TXTpassword.Location = New Point(139, 111)
        TXTpassword.Margin = New Padding(4)
        TXTpassword.Name = "TXTpassword"
        TXTpassword.PasswordChar = "•"c
        TXTpassword.Size = New Size(228, 23)
        TXTpassword.TabIndex = 3
        ' 
        ' BTNsignin
        ' 
        BTNsignin.BackColor = Color.DeepPink
        BTNsignin.Cursor = Cursors.Hand
        BTNsignin.ForeColor = SystemColors.ButtonHighlight
        BTNsignin.Location = New Point(137, 142)
        BTNsignin.Margin = New Padding(4)
        BTNsignin.Name = "BTNsignin"
        BTNsignin.Size = New Size(230, 37)
        BTNsignin.TabIndex = 4
        BTNsignin.Text = "Sign in"
        BTNsignin.UseVisualStyleBackColor = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10F, 18F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FloralWhite
        BackgroundImageLayout = ImageLayout.None
        ClientSize = New Size(438, 264)
        Controls.Add(BTNsignin)
        Controls.Add(TXTpassword)
        Controls.Add(TXTadminid)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point)
        ForeColor = SystemColors.Control
        FormBorderStyle = FormBorderStyle.FixedDialog
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        KeyPreview = True
        Margin = New Padding(4)
        MaximizeBox = False
        MaximumSize = New Size(454, 303)
        MinimizeBox = False
        MinimumSize = New Size(454, 303)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login Form"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTadminid As TextBox
    Friend WithEvents TXTpassword As TextBox
    Friend WithEvents BTNsignin As Button
End Class
