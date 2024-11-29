using EraTech.CurrencyManagement.Dtos;
using EraTech.CurrencyManagement.Permissions;
using EraTech.CurrencyManagement.Settings;
using EraTech.PushNotification.Firebase;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;

namespace EraTech.CurrencyManagement;

[Authorize(CurrencyManagementPermissions.Currency)]

public class CurrencyAppService : CurrencyManagementAppService, ICurrencyAppService
{
    protected ISettingManager SettingManager { get; }
    public CurrencyAppService(ISettingManager settingManager)
    {
        SettingManager = settingManager;
    }

    public async Task<CurrencySettingsDto> GetAsync()
    {
        await CheckFeatureAsync();
        var settingsDto = new CurrencySettingsDto()
        {
            Currency = (await SettingProvider.GetOrNullAsync(CurrencyManagementSettings.Currency))!
        };


        if (CurrentTenant.IsAvailable)
        {
            settingsDto.Currency = await SettingManager.GetOrNullForTenantAsync(CurrencyManagementSettings.Currency, CurrentTenant.GetId(), false);
        }
        return settingsDto;
    }


    public async Task UpdateAsync(UpdateCurrencySettingsDto input)
    {
        await CheckFeatureAsync();

        await SettingManager.SetForTenantOrGlobalAsync(CurrentTenant.Id, CurrencyManagementSettings.Currency, input.Currency);

    }

    protected virtual async Task CheckFeatureAsync()
    {
        await FeatureChecker.CheckEnabledAsync(SettingManagementFeatures.Enable);
        if (CurrentTenant.IsAvailable)
        {
            await FeatureChecker.CheckEnabledAsync(CurrencyManagementFeatures.AllowChangingCurrencySettings);
        }
    }
}
