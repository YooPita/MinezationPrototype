using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MindMap
{
    private Dictionary<IFoodSource, Vector2> _foodSources = new();
    
    public void AddFoodSource(IFoodSource foodSource, Vector2 position)
    {
        if (!_foodSources.ContainsKey(foodSource))
            _foodSources.Add(foodSource, position);
    }

    public bool FoodSourceExists()
    {
        return _foodSources.Count > 0;
    }

    public KeyValuePair<IFoodSource, Vector2> NearFoodSource(Vector2 targetPosition)
    {
        KeyValuePair<IFoodSource, Vector2> closestFoodSource = new KeyValuePair<IFoodSource, Vector2>(null, Vector2.zero);
        float minDistance = float.MaxValue;

        foreach (var foodSource in _foodSources)
        {
            Vector2 foodSourcePosition = foodSource.Value;
            float distance = Vector2.Distance(targetPosition, foodSourcePosition);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestFoodSource = foodSource;
            }
        }

        return closestFoodSource;
    }
}
