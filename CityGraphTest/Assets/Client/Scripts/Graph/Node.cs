using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private Institution _institution;
    private Vector2 _position;

    public Institution Institution => _institution;
    public Vector2 Position => _position;

    public List<Edge> Edges = new List<Edge>();

    public Node(Institution institution, Vector2 position)
    {
        _institution = institution;
        _position = position;
    }

}
