Imports Microsoft.Data.SqlClient

Public Class T_Sach
    Private viTriHienTai As Integer = 0
    Private quyen As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal userQuyen As String)
        InitializeComponent()
        Me.quyen = userQuyen
    End Sub

    Private Sub T_Sach_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Kiểm tra quyền và ẩn các nút thêm/sửa/xóa nếu là nhân viên
        If quyen = "NhanVien" Then
            BtThem.Visible = False
            BtSua.Visible = False
            BtXoa.Visible = False
        End If
        LoadData()
    End Sub

    Private Sub LoadData()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM SACH", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                Try
                    DataGridView1.Columns("MaSach").HeaderText = "Mã Sách"
                    DataGridView1.Columns("TenSach").HeaderText = "Tên Sách"
                    DataGridView1.Columns("TacGia").HeaderText = "Tác giả"
                    DataGridView1.Columns("SoLuong").HeaderText = "Số lượng"

                    ' Kiểm tra xem cột có tồn tại không trước khi đặt tên
                    If DataGridView1.Columns.Contains("NhaXuatBan") Then
                        DataGridView1.Columns("NhaXuatBan").HeaderText = "Nhà xuất bản"
                    End If
                    If DataGridView1.Columns.Contains("NamXuatBan") Then
                        DataGridView1.Columns("NamXuatBan").HeaderText = "Năm xuất bản"
                    End If
                Catch ex As Exception
                    ' Bỏ qua lỗi đặt tên cột nếu cột không tồn tại
                End Try
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
            Try
                DataGridView1.Rows(viTriHienTai).Selected = True
                DataGridView1.CurrentCell = DataGridView1.Rows(viTriHienTai).Cells(0)
                Dim row As DataGridViewRow = DataGridView1.Rows(viTriHienTai)

                ' Chỉ cập nhật các TextBox có sẵn
                If row.Cells("MaSach").Value IsNot Nothing Then
                    TxtMaSach.Text = row.Cells("MaSach").Value.ToString()
                End If
                If row.Cells("TenSach").Value IsNot Nothing Then
                    TxtTenSach.Text = row.Cells("TenSach").Value.ToString()
                End If
                If row.Cells("TacGia").Value IsNot Nothing Then
                    TxtTacGia.Text = row.Cells("TacGia").Value.ToString()
                End If
                If row.Cells("SoLuong").Value IsNot Nothing Then
                    TxtSoLuong.Text = row.Cells("SoLuong").Value.ToString()
                End If
                If row.Cells("NhaXuatBan").Value IsNot Nothing Then
                    TxtNhaXuatBan.Text = row.Cells("NhaXuatBan").Value.ToString()
                End If
                If row.Cells("NamXuatBan").Value IsNot Nothing Then
                    TxtNamXuatBan.Text = row.Cells("NamXuatBan").Value.ToString()
                End If
            Catch ex As Exception
                MsgBox("Lỗi cập nhật dữ liệu: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub
    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaSach.Text.Trim() = "" Or TxtTenSach.Text.Trim() = "" Or TxtTacGia.Text.Trim() = "" Or TxtSoLuong.Text.Trim() = "" Or TxtNhaXuatBan.Text.Trim() = "" Or TxtNamXuatBan.Text.Trim() = "" Then
            MsgBox("Vui lòng điền đầy đủ thông tin!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng MaSach
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM SACH WHERE MaSach=@MaSach", conn)
            checkCmd.Parameters.AddWithValue("@MaSach", CInt(TxtMaSach.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã sách đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO SACH (MaSach, TenSach, TacGia, SoLuong, NhaXuatBan, NamXuatBan) VALUES (@MaSach, @TenSach, @TacGia, @SoLuong, @NhaXuatBan, @NamXuatBan)", conn)
            cmd.Parameters.AddWithValue("@MaSach", CInt(TxtMaSach.Text))
            cmd.Parameters.AddWithValue("@TenSach", TxtTenSach.Text.Trim())
            cmd.Parameters.AddWithValue("@TacGia", TxtTacGia.Text.Trim())
            cmd.Parameters.AddWithValue("@SoLuong", CInt(TxtSoLuong.Text))
            cmd.Parameters.AddWithValue("@NhaXuatBan", TxtNhaXuatBan.Text.Trim())
            cmd.Parameters.AddWithValue("@NamXuatBan", CInt(TxtNamXuatBan.Text))

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaSach.Clear()
            TxtTenSach.Clear()
            TxtTacGia.Clear()
            TxtSoLuong.Clear()
            TxtNhaXuatBan.Clear()
            TxtNamXuatBan.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaSach.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn mặt hàng để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE SACH SET TenSach=@TenSach, TacGia=@TacGia, SoLuong=@SoLuong, NhaXuatBan=@NhaXuatBan, NamXuatBan=@NamXuatBan WHERE MaSach=@MaSach", conn)
            cmd.Parameters.AddWithValue("@MaSach", CInt(TxtMaSach.Text))
            cmd.Parameters.AddWithValue("@TenSach", TxtTenSach.Text.Trim())
            cmd.Parameters.AddWithValue("@TacGia", TxtTacGia.Text.Trim())
            cmd.Parameters.AddWithValue("@SoLuong", CInt(TxtSoLuong.Text))
            cmd.Parameters.AddWithValue("@NhaXuatBan", TxtNhaXuatBan.Text.Trim())
            cmd.Parameters.AddWithValue("@NamXuatBan", CInt(TxtNamXuatBan.Text))

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã sách không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaSach.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn sách để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa sách này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM SACH WHERE MaSach=@MaSach", conn)
                cmd.Parameters.AddWithValue("@MaSach", CInt(TxtMaSach.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã sách không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maMH As String = InputBox("Nhập mã sách cần tìm:", "Tìm kiếm")
        If maMH = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM SACH WHERE MaSach=@MaSach", conn)
            cmd.Parameters.AddWithValue("@MaSach", CInt(maMH))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Try
                    If dt.Rows(0)("MaSach") IsNot Nothing Then
                        TxtMaSach.Text = dt.Rows(0)("MaSach").ToString()
                    End If
                    If dt.Rows(0)("TenSach") IsNot Nothing Then
                        TxtTenSach.Text = dt.Rows(0)("TenSach").ToString()
                    End If
                    If dt.Rows(0)("TacGia") IsNot Nothing Then
                        TxtTacGia.Text = dt.Rows(0)("TacGia").ToString()
                    End If
                    If dt.Rows(0)("SoLuong") IsNot Nothing Then
                        TxtSoLuong.Text = dt.Rows(0)("SoLuong").ToString()
                    End If
                    If dt.Rows(0)("NhaXuatBan") IsNot Nothing Then
                        TxtNhaXuatBan.Text = dt.Rows(0)("NhaXuatBan").ToString()
                    End If
                    If dt.Rows(0)("NamXuatBan") IsNot Nothing Then
                        TxtNamXuatBan.Text = dt.Rows(0)("NamXuatBan").ToString()
                    End If
                    DataGridView1.DataSource = dt
                Catch ex As Exception
                    MsgBox("Lỗi hiển thị dữ liệu tìm kiếm: " & ex.Message, vbCritical, "Lỗi")
                End Try
            Else
                MsgBox("Không tìm thấy sách!", vbExclamation, "Lỗi")
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

    Private Sub TxtGia_TextChanged(sender As Object, e As EventArgs) Handles TxtTacGia.TextChanged

    End Sub

    Private Sub TxtTenSach_TextChanged(sender As Object, e As EventArgs) Handles TxtTenSach.TextChanged

    End Sub
End Class
