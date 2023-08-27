using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapGrid
{
    private readonly int _width;
    private readonly int _height;
    private readonly float _cellSize;
    private readonly float _halfCellSize;
    private readonly float _gridWidth;
    private readonly float _gridHeight;
    private readonly List<IMapEntity> _entities = new();
    private readonly MapCell[,] _grid;

    public MapGrid(int width, int height, float cellSize)
    {
        _width = width;
        _height = height;
        _cellSize = cellSize;
        _halfCellSize = _cellSize / 2f;
        _gridWidth = _cellSize * _width;
        _gridHeight = _cellSize * _height;
        _grid = new MapCell[_width, _height];
    }

    public void AddEntity(IMapEntity entity, Vector2 position)
    {
        if (!InsideGrid(position))
            return;
        Vector2Int index = GridIndex(position);
        MapCell cell = Cell(index);
        cell.AddEntity(entity);
    }

    public List<IMapEntity> Entities(Vector2Int position) => Cell(position.x, position.y).Entities();

    private MapCell Cell(Vector2Int position) => Cell(position.x, position.y);

    private MapCell Cell(int x, int y)
    {
        if (_grid[x, y] == null)
            _grid[x, y] = new MapCell();
        return _grid[x, y];
    }

    private Vector2Int GridIndex(Vector2 position)
    {
        Vector2 widthIndex = (position + new Vector2(_halfCellSize, _halfCellSize)) / _cellSize;
        return new Vector2Int(Mathf.FloorToInt(widthIndex.x), Mathf.FloorToInt(widthIndex.y));
    }

    private bool InsideGrid(Vector2 position)
    {
        position += new Vector2(_halfCellSize, _halfCellSize);
        return position.x >= 0 && position.x < _gridWidth &&
            position.y >= 0 && position.y < _gridHeight;
    }
}
