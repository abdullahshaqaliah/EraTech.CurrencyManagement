using Volo.Abp.Modularity;

namespace EraTech.CurrencyManagement;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class CurrencyManagementDomainTestBase<TStartupModule> : CurrencyManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
