using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    
    [SerializeField] private NodePresenter _nodePresenterPrefab;
    private Dictionary<Node,NodePresenter> _nodes = new Dictionary<Node,NodePresenter> ();
    private Institution[] _institutions;
    private void Start()
    {
        _institutions = Resources.LoadAll<Institution>("ScriptableObjects/Institutions"); 
    }

    public Node CreateNode(Vector2 point)
    {
        // если на этой позиции есть узел, то новый создавать не нужно, просто берем существующий
        // можно, при желании, сделать поиск близжайшего узла, чтобы все узлы в определенном радиусе объединялись 
        Node existNode = _nodes.FirstOrDefault(n => n.Key.Position == point).Key;

        if (existNode != null)
        {
           return existNode;
        }

        Node node = new Node(_institutions[Random.Range(0,_institutions.Length)],point);
        var nodePresenter = Instantiate(_nodePresenterPrefab,transform);
        nodePresenter.SetNode(node);
        
        _nodes.Add(node,nodePresenter);

        return node;

    }

    public void ClearNodes()
    {
        _nodes.Clear();
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
