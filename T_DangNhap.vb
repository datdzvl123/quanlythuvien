Imports Microsoft.Data.SqlClient

Public Class T_DangNhap
    Private Sub BtDangNhap_Click(sender As Object, e As EventArgs) Handles BtDangNhap.Click
        If TxtTenDN.Text.Trim() = "" Or TxtMatKhau.Text.Trim() = "" Then
            MsgBox("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT Quyen FROM TAIKHOAN WHERE TenDN=@TenDN AND Matkhau=@Matkhau", conn)
            cmd.Parameters.AddWithValue("@TenDN", TxtTenDN.Text.Trim())
            cmd.Parameters.AddWithValue("@Matkhau", TxtMatKhau.Text.Trim())

            Dim reader As SqlDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                Dim quyen As String = reader("Quyen").ToString()
                MsgBox("Đăng nhập thành công!", vbInformation, "Thành công")
                Dim mainForm As New T_Main(quyen, TxtTenDN.Text.Trim())
                mainForm.Show()
                Me.Hide()
            Else
                MsgBox("Tên đăng nhập hoặc mật khẩu sai!", vbCritical, "Lỗi")
            End If

            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi kết nối: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtThoat_Click(sender As Object, e As EventArgs) Handles BtThoat.Click
        Application.Exit()
    End Sub

    Private Sub F_DangNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class