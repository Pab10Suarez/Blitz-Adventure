using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grafo : MonoBehaviour
{
    // Start is called before the first frame update

    private grafo grapha = new grafo();
    public Region r15;
    public Region r20;

    void Start()
    {

        // Region r1 = new Region("Bogota",23);
        // Region r20 = new Region("Cali",34);
        // Region r3 = new Region("Manizales",53);
        // Region r4 = new Region("Sibundoy",14);


        // grapha.AddVertex(r1);
        // grapha.AddVertex(r20);
        // grapha.AddVertex(r3);
        // grapha.AddVertex(r4);

        r15 = new Region("Hola",12);
        r20 = new Region("Hol",18);

        grapha.AddVertex(r15);
        grapha.AddVertex(r20);
            
        // grapha.AddEdge(r1,r20);
        // grapha.AddEdge(r1,r4);
        // grapha.AddEdge(r3,r4);

        Debug.Log(grapha.size());



        

        // grapha.PrintGraph();
        
    }

    
}

public class grafo
{
    private Dictionary<Region, List<Region>> _adj;

    public grafo()
    {
        _adj = new Dictionary<Region, List<Region>>();
    }

    public void AddVertex(Region vertex)
    {
        _adj[vertex] = new List<Region>();
    }

    public void AddEdge(Region v, Region w)
    {
        if (!_adj.ContainsKey(v))
            AddVertex(v);
        if (!_adj.ContainsKey(w))
            AddVertex(w);
        _adj[v].Add(w);
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
    }

        public void PrintGraph()
        {
            foreach (var vertex in _adj.Keys)
            {
                Debug.Log(vertex.getName() + " -> ");
                foreach (var edge in _adj[vertex])
                    Debug.Log(edge.getName() + " ");
                Debug.Log("---------------------------");
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
                Debug.Log(s.getName()+" ");
                //Console.Write(s + " ");

                List<Region> list = _adj[s];
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

        public int size(){
            return _adj.Count;
        }
}
