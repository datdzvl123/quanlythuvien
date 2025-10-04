Imports Microsoft.Data.SqlClient

Public Class DBConnection
    Public Shared Function GetConnection() As SqlConnection
        'Return New SqlConnection("Data Source=localhost\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True;TrustServerCertificate=True")
        Return New SqlConnection("Data Source=localhost;Database=QuanLyThuVien;user id=SA;password=Password@123;TrustServerCertificate=True")

    End Function
End Class