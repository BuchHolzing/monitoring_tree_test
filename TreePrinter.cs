using System;
using System.Collections.Generic;

namespace MonitoringTree;

public static class TreePrinter
{
    public static void Print(IEnumerable<TechnicalPlace>? places, int level = 0)
    {
        foreach (var place in places ?? [])
        {
            var childPlaces = place.TechnicalPlaces ?? [];
            var equipments = place.Equipments ?? [];

            PrintLine(place.Name, level, childPlaces.Count + equipments.Count);
            Print(childPlaces, level + 1);

            foreach (var equipment in equipments)
            {
                var tasks = equipment.MonitoringTasks ?? [];

                PrintLine(equipment.Name, level + 1, tasks.Count);
                foreach (var task in tasks)
                    PrintLine(task.CharacteristicName, level + 2, 0);
            }
        }
    }

    private static void PrintLine(string? name, int level, int childCount)
    {
        var indent = new string(' ', level * 2);
        var count = childCount > 0 ? $" ({childCount})" : "";
        Console.WriteLine($"{indent}{name ?? "Без названия"}{count}");
    }
}
