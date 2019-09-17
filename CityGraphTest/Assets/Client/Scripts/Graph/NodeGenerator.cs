using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    [SerializeField] private NodePresenter _nodePresenterPrefab;
    private Transform _selfTransform;
    private List<Node> _nodes = new List<Node> ();
    private Institution[] _institutions;

    #region MonoBehaviour
    
    private void Awake()
    {
        _selfTransform = GetComponent<Transform>();
        _institutions = Resources.LoadAll<Institution>("ScriptableObjects/Institutions"); 
    }
    
    #endregion

    public Node CreateNode(Vector2 point)
    {
        // если на этой позиции есть узел, то новый создавать не нужно, просто берем существующий
        // можно, при желании, сделать поиск близжайшего узла, чтобы все узлы в определенном радиусе объединялись 
        Node existingNode = _nodes.FirstOrDefault(n => n.Position == point);

        if (existingNode != null)
        {
           return existingNode;
        }

        Node node = new Node(_institutions[Random.Range(0,_institutions.Length)],point);
        var nodePresenter = Instantiate(_nodePresenterPrefab,_selfTransform);
        nodePresenter.SetNode(node);
        
        _nodes.Add(node);

        return node;
    }

    public void ClearNodes()
    {
        _nodes.Clear();
        foreach (Transform child in _selfTransform)
        {
            Destroy(child.gameObject);
        }
    }


}
