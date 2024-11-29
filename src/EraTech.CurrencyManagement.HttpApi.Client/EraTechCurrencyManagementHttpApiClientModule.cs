using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(EraTechCurrencyManagementApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class EraTechCurrencyManagementHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddStaticHttpClientProxies(
            typeof(EraTechCurrencyManagementApplicationContractsModule).Assembly,
            CurrencyManagementRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<EraTechCurrencyManagementHttpApiClientModule>();
        });

    }
}
