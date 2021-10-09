using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementStopChecker : MonoBehaviour
{
    [SerializeField] private float _timer;
    [SerializeField] private float _deathZone = 0.001f;

    private float _value;
    private bool _isMovementStopped = false;
    private bool _isBossExploded = false;
    private Vector3 _previousPosition;
    private float _deltaPositionX = 0;

    public event UnityAction MovementStopped;

    private void Start()
    {
        _value = _timer;
        _previousPosition = transform.position;
    }

    private void Update()
    {
        _deltaPositionX = (transform.position - _previousPosition).x;
        _previousPosition = transform.position;

        if (_deltaPositionX < _deathZone)
            _deltaPositionX = 0;

        if (_deltaPositionX != 0 || !_isBossExploded)
        {
            ResetTimer();
            return;
        }

        if (_value <= 0 && !_isMovementStopped)
        {
            MovementStopped?.Invoke();
            _isMovementStopped = true;
        }
        else if (_value > 0)
        {
            _value -= Time.deltaTime;
        }
    }

    private void ResetTimer()
    {
        _value = _timer;
    }

    public void SetBossExploded()
    {
        _isBossExploded = true;
    }
}
