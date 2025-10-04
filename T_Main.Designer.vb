<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class T_Main
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
        components = New ComponentModel.Container()
        Label1 = New Label()
        ContextMenuStrip1 = New ContextMenuStrip(components)
        MainMenu = New MenuStrip()
        MenuDocGia = New ToolStripMenuItem()
        MenuSach = New ToolStripMenuItem()
        MenuNhanVien = New ToolStripMenuItem()
        MenuPhieuNhapSach = New ToolStripMenuItem()
        MenuDangKy = New ToolStripMenuItem()
        MenuDangXuat = New ToolStripMenuItem()
        MenuChiTietPhieuNhap = New ToolStripMenuItem()
        MainMenu.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(193, 201)
        Label1.Name = "Label1"
        Label1.Size = New Size(499, 41)
        Label1.TabIndex = 0
        Label1.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN"
        ' 
        ' ContextMenuStrip1
        ' 
        ContextMenuStrip1.ImageScalingSize = New Size(24, 24)
        ContextMenuStrip1.Name = "ContextMenuStrip1"
        ContextMenuStrip1.Size = New Size(61, 4)
        ' 
        ' MainMenu
        ' 
        MainMenu.ImageScalingSize = New Size(24, 24)
        MainMenu.Items.AddRange(New ToolStripItem() {MenuDocGia, MenuSach, MenuNhanVien, MenuPhieuNhapSach, MenuChiTietPhieuNhap, MenuDangKy, MenuDangXuat})
        MainMenu.Location = New Point(0, 0)
        MainMenu.Name = "MainMenu"
        MainMenu.Size = New Size(853, 33)
        MainMenu.TabIndex = 2
        MainMenu.Text = "MenuStrip1"
        ' 
        ' MenuKhachHang
        ' 
        MenuDocGia.Name = "MenuDocGia"
        MenuDocGia.Size = New Size(123, 29)
        MenuDocGia.Text = "Độc giả"
        ' 
        ' MenuMatHang
        ' 
        MenuSach.Name = "MenuSach"
        MenuSach.Size = New Size(107, 29)
        MenuSach.Text = "Sách"
        ' 
        ' MenuNhanVien
        ' 
        MenuNhanVien.Name = "MenuNhanVien"
        MenuNhanVien.Size = New Size(109, 29)
        MenuNhanVien.Text = "Nhân Viên"
        ' 
        ' MenuBanHang
        ' 
        MenuPhieuNhapSach.Name = "MenuPhieuNhapSach"
        MenuPhieuNhapSach.Size = New Size(105, 29)
        MenuPhieuNhapSach.Text = "Phiếu nhập sách"
        ' 
        ' MenuDangKy
        ' 
        MenuDangKy.Name = "MenuDangKy"
        MenuDangKy.Size = New Size(94, 29)
        MenuDangKy.Text = "Đăng ký"
        ' 
        ' MenuDangXuat
        ' 
        MenuDangXuat.Name = "MenuDangXuat"
        MenuDangXuat.Size = New Size(112, 29)
        MenuDangXuat.Text = "Đăng Xuất"
        ' 
        ' MenuQuanLyDonHang
        ' 
        MenuChiTietPhieuNhap.Name = "MenuChiTietPhieuNhap"
        MenuChiTietPhieuNhap.Size = New Size(174, 29)
        MenuChiTietPhieuNhap.Text = "Chi Tiết Phiếu Nhập"
        ' 
        ' F_Main
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.image_jpg
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(853, 526)
        Controls.Add(MainMenu)
        Controls.Add(Label1)
        Name = "T_Main"
        Text = "T_Main"
        MainMenu.ResumeLayout(False)
        MainMenu.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents MainMenu As MenuStrip
    Friend WithEvents MenuDocGia As ToolStripMenuItem
    Friend WithEvents MenuSach As ToolStripMenuItem
    Friend WithEvents MenuNhanVien As ToolStripMenuItem
    Friend WithEvents MenuPhieuNhapSach As ToolStripMenuItem
    Friend WithEvents MenuBaoCao As ToolStripMenuItem
    Friend WithEvents MenuDangXuat As ToolStripMenuItem
    Friend WithEvents MenuDangKy As ToolStripMenuItem
    Friend WithEvents MenuChiTietPhieuNhap As ToolStripMenuItem
End Class
