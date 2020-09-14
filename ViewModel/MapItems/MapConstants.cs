using System.Collections.Generic;

namespace Warehouse_Management.ViewModel.MapItems
{
    internal static class MapConstants
    {
        public static List<(double xPos, double yPos, string name)> Cities = new List<(double xPos, double yPos, string name)>()
        {
            (xPos: 0.634, yPos: 0.8640000000000001, name: "Nowy Sącz"),
            (xPos: 0.726, yPos: 0.22, name: "Giżycko"),
            (xPos: 0.446, yPos: 0.162, name: "Sopot"),
            (xPos: 0.057999999999999996, yPos: 0.24, name: "Świnoujście"),
            (xPos: 0.43200000000000005, yPos: 0.16, name: "Gdańsk"),
            (xPos: 0.628, yPos: 0.688, name: "Kielce"),
            (xPos: 0.35, yPos: 0.444, name: "Gniezno"),
            (xPos: 0.512, yPos: 0.768, name: "Dąbrowa Górnicza"),
            (xPos: 0.42200000000000004, yPos: 0.742, name: "Bytom")
        };

        //customersi
        public static List<(double xPos, double yPos, string name)> Customers = new List<(double xPos, double yPos, string name)>()
        {
            (xPos: 0.664, yPos: 0.49, name: "Warszawa"),
            (xPos: 0.478, yPos: 0.774, name: "Katowice"),
            (xPos: 0.5660000000000001, yPos: 0.8079999999999999, name: "Kraków"),
            (xPos: 0.758, yPos: 0.8140000000000001, name: "Rzeszów"),
            (xPos: 0.418, yPos: 0.192, name: "Gdańsk"),
            (xPos: 0.07200000000000001, yPos: 0.312, name: "Szczecin"),
            (xPos: 0.848, yPos: 0.204, name: "Suwałki"),
            (xPos: 0.804, yPos: 0.64, name: "Lublin"),
            (xPos: 0.27, yPos: 0.46799999999999997, name: "Poznań")
        };

    }
}