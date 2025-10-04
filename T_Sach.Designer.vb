<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class T_Sach
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
        TxtMaSach = New TextBox()
        Label5 = New Label()
        BtThoat = New Button()
        BtCuoi = New Button()
        BtSau = New Button()
        BtTruoc = New Button()
        BtDau = New Button()
        BtTimKiem = New Button()
        BtXoa = New Button()
        BtSua = New Button()
        BtThem = New Button()
        DataGridView1 = New DataGridView()
        TxtTacGia = New TextBox()
        TxtSoLuong = New TextBox()
        TxtTenSach = New TextBox()
        TxtNhaXuatBan = New TextBox()
        TxtNamXuatBan = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' TxtMaSach
        ' 
        TxtMaSach.Location = New Point(150, 91)
        TxtMaSach.Name = "TxtMaSach"
        TxtMaSach.Size = New Size(250, 31)
        TxtMaSach.TabIndex = 57
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(30, 94)
        Label5.Name = "Label5"
        Label5.Size = New Size(79, 25)
        Label5.TabIndex = 56
        Label5.Text = "Mã Sách"
        ' 
        ' BtThoat
        ' 
        BtThoat.BackColor = Color.IndianRed
        BtThoat.Location = New Point(778, 23)
        BtThoat.Name = "BtThoat"
        BtThoat.Size = New Size(112, 34)
        BtThoat.TabIndex = 55
        BtThoat.Text = "Thoát"
        BtThoat.UseVisualStyleBackColor = False
        ' 
        ' BtCuoi
        ' 
        BtCuoi.Location = New Point(559, 572)
        BtCuoi.Name = "BtCuoi"
        BtCuoi.Size = New Size(112, 34)
        BtCuoi.TabIndex = 54
        BtCuoi.Text = "Cuối"
        BtCuoi.UseVisualStyleBackColor = True
        ' 
        ' BtSau
        ' 
        BtSau.Location = New Point(441, 572)
        BtSau.Name = "BtSau"
        BtSau.Size = New Size(112, 34)
        BtSau.TabIndex = 53
        BtSau.Text = "Sau"
        BtSau.UseVisualStyleBackColor = True
        ' 
        ' BtTruoc
        ' 
        BtTruoc.Location = New Point(323, 572)
        BtTruoc.Name = "BtTruoc"
        BtTruoc.Size = New Size(112, 34)
        BtTruoc.TabIndex = 52
        BtTruoc.Text = "Trước"
        BtTruoc.UseVisualStyleBackColor = True
        ' 
        ' BtDau
        ' 
        BtDau.Location = New Point(205, 572)
        BtDau.Name = "BtDau"
        BtDau.Size = New Size(112, 34)
        BtDau.TabIndex = 51
        BtDau.Text = "Đầu"
        BtDau.UseVisualStyleBackColor = True
        ' 
        ' BtTimKiem
        ' 
        BtTimKiem.BackColor = Color.Transparent
        BtTimKiem.Location = New Point(591, 291)
        BtTimKiem.Name = "BtTimKiem"
        BtTimKiem.Size = New Size(112, 34)
        BtTimKiem.TabIndex = 50
        BtTimKiem.Text = "Tìm Kiếm"
        BtTimKiem.UseVisualStyleBackColor = False
        ' 
        ' BtXoa
        ' 
        BtXoa.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtXoa.Location = New Point(473, 291)
        BtXoa.Name = "BtXoa"
        BtXoa.Size = New Size(112, 34)
        BtXoa.TabIndex = 48
        BtXoa.Text = "Xóa"
        BtXoa.UseVisualStyleBackColor = False
        ' 
        ' BtSua
        ' 
        BtSua.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        BtSua.Location = New Point(355, 291)
        BtSua.Name = "BtSua"
        BtSua.Size = New Size(112, 34)
        BtSua.TabIndex = 47
        BtSua.Text = "Sửa"
        BtSua.UseVisualStyleBackColor = False
        ' 
        ' BtThem
        ' 
        BtThem.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        BtThem.Location = New Point(237, 291)
        BtThem.Name = "BtThem"
        BtThem.Size = New Size(112, 34)
        BtThem.TabIndex = 46
        BtThem.Text = "Thêm"
        BtThem.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(52, 341)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(776, 225)
        DataGridView1.TabIndex = 45
        ' 
        ' TxtTenSach
        ' 
        TxtTenSach.Location = New Point(150, 138)
        TxtTenSach.Name = "TxtTenSach"
        TxtTenSach.Size = New Size(250, 31)
        TxtTenSach.TabIndex = 42
        ' 
        ' TxtTacGia
        ' 
        TxtTacGia.Location = New Point(150, 185)
        TxtTacGia.Name = "TxtTacGia"
        TxtTacGia.Size = New Size(250, 31)
        TxtTacGia.TabIndex = 44
        ' 
        ' TxtSoLuong
        ' 
        TxtSoLuong.Location = New Point(150, 232)
        TxtSoLuong.Name = "TxtSoLuong"
        TxtSoLuong.Size = New Size(250, 31)
        TxtSoLuong.TabIndex = 43
        ' 
        ' TxtNhaXuatBan
        ' 
        TxtNhaXuatBan.Location = New Point(580, 91)
        TxtNhaXuatBan.Name = "TxtNhaXuatBan"
        TxtNhaXuatBan.Size = New Size(250, 31)
        TxtNhaXuatBan.TabIndex = 58
        ' 
        ' TxtNamXuatBan
        ' 
        TxtNamXuatBan.Location = New Point(580, 138)
        TxtNamXuatBan.Name = "TxtNamXuatBan"
        TxtNamXuatBan.Size = New Size(250, 31)
        TxtNamXuatBan.TabIndex = 59
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(30, 141)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 25)
        Label2.TabIndex = 39
        Label2.Text = "Tên Sách"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(30, 188)
        Label3.Name = "Label3"
        Label3.Size = New Size(65, 25)
        Label3.TabIndex = 40
        Label3.Text = "Tác giả"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(30, 235)
        Label4.Name = "Label4"
        Label4.Size = New Size(89, 25)
        Label4.TabIndex = 41
        Label4.Text = "Số Lượng"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Location = New Point(440, 94)
        Label6.Name = "Label6"
        Label6.Size = New Size(120, 25)
        Label6.TabIndex = 60
        Label6.Text = "Nhà Xuất Bản"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Location = New Point(440, 141)
        Label7.Name = "Label7"
        Label7.Size = New Size(125, 25)
        Label7.TabIndex = 61
        Label7.Text = "Năm Xuất Bản"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI Black", 15.0F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(285, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(244, 41)
        Label1.TabIndex = 38
        Label1.Text = "QUẢN LÝ SÁCH"
        ' 
        ' T_Sach
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(912, 641)
        Controls.Add(TxtNamXuatBan)
        Controls.Add(TxtNhaXuatBan)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(TxtMaSach)
        Controls.Add(Label5)
        Controls.Add(BtThoat)
        Controls.Add(BtCuoi)
        Controls.Add(BtSau)
        Controls.Add(BtTruoc)
        Controls.Add(BtDau)
        Controls.Add(BtTimKiem)
        Controls.Add(BtXoa)
        Controls.Add(BtSua)
        Controls.Add(BtThem)
        Controls.Add(DataGridView1)
        Controls.Add(TxtTacGia)
        Controls.Add(TxtSoLuong)
        Controls.Add(TxtTenSach)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "T_Sach"
        Text = "T_Sach"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TxtMaSach As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents BtThoat As Button
    Friend WithEvents BtCuoi As Button
    Friend WithEvents BtSau As Button
    Friend WithEvents BtTruoc As Button
    Friend WithEvents BtDau As Button
    Friend WithEvents BtTimKiem As Button
    Friend WithEvents BtXoa As Button
    Friend WithEvents BtSua As Button
    Friend WithEvents BtThem As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TxtSoLuong As TextBox
    Friend WithEvents TxtTenSach As TextBox
    Friend WithEvents TxtTacGia As TextBox
    Friend WithEvents TxtNhaXuatBan As TextBox
    Friend WithEvents TxtNamXuatBan As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
