using System.Linq;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.Validation.StringValues;

namespace EraTech.PushNotification.Firebase;

public class CurrencyManagementFeatureDefinitionProvider : FeatureDefinitionProvider
{
    public override void Define(IFeatureDefinitionContext context)
    {

        var group = context.GetGroupOrNull(SettingManagementFeatures.GroupName)!;

        var settingEnableFeature = group.Features.First(e => e.Name == SettingManagementFeatures.Enable);

        settingEnableFeature.CreateChild(
            CurrencyManagementFeatures.AllowChangingCurrencySettings,
            "true",
            L("Feature:AllowChangingCurrencySettings"),
            null,
            new ToggleStringValueType(),
            isAvailableToHost: true);
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AbpSettingManagementResource>(name);
    }
}
