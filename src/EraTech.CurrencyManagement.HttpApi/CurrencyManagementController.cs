using EraTech.CurrencyManagement;
using EraTech.CurrencyManagement.Dtos;
using EraTech.CurrencyManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.SettingManagement.Localization;

[Area(CurrencyManagementRemoteServiceConsts.ModuleName)]
[RemoteService(Name = CurrencyManagementRemoteServiceConsts.RemoteServiceName)]
[Route("api/setting-management/Currency")]
[Authorize(CurrencyManagementPermissions.Currency)]
public class CurrencyManagementController : AbpControllerBase, ICurrencyAppService
{
    private readonly ICurrencyAppService _currencySettingsAppService;

    public CurrencyManagementController(ICurrencyAppService currencySettingsAppService)
    {
        LocalizationResource = typeof(AbpSettingManagementResource);
        _currencySettingsAppService = currencySettingsAppService;
    }

    [HttpGet]
    public Task<CurrencySettingsDto> GetAsync()
    {
        return _currencySettingsAppService.GetAsync();
    }


    [HttpPost]
    public Task UpdateAsync(UpdateCurrencySettingsDto input)
    {
        return _currencySettingsAppService.UpdateAsync(input);
    }
}