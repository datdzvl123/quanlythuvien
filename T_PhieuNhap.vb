Imports Microsoft.Data.SqlClient
Imports System.Data.SqlClient

Public Class T_PhieuNhap
    Private viTriHienTai As Integer = 0

    Private Sub T_PhieuNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        LoadNhanVien()
    End Sub

    Private Sub LoadData()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM PHIEU_NHAP_SACH", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaPhieu").HeaderText = "Mã phiếu"
                DataGridView1.Columns("MaNhanVien").HeaderText = "Mã nhân viên"
                DataGridView1.Columns("NgayNhap").HeaderText = "Ngày nhập"
                DataGridView1.Columns("TongTien").HeaderText = "Tổng tiền"
            End If

            If DataGridView1.Rows.Count > 0 Then
                viTriHienTai = 0
                UpdateDataGridView()
            End If
        Catch ex As Exception
            MsgBox("Lỗi tải dữ liệu: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub LoadNhanVien()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT MaNhanVien, HoTen FROM NHAN_VIEN", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            
            CboMaNhanVien.DataSource = dt
            CboMaNhanVien.DisplayMember = "HoTen"
            CboMaNhanVien.ValueMember = "MaNhanVien"
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi tải danh sách nhân viên: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub UpdateDataGridView()
        If DataGridView1.Rows.Count > 0 AndAlso viTriHienTai >= 0 AndAlso viTriHienTai < DataGridView1.Rows.Count Then
            DataGridView1.Rows(viTriHienTai).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(viTriHienTai).Cells(0)
            Dim row As DataGridViewRow = DataGridView1.Rows(viTriHienTai)
            TxtMaPhieu.Text = If(row.Cells("MaPhieu").Value IsNot Nothing, row.Cells("MaPhieu").Value.ToString(), "")
            
            If row.Cells("MaNhanVien").Value IsNot Nothing Then
                CboMaNhanVien.SelectedValue = row.Cells("MaNhanVien").Value
            End If
            
            DtpNgayNhap.Value = If(row.Cells("NgayNhap").Value IsNot Nothing AndAlso IsDate(row.Cells("NgayNhap").Value), CDate(row.Cells("NgayNhap").Value), DateTime.Now)
            TxtTongTien.Text = If(row.Cells("TongTien").Value IsNot Nothing, row.Cells("TongTien").Value.ToString(), "0")
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaPhieu.Text.Trim() = "" Or CboMaNhanVien.SelectedValue Is Nothing Then
            MsgBox("Vui lòng điền đầy đủ thông tin bắt buộc!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng MaPhieu
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM PHIEU_NHAP_SACH WHERE MaPhieu=@MaPhieu", conn)
            checkCmd.Parameters.AddWithValue("@MaPhieu", CInt(TxtMaPhieu.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã phiếu đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO PHIEU_NHAP_SACH (MaPhieu, MaNhanVien, NgayNhap, TongTien) VALUES (@MaPhieu, @MaNhanVien, @NgayNhap, @TongTien)", conn)
            cmd.Parameters.AddWithValue("@MaPhieu", CInt(TxtMaPhieu.Text))
            cmd.Parameters.AddWithValue("@MaNhanVien", CInt(CboMaNhanVien.SelectedValue))
            cmd.Parameters.AddWithValue("@NgayNhap", DtpNgayNhap.Value)
            cmd.Parameters.AddWithValue("@TongTien", CDec(If(TxtTongTien.Text.Trim() = "", "0", TxtTongTien.Text.Trim())))

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaPhieu.Clear()
            DtpNgayNhap.Value = DateTime.Now
            TxtTongTien.Text = "0"
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaPhieu.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn phiếu nhập để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE PHIEU_NHAP_SACH SET MaNhanVien=@MaNhanVien, NgayNhap=@NgayNhap, TongTien=@TongTien WHERE MaPhieu=@MaPhieu", conn)
            cmd.Parameters.AddWithValue("@MaPhieu", CInt(TxtMaPhieu.Text))
            cmd.Parameters.AddWithValue("@MaNhanVien", CInt(CboMaNhanVien.SelectedValue))
            cmd.Parameters.AddWithValue("@NgayNhap", DtpNgayNhap.Value)
            cmd.Parameters.AddWithValue("@TongTien", CDec(If(TxtTongTien.Text.Trim() = "", "0", TxtTongTien.Text.Trim())))

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã phiếu không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaPhieu.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn phiếu nhập để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa phiếu nhập này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM PHIEU_NHAP_SACH WHERE MaPhieu=@MaPhieu", conn)
                cmd.Parameters.AddWithValue("@MaPhieu", CInt(TxtMaPhieu.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã phiếu không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maPhieu As String = InputBox("Nhập mã phiếu cần tìm:", "Tìm kiếm")
        If maPhieu = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM PHIEU_NHAP_SACH WHERE MaPhieu=@MaPhieu", conn)
            cmd.Parameters.AddWithValue("@MaPhieu", CInt(maPhieu))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaPhieu.Text = dt.Rows(0)("MaPhieu").ToString()
                CboMaNhanVien.SelectedValue = dt.Rows(0)("MaNhanVien")
                DtpNgayNhap.Value = If(dt.Rows(0)("NgayNhap") IsNot DBNull.Value, CDate(dt.Rows(0)("NgayNhap")), DateTime.Now)
                TxtTongTien.Text = dt.Rows(0)("TongTien").ToString()
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy phiếu nhập!", vbExclamation, "Lỗi")
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
