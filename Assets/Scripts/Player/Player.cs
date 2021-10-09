using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerBombDropper))]
[RequireComponent(typeof(Wallet))]
[RequireComponent(typeof(MultipleVibrator))]
[RequireComponent(typeof(CameraTarget))]
public class Player : MonoBehaviour
{
    private Wallet _wallet;
    private PlayerMovement _playerMovement;
    private PlayerBombDropper _bombDropper;
    private Animator _animator;
    private bool _gameStarted = false;
    private Bomb _bomb;
    private MultipleVibrator _multipleVibrator;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _bombDropper = GetComponent<PlayerBombDropper>();
        _wallet = GetComponent<Wallet>();
        _animator = GetComponent<Animator>();
        _multipleVibrator = GetComponent<MultipleVibrator>();
    }

    private void Update()
    {
        if (!_gameStarted)
            return;

        _playerMovement.Move();

        if(Input.GetMouseButtonDown(0))
        {
            _bomb = _bombDropper.TrySpawnBomb(_wallet);
            if(_bomb)   
                _animator.SetBool("IsBombSpawned", true);
        }

        if (Input.GetMouseButtonUp(0) && _wallet.Bombs > 0)
        {
            _animator.SetBool("IsBombSpawned", false);
            _bombDropper.DropBomb(_bomb, _playerMovement.Speed.x);
            _wallet.AddBombs(-1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BombItem>(out BombItem bombItem))
            CollectBombItem(bombItem);
    }

    private void CollectBombItem(BombItem bombItem)
    {
        _wallet.AddBombs(bombItem.Value);
        Destroy(bombItem.gameObject);
        _multipleVibrator.StartVibrateSeveralTimes();
    }

    public void StartLevel()
    {
        _gameStarted = true;
    }

    public void FinishLevel()
    {
        _gameStarted = false;
        _animator.SetTrigger("Finished");
    }
}