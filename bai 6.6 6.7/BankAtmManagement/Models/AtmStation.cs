namespace BankAtmManagement.Models;

/// <summary>
/// Đại diện cho một trạm ATM trong mạng lưới ngân hàng.
/// </summary>
public class AtmStation
{
    public string StationCode { get; set; } = string.Empty;
    public string LocationAddress { get; set; } = string.Empty;
    public decimal CashBalance { get; set; }
    public string Status { get; set; } = "Hoạt động";
    public string? PhotoPath { get; set; }
    public DateTime LastUpdated { get; set; } = DateTime.Now;

    public string HasPhotoDisplay =>
        !string.IsNullOrWhiteSpace(PhotoPath) && File.Exists(PhotoPath)
            ? Path.GetFileName(PhotoPath)
            : "Chưa đính kèm";
}
