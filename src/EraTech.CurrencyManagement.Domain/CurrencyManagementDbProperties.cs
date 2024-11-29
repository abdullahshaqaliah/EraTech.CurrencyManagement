namespace EraTech.CurrencyManagement;

public static class CurrencyManagementDbProperties
{
    public static string DbTablePrefix { get; set; } = "CurrencyManagement";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "CurrencyManagement";
}
