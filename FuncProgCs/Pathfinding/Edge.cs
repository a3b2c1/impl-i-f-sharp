using System;

namespace FuncProgArt.Pathfinding
{
    public class Edge
    {
        public double Distance { get; set; }
        public Vertex Start { get; set; }
        public Vertex End { get; set; }
        public string RouteName { get; set; }

        public Edge(Vertex start, Vertex end)
        {
            double a = start.Coordinates.X - end.Coordinates.X;
            double b = start.Coordinates.Y - end.Coordinates.Y;
            double c_2 = Math.Pow(a, 2) + Math.Pow(b, 2);
            Distance = Math.Sqrt(c_2);
            Start = start;
            End = end;
            RouteName = string.Format("{0} to {1}", start.Name, end.Name);
        }
    }
}