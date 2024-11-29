using Volo.Abp.Modularity;

namespace EraTech.CurrencyManagement;

[DependsOn(
    typeof(EraTechCurrencyManagementApplicationModule),
    typeof(CurrencyManagementDomainTestModule)
    )]
public class CurrencyManagementApplicationTestModule : AbpModule
{

}
