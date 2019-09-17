using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Navigator : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    private Transform _transform;
    
    private Node _startNode;
    private Type _targetInstitution;
    
    #region MonoBehaviour

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _lineRenderer = GetComponent<LineRenderer>();
        
        InputSystem.Instance.StartNodeSetted += SetStartNode;
        InputSystem.Instance.TargetInstitutionSetted += SetTargetInstitution;
    }
    
    #endregion

    private void HighlightTrack(List<Node> nodes)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.positionCount = 0; // чистка списка
        _lineRenderer.positionCount = nodes.Count;

        for (int i = 0; i < nodes.Count; i++)
        {
            _lineRenderer.SetPosition(i, _transform.position + (Vector3)nodes[i].Position);
        }
        
    }

    private void SetStartNode(Node node)
    {
        _startNode = node;
        GenerateTrack();
    }

    private void SetTargetInstitution(Type type)
    {
        _targetInstitution = type;
        GenerateTrack();
    }

    public void GenerateTrack()
    {
        _lineRenderer.enabled = false;
        if(_startNode == null || _targetInstitution == null)
            return;

        Dijkstra dijkstra = new Dijkstra();
        var list = dijkstra.FindWay(_startNode);

        Dijkstra.Vertex targetVertex = null;

        foreach (var item in list.OrderBy(v=>v.Length))
        {
            if (item.Length != 0 && item.Node.Institution.GetType() == _targetInstitution)
            {
                targetVertex = item;
                break;
            }
        }

        if (targetVertex != null)
        {
            HighlightTrack(targetVertex.NodeMap);
        }

    }
}


