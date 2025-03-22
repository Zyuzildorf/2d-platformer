using UnityEngine;

[RequireComponent(typeof(CoinsCollector), typeof(InputReader), typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper), typeof(PlayerAnimationSetter), typeof(PlayerGroundDetector))]
public class Player : MonoBehaviour
{
    private int _money;
    private CoinsCollector _coinsCollector;
    private InputReader _inputReader;
    private PlayerMover _playerMover;
    private PlayerJumper _playerJumper;
    private PlayerAnimationSetter _playerAnimationSetter;
    private PlayerGroundDetector _playerGroundDetector;
    
    private void Awake()
    {
        _coinsCollector = GetComponent<CoinsCollector>();
        _inputReader = GetComponent<InputReader>();
        _playerMover = GetComponent<PlayerMover>();
        _playerJumper = GetComponent<PlayerJumper>();
        _playerAnimationSetter = GetComponent<PlayerAnimationSetter>();
        _playerGroundDetector = GetComponent<PlayerGroundDetector>();
    }
    
    private void OnEnable()
    {
        _coinsCollector.OnCoinCollected += TakeCoin;
    }

    private void OnDisable()
    {
        _coinsCollector.OnCoinCollected -= TakeCoin;
    }

    private void Update()
    {
        if (_inputReader.Direction != 0)
        {
            _playerMover.Move(_inputReader.Direction);
            _playerAnimationSetter.RestartRunAnimation();
        }
        else
        {
            _playerAnimationSetter.StopRunAnimation();
        }

        if (_inputReader.OnSpacebarPressed && _playerGroundDetector.IsGrounded)
        {
            _playerJumper.Jump();
        }
    }

    private void TakeCoin(int coinValue)
    {
        _money += coinValue;
        
        Debug.Log("Денег в кошельке: " + _money);
    }
}