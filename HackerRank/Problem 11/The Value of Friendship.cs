using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string[] tokens_n = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(tokens_n[0]);
            int m = Convert.ToInt32(tokens_n[1]);
            Query q = new Query();
            for (int a1 = 0; a1 < m; a1++)
            {
                string[] tokens_x = Console.ReadLine().Split(' ');
                int x = Convert.ToInt32(tokens_x[0]);
                int y = Convert.ToInt32(tokens_x[1]);
                q.Add(x, y);
            }
            var res = q.Exec();
            Console.WriteLine(res);
        }
    }
}

class Query
{
    Graph graph = new Graph();

    public System.Numerics.BigInteger Exec()
    {
        var graphs = GraphHelper.GetSouvisleGrafy(graph);//.Dump();

        System.Numerics.BigInteger total = 0;
        System.Numerics.BigInteger topLevelTotal = 0;



        foreach (var g in graphs.OrderByDescending(x => x.vertices.Count))
        {
            System.Numerics.BigInteger subTotal = 0;
            for (int i = 0; i <= g.vertices.Count - 2; i++)
            {
                System.Numerics.BigInteger si = i + 1;
                subTotal += ValueOfFrendAtLevel(i);
                total += topLevelTotal;
                //total += i + 1
                // if (total > long.MaxValue) throw new Exception();
            }
            // added others
            total += subTotal;
            topLevelTotal += ValueOfFrendAtLevel(g.vertices.Count - 2);
        }

        // add total levels(doubled relations ships)
        foreach (var g in graphs)
        {
            for (int i = 0; i <= g.edges.Count - g.vertices.Count; i++)
            {
                total += topLevelTotal;
            }
        }

        return total;

    }

    HashSet<long> duplitates = new HashSet<long>();

    public void Add(int a, int b)
    {
        graph.AddEdge(a, b);

        long key = Edge.GetEdgeKey(a, b);
        if (duplitates.Contains(key)) throw new Exception();
        duplitates.Add(key);
    }

    private System.Numerics.BigInteger ValueOfFrendAtLevel(System.Numerics.BigInteger level)
    {
        return (level + 1) * (level + 2);
    }


}

public static class GraphHelper
{
    public static List<Graph> GetSouvisleGrafy(Graph original)
    {
        List<Graph> ret = new List<Graph>();

        // abych dokazal vyhodnotit jiz prosle cesty v grafu
        HashSet<long> traversedPaths = new HashSet<long>();

        // abych dokazal nesouvisle gragy
        HashSet<int> traversedVertices = new HashSet<int>();

        foreach (int vertex in original.vertices.Keys)
        {
            // skip traversed 
            if (traversedVertices.Contains(vertex)) continue;

            Graph g = new Graph();
            ret.Add(g);

            TraverseEdges(original, g, vertex, traversedVertices, traversedPaths);
        }

        return ret;
    }

    private static void TraverseEdges(Graph original, Graph graph, int vertexX, HashSet<int> traversedVertices, HashSet<long> traversedPath)
    {
        // already used
        traversedVertices.Add(vertexX);

        var vertex = original.vertices[vertexX];

        foreach (var oppositVertex in vertex.Edges)
        {
            //    if(backPath != oppositVertex) graph.AddEdge(vertexX, oppositVertex);

            // tohle se da vylepsit, A a B kotrolovat na vertexX
            //  int oppositVertex;
            //if (edge.VertexA == vertexX) oppositVertex = edge.VertexB; else oppositVertex = edge.VertexA;

            // do tohohle bodu jsem jeste nesel, tak ho taky projdu

            long edgeKey = Edge.GetEdgeKey(vertexX, oppositVertex);

            if (!traversedPath.Contains(edgeKey))
            {
                traversedPath.Add(edgeKey);
                graph.AddEdge(vertexX, oppositVertex);
                TraverseEdges(original, graph, oppositVertex, traversedVertices, traversedPath);
            }
        }
    }
}



public class Graph
{
    public readonly Dictionary<int, Vertex> vertices = new Dictionary<int, Vertex>();
    public readonly List<Edge> edges = new List<Edge>();

    public void AddEdge(int a, int b)
    {
        Vertex vertexA = this.GetOrCreateVertex(a);
        Vertex vertexB = this.GetOrCreateVertex(b);

        Edge edg = new Edge(a, b);
        vertexA.Edges.Add(b);
        vertexB.Edges.Add(a);
        edges.Add(edg);
    }

    private Vertex GetOrCreateVertex(int x)
    {
        Vertex ret;
        if (this.vertices.TryGetValue(x, out ret)) return ret;

        ret = new Vertex();
        vertices.Add(x, ret);
        return ret;
    }

    public override string ToString()
    {
        return $"Graph Edges:{this.edges.Count}, Vertices:{this.vertices.Count}";
    }
}

public class Edge
{
    public Edge(int vertexA, int vertexB)
    {
        this.VertexA = vertexA;
        this.VertexB = vertexB;
    }
    public int VertexA { get; set; }
    public int VertexB { get; set; }

    public static long GetEdgeKey(int a, int b)
    {
        if (a > b)
        {
            return (((long)a) << 32) | b;
        }
        return (((long)b) << 32) | a;
    }

    public override string ToString()
    {
        return $"Edge A:{VertexA}, B:{VertexB}";
    }
}

public class Vertex
{
    public HashSet<int> Edges = new HashSet<int>();

    public override string ToString()
    {
        return $"Vertex Edges:{Edges.Count}";
    }
}
///aaaaaaaaaaaaaaaaaaaaaaaaaaa