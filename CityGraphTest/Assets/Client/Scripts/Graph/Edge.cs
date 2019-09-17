using UnityEngine;
using UnityEngine.Events;

public class Edge 
{
    private Node _node1;
    private Node _node2;
    
    public event UnityAction EdgeRemoved = delegate { };
    public Node Node1 => _node1;
    public Node Node2 => _node2;

    private float _value;
    public float Value => _value;

    public Edge(Node node1, Node node2)
    {
        _node1 = node1;
        _node2 = node2;

        _value = Vector2.Distance(node1.Position, node2.Position);
    }

    public void Remove()
    {
        _node1.Edges.Remove(this);
        _node2.Edges.Remove(this);
        
        EdgeRemoved.Invoke();
    }

}

