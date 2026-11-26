using BankAtmManagement.Models;

namespace BankAtmManagement.Services;

/// <summary>
/// Kho dữ liệu dùng chung trong bộ nhớ cho các trạm ATM của hệ thống.
/// </summary>
public static class AtmDataStore
{
    private static readonly object SyncLock = new();

    public static readonly string[] ValidStatuses =
    [
        "Hoạt động",
        "Sắp hết tiền",
        "Bảo trì",
        "Ngừng kết nối"
    ];

    private static readonly List<AtmStation> Stations =
    [
        new AtmStation
        {
            StationCode = "ATM-HN-001",
            LocationAddress = "235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội",
            CashBalance = 1_450_000_000m,
            Status = "Hoạt động",
            LastUpdated = DateTime.Now.AddMinutes(-15)
        },
        new AtmStation
        {
            StationCode = "ATM-HN-002",
            LocationAddress = "54 Liễu Giai, Ba Đình, Hà Nội",
            CashBalance = 820_000_000m,
            Status = "Hoạt động",
            LastUpdated = DateTime.Now.AddMinutes(-32)
        },
        new AtmStation
        {
            StationCode = "ATM-HN-003",
            LocationAddress = "191 Bà Triệu, Hai Bà Trưng, Hà Nội",
            CashBalance = 145_000_000m,
            Status = "Sắp hết tiền",
            LastUpdated = DateTime.Now.AddMinutes(-8)
        },
        new AtmStation
        {
            StationCode = "ATM-HN-004",
            LocationAddress = "144 Xuân Thủy, Cầu Giấy, Hà Nội",
            CashBalance = 0m,
            Status = "Bảo trì",
            LastUpdated = DateTime.Now.AddHours(-2)
        },
        new AtmStation
        {
            StationCode = "ATM-HCM-001",
            LocationAddress = "72 Lê Thánh Tôn, Quận 1, TP. Hồ Chí Minh",
            CashBalance = 2_180_000_000m,
            Status = "Hoạt động",
            LastUpdated = DateTime.Now.AddMinutes(-5)
        },
        new AtmStation
        {
            StationCode = "ATM-HCM-002",
            LocationAddress = "268 Lý Thường Kiệt, Quận 10, TP. Hồ Chí Minh",
            CashBalance = 670_000_000m,
            Status = "Hoạt động",
            LastUpdated = DateTime.Now.AddMinutes(-47)
        },
        new AtmStation
        {
            StationCode = "ATM-DN-001",
            LocationAddress = "115 Nguyễn Văn Linh, Hải Châu, Đà Nẵng",
            CashBalance = 95_000_000m,
            Status = "Ngừng kết nối",
            LastUpdated = DateTime.Now.AddHours(-1)
        }
    ];

    public static List<AtmStation> GetAll(string? keyword = null, string? statusFilter = null)
    {
        lock (SyncLock)
        {
            IEnumerable<AtmStation> query = Stations;

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var term = keyword.Trim();
                query = query.Where(s =>
                    s.StationCode.Contains(term, StringComparison.OrdinalIgnoreCase) ||
                    s.LocationAddress.Contains(term, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(statusFilter) &&
                !statusFilter.Equals("Tất cả", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(s => s.Status.Equals(statusFilter, StringComparison.OrdinalIgnoreCase));
            }

            return query.Select(Clone).ToList();
        }
    }

    public static bool Exists(string stationCode)
    {
        lock (SyncLock)
        {
            return Stations.Any(s => s.StationCode.Equals(stationCode.Trim(), StringComparison.OrdinalIgnoreCase));
        }
    }

    public static (bool Success, string Message) Add(AtmStation station)
    {
        var code = station.StationCode.Trim().ToUpperInvariant();
        if (string.IsNullOrWhiteSpace(code))
            return (false, "Mã trạm ATM không được để trống.");

        if (string.IsNullOrWhiteSpace(station.LocationAddress))
            return (false, "Địa chỉ đặt máy không được để trống.");

        if (station.CashBalance < 0)
            return (false, "Số tiền tồn quỹ không được âm.");

        lock (SyncLock)
        {
            if (Stations.Any(s => s.StationCode.Equals(code, StringComparison.OrdinalIgnoreCase)))
                return (false, $"Mã trạm '{code}' đã tồn tại trong hệ thống.");

            Stations.Add(new AtmStation
            {
                StationCode = code,
                LocationAddress = station.LocationAddress.Trim(),
                CashBalance = station.CashBalance,
                Status = string.IsNullOrWhiteSpace(station.Status) ? "Hoạt động" : station.Status,
                PhotoPath = station.PhotoPath,
                LastUpdated = DateTime.Now
            });
        }

        return (true, $"Đã thêm trạm ATM '{code}' thành công.");
    }

    public static (bool Success, string Message) Update(AtmStation station)
    {
        var code = station.StationCode.Trim().ToUpperInvariant();
        if (string.IsNullOrWhiteSpace(code))
            return (false, "Vui lòng chọn trạm ATM cần cập nhật.");

        if (string.IsNullOrWhiteSpace(station.LocationAddress))
            return (false, "Địa chỉ đặt máy không được để trống.");

        if (station.CashBalance < 0)
            return (false, "Số tiền tồn quỹ không được âm.");

        lock (SyncLock)
        {
            var existing = Stations.FirstOrDefault(s => s.StationCode.Equals(code, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
                return (false, $"Không tìm thấy trạm ATM '{code}'.");

            existing.LocationAddress = station.LocationAddress.Trim();
            existing.CashBalance = station.CashBalance;
            existing.Status = string.IsNullOrWhiteSpace(station.Status) ? existing.Status : station.Status;
            existing.PhotoPath = station.PhotoPath;
            existing.LastUpdated = DateTime.Now;
        }

        return (true, $"Đã cập nhật thông tin trạm '{code}'.");
    }

    public static (bool Success, string Message) Delete(string stationCode)
    {
        var code = stationCode.Trim();
        lock (SyncLock)
        {
            var existing = Stations.FirstOrDefault(s => s.StationCode.Equals(code, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
                return (false, $"Không tìm thấy trạm '{code}' để xóa.");

            Stations.Remove(existing);
        }

        return (true, $"Đã xóa trạm ATM '{code}'.");
    }

    private static AtmStation Clone(AtmStation source) => new()
    {
        StationCode = source.StationCode,
        LocationAddress = source.LocationAddress,
        CashBalance = source.CashBalance,
        Status = source.Status,
        PhotoPath = source.PhotoPath,
        LastUpdated = source.LastUpdated
    };
}
