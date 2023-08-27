using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeAgentBrain
{
    private readonly MonkeAgent _monkeAgent;

    public MonkeAgentBrain(MonkeAgent monkeAgent)
    {
        _monkeAgent = monkeAgent;
    }

    public void Execute()
    {
        if (_monkeAgent.HungerDegree() < 0.96f)
            _monkeAgent.MoveToNearFoodSource();
    }
}
