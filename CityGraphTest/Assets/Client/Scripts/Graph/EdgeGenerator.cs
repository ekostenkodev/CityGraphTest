using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EdgeGenerator : MonoBehaviour
{
    [SerializeField] private EdgePresenter _edgePresenterPrefab;
    private List<Edge> _edges = new List<Edge>(); // все ветви, которые существуют // todo убрать
    public IEnumerable<Edge> Edges => _edges.ToList();
    
    private Transform _selfTransform;

    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
    }


    public void SplitEdge(Edge edge, Node newNode)
    {
        // обращаемся к узлам старой ветви
        var node1 = edge.Node1;
        var node2 = edge.Node2;
        
        if (node1.Position == newNode.Position || node2.Position == newNode.Position)
            return;

        edge.Remove();

        _edges.Remove(edge);
        
        // создаем ветви старых узлов с новым
        CreateEdge(node1,newNode);
        CreateEdge(node2,newNode);
    }

    public void CreateEdge(Node node1, Node node2)
    {
        Edge edge = new Edge(node1,node2);
        
        var edgePresenter = Instantiate(_edgePresenterPrefab, _selfTransform);
        edgePresenter.SetEdge(edge);
        
        node1.Edges.Add(edge);
        node2.Edges.Add(edge);
            
        _edges.Add(edge);
    }

    public void ClearEdges()
    {
        _edges.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
