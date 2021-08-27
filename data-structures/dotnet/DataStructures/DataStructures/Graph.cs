using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
  class Vertex<T>
  {
    public T Value { get; set;  }

    public Vertex(T value)
    {
      Value = value;
    }
  }

  class Edge<T>  // Directed Edge
  {
    public int Weight { get; set; }
    public Vertex<T> Vertex { get; set; }

    public Edge(Vertex<T> vertex, int weight)
    {
      Vertex = vertex;
      Weight = weight;
    }
  }
  
  class Graph<T>
  {
    private int _size;

    public Dictionary<Vertex<T>, List<Edge<T>>> AdjacencyLists { get; set; }
    
    public Graph()
    {
      AdjacencyLists = new Dictionary<Vertex<T>, List<Edge<T>>>();
      _size = 0;
    }

    public Vertex<T> AddNode(T value)
    {
      Vertex <T> Vertex = new (value);
      AdjacencyLists.Add(Vertex, new List<Edge<T>>());
      _size++;

      return Vertex;
    }

    // Add bidirectional edge
    public void AddEdge(Vertex<T> sourceVertex, Vertex<T> destVertex, int weight)
    {
      AddDirectionalEdge(sourceVertex, destVertex, weight);
      AddDirectionalEdge(destVertex, sourceVertex, weight);
    }
    public void AddDirectionalEdge(Vertex<T> sourceVertex, Vertex<T> destVertex, int weight)
    {
      List<Edge<T>> edges = AdjacencyLists[sourceVertex];
      edges.Add(
        new Edge<T>(destVertex, weight)
      );
    }

    /*public GetNodes()
    {
      //TODO: Implement me
    }*/

    public List<Vertex<T>> GetNeighbors(Vertex<T> vertex)  // for a particular node/vertex
    {
      var neighborAdjacencyList = AdjacencyLists[vertex];
      List<Vertex<T>> neighborList = new List<Vertex<T>>();

      foreach(Edge<T> edge in neighborAdjacencyList)
      {
        neighborList.Add(edge.Vertex);
      }

      return neighborList;
    }

    public int GetSize()
    {
      return _size;
    }

    public void Print()
    {
      foreach(var key in AdjacencyLists)
      {
        Console.Out.Write($"{key.Key.Value} -> ");

        var adjacencyList = AdjacencyLists[key.Key];

        foreach (Edge<T> edge in adjacencyList)
        {
          Console.Out.Write($"{edge.Vertex.Value}, {edge.Weight} -> ");
        }
        Console.Out.WriteLine("null");
      }
    }
  }
}
