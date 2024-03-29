﻿using UnityEngine;

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
    
    private void OnMouseDown()
    {
        InputSystem.Instance.SetStartNode(_node);
    }
    
    #endregion

    public void SetNode(Node node)
    {
        _node = node;
        _selfTransform.localPosition = node.Position;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = node.Institution.Sprite;
        GetComponent<BoxCollider2D>().size = _spriteRenderer.size;
    }
}
