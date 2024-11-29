using Localization.Resources.AbpUi;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(EraTechCurrencyManagementApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class EraTechCurrencyManagementHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(EraTechCurrencyManagementHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpSettingManagementResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
