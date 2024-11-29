using EraTech.CurrencyManagement.Dtos;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace EraTech.CurrencyManagement;

public interface ICurrencyAppService : IApplicationService
{
    Task<CurrencySettingsDto> GetAsync();


    Task UpdateAsync(UpdateCurrencySettingsDto input);

}
