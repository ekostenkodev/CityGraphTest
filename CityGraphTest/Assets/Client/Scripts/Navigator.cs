using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    public Node StartNode;

    private void Start()
    {
        InputSystem.Instance.StartNodeSetted += SetStartNode;
    }

    public void SetStartNode(Node node)
    {
        StartNode = node;
    }
}
