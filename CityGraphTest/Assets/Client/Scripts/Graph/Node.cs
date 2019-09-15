using System.Collections.Generic;
using UnityEngine;

public class Node
{
    private Institution _institution;
    public Institution Institution => _institution;

    public List<Edge> Edges = new List<Edge>();

    private Vector2 _position;

    public Vector2 Position => _position;

    public Node(Institution institution, Vector2 position)
    {
        _institution = institution;
        _position = position;
    }

}
