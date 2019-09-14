using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class NodePresenter : MonoBehaviour
{
    private Node _node;
    public Node Node=>_node;
    
    public event UnityAction<Node> NodeClick = delegate {}; 
    
    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
    }
        
    private Transform _selfTransform;
    


    private void OnMouseDown()
    {
        InputSystem.Instance.SetStartNode(_node);
    }

    public void SetNode(Node node)
    {
        _node = node;
        _selfTransform.localPosition = node.Position;
        var spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = node.Institution.Sprite;
        GetComponent<BoxCollider2D>().size = spriteRenderer.size;
    }
}
