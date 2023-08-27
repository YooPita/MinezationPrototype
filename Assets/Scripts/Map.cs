using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Map : MonoBehaviour
{
    [SerializeField] private int _width = 100;
    [SerializeField] private int _height = 100;
    [SerializeField] private float _cellSize = 2f;
    private Vector2 _mapOffset;
    private Vector2 _originPosition;
    private MapGrid _grid;

    [SerializeField] private MindMapTileView _prefab;

    private void Awake()
    {
        _originPosition = transform.position;
        _mapOffset = new Vector2(
            Mathf.RoundToInt(_width / 2 * _cellSize),
            Mathf.RoundToInt(_height / 2 * _cellSize));
        _grid = new MapGrid(_width, _height, _cellSize);
        CashEntities();
    }
    private void CashEntities()
    {
        IEnumerable<IMapEntity> entities = FindObjectsOfType<MonoBehaviour>().OfType<IMapEntity>();
        foreach (IMapEntity entity in entities)
        {
            Vector2 entityPosition = (entity as MonoBehaviour).transform.position;
            _grid.AddEntity(entity, entityPosition + _mapOffset - _originPosition);
        }
    }
    
    private void SpeedDebugDraw()
    {
        for (int y = 0; y < _height; y++)
        {
            for (int x = 0; x < _width; x++)
            {
                bool exist = _grid.Entities(new Vector2Int(x, y)).Count > 0;
                DrawTile(new Vector2(x, y) * _cellSize - _mapOffset + _originPosition, exist);
            }
        }
    }

    private void DrawTile(Vector2 position, bool exists)
    {
        MindMapTileView tile = Instantiate(_prefab, position, transform.rotation);
        tile.ChangeType(MindMapTileView.Visibility.Explored, exists ? MindMapTileView.Type.Food : MindMapTileView.Type.Ordinary);
    }
}
