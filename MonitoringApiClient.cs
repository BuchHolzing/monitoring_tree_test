using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MonitoringTree;

public class MonitoringApiClient(HttpClient http)
{
    private const string Url = "https://it-dev.kovalska.dev/DEV_TOR/ws/api/_MOBILEDATASYNC";

    public async Task<MonitoringPlan> GetMonitoringPlanAsync()
    {
        var request = new
        {
            Jsonrpc = "2.0",
            Method = "TestMonitoringPlan",
            Id = "0cd24fad-4422-41ad-83d8-f87bdfbe8aaa",
            Params = new
            {
                AppId = "RAM",
                PersonnelNumber = "000000",
                FactoryCode = "00005",
                Date = "2026-10-01"
            }
        };
        
        using var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");
        using var response = await http.PostAsync(Url, content);
        response.EnsureSuccessStatusCode();

        var body = await response.Content.ReadFromJsonAsync<RpcResponse>();

        if (body?.Error is { } error)
            throw new Exception($"Ошибка API {error.Code}: {error.Message}");

        return body?.Result ?? throw new Exception("API не вернул данные.");
    }
}
