using EraTech.CurrencyManagement.Web.Pages.SettingManagement.Components.CurrencySettingGroup;
using EraTech.CurrencyManagement.Permissions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Web.Pages.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using EraTech.PushNotification.Firebase;

namespace EraTech.CurrencyManagement.Web.Settings;

public class CurrencySettingPageContributor : SettingPageContributorBase
{
    public CurrencySettingPageContributor()
    {
        RequiredTenantSideFeatures(SettingManagementFeatures.Enable);
        RequiredTenantSideFeatures(CurrencyManagementFeatures.AllowChangingCurrencySettings);
        RequiredPermissions(CurrencyManagementPermissions.Currency);
    }

    public override Task ConfigureAsync(SettingPageCreationContext context)
    {
        var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpSettingManagementResource>>();
        context.Groups.Add(
            new SettingPageGroup(
                "EraTech.Settings.Currency",
                l["Menu:Settings:Currency"],
                typeof(CurrencySettingGroupViewComponent)
            )
        );
        return Task.CompletedTask;
    }
}
