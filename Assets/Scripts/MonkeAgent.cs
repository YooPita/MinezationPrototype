using UnityEngine;

public class MonkeAgent : MonoBehaviour
{
    [SerializeField, Range(1, 5)] private float _speed = 1.0f;
    private Vector2 _targetPosition;
    private bool _positionReached = true;
    private MonkeAgentBrain _brain;
    private float _maxHungry = 100f;
    private float _hungry = 0f;

    public void Start()
    {
        _brain = new MonkeAgentBrain(this);
        _hungry = _maxHungry;
    }

    public void FixedUpdate()
    {
        if (!_positionReached)
        {
            Vector2 direction = _targetPosition - (Vector2)transform.position;
            Vector2 move = _speed * Time.deltaTime * direction.normalized;
            if (move.magnitude > direction.magnitude)
                move = move.normalized * direction.magnitude;
            transform.position = (Vector2)transform.position + move;
            if ((Vector2)transform.position == _targetPosition)
                _positionReached = true;
        }
        if (_hungry > 0)
            _hungry -= Time.deltaTime;
        _brain.Execute();
        Debug.Log(_hungry);
    }

    public void Move(Vector2 position)
    {
        _targetPosition = position;
        _positionReached = false;
    }

    public float HungerDegree()
    {
        return _hungry / _maxHungry;
    }
}
