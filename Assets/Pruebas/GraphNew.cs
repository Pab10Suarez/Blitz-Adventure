using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNew : MonoBehaviour
{
    // Start is called before the first frame update

    private grafo grapha = new grafo();
    void Start()
    {
        Region r1 = new Region("Daniel",12);
        Region r2 = new Region("Catalina",23);
        Region r3 = new Region("Catal",21);

        grapha.AddVertex(r1);
        grapha.AddVertex(r2);
        grapha.AddVertex(r3);

        grapha.PrintGraph();

        //Debug.Log(grapha.size()+"Hpla");
    }

}

public class grafoNew
{
    private Dictionary<Region, List<Region>> _adj;

    public grafoNew()
    {
        _adj = new Dictionary<Region, List<Region>>();
    }

    public void AddVertex(Region vertex)
    {
        if (!_adj.ContainsKey(vertex))
            _adj[vertex] = new List<Region>();
    }

    public void AddEdge(Region v, Region w)
    {
        AddVertex(v);
        AddVertex(w);
        _adj[v].Add(w);
        _adj[w].Add(v); // Opcional: si el grafo es no dirigido
    }

    public void RemoveVertex(Region v)
    {
        if (_adj.ContainsKey(v))
        {
            _adj.Remove(v);
            foreach (var key in _adj.Keys)
                _adj[key].Remove(v);
        }
    }

    public void RemoveEdge(Region v, Region w)
    {
        if (_adj.ContainsKey(v))
            _adj[v].Remove(w);
        if (_adj.ContainsKey(w))
            _adj[w].Remove(v); // Opcional: si el grafo es no dirigido
    }

    public void PrintGraph()
    {
        foreach (var vertex in _adj.Keys)
        {
            string vertices = vertex.getName() + " -> ";
            foreach (var edge in _adj[vertex])
                vertices += edge.getName() + " ";
            Debug.Log(vertices);
        }
    }

    public void BFS(Region s)
    {
        HashSet<Region> visited = new HashSet<Region>();
        Queue<Region> queue = new Queue<Region>();
        visited.Add(s);
        queue.Enqueue(s);

        while (queue.Count != 0)
        {
            s = queue.Dequeue();
            Debug.Log(s.getName());

            List<Region> list;
            if (_adj.TryGetValue(s, out list))
            {
                foreach (var val in list)
                {
                    if (!visited.Contains(val))
                    {
                        visited.Add(val);
                        queue.Enqueue(val);
                    }
                }
            }
        }
    }

    public int size()
    {
        return _adj.Count;
    }

    public List<Region> GetAdjacencyList(Region v)
    {
        List<Region> adjacencyList;
        _adj.TryGetValue(v, out adjacencyList);
        return adjacencyList;
    }
}
