﻿using System.Threading.Tasks;
using Shouldly;
using Volo.Abp.Modularity;
using Xunit;

namespace EraTech.CurrencyManagement.Samples;

public abstract class SampleAppService_Tests<TStartupModule> : CurrencyManagementApplicationTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{
    private readonly ISampleAppService _sampleAppService;

    protected SampleAppService_Tests()
    {
        _sampleAppService = GetRequiredService<ISampleAppService>();
    }

    [Fact]
    public async Task GetAsync()
    {
        var result = await _sampleAppService.GetAsync();
        result.Value.ShouldBe(42);
    }

    [Fact]
    public async Task GetAuthorizedAsync()
    {
        var result = await _sampleAppService.GetAuthorizedAsync();
        result.Value.ShouldBe(42);
    }
}
