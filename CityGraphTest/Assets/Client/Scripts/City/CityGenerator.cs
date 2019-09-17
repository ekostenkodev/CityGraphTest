using UnityEngine;

public class CityGenerator : MonoBehaviour
{
    [SerializeField] private EdgeGenerator _edgeGenerator;
    [SerializeField] private NodeGenerator _nodeGenerator;
    
    [SerializeField] private float _width = 40;
    [SerializeField] private float _height = 20;

    public void GenerateCity(int roadCount)
    {
        var _startRoads = new []
        {
            new Road(new Vector2(0, 0), new Vector2(0, _height)),
            new Road(new Vector2(0, _height), new Vector2(_width, _height)),
            new Road(new Vector2(_width, _height), new Vector2(_width, 0)),
            new Road(new Vector2(_width, 0), new Vector2(0, 0))
        };
        
        ClearCity();
        
        CreateStartRoads(_startRoads);

        for (int i = 0; i < roadCount; i++)
        {
            GenerateRandomRoadInPerimeter(_startRoads);
        }
    }

    private void CreateStartRoads(Road[] roads)
    {
        foreach (var road in roads)
            CreateEdgeOnRoad(road);
    }
    
    private void GenerateRandomRoadInPerimeter(Road[] roads)
    {
        int rectangleEdge1 = Random.Range(0, 4);
        int rectangleEdge2;
        do  { rectangleEdge2 = Random.Range(0, 4); } while (rectangleEdge2==rectangleEdge1); // делаем так, чтобы стороны были разными

        var point1 = Vector2.Lerp(roads[rectangleEdge1].Point1, roads[rectangleEdge1].Point2,Random.Range(.1f,.9f)); // 0.1f-0.9f, чтобы точки были подальше от углов прямоугольника
        var point2 = Vector2.Lerp(roads[rectangleEdge2].Point1, roads[rectangleEdge2].Point2,Random.Range(.1f,.9f));

        CreateEdgeOnRoad(new Road(point1,point2));
    }
    
    private void CreateEdgeOnRoad(Road road)
    {
        Node node1 = null, node2 = null;
        
        foreach (var edge in _edgeGenerator.Edges) 
        {
            // проверяем, пересекается линия,созданная узлами startNode и endNode, с другими ветвями
            if (Math2D.LineSegmentsIntersection(
                road.Point1, 
                road.Point2, 
                edge.Node1.Position,
                edge.Node2.Position, 
                out Vector2 intersectionPoint))
            {

                // пересечение есть, значит на месте пересечения ставим новый узел
                var newNode = _nodeGenerator.CreateNode(intersectionPoint);
                // делим пересеченую ветвь на две части
                _edgeGenerator.SplitEdge(edge,newNode);

                // если пересечение призошло в начале/конце создаваемой дороги
                if (road.Point1 == intersectionPoint)
                {
                    node1 = newNode;
                    continue;
                }

                if (road.Point2 == intersectionPoint)
                {
                    node2 = newNode;
                    continue;
                }

                // продолжаем строить дорогу на оставшихся участках (с помощью рекурсии)
                CreateEdgeOnRoad(new Road(road.Point1, intersectionPoint));
                CreateEdgeOnRoad(new Road(road.Point2, intersectionPoint));
                
                // покидаем метод, тк дорога уже разделена и ее достраивает рекурсия
                return;
            }
        }
        
        if(node1 == null)
            node1 = _nodeGenerator.CreateNode(road.Point1);
        if (node2 == null)
            node2 = _nodeGenerator.CreateNode(road.Point2);

        _edgeGenerator.CreateEdge(node1, node2);

    }

    private void ClearCity()
    {
        _edgeGenerator.ClearEdges();
        _nodeGenerator.ClearNodes();
    }
}
