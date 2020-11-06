using FuncProgArt.Pathfinding;
using System;

namespace FuncProgArt
{
    class Program
    {
        static void Main(string[] args)
        {
            PathfindingAlgorithms algo = new PathfindingAlgorithms();

            algo.PrintVertices();

            algo.DijkstrasAlgo();
        }
    }
}
