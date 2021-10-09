using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryLandingAnimation : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Battery _battery;
    [SerializeField] private float _duration;

    private Vector3 _startPosition;

    public event UnityAction BatteryLandingFinished;

    public void StartChangePosition(Vector3 targetPosition)
    {
        _startPosition = _battery.transform.localPosition;
        StartCoroutine(ChangePosition(targetPosition));
    }

    public void StartChangePosition()
    {
        _startPosition = _battery.transform.localPosition;
        StartCoroutine(ChangePosition(_targetPosition.localPosition));
    }

    private IEnumerator ChangePosition(Vector3 targetPosition)
    {
        for (float i = 0; i < 1; i += Time.deltaTime / _duration)
        {
            _battery.transform.localPosition = Vector3.Lerp(_startPosition, targetPosition, _animationCurve.Evaluate(i));
            yield return null;
        }
        _battery.transform.localPosition = targetPosition;
        BatteryLandingFinished?.Invoke();
        _battery.PlayParticleSystems();
    }
}
