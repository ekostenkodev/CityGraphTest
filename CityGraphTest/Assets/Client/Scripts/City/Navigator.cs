using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Navigator : MonoBehaviour
{
    public Node StartNode;
    public Type TargetInstitution;

    private LineRenderer _lineRenderer;
    private Transform _transform;
    
    #region MonoBehaviour

    private void Start()
    {
        _transform = GetComponent<Transform>();
        _lineRenderer = GetComponent<LineRenderer>();
        
        InputSystem.Instance.StartNodeSetted += SetStartNode;
        InputSystem.Instance.TargetInstitutionSetted += SetTargetInstitution;
    }
    
    #endregion

    public void HighlightTrack(List<Node> nodes)
    {
        _lineRenderer.enabled = true;
        _lineRenderer.positionCount = 0; // чистка списка
        _lineRenderer.positionCount = nodes.Count;

        for (int i = 0; i < nodes.Count; i++)
        {
            _lineRenderer.SetPosition(i, _transform.position + (Vector3)nodes[i].Position);
        }
        
    }

    public void SetStartNode(Node node)
    {
        StartNode = node;
        GenerateTrack();
    }

    public void SetTargetInstitution(Type type)
    {
        TargetInstitution = type;
        GenerateTrack();
    }

    public void GenerateTrack()
    {
        _lineRenderer.enabled = false;
        if(StartNode == null || TargetInstitution == null)
            return;

        Dijkstra dijkstra = new Dijkstra();
        var list = dijkstra.FindWay(StartNode);

        Dijkstra.Vertex targetVertex = null;

        foreach (var item in list.OrderBy(v=>v.Length))
        {
            if (item.Length != 0 && item.Node.Institution.GetType() == TargetInstitution)
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


