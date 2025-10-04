Imports Microsoft.Data.SqlClient
Imports System.Data.SqlClient

Public Class T_ChiTietPhieuNhap
    Private viTriHienTai As Integer = 0
    Private currentMaPhieu As Integer = 0

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal maPhieu As Integer)
        InitializeComponent()
        currentMaPhieu = maPhieu
    End Sub

    Private Sub T_ChiTietPhieuNhap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPhieuNhap()
        LoadSach()

        If currentMaPhieu > 0 Then
            ' Nếu có mã phiếu, hiển thị và khóa textbox
            TxtMaPhieu.Text = currentMaPhieu.ToString()
            TxtMaPhieu.ReadOnly = True
            TxtMaPhieu.Visible = True
            CboMaPhieu.Visible = False
            Label6.Visible = True
            LoadData()
        Else
            ' Nếu không có mã phiếu, hiển thị ComboBox để chọn
            TxtMaPhieu.Visible = False
            CboMaPhieu.Visible = True
            Label6.Visible = True
        End If
    End Sub

    Private Sub LoadData()
        ' Debug: Hiển thị giá trị currentMaPhieu
        Debug.WriteLine("currentMaPhieu: " & currentMaPhieu)

        If currentMaPhieu = 0 Then
            DataGridView1.DataSource = Nothing
            ' Thông báo cho người dùng biết cần chọn phiếu nhập
            If CboMaPhieu.Visible Then
                MsgBox("Vui lòng chọn mã phiếu nhập để hiển thị chi tiết!", vbInformation, "Thông báo")
            End If
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim da As New SqlDataAdapter("SELECT * FROM CHI_TIET_NHAP_SACH WHERE MaPhieu=@MaPhieu", conn)
            da.SelectCommand.Parameters.AddWithValue("@MaPhieu", currentMaPhieu)
            Dim dt As New DataTable()
            da.Fill(dt)

            ' Debug: Hiển thị số lượng bản ghi tìm được
            Debug.WriteLine("Số bản ghi tìm được: " & dt.Rows.Count)

            DataGridView1.DataSource = dt
            conn.Close()

            ' Hiển thị thông báo nếu không có dữ liệu
            If dt.Rows.Count = 0 Then
                MsgBox("Không tìm thấy chi tiết nào cho phiếu nhập này!", vbInformation, "Thông báo")
            End If

            ' Đặt tên cột tiếng Việt
            If DataGridView1.Columns.Count > 0 Then
                DataGridView1.Columns("MaChiTiet").HeaderText = "Mã chi tiết"
                DataGridView1.Columns("MaPhieu").HeaderText = "Mã phiếu"
                DataGridView1.Columns("MaSach").HeaderText = "Mã sách"
                DataGridView1.Columns("SoLuong").HeaderText = "Số lượng"
                DataGridView1.Columns("GiaNhap").HeaderText = "Giá nhập"
            End If

            If DataGridView1.Rows.Count > 0 Then
                viTriHienTai = 0
                UpdateDataGridView()
            End If
        Catch ex As Exception
            MsgBox("Lỗi tải dữ liệu: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub LoadSach()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT MaSach, TenSach FROM SACH", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            CboMaSach.DataSource = dt
            CboMaSach.DisplayMember = "TenSach"
            CboMaSach.ValueMember = "MaSach"
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi tải danh sách sách: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub LoadPhieuNhap()
        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()
            Dim cmd As New SqlCommand("SELECT MaPhieu, NgayNhap FROM PHIEU_NHAP_SACH", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            CboMaPhieu.DataSource = dt
            CboMaPhieu.DisplayMember = "MaPhieu"
            CboMaPhieu.ValueMember = "MaPhieu"
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi tải danh sách phiếu nhập: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub UpdateDataGridView()
        If DataGridView1.Rows.Count > 0 AndAlso viTriHienTai >= 0 AndAlso viTriHienTai < DataGridView1.Rows.Count Then
            DataGridView1.Rows(viTriHienTai).Selected = True
            DataGridView1.CurrentCell = DataGridView1.Rows(viTriHienTai).Cells(0)
            Dim row As DataGridViewRow = DataGridView1.Rows(viTriHienTai)
            TxtMaChiTiet.Text = If(row.Cells("MaChiTiet").Value IsNot Nothing, row.Cells("MaChiTiet").Value.ToString(), "")

            If row.Cells("MaSach").Value IsNot Nothing Then
                CboMaSach.SelectedValue = row.Cells("MaSach").Value
            End If

            TxtSoLuong.Text = If(row.Cells("SoLuong").Value IsNot Nothing, row.Cells("SoLuong").Value.ToString(), "")
            TxtGiaNhap.Text = If(row.Cells("GiaNhap").Value IsNot Nothing, row.Cells("GiaNhap").Value.ToString(), "")
        End If
    End Sub

    Private Sub BtThem_Click(sender As Object, e As EventArgs) Handles BtThem.Click
        Dim maPhieu As Integer

        If currentMaPhieu > 0 Then
            maPhieu = currentMaPhieu
        Else
            If CboMaPhieu.SelectedValue Is Nothing OrElse IsDBNull(CboMaPhieu.SelectedValue) Then
                MsgBox("Vui lòng chọn mã phiếu nhập!", vbExclamation, "Lỗi")
                Exit Sub
            End If
            If Not Integer.TryParse(CboMaPhieu.SelectedValue.ToString(), maPhieu) Then
                MsgBox("Mã phiếu không hợp lệ!", vbExclamation, "Lỗi")
                Exit Sub
            End If
        End If

        ' Validate sách
        If CboMaSach.SelectedValue Is Nothing OrElse IsDBNull(CboMaSach.SelectedValue) Then
            MsgBox("Vui lòng chọn sách!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        ' Validate số lượng
        Dim soLuong As Integer
        If TxtSoLuong.Text.Trim() = "" OrElse Not Integer.TryParse(TxtSoLuong.Text, soLuong) OrElse soLuong <= 0 Then
            MsgBox("Số lượng phải là số nguyên dương!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        ' Validate đơn giá
        Dim giaNhap As Decimal
        If TxtGiaNhap.Text.Trim() = "" OrElse Not Decimal.TryParse(TxtGiaNhap.Text, giaNhap) OrElse giaNhap <= 0 Then
            MsgBox("Giá nhập phải là số dương!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Lấy mã chi tiết tiếp theo
            Dim getMaChiTietCmd As New SqlCommand("SELECT ISNULL(MAX(MaChiTiet), 0) + 1 FROM CHI_TIET_NHAP_SACH", conn)
            Dim maChiTiet As Integer = CInt(getMaChiTietCmd.ExecuteScalar())

            Dim cmd As New SqlCommand("INSERT INTO CHI_TIET_NHAP_SACH (MaChiTiet, MaPhieu, MaSach, SoLuong, GiaNhap) VALUES (@MaChiTiet, @MaPhieu, @MaSach, @SoLuong, @GiaNhap)", conn)
            cmd.Parameters.AddWithValue("@MaChiTiet", maChiTiet)
            cmd.Parameters.AddWithValue("@MaPhieu", maPhieu)
            cmd.Parameters.AddWithValue("@MaSach", CInt(CboMaSach.SelectedValue))
            cmd.Parameters.AddWithValue("@SoLuong", soLuong)
            cmd.Parameters.AddWithValue("@GiaNhap", giaNhap)

            cmd.ExecuteNonQuery()
            MsgBox("Thêm thành công!", vbInformation, "Thành công")
            conn.Close()

            ' Cập nhật currentMaPhieu nếu đang ở chế độ chọn
            If currentMaPhieu = 0 Then
                currentMaPhieu = maPhieu
                TxtMaPhieu.Text = currentMaPhieu.ToString()
                TxtMaPhieu.Visible = True
                CboMaPhieu.Visible = False
            End If

            LoadData()

            TxtMaChiTiet.Clear()
            TxtSoLuong.Clear()
            TxtGiaNhap.Clear()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtSua_Click(sender As Object, e As EventArgs) Handles BtSua.Click
        If TxtMaChiTiet.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn chi tiết để sửa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("UPDATE CHI_TIET_NHAP_SACH SET MaSach=@MaSach, SoLuong=@SoLuong, GiaNhap=@GiaNhap WHERE MaChiTiet=@MaChiTiet AND MaPhieu=@MaPhieu", conn)
            cmd.Parameters.AddWithValue("@MaChiTiet", CInt(TxtMaChiTiet.Text))
            cmd.Parameters.AddWithValue("@MaPhieu", currentMaPhieu)
            cmd.Parameters.AddWithValue("@MaSach", CInt(CboMaSach.SelectedValue))
            cmd.Parameters.AddWithValue("@SoLuong", CInt(TxtSoLuong.Text))
            cmd.Parameters.AddWithValue("@GiaNhap", CDec(TxtGiaNhap.Text))

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                MsgBox("Cập nhật thành công!", vbInformation, "Thành công")
                CapNhatTongTien()
                LoadData()
            Else
                MsgBox("Mã chi tiết không tồn tại!", vbExclamation, "Lỗi")
            End If
            conn.Close()
        Catch ex As Exception
            MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
        End Try
    End Sub

    Private Sub BtXoa_Click(sender As Object, e As EventArgs) Handles BtXoa.Click
        If TxtMaChiTiet.Text.Trim() = "" Then
            MsgBox("Vui lòng chọn chi tiết để xóa!", vbExclamation, "Lỗi")
            Exit Sub
        End If

        If MsgBox("Bạn có chắc muốn xóa chi tiết này?", vbQuestion + vbYesNo, "Xác nhận") = vbYes Then
            Try
                Dim conn As SqlConnection = DBConnection.GetConnection()
                conn.Open()
                Dim cmd As New SqlCommand("DELETE FROM CHI_TIET_NHAP_SACH WHERE MaChiTiet=@MaChiTiet AND MaPhieu=@MaPhieu", conn)
                cmd.Parameters.AddWithValue("@MaChiTiet", CInt(TxtMaChiTiet.Text))
                cmd.Parameters.AddWithValue("@MaPhieu", currentMaPhieu)

                Dim result As Integer = cmd.ExecuteNonQuery()
                If result > 0 Then
                    MsgBox("Xóa thành công!", vbInformation, "Thành công")
                    CapNhatTongTien()
                    LoadData()
                Else
                    MsgBox("Mã chi tiết không tồn tại!", vbExclamation, "Lỗi")
                End If
                conn.Close()
            Catch ex As Exception
                MsgBox("Lỗi: " & ex.Message, vbCritical, "Lỗi")
            End Try
        End If
    End Sub

    Private Sub BtTimKiem_Click(sender As Object, e As EventArgs) Handles BtTimKiem.Click
        Dim maChiTiet As String = InputBox("Nhập mã chi tiết cần tìm:", "Tìm kiếm")
        If maChiTiet = "" Then Exit Sub

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            Dim cmd As New SqlCommand("SELECT * FROM CHI_TIET_NHAP_SACH WHERE MaChiTiet=@MaChiTiet AND MaPhieu=@MaPhieu", conn)
            cmd.Parameters.AddWithValue("@MaChiTiet", CInt(maChiTiet))
            cmd.Parameters.AddWithValue("@MaPhieu", currentMaPhieu)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                TxtMaChiTiet.Text = dt.Rows(0)("MaChiTiet").ToString()
                CboMaSach.SelectedValue = dt.Rows(0)("MaSach")
                TxtSoLuong.Text = dt.Rows(0)("SoLuong").ToString()
                TxtGiaNhap.Text = dt.Rows(0)("GiaNhap").ToString()
                DataGridView1.DataSource = dt
            Else
                MsgBox("Không tìm thấy chi tiết!", vbExclamation, "Lỗi")
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

    Private Sub CboMaPhieu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CboMaPhieu.SelectedIndexChanged
        ' Debug: Hiển thị giá trị được chọn
        If CboMaPhieu.SelectedValue IsNot Nothing Then
            Debug.WriteLine("SelectedValue: " & CboMaPhieu.SelectedValue.ToString())
        Else
            Debug.WriteLine("SelectedValue: Nothing")
        End If

        If CboMaPhieu.SelectedValue IsNot Nothing AndAlso Not IsDBNull(CboMaPhieu.SelectedValue) AndAlso Integer.TryParse(CboMaPhieu.SelectedValue.ToString(), currentMaPhieu) Then
            Debug.WriteLine("currentMaPhieu được cập nhật thành: " & currentMaPhieu)
            LoadData()
        Else
            Debug.WriteLine("Không thể cập nhật currentMaPhieu")
        End If
    End Sub

    Private Sub TxtSoLuong_TextChanged(sender As Object, e As EventArgs) Handles TxtSoLuong.TextChanged
        CapNhatTongTien()
    End Sub

    Private Sub TxtGiaNhap_TextChanged(sender As Object, e As EventArgs) Handles TxtGiaNhap.TextChanged
        CapNhatTongTien()
    End Sub

    Private Sub CapNhatTongTien()
        If currentMaPhieu = 0 Then Exit Sub

        Dim soLuong As Integer
        Dim giaNhap As Decimal

        ' Kiểm tra và chuyển đổi số lượng
        If Not Integer.TryParse(TxtSoLuong.Text, soLuong) OrElse soLuong <= 0 Then
            Exit Sub
        End If

        ' Kiểm tra và chuyển đổi đơn giá
        If Not Decimal.TryParse(TxtGiaNhap.Text, giaNhap) OrElse giaNhap <= 0 Then
            Exit Sub
        End If

        Try
            Dim conn As SqlConnection = DBConnection.GetConnection()
            conn.Open()

            ' Tính tổng tiền cho tất cả chi tiết của phiếu nhập này
            Dim cmd As New SqlCommand("SELECT SUM(SoLuong * GiaNhap) FROM CHI_TIET_NHAP_SACH WHERE MaPhieu=@MaPhieu", conn)
            cmd.Parameters.AddWithValue("@MaPhieu", currentMaPhieu)
            Dim tongTien As Object = cmd.ExecuteScalar()

            ' Cập nhật tổng tiền vào bảng PHIEU_NHAP_SACH
            Dim updateCmd As New SqlCommand("UPDATE PHIEU_NHAP_SACH SET TongTien=@TongTien WHERE MaPhieu=@MaPhieu", conn)
            updateCmd.Parameters.AddWithValue("@MaPhieu", currentMaPhieu)
            updateCmd.Parameters.AddWithValue("@TongTien", If(tongTien IsNot DBNull.Value AndAlso IsNumeric(tongTien), CDec(tongTien), 0))
            updateCmd.ExecuteNonQuery()

            conn.Close()
        Catch ex As Exception
            ' Không hiển thị lỗi để không làm gián đoạn người dùng nhập liệu
        End Try
    End Sub
End Class
