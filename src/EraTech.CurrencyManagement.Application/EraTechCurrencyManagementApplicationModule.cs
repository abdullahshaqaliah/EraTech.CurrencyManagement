using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(EraTechCurrencyManagementDomainModule),
    typeof(EraTechCurrencyManagementApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class EraTechCurrencyManagementApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<EraTechCurrencyManagementApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<EraTechCurrencyManagementApplicationModule>(validate: true);
        });
    }
}
