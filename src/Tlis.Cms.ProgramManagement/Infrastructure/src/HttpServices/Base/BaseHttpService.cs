using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Tlis.Cms.ProgramManagement.Infrastructure.Configurations;

namespace Tlis.Cms.ProgramManagement.Infrastructure.HttpServices.Base;

internal abstract class BaseHttpService
{
    private readonly HttpServiceConfiguration _configuration;

    private readonly HttpClient _client;

    public BaseHttpService(HttpClient client, HttpServiceConfiguration configuration)
    {
        _configuration = configuration;
        _client = client;

        _client.BaseAddress = _configuration.BaseAddress;
    }

    public async Task<T> GetAsync<T>(string requestUri)
    {
        return await _client.GetFromJsonAsync<T>(requestUri) ?? throw new Exception("Response is null");
    }
}