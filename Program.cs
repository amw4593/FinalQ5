using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalQ5
{
    public class Node : IComparable<Node>
    {
        public int nState;

        public List<Edge> edges = new List<Edge>();

        public int minToStart;
        public Node nearestToStart;
        public bool visited;

        public Node(int nState)
        {
            this.nState = nState;
            this.minToStart = int.MaxValue;
        }

        public void AddEdge(int cost, Node connection)
        {
            Edge e = new Edge(cost, connection);
            edges.Add(e);
        }

        public int CompareTo(Node n)
        {
            return this.minToStart.CompareTo(n.minToStart);
        }
    }

    public class Edge : IComparable<Edge>
    {
        public int cost;
        public Node connectionNode;

        public Edge(int cost, Node connectionNode)
        {
            this.cost = cost;
            this.connectionNode = connectionNode;

        }

        public int CompareTo(Edge e)
        {
            return this.cost.CompareTo(e.cost);
        }
    }

    public enum EColor
    {
        red,
        blue,
        grey,
        lightblue,
        orange,
        yellow,
        magenta,
        green
    }

    internal static class Program
    {
        static bool[,] matrixDiGraph = new bool[,]
        {
                /* RED *//* BLUE *//* GREY *//* LIGHTBLUE *//* ORANGE *//* YELLOW *//* MAGENTA *//* GREEN */
       /* RED */{ false ,   true,     true,       false,       false,      false,       false,      false },
       /* BLUE */{ false ,  false,    false,      true,        false,      true,        false,      false },
       /* GREY */{ false ,  false,    false,      true,        true,       false,       false,      false },
       /* LIGHTBLUE */{false,true,     true,      false,       false,      false,       false,      false },
       /* ORANGE */{false , false,    false,      false,       false,      false,       true,       false },
       /* YELLOW */{false , false,    false,      false,       false,      false,       false,      true },
       /* MAGENTA */{false ,false,    false,      false,       false,      true,        false,      false },
       /* GREEN */{false ,  false,    false,      false,       false,      false,       false,      false }

        };

        static int[][] listDiGraph = new int[][]
        {
        /* RED */ new int[] { (int) EColor.blue, (int)EColor.grey},
        /* BLUE */ new int[] { (int) EColor.lightblue, (int)EColor.yellow},
        /* GREY */ new int[] { (int) EColor.lightblue, (int)EColor.orange},
        /* LIGHTBLUE */ new int[] { (int) EColor.blue, (int)EColor.grey},
        /* ORANGE */ new int[] { (int) EColor.magenta},
        /* YELLOW */ new int[] { (int) EColor.green},
        /* MAGENTA */ new int[] { (int) EColor.yellow},
        /* GREEN */ null
        };

        static void Main(string[] args)
        {
            int[] distances = new int[Enum.GetNames(typeof(EColor)).Length];
            bool[] visited = new bool[Enum.GetNames(typeof(EColor)).Length];
            int[] previous = new int[Enum.GetNames(typeof(EColor)).Length];

            // Initialize the distances and previous arrays
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = int.MaxValue;
                previous[i] = -1;
            }

            distances[(int)EColor.red] = 0;

            // Run Dijkstra's algorithm
            for (int i = 0; i < distances.Length; i++)
            {
                int current = minToStart(distances, visited);

                if (current == (int)EColor.green)
                {
                    break;
                }

                visited[current] = true;

                if (listDiGraph[current] != null)
                {
                    for (int j = 0; j < listDiGraph[current].Length; j++)
                    {
                        int neighbor = listDiGraph[current][j];
                        int distance = 1;

                        if (matrixDiGraph[current, neighbor])
                        {
                            distance = 2;


                        }
                    }
                }
            }
        }
    }
}
