using Unity.Mathematics;
using UnityEngine;

[RequireComponent(typeof(Flipper))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Flipper _flipper;
    private Vector3 _direction;

    private void Awake()
    {
        _flipper = GetComponent<Flipper>();
    }

    public void MoveTo(Vector3 target)
    {
        FlipTowardsTarget(target);
        
        transform.position = Vector2.MoveTowards(transform.position,
            target,
            _moveSpeed * Time.deltaTime);
    }

    private void FlipTowardsTarget(Vector3 target)
    {
        _direction = transform.position - target;
        
        Debug.Log(_direction.x);
        
        _flipper.Flip(_direction.x);
    }
}