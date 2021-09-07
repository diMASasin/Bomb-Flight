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

    private Bomb _bomb;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _bomb = Instantiate(_bombTemplate, _bombPosition);
        _wallet.AddBombs(0);
    }

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && _wallet.Bombs > 0)
        {
            _bomb.transform.parent = null;
            _bomb.SetSpeed(_playerMovement.Speed.x);
            _bomb.TurnOnGravity();
            _bomb.SetDroped();
            _wallet.AddBombs(-1);
            if(_wallet.Bombs > 0)
                _bomb = Instantiate(_bombTemplate, _bombPosition);
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
    }
}