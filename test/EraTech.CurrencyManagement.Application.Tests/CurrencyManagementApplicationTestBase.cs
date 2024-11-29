using Volo.Abp.Modularity;

namespace EraTech.CurrencyManagement;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class CurrencyManagementApplicationTestBase<TStartupModule> : CurrencyManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
