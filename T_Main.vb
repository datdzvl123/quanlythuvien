Public Class T_Main
    Private quyen As String
    Private tenDN As String

    Public Sub New(ByVal userQuyen As String, ByVal userTenDN As String)
        InitializeComponent()
        Me.quyen = userQuyen
        Me.tenDN = userTenDN
    End Sub

    Private Sub F_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If quyen = "NhanVien" Then
            MenuNhanVien.Visible = False  ' Nhân viên không được quản lý nhân viên
            ' MenuDocGia và MenuSach vẫn hiển thị để nhân viên có thể xem
        End If
    End Sub

    Private Sub MenuDocGia_Click(sender As Object, e As EventArgs) Handles MenuDocGia.Click
        Dim f As New T_DocGia(quyen)
        f.ShowDialog()
    End Sub

    Private Sub MenuSach_Click(sender As Object, e As EventArgs) Handles MenuSach.Click
        Dim f As New T_Sach(quyen)
        f.ShowDialog()
    End Sub

    Private Sub MenuNhanVien_Click(sender As Object, e As EventArgs) Handles MenuNhanVien.Click
        Dim f As New T_NhanVien()
        f.ShowDialog()
    End Sub

    Private Sub MenuPhieuNhapSach_Click(sender As Object, e As EventArgs) Handles MenuPhieuNhapSach.Click
        Dim f As New T_PhieuNhap() ' Truyền tenDN vào constructor
        f.ShowDialog()
    End Sub

    Private Sub MenuChiTietPhieuNhap_Click(sender As Object, e As EventArgs) Handles MenuChiTietPhieuNhap.Click
        Dim f As New T_ChiTietPhieuNhap()
        f.ShowDialog()
    End Sub

    Private Sub MenuDangKy_Click(sender As Object, e As EventArgs) Handles MenuDangKy.Click
        If quyen <> "Admin" Then
            MsgBox("Chỉ quản lý có quyền đăng ký tài khoản mới!", vbExclamation, "Lỗi")
            Exit Sub
        End If
        Dim f As New F_DangKy()
        f.ShowDialog()
    End Sub

    Private Sub MenuDangXuat_Click(sender As Object, e As EventArgs) Handles MenuDangXuat.Click
        Me.Close()
        Dim login As New T_DangNhap()
        login.Show()
    End Sub

    'Private Sub MenuQuanLyDonHang_Click(sender As Object, e As EventArgs) Handles MenuQuanLyDonHang.Click
    '    Dim f As New F_BaoCao()
    '    f.ShowDialog()
    'End Sub
End Class