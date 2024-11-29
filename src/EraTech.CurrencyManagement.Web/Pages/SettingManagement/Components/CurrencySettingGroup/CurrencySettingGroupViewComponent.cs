using EraTech.CurrencyManagement.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;
using Volo.Abp.SettingManagement.Localization;

namespace EraTech.CurrencyManagement.Web.Pages.SettingManagement.Components.CurrencySettingGroup;

/// <summary>
/// View component for managing currency settings
/// </summary>
public class CurrencySettingGroupViewComponent : AbpViewComponent
{

    private const string _excludedCurrency = "ILS";

    /// <summary>
    /// Service for managing currency settings
    /// </summary>
    protected ICurrencyAppService CurrencySettingsAppService { get; }

    public CurrencySettingGroupViewComponent(ICurrencyAppService currencySettingsAppService)
    {
        ObjectMapperContext = typeof(AbpSettingManagementResource);
        CurrencySettingsAppService = currencySettingsAppService;
    }

    public virtual async Task<IViewComponentResult> InvokeAsync()
    {
        var settings = await CurrencySettingsAppService.GetAsync().ConfigureAwait(false);
        var model = CreateViewModel(settings);
        ViewData["Currencies"] = GetAvailableCurrencies();

        return View("~/Pages/SettingManagement/Components/CurrencySettingGroup/Default.cshtml", model);
    }

    private UpdateCurrencySettingsViewModel CreateViewModel(CurrencySettingsDto settings)
    {
        return new UpdateCurrencySettingsViewModel
        {
            Currency = settings.Currency
        };
    }


    public class UpdateCurrencySettingsViewModel
    {
        [Required]
        [Display(Name = "Currency")]
        [SelectItems("Currencies")]
        public required string Currency { get; set; }
    }


    private List<SelectListItem> GetAvailableCurrencies()
    {
        var currencies = new List<SelectListItem>();
        var cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

        foreach (var culture in cultures)
        {
            var region = new RegionInfo(culture.Name);
            if (ShouldIncludeCurrency(region, currencies))
            {
                currencies.Add(CreateCurrencyListItem(region));
            }
        }

        return currencies.OrderBy(x => x.Value).ToList();
    }

    private bool ShouldIncludeCurrency(RegionInfo region, List<SelectListItem> existingCurrencies)
    {
        return region.ISOCurrencySymbol != _excludedCurrency &&
               !existingCurrencies.Any(x => x.Value == region.ISOCurrencySymbol) &&
               !string.IsNullOrEmpty(region.CurrencyEnglishName);
    }

    private SelectListItem CreateCurrencyListItem(RegionInfo region)
    {
        return new SelectListItem
        {
            Value = region.ISOCurrencySymbol,
            Text = $"{region.CurrencyEnglishName}({region.ISOCurrencySymbol})"
        };
    }
}