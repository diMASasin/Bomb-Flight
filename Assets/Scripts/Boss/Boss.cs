using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CameraTarget))]
public class Boss : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private ParticleSystem[] _particleSystems; 
    [SerializeField] private Transform _explosionPosition;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _addingForceForLightning = 550;
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private RewardSpawner _rewardSpawner;
    [SerializeField] private TMP_Text _crystalMultiplierText;
    [SerializeField] private MovementStopChecker _movementStopChecker;

    public CameraTarget CameraTarget { get; private set; }

    private Animator _animator;

    private void Start()
    {
        CameraTarget = GetComponent<CameraTarget>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _movementStopChecker.MovementStopped += OnMovementStopped;
    }

    private void OnDisable()
    {
        _movementStopChecker.MovementStopped -= OnMovementStopped;
    }

    public void OnMovementStopped()
    {
        _finishScreen.SetActive(true);
        _crystalMultiplierText.gameObject.SetActive(false);

        _rewardSpawner.SpawnReward();
        _wallet.MultiplyCrystals();

        Handheld.Vibrate();

        foreach (var particleSystem in _particleSystems)
            particleSystem.Play();
    }

    public void Explode()
    {
        _ragdoll.MakePhysical();
        _animator.enabled = false;

        foreach (var rigidbody in _rigidbodies)
            rigidbody.AddExplosionForce(_addingForceForLightning * _wallet.Lightnings, _explosionPosition.position, _radius, _upwardsModifier);

        _movementStopChecker.SetBossExploded();
    }
}
