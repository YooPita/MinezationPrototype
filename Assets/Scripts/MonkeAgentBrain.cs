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
        if (_monkeAgent.HungerDegree() < 0.8f)
            _monkeAgent.Move(new Vector2(-4.910125f, 0.7686201f));
    }
}
