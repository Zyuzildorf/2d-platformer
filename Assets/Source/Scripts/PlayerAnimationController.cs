using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private float _moveInput;

    private void Awake()
    {
        if (TryGetComponent(out Animator animator))
        {
            _animator = animator;
        }
    }

    private void Update()
    {
        _moveInput = Input.GetAxis("Horizontal");

        if (_moveInput != 0)
        {
            _animator.SetBool("IsWalking", true); 
        }
        else
        {
            _animator.SetBool("IsWalking", false);
        }
    }
}