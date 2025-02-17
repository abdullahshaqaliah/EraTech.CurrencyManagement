﻿using EraTech.PushNotification.Firebase;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Features;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SimpleStateChecking;

namespace EraTech.WhatsApp.Facebook;

public class AllowChangingCurrencySettingsFeatureSimpleStateChecker : ISimpleStateChecker<PermissionDefinition>
{
    public async Task<bool> IsEnabledAsync(SimpleStateCheckerContext<PermissionDefinition> context)
    {
        var currentTenant = context.ServiceProvider.GetRequiredService<ICurrentTenant>();

        if (!currentTenant.IsAvailable)
        {
            return true;
        }

        var featureChecker = context.ServiceProvider.GetRequiredService<IFeatureChecker>();
        return await featureChecker.IsEnabledAsync(CurrencyManagementFeatures.AllowChangingCurrencySettings);
    }
}
