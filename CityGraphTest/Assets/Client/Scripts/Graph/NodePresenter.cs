using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SpriteRenderer),typeof(BoxCollider2D))]
public class NodePresenter : MonoBehaviour
{
    private Transform _selfTransform;
    private SpriteRenderer _spriteRenderer;

    private Node _node;
    
    #region MonoBehaviour
    
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _selfTransform = GetComponent<Transform>();
    }
    
    #endregion
        
    
    private void OnMouseDown()
    {
        InputSystem.Instance.SetStartNode(_node);
    }

    public void SetNode(Node node)
    {
        _node = node;
        _selfTransform.localPosition = node.Position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = node.Institution.Sprite;
        GetComponent<BoxCollider2D>().size = _spriteRenderer.size;
    }
    

}
