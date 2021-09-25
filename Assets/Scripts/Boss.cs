using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private Rigidbody[] _rigidbodies;
    [SerializeField] private Rigidbody _spineRigidbody;
    [SerializeField] private Transform _explosionPosition;
    [SerializeField] private float _radius;
    [SerializeField] private float _upwardsModifier;
    [SerializeField] private Ragdoll _ragdoll;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _addingForeForLightning = 550;
    [SerializeField] private GameObject _finishScreen;
    [SerializeField] private RewardSpawner _rewardSpawner;

    private bool _isExploded = false;
    private bool _isRewardSpawned = false;

    private void Update()
    {
        if (_spineRigidbody.velocity != Vector3.zero)
            _isExploded = true;

        if (_spineRigidbody.velocity == Vector3.zero && _isExploded)
        {
            if(!_finishScreen.activeInHierarchy)
                _finishScreen.SetActive(true);

            if(!_isRewardSpawned)
            {
                _rewardSpawner.SpawnReward();
                _wallet.MultiplyCrystals();
                _isRewardSpawned = true;
            }
        }
    }

    public void Explode()
    {
        _ragdoll.MakePhysical();

        foreach (var rigidbody in _rigidbodies)
            rigidbody.AddExplosionForce(_addingForeForLightning * _wallet.Lightnings, _explosionPosition.position, _radius, _upwardsModifier);
    }
}
