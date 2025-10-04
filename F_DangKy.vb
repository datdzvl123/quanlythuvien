Imports Microsoft.Data.SqlClient

Public Class F_DangKy
    Private Sub F_DangKy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CmbQuyen.Items.AddRange({"Admin", "NhanVien"})
        CmbQuyen.SelectedIndex = -1
    End Sub

    Private Sub BtDangKy_Click(sender As Object, e As EventArgs) Handles BtDangKy.Click
        If TxtTenDN.Text.Trim() = "" Or TxtMatKhau.Text.Trim() = "" Or CmbQuyen.SelectedIndex = -1 Then
            MsgBox("Vui lòng điền đầy đủ thông tin!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If TxtMatKhau.Text.Length < 6 Then
            MsgBox("Mật khẩu phải có ít nhất 6 ký tự!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng TenDN
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM tblTaikhoan WHERE TenDN=@TenDN", conn)
            checkCmd.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Tên đăng nhập đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            ' Thêm tài khoản
            Dim cmd As New SqlCommand("INSERT INTO tblTaikhoan (TenDN, Matkhau, Quyen) VALUES (@TenDN, @Matkhau, @Quyen)", conn)
            cmd.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())
            cmd.Parameters.AddWithValue("@Matkhau", TxtMatKhau.Text.Trim())
            cmd.Parameters.AddWithValue("@Quyen", CmbQuyen.Text)

            cmd.ExecuteNonQuery()
            MsgBox("Đăng ký thành công!", vbInformation, "Thành công")
            conn.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtThoat_Click(sender As Object, e As EventArgs) Handles BtThoat.Click
        Me.Close()
    End Sub
End Class