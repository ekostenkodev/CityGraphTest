using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputSystem : Singleton<InputSystem>
{
    public event UnityAction<Node> StartNodeSetted = delegate {  }; 
    public void SetStartNode(Node node)
    {
        StartNodeSetted.Invoke(node);
    }
}
