using System;
using System.Collections.Generic;
using System.Text;

namespace FuncProgArt.Pathfinding
{
    public class Vertex
    {
        public Coordinates Coordinates { get; set; }
        public List<Edge> Edges { get; set; }
        public string Name { get; set; }
        public bool Visited { get; set; }

        public Vertex(Coordinates coordinates, int index)
        {
            Coordinates = coordinates;
            AssignName(index);
            Edges = new List<Edge>();
            Visited = false;
        }

        private void AssignName(int index)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Name = alphabet[index].ToString();
        }
    }
}
