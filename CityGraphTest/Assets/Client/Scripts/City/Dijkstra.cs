using System.Collections.Generic;
using System.Linq;

public class Dijkstra
{
    public class Vertex
    {
        public List<Node> NodeMap = new List<Node>();
        
        public Node Node;
        public float Length;

        public Vertex(Node node, float length)
        {
            Node = node;
            Length = length;
        }

        public override string ToString()
        {
            return Node.Position + "  " + Length;
        }
    }

    public List<Vertex> FindWay(Node startNode)
    {
        List<Vertex> passedVertex = new List<Vertex>();
        List<Vertex> vertexOrder = new List<Vertex>();

        var startVertex = new Vertex(startNode, 0);
        startVertex.NodeMap.Add(startNode);

        vertexOrder.Add(startVertex);
        
        

        while (vertexOrder.Count != 0)
        {
            var pastVertex = vertexOrder[0];

            foreach (var edge in pastVertex.Node.Edges)
            {
                Node node = edge.Node1.Equals(pastVertex.Node) ? edge.Node2 : edge.Node1;
                
                if(passedVertex.FirstOrDefault(n => n.Node.Equals(node))!=null)
                    continue;

                Vertex existingVertex = vertexOrder.FirstOrDefault(n => n.Node.Equals(node));

                if (existingVertex != null)
                {
                    float possibleValue = edge.Value + pastVertex.Length;
                    if (existingVertex.Length > possibleValue)
                    {
                        existingVertex.Length = possibleValue;
                        
                        existingVertex.NodeMap.Clear();
                        
                        existingVertex.NodeMap.AddRange(pastVertex.NodeMap);
                        existingVertex.NodeMap.Add(node);
                    }
                }
                else
                {
                    var newVertex = new Vertex(node, edge.Value + pastVertex.Length);
                        
                    newVertex.NodeMap.AddRange(pastVertex.NodeMap);
                    newVertex.NodeMap.Add(node);
                    
                    vertexOrder.Add(newVertex);

                }
            }
            passedVertex.Add(pastVertex);
            vertexOrder.Remove(pastVertex);
        }

        return passedVertex;

    }
    
}