Imports Microsoft.Data.SqlClient
Imports System.Data.SqlClient

Public Class T_DocGia
    Private viTriHienTai As Integer = 0
    Private quyen As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal userQuyen As String)
        InitializeComponent()
        Me.quyen = userQuyen
    End Sub

    Private Sub T_DocGia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Dim da As New SqlDataAdapter("SELECT * FROM DOC_GIA", conn)
            Dim dt As New DataTable()
            da.Fill(dt)
            DataGridView1.DataSource = dt
            conn.Close()

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaDocGia").HeaderText = "Mã độc giả"
                DataGridView1.Columns("HoTen").HeaderText = "Họ tên"
                DataGridView1.Columns("NgaySinh").HeaderText = "Ngày sinh"
                DataGridView1.Columns("DiaChi").HeaderText = "Địa chỉ"
                DataGridView1.Columns("SoDienThoai").HeaderText = "Số điện thoại"
                DataGridView1.Columns("Email").HeaderText = "Email"
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
            TxtMaDocGia.Text = If(row.Cells("MaDocGia").Value IsNot Nothing, row.Cells("MaDocGia").Value.ToString(), "")
            TxtHoTen.Text = If(row.Cells("HoTen").Value IsNot Nothing, row.Cells("HoTen").Value.ToString(), "")
            DtpNgaySinh.Value = If(row.Cells("NgaySinh").Value IsNot Nothing AndAlso IsDate(row.Cells("NgaySinh").Value), CDate(row.Cells("NgaySinh").Value), DateTime.Now)
            TxtDiaChi.Text = If(row.Cells("DiaChi").Value IsNot Nothing, row.Cells("DiaChi").Value.ToString(), "")
            TxtSoDienThoai.Text = If(row.Cells("SoDienThoai").Value IsNot Nothing, row.Cells("SoDienThoai").Value.ToString(), "")
            TxtEmail.Text = If(row.Cells("Email").Value IsNot Nothing, row.Cells("Email").Value.ToString(), "")
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        If TxtMaDocGia.Text.Trim() = "" Or TxtHoTen.Text.Trim() = "" Or TxtDiaChi.Text.Trim() = "" Then
            MsgBox("Vui lòng điền đầy đủ thông tin bắt buộc!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Kiểm tra trùng MaDocGia
            Dim checkCmd As New SqlCommand("SELECT COUNT(*) FROM DOC_GIA WHERE MaDocGia=@MaDocGia", conn)
            checkCmd.Parameters.AddWithValue("@MaDocGia", CInt(TxtMaDocGia.Text))
            If CInt(checkCmd.ExecuteScalar()) > 0 Then
                MsgBox("Mã độc giả đã tồn tại!", vbExclamation, "Lỗi")
                conn.Close()
                Exit Sub
            End If

            Dim cmd As New SqlCommand("INSERT INTO DOC_GIA (MaDocGia, HoTen, NgaySinh, DiaChi, SoDienThoai, Email) VALUES (@MaDocGia, @HoTen, @NgaySinh, @DiaChi, @SoDienThoai, @Email)", conn)
            cmd.Parameters.AddWithValue("@MaDocGia", CInt(TxtMaDocGia.Text))
            cmd.Parameters.AddWithValue("@HoTen", TxtHoTen.Text.Trim())
            cmd.Parameters.AddWithValue("@NgaySinh", DtpNgaySinh.Value)
            cmd.Parameters.AddWithValue("@DiaChi", TxtDiaChi.Text.Trim())
            cmd.Parameters.AddWithValue("@SoDienThoai", If(TxtSoDienThoai.Text.Trim() = "", DBNull.Value, TxtSoDienThoai.Text.Trim()))
            cmd.Parameters.AddWithValue("@Email", If(TxtEmail.Text.Trim() = "", DBNull.Value, TxtEmail.Text.Trim()))

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()
            LoadData()

            TxtMaDocGia.Clear()
            TxtHoTen.Clear()
            DtpNgaySinh.Value = DateTime.Now
            TxtDiaChi.Clear()
            TxtSoDienThoai.Clear()
            TxtEmail.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaDocGia.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn độc giả để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE DOC_GIA SET HoTen=@HoTen, NgaySinh=@NgaySinh, DiaChi=@DiaChi, SoDienThoai=@SoDienThoai, Email=@Email WHERE MaDocGia=@MaDocGia", conn)
            cmd.Parameters.AddWithValue("@MaDocGia", CInt(TxtMaDocGia.Text))
            cmd.Parameters.AddWithValue("@HoTen", TxtHoTen.Text.Trim())
            cmd.Parameters.AddWithValue("@NgaySinh", DtpNgaySinh.Value)
            cmd.Parameters.AddWithValue("@DiaChi", TxtDiaChi.Text.Trim())
            cmd.Parameters.AddWithValue("@SoDienThoai", If(TxtSoDienThoai.Text.Trim() = "", DBNull.Value, TxtSoDienThoai.Text.Trim()))
            cmd.Parameters.AddWithValue("@Email", If(TxtEmail.Text.Trim() = "", DBNull.Value, TxtEmail.Text.Trim()))

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                LoadData()
            Else
                MsgBox("Mã độc giả không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaDocGia.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn độc giả để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa độc giả này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()

                Dim cmd As New SqlCommand("DELETE FROM DOC_GIA WHERE MaDocGia=@MaDocGia", conn)
                cmd.Parameters.AddWithValue("@MaDocGia", CInt(TxtMaDocGia.Text))

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    LoadData()
                Else
                    MsgBox("Mã độc giả không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maDG As String = InputBox("Nhập mã độc giả cần tìm:", "Tìm kiếm")
        If maDG = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM DOC_GIA WHERE MaDocGia=@MaDocGia", conn)
            cmd.Parameters.AddWithValue("@MaDocGia", CInt(maDG))
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaDocGia.Text = dt.Rows(0)("MaDocGia").ToString()
                TxtHoTen.Text = dt.Rows(0)("HoTen").ToString()
                DtpNgaySinh.Value = If(dt.Rows(0)("NgaySinh") IsNot DBNull.Value, CDate(dt.Rows(0)("NgaySinh")), DateTime.Now)
                TxtDiaChi.Text = dt.Rows(0)("DiaChi").ToString()
                TxtSoDienThoai.Text = If(dt.Rows(0)("SoDienThoai") IsNot DBNull.Value, dt.Rows(0)("SoDienThoai").ToString(), "")
                TxtEmail.Text = If(dt.Rows(0)("Email") IsNot DBNull.Value, dt.Rows(0)("Email").ToString(), "")
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy độc giả!", vbExclamation, "Lỗi")
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
