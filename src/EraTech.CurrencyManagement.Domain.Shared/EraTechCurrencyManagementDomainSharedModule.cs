using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Domain;
using Volo.Abp.Features;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.Validation;
using Volo.Abp.VirtualFileSystem;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(AbpValidationModule),
    typeof(AbpDddDomainSharedModule),
    typeof(AbpFeaturesModule),
    typeof(AbpSettingManagementDomainSharedModule)
)]
public class EraTechCurrencyManagementDomainSharedModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EraTechCurrencyManagementDomainSharedModule>();
        });

        context.Services.Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AbpSettingManagementResource>()
                .AddVirtualJson("/Localization/CurrencyManagement");
        });

    }
}
