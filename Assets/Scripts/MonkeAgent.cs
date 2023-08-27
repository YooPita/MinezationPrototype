using UnityEngine;

public class MonkeAgent : MonoBehaviour, ICharacter
{
    [SerializeField, Range(1, 5)] private float _speed = 1.0f;
    [SerializeField] private Map _map;
    private Vector2 _targetPosition;
    private bool _positionReached = true;
    private MonkeAgentBrain _brain;
    private MindMap _mindMap;
    private float _maxHungry = 100f;
    private float _hungry = 0f;

    public void Start()
    {
        _brain = new MonkeAgentBrain(this);
        _mindMap = new MindMap();
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
    }

    public void Move(Vector2 position)
    {
        _targetPosition = position;
        _positionReached = false;
    }

    public void MoveToNearFoodSource()
    {
        if (_mindMap.FoodSourceExists())
            Move(_mindMap.NearFoodSource(transform.position).Value);
    }

    public float HungerDegree()
    {
        return _hungry / _maxHungry;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        IFoodSource foodSource = collision.GetComponent<IFoodSource>();
        if (foodSource != null)
        {
            _mindMap.AddFoodSource(foodSource, collision.gameObject.transform.position);
        }
    }
}
