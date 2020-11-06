using System;
using System.Collections.Generic;
using System.Text;

namespace FuncProgArt.Pathfinding
{
    public class Vertice
    {
        public Coordinates Coordinates { get; set; }
        public List<Edge> Edges { get; set; }
        public string VerticeName { get; set; }
        public bool Visited { get; set; }

        public Vertice(Coordinates coordinates, int index)
        {
            Coordinates = coordinates;
            AssignVerticeName(index);
            Edges = new List<Edge>();
            Visited = false;
        }

        private void AssignVerticeName(int index)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            VerticeName = alphabet[index].ToString();
        }
    }
}
