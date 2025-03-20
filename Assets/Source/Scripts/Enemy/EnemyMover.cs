using UnityEngine;

[RequireComponent(typeof(EnemyAnimationController))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _enemySprite;
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _pauseTime;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _accuracyValue = 0.1f;

    private EnemyAnimationController _animator;
    private int _currentWaypoint;
    private bool _canMove = true;
    private float _distanceToWaypoint;

    private void Awake()
    {
        _animator = GetComponent<EnemyAnimationController>();
    }

    private void Update()
    {
        Patrol();
    }


    private void Patrol()
    {
        if (_canMove == false)
            return;

        _animator.RestartWalkAnimation();

        _distanceToWaypoint = Vector2.Distance(transform.position,
            _waypoints.WaypointsArray[_currentWaypoint].position);

        if (_distanceToWaypoint < _accuracyValue)
        {
            _canMove = false;
            Invoke(nameof(CanMove), _pauseTime);
            
            _animator.StopWalkAnimation();
            
            _currentWaypoint = ++_currentWaypoint % _waypoints.WaypointsArray.Length;
            
            return;
        }

        MoveTo(_waypoints.WaypointsArray[_currentWaypoint].position, _moveSpeed);
    }

    private void MoveTo(Vector3 target, float speed)
    {
        transform.position = Vector2.MoveTowards(transform.position,
            target,
            speed * Time.deltaTime);
    }

    private void CanMove()
    {
        _enemySprite.flipX = !_enemySprite.flipX;
        _canMove = true;
    }
}