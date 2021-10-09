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
    [SerializeField] private float _addingForeForLightning = 550;
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private RewardSpawner _rewardSpawner;
    [SerializeField] private TMP_Text _crystalMultiplierText;
    [SerializeField] private MovementStopChecker _bossFollower;
    [SerializeField] private float _endScreenDelay;

    public CameraTarget CameraTarget { get; private set; }

    private Animator _animator;

    private void Start()
    {
        CameraTarget = GetComponent<CameraTarget>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _bossFollower.MovementStopped += OnMovementStopped;
    }

    private void OnDisable()
    {
        _bossFollower.MovementStopped -= OnMovementStopped;
    }

    public void OnMovementStopped()
    {
        StartCoroutine(OnMovementStoppedWithDelay(_endScreenDelay));
    }

    private IEnumerator OnMovementStoppedWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

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
            rigidbody.AddExplosionForce(_addingForeForLightning * _wallet.Lightnings, _explosionPosition.position, _radius, _upwardsModifier);

        _bossFollower.SetBossExploded();
    }
}
