using Volo.Abp.SettingManagement.Localization;
using Volo.Abp.Application.Services;

namespace EraTech.CurrencyManagement;

public abstract class CurrencyManagementAppService : ApplicationService
{
    protected CurrencyManagementAppService()
    {
        LocalizationResource = typeof(AbpSettingManagementResource);
        ObjectMapperContext = typeof(EraTechCurrencyManagementApplicationModule);
    }
}
