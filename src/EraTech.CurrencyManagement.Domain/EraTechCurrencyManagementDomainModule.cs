using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.SettingManagement;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(EraTechCurrencyManagementDomainSharedModule)
)]
public class EraTechCurrencyManagementDomainModule : AbpModule
{

}
