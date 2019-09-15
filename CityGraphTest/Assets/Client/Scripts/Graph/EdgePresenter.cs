using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EdgePresenter : MonoBehaviour
{
    private SpriteRenderer _edgeSprite;

    #region MonoBehaviour

    private void Awake()
    {
        _edgeSprite = GetComponent<SpriteRenderer>();
        _edgeSprite.drawMode = SpriteDrawMode.Tiled;
    }


    #endregion

    
    public void SetEdge(Edge edge)
    {
        StrechEdgeSprite(edge.Node1.Position, edge.Node2.Position);
        edge.EdgeRemoved += Remove;
    }

    private void Remove()
    {
        Destroy(gameObject);
    }

    private void StrechEdgeSprite(Vector2 point1, Vector2 point2)
    {
        _edgeSprite.enabled = true;
        
        Vector3 centerPosition = (point1 + point2) / 2f;
        Vector3 direction = (point2 - point1).normalized;

        _edgeSprite.transform.localPosition = centerPosition;
        _edgeSprite.transform.up = direction;
        
        _edgeSprite.size = new Vector2(_edgeSprite.size.x,Vector2.Distance(point1, point2));
    }
}
