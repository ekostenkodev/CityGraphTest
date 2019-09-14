using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Edge 
{
    public event UnityAction EdgeRemoved = delegate { };
    
    private Node _node1;
    private Node _node2;
    public Node Node1 => _node1;
    public Node Node2 => _node2;

    public float Value;

    public Edge(Node node1, Node node2)
    {
        _node1 = node1;
        _node2 = node2;
    }

    public void Remove()
    {
        _node1.Edges.Remove(this);
        _node2.Edges.Remove(this);
        
        EdgeRemoved.Invoke();
    }

}

