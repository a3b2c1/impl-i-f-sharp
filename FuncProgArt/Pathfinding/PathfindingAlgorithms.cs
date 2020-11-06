using System;
using System.Collections.Generic;

namespace FuncProgArt.Pathfinding
{
    public class PathfindingAlgorithms
    {
        private Vertice playerVertice;
        public List<Vertice> GeneratedVertices { get; set; }

        public PathfindingAlgorithms()
        {
            GenerateVertices();
        }

        private void GenerateVertices()
        {
            GeneratedVertices = new List<Vertice>();
            for (int i = 0; i < 5; i++)
            {
                double random_x = GenerateRandomCoordinate();
                double random_y = GenerateRandomCoordinate();

                while (CheckForDuplicates(GeneratedVertices, random_x, random_y))
                {
                    random_x = GenerateRandomCoordinate();
                    random_y = GenerateRandomCoordinate();
                }

                Coordinates coordinates = new Coordinates(random_x, random_y);
                Vertice vertice = new Vertice(coordinates, i);

                GeneratedVertices.Add(vertice);
            }

            playerVertice = new Vertice(new Coordinates(GenerateRandomCoordinate(), GenerateRandomCoordinate()), 0);
            playerVertice.VerticeName = "Player";
            playerVertice.Visited = true;
            GeneratedVertices.Add(playerVertice);

            CalculateVerticesDistances(GeneratedVertices);
        }

        private void CalculateVerticesDistances(List<Vertice> vertices)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertice startVertice = vertices[i];
                for (int j = 0; j < vertices.Count; j++)
                {
                    Vertice endVertice = vertices[j];

                    if (i != j && endVertice.VerticeName != "Player")
                    {
                        Edge edge = new Edge(startVertice, endVertice);

                        startVertice.Edges.Add(edge);
                    }
                }
            }
        }

        private bool CheckForDuplicates(List<Vertice> vertices, double x, double y)
        {
            bool foundDuplicate = false;
            int index = 0;

            while (!foundDuplicate && index < vertices.Count)
            {
                Vertice vertice = vertices[index];

                if (vertice.Coordinates.X == x && vertice.Coordinates.Y == y)
                {
                    foundDuplicate = true;
                }

                index++;
            }

            return foundDuplicate;
        }

        private double GenerateRandomCoordinate()
        {
            Random rand = new Random();

            return Math.Round(rand.NextDouble() * 99, 2);
        }

        public void PrintVertices()
        {
            Vertice playerVertice = GeneratedVertices.Find(v => v.VerticeName == "Player");
            Console.WriteLine(string.Format("{0} : {1}, {2}\n", playerVertice.VerticeName, playerVertice.Coordinates.X, playerVertice.Coordinates.Y));
            foreach (Vertice vertice in GeneratedVertices)
            {
                foreach (Edge edge in vertice.Edges)
                {
                    Console.WriteLine(string.Format("{0} : {1}", edge.RouteName, edge.Distance));
                }
                Console.WriteLine();
            }
        }

        public void DijkstrasAlgo()
        {
            string routeName = string.Format("{0}", playerVertice.VerticeName);
            double shortestRoute = 0.0;
            Edge shortestEdgeDistance = null;

            while (UnvisitedVerticeExists(playerVertice, ref shortestEdgeDistance))
            {
                for (int i = 0; i < playerVertice.Edges.Count; i++)
                {
                    Edge edge = playerVertice.Edges[i];

                    if (!edge.End.Visited && edge.Distance < shortestEdgeDistance.Distance)
                    {
                        shortestEdgeDistance = edge;
                    }
                }
                shortestRoute += shortestEdgeDistance.Distance;
                routeName += string.Format(" -> {0}", shortestEdgeDistance.End.VerticeName);

                shortestEdgeDistance.End.Visited = true;
                playerVertice = shortestEdgeDistance.End;
            }
            Console.WriteLine(routeName);
            Console.WriteLine(string.Format("shortest route length: {0}", shortestRoute));
        }

        private bool UnvisitedVerticeExists(Vertice vertice, ref Edge edge)
        {
            bool unvisitedVerticeExists = false;
            int index = 0;

            while (!unvisitedVerticeExists && index < vertice.Edges.Count)
            {
                edge = vertice.Edges[index];

                if (!edge.End.Visited)
                {
                    unvisitedVerticeExists = true;
                }

                index++;
            }

            return unvisitedVerticeExists;
        }
    }
}

