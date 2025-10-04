<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class T_PhieuNhap
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
        TxtTongTien = New TextBox()
        TxtMaPhieu = New TextBox()
        DtpNgayNhap = New DateTimePicker()
        CboMaNhanVien = New ComboBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Label5 = New Label()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' BtThoat
        ' 
        BtThoat.BackColor = Color.IndianRed
        BtThoat.Location = New Point(859, 21)
        BtThoat.Name = "BtThoat"
        BtThoat.Size = New Size(112, 34)
        BtThoat.TabIndex = 35
        BtThoat.Text = "Thoát"
        BtThoat.UseVisualStyleBackColor = False
        ' 
        ' BtCuoi
        ' 
        BtCuoi.Location = New Point(628, 570)
        BtCuoi.Name = "BtCuoi"
        BtCuoi.Size = New Size(112, 34)
        BtCuoi.TabIndex = 34
        BtCuoi.Text = "Cuối"
        BtCuoi.UseVisualStyleBackColor = True
        ' 
        ' BtSau
        ' 
        BtSau.Location = New Point(510, 570)
        BtSau.Name = "BtSau"
        BtSau.Size = New Size(112, 34)
        BtSau.TabIndex = 33
        BtSau.Text = "Sau"
        BtSau.UseVisualStyleBackColor = True
        ' 
        ' BtTruoc
        ' 
        BtTruoc.Location = New Point(392, 570)
        BtTruoc.Name = "BtTruoc"
        BtTruoc.Size = New Size(112, 34)
        BtTruoc.TabIndex = 32
        BtTruoc.Text = "Trước"
        BtTruoc.UseVisualStyleBackColor = True
        ' 
        ' BtDau
        ' 
        BtDau.Location = New Point(274, 570)
        BtDau.Name = "BtDau"
        BtDau.Size = New Size(112, 34)
        BtDau.TabIndex = 31
        BtDau.Text = "Đầu"
        BtDau.UseVisualStyleBackColor = True
        ' 
        ' BtTimKiem
        ' 
        BtTimKiem.BackColor = Color.FromArgb(CByte(128), CByte(128), CByte(255))
        BtTimKiem.Location = New Point(650, 280)
        BtTimKiem.Name = "BtTimKiem"
        BtTimKiem.Size = New Size(112, 34)
        BtTimKiem.TabIndex = 30
        BtTimKiem.Text = "Tìm Kiếm"
        BtTimKiem.UseVisualStyleBackColor = False
        ' 
        ' BtXoa
        ' 
        BtXoa.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(128))
        BtXoa.Location = New Point(532, 280)
        BtXoa.Name = "BtXoa"
        BtXoa.Size = New Size(112, 34)
        BtXoa.TabIndex = 28
        BtXoa.Text = "Xóa"
        BtXoa.UseVisualStyleBackColor = False
        ' 
        ' BtSua
        ' 
        BtSua.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(128))
        BtSua.Location = New Point(414, 280)
        BtSua.Name = "BtSua"
        BtSua.Size = New Size(112, 34)
        BtSua.TabIndex = 27
        BtSua.Text = "Sửa"
        BtSua.UseVisualStyleBackColor = False
        ' 
        ' BtThem
        ' 
        BtThem.BackColor = Color.FromArgb(CByte(0), CByte(192), CByte(0))
        BtThem.Location = New Point(296, 280)
        BtThem.Name = "BtThem"
        BtThem.Size = New Size(112, 34)
        BtThem.TabIndex = 26
        BtThem.Text = "Thêm"
        BtThem.UseVisualStyleBackColor = False
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Location = New Point(121, 330)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowHeadersWidth = 62
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.Size = New Size(776, 225)
        DataGridView1.TabIndex = 25
        ' 
        ' TxtTongTien
        ' 
        TxtTongTien.Location = New Point(650, 172)
        TxtTongTien.Name = "TxtTongTien"
        TxtTongTien.ReadOnly = True
        TxtTongTien.Size = New Size(300, 31)
        TxtTongTien.TabIndex = 24
        TxtTongTien.Text = "0"
        ' 
        ' TxtMaPhieu
        ' 
        TxtMaPhieu.Location = New Point(200, 124)
        TxtMaPhieu.Name = "TxtMaPhieu"
        TxtMaPhieu.Size = New Size(300, 31)
        TxtMaPhieu.TabIndex = 22
        ' 
        ' DtpNgayNhap
        ' 
        DtpNgayNhap.Format = DateTimePickerFormat.Short
        DtpNgayNhap.Location = New Point(200, 220)
        DtpNgayNhap.Name = "DtpNgayNhap"
        DtpNgayNhap.Size = New Size(300, 31)
        DtpNgayNhap.TabIndex = 21
        ' 
        ' CboMaNhanVien
        ' 
        CboMaNhanVien.DropDownStyle = ComboBoxStyle.DropDownList
        CboMaNhanVien.FormattingEnabled = True
        CboMaNhanVien.Location = New Point(200, 172)
        CboMaNhanVien.Name = "CboMaNhanVien"
        CboMaNhanVien.Size = New Size(300, 33)
        CboMaNhanVien.TabIndex = 20
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(550, 175)
        Label4.Name = "Label4"
        Label4.Size = New Size(86, 25)
        Label4.TabIndex = 19
        Label4.Text = "Tổng tiền"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(50, 223)
        Label3.Name = "Label3"
        Label3.Size = New Size(99, 25)
        Label3.TabIndex = 18
        Label3.Text = "Ngày nhập"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(50, 175)
        Label2.Name = "Label2"
        Label2.Size = New Size(118, 25)
        Label2.TabIndex = 17
        Label2.Text = "Tên nhân viên"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(50, 127)
        Label1.Name = "Label1"
        Label1.Size = New Size(87, 25)
        Label1.TabIndex = 16
        Label1.Text = "Mã phiếu"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Transparent
        Label5.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(300, 21)
        Label5.Name = "Label5"
        Label5.Size = New Size(403, 41)
        Label5.TabIndex = 36
        Label5.Text = "QUẢN LÝ PHIẾU NHẬP"
        ' 
        ' T_PhieuNhap
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.image_jpg
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1000, 628)
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
        Controls.Add(TxtTongTien)
        Controls.Add(TxtMaPhieu)
        Controls.Add(DtpNgayNhap)
        Controls.Add(CboMaNhanVien)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Name = "T_PhieuNhap"
        Text = "Quản lý phiếu nhập"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

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
    Friend WithEvents TxtTongTien As TextBox
    Friend WithEvents TxtMaPhieu As TextBox
    Friend WithEvents DtpNgayNhap As DateTimePicker
    Friend WithEvents CboMaNhanVien As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
End Class
