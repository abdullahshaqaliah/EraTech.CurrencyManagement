using Volo.Abp.Localization;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.Settings;

namespace EraTech.CurrencyManagement.Settings;

public class CurrencyManagementSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        context.Add(
            new SettingDefinition(CurrencyManagementSettings.Currency,
                "USD",
                L("Currency"),
                isVisibleToClients: true)
        );
    }
    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpSettingManagementResource>(name);
    }
}
