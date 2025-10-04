Imports Microsoft.Data.SqlClient

Imports System.Data.SqlClient

Public Class T_NhanVien
    Private viTriHienTai As Integer = 0

    Private Sub F_NhanVien_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM NHAN_VIEN", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaNhanVien").HeaderText = "Mã NV"
                DataGridView1.Columns("HoTen").HeaderText = "Tên NV"
                DataGridView1.Columns("ChucVu").HeaderText = "Chức vụ"
                DataGridView1.Columns("Luong").HeaderText = "Lương"
            End If

            If DataGridView1.Rows.Count > 0 Then
                viTriHienTai = 0
                UpdateDataGridView()
            End If
        Catch ex As Exception
            MsgBox("Lỗi tải dữ liệu: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub
    Private Sub UpdateDataGridView()
        If DataGridView1.Rows.Count > 0 AndAlso viTriHienTai >= 0 AndAlso viTriHienTai < DataGridView1.Rows.Count Then
            DataGridView1.Rows(viTriHienTai).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(viTriHienTai).Cells(0)
            Dim row As DataGridViewRow = DataGridView1.Rows(viTriHienTai)
            TxtMaNhanVien.Text = If(row.Cells("MaNhanVien").Value IsNot Nothing, row.Cells("MaNhanVien").Value.ToString(), "")
            TxtHoTen.Text = If(row.Cells("HoTen").Value IsNot Nothing, row.Cells("HoTen").Value.ToString(), "")
            TxtChucVu.Text = If(row.Cells("ChucVu").Value IsNot Nothing, row.Cells("ChucVu").Value.ToString(), "")
            TxtLuong.Text = If(row.Cells("Luong").Value IsNot Nothing, row.Cells("Luong").Value.ToString(), "")
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaNhanVien.Text.Trim() = "" Or TxtHoTen.Text.Trim() = "" Or TxtChucVu.Text.Trim() = "" Or TxtLuong.Text.Trim() = "" Then
            MsgBox("Vui lòng điền đầy đủ thông tin!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            ' Kiểm tra trùng MaNV
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM NHAN_VIEN WHERE MaNhanVien=@MaNhanVien", conn)
            checkCmd.Parameters.AddWithValue("@MaNhanVien", CInt(TxtMaNhanVien.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã nhân viên đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO NHAN_VIEN (MaNhanVien, HoTen, ChucVu, Luong) VALUES (@MaNhanVien, @HoTen, @ChucVu, @Luong)", conn)
            cmd.Parameters.AddWithValue("@MaNhanVien", CInt(TxtMaNhanVien.Text))
            cmd.Parameters.AddWithValue("@HoTen", TxtHoTen.Text.Trim())
            cmd.Parameters.AddWithValue("@ChucVu", TxtChucVu.Text.Trim())
            cmd.Parameters.AddWithValue("@Luong", CDec(TxtLuong.Text.Trim()))

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaNhanVien.Clear()
            TxtHoTen.Clear()
            TxtChucVu.Clear()
            TxtLuong.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaNhanVien.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn nhân viên để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE NHAN_VIEN SET HoTen=@HoTen, ChucVu=@ChucVu, Luong=@Luong WHERE MaNhanVien=@MaNhanVien", conn)
            cmd.Parameters.AddWithValue("@MaNhanVien", CInt(TxtMaNhanVien.Text))
            cmd.Parameters.AddWithValue("@HoTen", TxtHoTen.Text.Trim())
            cmd.Parameters.AddWithValue("@ChucVu", TxtChucVu.Text.Trim())
            cmd.Parameters.AddWithValue("@Luong", CDec(TxtLuong.Text.Trim()))

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã nhân viên không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaNhanVien.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn nhân viên để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa nhân viên này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM NHAN_VIEN WHERE MaNhanVien=@MaNhanVien", conn)
                cmd.Parameters.AddWithValue("@MaNhanVien", CInt(TxtMaNhanVien.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã nhân viên không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maNV As String = InputBox("Nhập mã nhân viên cần tìm:", "Tìm kiếm")
        If maNV = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM NHAN_VIEN WHERE MaNhanVien=@MaNhanVien", conn)
            cmd.Parameters.AddWithValue("@MaNhanVien", CInt(maNV))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaNhanVien.Text = dt.Rows(0)("MaNhanVien").ToString()
                TxtHoTen.Text = dt.Rows(0)("HoTen").ToString()
                TxtChucVu.Text = dt.Rows(0)("ChucVu").ToString()
                TxtLuong.Text = dt.Rows(0)("Luong").ToString()
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy nhân viên!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtDau_Click(sender As Object, e As EventArgs) Handles BtDau.Click
        viTriHienTai = 0
        UpdateDataGridView()
    End Sub

    Private Sub BtTruoc_Click(sender As Object, e As EventArgs) Handles BtTruoc.Click
        If viTriHienTai > 0 Then
            viTriHienTai -= 1
            UpdateDataGridView()
        Else
            MsgBox("Đã ở dòng đầu tiên!", vbInformation, "Thông báo")
        End If
    End Sub

    Private Sub BtSau_Click(sender As Object, e As EventArgs) Handles BtSau.Click
        If viTriHienTai < DataGridView1.Rows.Count - 1 Then
            viTriHienTai += 1
            UpdateDataGridView()
        Else
            MsgBox("Đã ở dòng cuối cùng!", vbInformation, "Thông báo")
        End If
    End Sub

    Private Sub BtCuoi_Click(sender As Object, e As EventArgs) Handles BtCuoi.Click
        viTriHienTai = DataGridView1.Rows.Count - 1
        UpdateDataGridView()
    End Sub

    Private Sub BtThoat_Click(sender As Object, e As EventArgs) Handles BtThoat.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            viTriHienTai = e.RowIndex
            UpdateDataGridView()
        End If
    End Sub
End Class