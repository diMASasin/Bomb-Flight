using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CameraTarget))]
public class Battery : MonoBehaviour
{
    [SerializeField] private BatteryLandingAnimation _landingAnimation;
    [SerializeField] private BatteryIncreaseSizeAnimation _increaseSize;
    [SerializeField] private ParticleSystem[] _particleSystems;

    public BatteryLandingAnimation LandingAnimation => _landingAnimation;
    public BatteryIncreaseSizeAnimation IncreaseSizeAnimation => _increaseSize;
    public ParticleSystem[] ParticleSystems => _particleSystems;

    public CameraTarget CameraTarget { get; private set; }

    private void Start()
    {
        CameraTarget = GetComponent<CameraTarget>();
    }

    public void PlayParticleSystems()
    {
        foreach (var particleSystem in _particleSystems)
            particleSystem.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Reward reward))
        {
            if (reward.Target != gameObject)
                return;

            Destroy(reward.gameObject);
        }
    }
}
