using EraTech.WhatsApp.Facebook;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;

namespace EraTech.CurrencyManagement.Permissions;

public class CurrencyManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var settings = context.GetGroup(SettingManagementPermissions.GroupName);

         settings
             .AddPermission(CurrencyManagementPermissions.Currency, L("Permission:Settings:Currency"))
             .StateCheckers.Add(new AllowChangingCurrencySettingsFeatureSimpleStateChecker());
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpSettingManagementResource>(name);
    }
}
