<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class T_DangNhap
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        TxtTenDN = New TextBox()
        TxtMatKhau = New TextBox()
        BtDangNhap = New Button()
        BtThoat = New Button()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(109, 139)
        Label1.Name = "Label1"
        Label1.Size = New Size(143, 25)
        Label1.TabIndex = 0
        Label1.Text = "Tên đăng nhập"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(109, 197)
        Label2.Name = "Label2"
        Label2.Size = New Size(96, 25)
        Label2.TabIndex = 1
        Label2.Text = "Mật khẩu"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.Black
        Label3.Location = New Point(195, 22)
        Label3.Name = "Label3"
        Label3.Size = New Size(378, 41)
        Label3.TabIndex = 2
        Label3.Text = "ĐĂNG NHẬP HỆ THỐNG"
        ' 
        ' TxtTenDN
        ' 
        TxtTenDN.Location = New Point(255, 136)
        TxtTenDN.Name = "TxtTenDN"
        TxtTenDN.Size = New Size(271, 31)
        TxtTenDN.TabIndex = 3
        ' 
        ' TxtMatKhau
        ' 
        TxtMatKhau.Location = New Point(255, 194)
        TxtMatKhau.Name = "TxtMatKhau"
        TxtMatKhau.PasswordChar = "*"c
        TxtMatKhau.RightToLeft = RightToLeft.No
        TxtMatKhau.ScrollBars = ScrollBars.Both
        TxtMatKhau.Size = New Size(271, 31)
        TxtMatKhau.TabIndex = 4
        ' 
        ' BtDangNhap
        ' 
        BtDangNhap.BackColor = Color.LimeGreen
        BtDangNhap.Location = New Point(248, 279)
        BtDangNhap.Name = "BtDangNhap"
        BtDangNhap.Size = New Size(136, 41)
        BtDangNhap.TabIndex = 5
        BtDangNhap.Text = "Đăng Nhập"
        BtDangNhap.UseVisualStyleBackColor = False
        ' 
        ' BtThoat
        ' 
        BtThoat.BackColor = Color.IndianRed
        BtThoat.Location = New Point(390, 279)
        BtThoat.Name = "BtThoat"
        BtThoat.Size = New Size(136, 41)
        BtThoat.TabIndex = 6
        BtThoat.Text = "Thoát"
        BtThoat.UseVisualStyleBackColor = False
        ' 
        ' T_DangNhap
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        BackgroundImage = My.Resources.Resources.image_jpg
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(711, 408)
        Controls.Add(BtThoat)
        Controls.Add(BtDangNhap)
        Controls.Add(TxtMatKhau)
        Controls.Add(TxtTenDN)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "T_DangNhap"
        Text = "T_DangNhap"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtTenDN As TextBox
    Friend WithEvents TxtMatKhau As TextBox
    Friend WithEvents BtDangNhap As Button
    Friend WithEvents BtThoat As Button

End Class
