using System.Collections.Generic;

public class MapCell
{
    private readonly HashSet<IMapEntity> _entities = new();

    public void AddEntity(IMapEntity entity)
    {
        _entities.Add(entity);
    }

    public void RemoveEntity(IMapEntity entity)
    {
        _entities.Remove(entity);
    }

    public bool ContainsEntity(IMapEntity entity)
    {
        return _entities.Contains(entity);
    }

    public List<IMapEntity> Entities()
    {
        return new List<IMapEntity>(_entities);
    }
}
