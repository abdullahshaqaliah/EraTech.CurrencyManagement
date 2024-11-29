using Volo.Abp.Modularity;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(EraTechCurrencyManagementDomainModule),
    typeof(CurrencyManagementTestBaseModule)
)]
public class CurrencyManagementDomainTestModule : AbpModule
{

}
