-- Trigger tự động tính tổng tiền phiếu nhập khi thêm chi tiết
CREATE OR ALTER TRIGGER trg_UpdateTongTien_Insert
ON CHI_TIET_NHAP_SACH
AFTER INSERT
AS
BEGIN
    UPDATE PHIEU_NHAP_SACH
    SET TongTien = (
        SELECT ISNULL(SUM(SoLuong * GiaNhap), 0)
        FROM CHI_TIET_NHAP_SACH
        WHERE MaPhieu = PHIEU_NHAP_SACH.MaPhieu
    )
    WHERE MaPhieu IN (SELECT DISTINCT MaPhieu FROM inserted)
END
GO

-- Trigger tự động tính tổng tiền phiếu nhập khi cập nhật chi tiết
CREATE OR ALTER TRIGGER trg_UpdateTongTien_Update
ON CHI_TIET_NHAP_SACH
AFTER UPDATE
AS
BEGIN
    UPDATE PHIEU_NHAP_SACH
    SET TongTien = (
        SELECT ISNULL(SUM(SoLuong * GiaNhap), 0)
        FROM CHI_TIET_NHAP_SACH
        WHERE MaPhieu = PHIEU_NHAP_SACH.MaPhieu
    )
    WHERE MaPhieu IN (SELECT DISTINCT MaPhieu FROM inserted)
END
GO

-- Trigger tự động tính tổng tiền phiếu nhập khi xóa chi tiết
CREATE OR ALTER TRIGGER trg_UpdateTongTien_Delete
ON CHI_TIET_NHAP_SACH
AFTER DELETE
AS
BEGIN
    UPDATE PHIEU_NHAP_SACH
    SET TongTien = (
        SELECT ISNULL(SUM(SoLuong * GiaNhap), 0)
        FROM CHI_TIET_NHAP_SACH
        WHERE MaPhieu = PHIEU_NHAP_SACH.MaPhieu
    )
    WHERE MaPhieu IN (SELECT DISTINCT MaPhieu FROM deleted)
END
GO
