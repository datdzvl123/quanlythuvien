<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class F_DangKy
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        TxtTenDN = New TextBox()
        TxtMatKhau = New TextBox()
        CmbQuyen = New ComboBox()
        BtDangKy = New Button()
        BtThoat = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(255, 114)
        Label1.Name = "Label1"
        Label1.Size = New Size(332, 41)
        Label1.TabIndex = 0
        Label1.Text = "ĐĂNG KÍ TÀI KHOẢN"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(96, 161)
        Label2.Name = "Label2"
        Label2.Size = New Size(134, 25)
        Label2.TabIndex = 1
        Label2.Text = "Tên Đăng Nhập"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(96, 229)
        Label3.Name = "Label3"
        Label3.Size = New Size(87, 25)
        Label3.TabIndex = 2
        Label3.Text = "Mật Khẩu"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(96, 290)
        Label4.Name = "Label4"
        Label4.Size = New Size(64, 25)
        Label4.TabIndex = 3
        Label4.Text = "Quyền"
        ' 
        ' TxtTenDN
        ' 
        TxtTenDN.Location = New Point(263, 160)
        TxtTenDN.Name = "TxtTenDN"
        TxtTenDN.Size = New Size(324, 31)
        TxtTenDN.TabIndex = 4
        ' 
        ' TxtMatKhau
        ' 
        TxtMatKhau.Location = New Point(263, 224)
        TxtMatKhau.Name = "TxtMatKhau"
        TxtMatKhau.Size = New Size(324, 31)
        TxtMatKhau.TabIndex = 5
        ' 
        ' CmbQuyen
        ' 
        CmbQuyen.FormattingEnabled = True
        CmbQuyen.Location = New Point(263, 290)
        CmbQuyen.Name = "CmbQuyen"
        CmbQuyen.Size = New Size(324, 33)
        CmbQuyen.TabIndex = 6
        ' 
        ' BtDangKy
        ' 
        BtDangKy.BackColor = Color.LimeGreen
        BtDangKy.Location = New Point(262, 355)
        BtDangKy.Name = "BtDangKy"
        BtDangKy.Size = New Size(147, 34)
        BtDangKy.TabIndex = 7
        BtDangKy.Text = "Đăng Ký"
        BtDangKy.UseVisualStyleBackColor = False
        ' 
        ' BtThoat
        ' 
        BtThoat.BackColor = Color.IndianRed
        BtThoat.Location = New Point(440, 355)
        BtThoat.Name = "BtThoat"
        BtThoat.Size = New Size(147, 34)
        BtThoat.TabIndex = 8
        BtThoat.Text = "Thoát"
        BtThoat.UseVisualStyleBackColor = False
        ' 
        ' F_DangKy
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.image_jpg
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(763, 461)
        Controls.Add(BtThoat)
        Controls.Add(BtDangKy)
        Controls.Add(CmbQuyen)
        Controls.Add(TxtMatKhau)
        Controls.Add(TxtTenDN)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "T_DangKy"
        Text = "T_DangKy"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtTenDN As TextBox
    Friend WithEvents TxtMatKhau As TextBox
    Friend WithEvents CmbQuyen As ComboBox
    Friend WithEvents BtDangKy As Button
    Friend WithEvents BtThoat As Button
End Class
