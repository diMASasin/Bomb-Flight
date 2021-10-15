using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BonusPlatform : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _particleSystems;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _addingCrystalMultiplier;
    [SerializeField] private Animator _animator;
    [SerializeField] private TMP_Text _crystalMultiplierText;

    private bool _isBonusIssued;

    private void Start()
    {
        SetParticleSystemsActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out MovementStopChecker boss))
            return;

        SetParticleSystemsActive(true);
        _animator.SetTrigger("OnHitting");


        if(!_isBonusIssued)
        {
            _wallet.AddCrystalMultiplier(_addingCrystalMultiplier);
            Handheld.Vibrate();
            _isBonusIssued = true;
        }
    }

    private void SetParticleSystemsActive(bool value)
    {
        foreach (var particleSystem in _particleSystems)
            particleSystem.gameObject.SetActive(value);
    }
}
