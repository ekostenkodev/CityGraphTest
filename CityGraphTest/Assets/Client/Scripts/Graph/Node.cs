using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Node
{
    public event UnityAction<Institution> InstitutionSetted = delegate { }; 
    
    private Institution _institution;
    public Institution Institution
    {
        get => _institution;
        set
        {
            _institution = value;
            InstitutionSetted.Invoke(value);
        }
    }

    public List<Edge> Edges = new List<Edge>();

    private Vector2 _position;

    public Vector2 Position => _position;

    public Node(Institution institution, Vector2 position)
    {
        _institution = institution;
        _position = position;
    }

}
