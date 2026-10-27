using System.Collections.Generic;

namespace MonitoringTree;

public class RpcResponse
{
    public MonitoringPlan? Result { get; set; }
    public RpcError? Error { get; set; }
}

public class RpcError
{
    public int Code { get; set; }
    public string? Message { get; set; }
}

public class MonitoringPlan
{
    public List<TechnicalPlace>? TechnicalPlaces { get; set; }
}

public class TechnicalPlace
{
    public string? Name { get; set; }
    public List<TechnicalPlace>? TechnicalPlaces { get; set; }
    public List<Equipment>? Equipments { get; set; }
}

public class Equipment
{
    public string? Name { get; set; }
    public List<MonitoringTask>? MonitoringTasks { get; set; }
}

public class MonitoringTask
{
    public string? CharacteristicName { get; set; }
}
