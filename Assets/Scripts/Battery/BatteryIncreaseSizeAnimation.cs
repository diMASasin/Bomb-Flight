using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BatteryIncreaseSizeAnimation : MonoBehaviour
{
    [SerializeField] private AnimationCurve _animationCurve;
    [SerializeField] private Battery _battery;
    [SerializeField] private float _duration;
    [SerializeField] private float _delay;

    private Vector3 _startScale;

    public event UnityAction IncreaseSizeFinished;

    public void StartIncreaseSizeWithDelay(Vector3 targetScale)
    {
        _startScale = _battery.transform.localScale;
        StartCoroutine(IncreaseSizeWithDelay(targetScale, _delay));
    }

    private IEnumerator IncreaseSizeWithDelay(Vector3 targetScale, float delay)
    {
        yield return new WaitForSeconds(delay);

        for (float i = 0; i < 1; i += Time.deltaTime / _duration)
        {
            _battery.transform.localScale = Vector3.Lerp(_startScale, targetScale, _animationCurve.Evaluate(i));
            foreach (var particleSystem in _battery.ParticleSystems)
                particleSystem.transform.localScale = Vector3.Lerp(_startScale, targetScale, _animationCurve.Evaluate(i));
            yield return null;
        }
        _battery.transform.localScale = targetScale;
        IncreaseSizeFinished?.Invoke();
    }
}
