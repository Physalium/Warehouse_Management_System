using System.Collections.Generic;

namespace Warehouse_Management.ViewModel.MapItems
{
    internal static class MapConstants
    {
        public static List<(double xPos, double yPos, string name)> Cities = new List<(double xPos, double yPos, string name)>()
        {
            (xPos: 0.48, yPos: 0.75, name: "Katowice"),
            (xPos: 0.38, yPos: 0.69, name: "Opole")
        };
    }
}