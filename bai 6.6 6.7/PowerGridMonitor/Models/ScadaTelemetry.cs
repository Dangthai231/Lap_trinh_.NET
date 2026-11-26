namespace PowerGridMonitor.Models;

/// <summary>
/// Bản tin thông số vận hành SCADA thu thập từ trạm biến áp theo chu kỳ.
/// </summary>
public sealed class TelemetrySample
{
    public const int OverloadThresholdPercent = 85;

    public string SubstationName { get; init; } = string.Empty;
    public double VoltageKv { get; init; }
    public int LoadPercent { get; init; }
    public DateTime Timestamp { get; init; }
    public int CycleNumber { get; init; }

    public bool IsOverload => LoadPercent > OverloadThresholdPercent;
    public string StatusText => IsOverload ? "Quá tải" : "Ổn định";
}
