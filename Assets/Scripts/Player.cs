using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Bomb _bombTemplate;
    [SerializeField] private Transform _bombPosition;
    [SerializeField] private StartZone _startZone;
    [SerializeField] private float _slowMotionDuration = 1;
    [SerializeField] private float _slowMotionScale = 0.5f;
    [SerializeField] private Animator _animator;
    [SerializeField] private Finish _finish;

    private bool _gameStarted = false;
    private Bomb _bomb;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnEnable()
    {
        _startZone.GameStarted += OnGameStarted;
    }

    private void OnDisable()
    {
        _startZone.GameStarted -= OnGameStarted;
    }

    private void Update()
    {
        if (!_gameStarted)
            return;

        _playerMovement.Move();

        if(Input.GetMouseButtonDown(0))
            TrySpawnBomb();

        if (Input.GetMouseButtonUp(0) && _wallet.Bombs > 0)
        {
            _bomb.transform.parent = null;
            _bomb.SetSpeed(_playerMovement.Speed.x);
            _bomb.TurnOnGravity();
            _bomb.SetDroped();
            _wallet.AddBombs(-1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Bombs>(out Bombs bombs))
        {
            _wallet.AddBombs(bombs.Value);
            Destroy(bombs.gameObject);
            if (!_bomb && _wallet.Bombs > 0)
                _bomb = Instantiate(_bombTemplate, _bombPosition);
        }
        else if (other.TryGetComponent(out Finish finish))
        {
            FinishLevel();
        }
    }

    private void FinishLevel()
    {
        _gameStarted = false;
        _animator.SetTrigger("Finished");
        _finish.FinishLevel();
    }

    private void OnGameStarted()
    {
        _gameStarted = true;
    }

    private void TrySpawnBomb()
    {
        if (_wallet.Bombs > 0)
        {
            _bomb = Instantiate(_bombTemplate, _bombPosition);
            _bomb.Exploded += OnBombExploded;
        }
    }

    private void OnBombExploded(Bomb bomb)
    {
        bomb.Exploded -= OnBombExploded;
        StartCoroutine(SlowDownTime(_slowMotionScale, _slowMotionDuration));
    }

    private IEnumerator SlowDownTime(float scale, float duration)
    {
        Time.timeScale *= scale;
        yield return new WaitForSeconds(duration);
        Time.timeScale /= scale;
    }
}