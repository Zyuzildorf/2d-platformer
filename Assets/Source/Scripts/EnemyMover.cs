using System;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private Waypoints _waypoints;
    [SerializeField] private float _moveSpeed;

    private int _currentWaypoint;

    public event Action OnMoving;
    public event Action OnStopMoving;
    
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position.x == _waypoints.WaypointsArray[_currentWaypoint].position.x)
        {
            OnStopMoving?.Invoke();
            
            _currentWaypoint = ++_currentWaypoint % _waypoints.WaypointsArray.Length;
        }

        transform.position = Vector2.MoveTowards(transform.position,
            _waypoints.WaypointsArray[_currentWaypoint].position,
            _moveSpeed * Time.deltaTime);
        
        OnMoving?.Invoke();
    }
}