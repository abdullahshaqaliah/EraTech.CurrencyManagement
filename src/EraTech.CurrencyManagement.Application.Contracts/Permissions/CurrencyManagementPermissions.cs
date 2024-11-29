using Volo.Abp.Reflection;
using Volo.Abp.SettingManagement;

namespace EraTech.CurrencyManagement.Permissions;

public class CurrencyManagementPermissions
{
    public const string Currency = SettingManagementPermissions.GroupName +".CurrencyManagement";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(CurrencyManagementPermissions));
    }
}
