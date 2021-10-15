using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ExplosionEffect : MonoBehaviour
{
    [SerializeField] private PostProcessProfile _postProcessProfile;
    [SerializeField] private float _maxIntensity = 1;
    [SerializeField] private float _duration = 1;
    [SerializeField] private float _maxValueDuration = 1;

    private ChromaticAberration _chromaticAberration;

    private void Start()
    {
        _chromaticAberration = _postProcessProfile.GetSetting<ChromaticAberration>();
        _chromaticAberration.intensity.value = 0;
    }

    public void PlayExplosionEffect()
    {
        StartCoroutine(IncreaseIntensivity());
    }

    private IEnumerator IncreaseIntensivity()
    {
        while (_chromaticAberration.intensity.value < _maxIntensity)
        {
            _chromaticAberration.intensity.value += Time.deltaTime / _duration;
            yield return null;
        }
        yield return new WaitForSeconds(_maxValueDuration);
        StartCoroutine(DecreaseIntensivity());
    }

    private IEnumerator DecreaseIntensivity()
    {
        float _minIntensity = 0;
        while (_chromaticAberration.intensity.value > _minIntensity)
        {
            _chromaticAberration.intensity.value -= Time.deltaTime / _duration;
            yield return null;
        }
    }
}
