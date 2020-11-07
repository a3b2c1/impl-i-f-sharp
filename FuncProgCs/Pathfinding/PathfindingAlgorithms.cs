using System;
using System.Collections.Generic;

namespace FuncProgArt.Pathfinding
{
    public class PathfindingAlgorithms
    {
        private Vertex playerVertex;
        public List<Vertex> GeneratedVertices { get; set; }

        public PathfindingAlgorithms()
        {
            GenerateVertices();
        }

        private void GenerateVertices()
        {
            GeneratedVertices = new List<Vertex>();
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
                Vertex vertex = new Vertex(coordinates, i);

                GeneratedVertices.Add(vertex);
            }

            playerVertex = new Vertex(new Coordinates(GenerateRandomCoordinate(), GenerateRandomCoordinate()), 0);
            playerVertex.Name = "Player";
            playerVertex.Visited = true;
            GeneratedVertices.Add(playerVertex);

            CalculateVerticesDistances(GeneratedVertices);
        }

        private void CalculateVerticesDistances(List<Vertex> vertices)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                Vertex startVertex = vertices[i];
                for (int j = 0; j < vertices.Count; j++)
                {
                    Vertex endVertex = vertices[j];

                    if (i != j && endVertex.Name != "Player")
                    {
                        Edge edge = new Edge(startVertex, endVertex);

                        startVertex.Edges.Add(edge);
                    }
                }
            }
        }

        private bool CheckForDuplicates(List<Vertex> vertices, double x, double y)
        {
            bool foundDuplicate = false;
            int index = 0;

            while (!foundDuplicate && index < vertices.Count)
            {
                Vertex vertice = vertices[index];

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

            Vertex playerVertice = FindVertex("Player");
            Console.WriteLine(string.Format("{0} : {1}, {2}\n", playerVertice.Name, playerVertice.Coordinates.X, playerVertice.Coordinates.Y));
            foreach (Vertex vertice in GeneratedVertices)
            {
                foreach (Edge edge in vertice.Edges)
                {
                    Console.WriteLine(string.Format("{0} : {1}", edge.RouteName, edge.Distance));
                }
                Console.WriteLine();
            }
        }

        private Vertex FindVertex(string name)
        {
            int index = 0;
            Vertex foundVertex = null;

            while (foundVertex == null && index < GeneratedVertices.Count)
            {
                Vertex indexedVertex = GeneratedVertices[index];

                if (indexedVertex.Name == name)
                {
                    foundVertex = indexedVertex;
                }

                index++;
            }

            return foundVertex;

        }

        public void DijkstrasAlgo()
        {
            string routeName = string.Format("{0}", playerVertex.Name);
            double shortestRoute = 0.0;
            Edge shortestEdgeDistance = null;

            while (UnvisitedVerticeExists(playerVertex, ref shortestEdgeDistance))
            {
                for (int i = 0; i < playerVertex.Edges.Count; i++)
                {
                    Edge edge = playerVertex.Edges[i];

                    if (!edge.End.Visited && edge.Distance < shortestEdgeDistance.Distance)
                    {
                        shortestEdgeDistance = edge;
                    }
                }
                shortestRoute += shortestEdgeDistance.Distance;
                routeName += string.Format(" -> {0}", shortestEdgeDistance.End.Name);

                shortestEdgeDistance.End.Visited = true;
                playerVertex = shortestEdgeDistance.End;
            }
            Console.WriteLine(routeName);
            Console.WriteLine(string.Format("shortest route length: {0}", shortestRoute));
        }

        private bool UnvisitedVerticeExists(Vertex vertice, ref Edge edge)
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

