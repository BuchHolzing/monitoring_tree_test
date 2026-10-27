using System;
using System.Net.Http;
using MonitoringTree;

using var http = new HttpClient();

try
{
    var plan = await new MonitoringApiClient(http).GetMonitoringPlanAsync();
    TreePrinter.Print(plan.TechnicalPlaces);
}
catch (Exception ex)
{
    Console.Error.WriteLine($"Ошибка: {ex.Message}");
    return 1;
}

return 0;
